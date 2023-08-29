using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.SIKP2.Models;
using NewLMS.UMKM.SIKP2.Interfaces;
using NewLMS.UMKM.SIKP.Interfaces;
using System.Linq;

namespace NewLMS.UMKM.MediatR.Features.SIKP.Queries
{
    public class SIKPGetRateAkadQuery : RateAkadRequestModel, IRequest<ServiceResponse<RateAkadResponseModel>>
    {

    }

    public class SIKPGetRateAkadQueryHandler : IRequestHandler<SIKPGetRateAkadQuery, ServiceResponse<RateAkadResponseModel>>
    {
        private ISIKPService2 _SIKPService2;
        private ISIKPService _SIKPService;
        private IGenericRepositoryAsync<RFSkemaSIKP> _RFSkemaSIKP;
        private readonly IMapper _mapper;

        public SIKPGetRateAkadQueryHandler(
            ISIKPService2 SIKPService2,
            ISIKPService SIKPService,
            IGenericRepositoryAsync<RFSkemaSIKP> RFSkemaSIKP,
            IMapper mapper)
        {
            _SIKPService2 = SIKPService2;
            _SIKPService = SIKPService;
            _RFSkemaSIKP = RFSkemaSIKP;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RateAkadResponseModel>> Handle(SIKPGetRateAkadQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                };

                var data = await _SIKPService2.GetRateAkad(request);
                if (data == null)
                    return ServiceResponse<RateAkadResponseModel>.Return404("Data SIKPService not found");

                var dataCalon = await _SIKPService.GetCalonDebitur(request.nik);

                data.code_inquiry_calon = dataCalon.code;

                if (data.data.Count > 0)
                {
                    var listSkema = await _RFSkemaSIKP.GetAllAsync();

                    var listSkemaParent = listSkema.DistinctBy(x => x.SkemaParentCode)
                    .Select(x => new { x.SkemaParentCode, x.SkemaParentDesc })
                    .OrderBy(i => i.SkemaParentCode)
                    .ToList();

                    for (var i = 0; i < data.data.Count; i++)
                    {
                        data.data[i].sisaWaktuBooking = int.Parse(dataCalon.data.sisa_waktu_book ?? "0");
                        data.data[i].sisaHari = int.Parse(dataCalon.data.sisa_hari ?? "0");

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