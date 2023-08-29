using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFJenisUsahaMaps;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.MediatR.Features.RFJenisUsahaMaps.Queries
{
    public class RFJenisUsahaByKelompokCodeQuery : RequestParameter, IRequest<ServiceResponse<IEnumerable<RFJenisUsahaByKelompokResponse>>>
    {
        public string KELOMPOK_CODE { get; set;}
    }

    public class RFJenisUsahaByKelompokCodeQueryHandler : IRequestHandler<RFJenisUsahaByKelompokCodeQuery, ServiceResponse<IEnumerable<RFJenisUsahaByKelompokResponse>>>
    {
        private IGenericRepositoryAsync<RFJenisUsahaMap> _RFJenisUsahaMap;
                private IGenericRepositoryAsync<RFJenisUsaha> _RFJenisUsaha;
        private readonly IMapper _mapper;

        public RFJenisUsahaByKelompokCodeQueryHandler(IGenericRepositoryAsync<RFJenisUsahaMap> RFJenisUsahaMap, IGenericRepositoryAsync<RFJenisUsaha> RFJenisUsaha, IMapper mapper)
        {
            _RFJenisUsahaMap = RFJenisUsahaMap;
            _RFJenisUsaha = RFJenisUsaha;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<IEnumerable<RFJenisUsahaByKelompokResponse>>> Handle(RFJenisUsahaByKelompokCodeQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFJenisUsahaMap.GetListByPredicate(x=> x.KELOMPOK_CODE == request.KELOMPOK_CODE);
            // var dataVm = _mapper.Map<IEnumerable<RFJenisUsahaByKelompokResponse>>(data.Results);
            IEnumerable<RFJenisUsahaByKelompokResponse> dataVm;
            var listResponse = new List<RFJenisUsahaByKelompokResponse>();
            var addedANL = new List<string>();

            foreach (var res in data)
            {
                var response = _mapper.Map<RFJenisUsahaByKelompokResponse>(res);

                var jenisUsaha = await _RFJenisUsaha.GetByIdAsync(response.ANL_CODE, "ANL_CODE");

                if (jenisUsaha != null){
                    response.ANL_DESC = jenisUsaha.ANL_DESC;
                    response.ANL_ACTIVE = jenisUsaha.ACTIVE??false;
                    response.JENIS_USAHA = jenisUsaha;
                }

                if (!addedANL.Contains(response.ANL_CODE)){
                    addedANL.Add(response.ANL_CODE);
                    listResponse.Add(response);
                }
            }

            dataVm = listResponse.ToArray();
            return ServiceResponse<IEnumerable<RFJenisUsahaByKelompokResponse>>.ReturnResultWith200(dataVm);
        }
    }
}