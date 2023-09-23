using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using NewLMS.Umkm.SIKP.Interfaces;
using NewLMS.Umkm.SIKP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.SIKPs.SIKP
{
    public class RateAkadSIKPQuery : RateAkadRequestModel, IRequest<ServiceResponse<RateAkadResponseModel>>
    {

    }

    public class RateAkadSIKPQueryHandler : IRequestHandler<RateAkadSIKPQuery, ServiceResponse<RateAkadResponseModel>>
    {
        private ISIKPService _SIKPService;
        private IGenericRepositoryAsync<RfSkemaSIKP> _rfSkemaSIKP;
        private readonly IMapper _mapper;

        public RateAkadSIKPQueryHandler(
            ISIKPService SIKPService,
            IGenericRepositoryAsync<RfSkemaSIKP> rfSkemaSIKP,
            IMapper mapper)
        {
            _SIKPService = SIKPService;
            _rfSkemaSIKP = rfSkemaSIKP;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RateAkadResponseModel>> Handle(RateAkadSIKPQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                };

                var data = (await _SIKPService.GetRateAkad(request)).data;
                if (data == null)
                    return ServiceResponse<RateAkadResponseModel>.Return404("Data SIKPService not found");

                var dataCalon = (await _SIKPService.GetCalonDebitur(request.nik))?.data;
                if (dataCalon == null)
                    return ServiceResponse<RateAkadResponseModel>.Return404("Data Calon not found");

                data.code_inquiry_calon = dataCalon.code;

                if (data.data?.Count > 0)
                {
                    var listSkema = await _rfSkemaSIKP.GetAllAsync();

                    var listSkemaParent = listSkema.DistinctBy(x => x.SkemaParentCode)
                    .Select(x => new { x.SkemaParentCode, x.SkemaParentDesc })
                    .OrderBy(i => i.SkemaParentCode)
                    .ToList();

                    for (var i = 0; i < data.data.Count; i++)
                    {
                        data.data[i].sisaWaktuBooking = int.Parse(dataCalon.data?.sisa_waktu_book ?? "0");
                        data.data[i].sisaHari = int.Parse(dataCalon.data?.sisa_hari ?? "0");

                        var skemaObj = listSkemaParent.Where(x => x.SkemaParentCode == data.data[i].skema).ToList().Last();

                        data.data[i].skema += " - " + skemaObj.SkemaParentDesc;
                    }
                }
                var response = _mapper.Map<RateAkadResponseModel>(data);
                return ServiceResponse<RateAkadResponseModel>.ReturnResultWith200(data);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RateAkadResponseModel>.ReturnException(ex);
            }
        }
    }
}
