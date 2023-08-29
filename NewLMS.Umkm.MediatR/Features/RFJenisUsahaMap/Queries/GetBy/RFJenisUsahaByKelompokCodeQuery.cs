using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfCompanyTypeMaps;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.MediatR.Features.RfCompanyTypeMaps.Queries
{
    public class RfCompanyTypeByKelompokCodeQuery : RequestParameter, IRequest<ServiceResponse<IEnumerable<RfCompanyTypeByKelompokResponse>>>
    {
        public string KELOMPOK_CODE { get; set;}
    }

    public class RfCompanyTypeByKelompokCodeQueryHandler : IRequestHandler<RfCompanyTypeByKelompokCodeQuery, ServiceResponse<IEnumerable<RfCompanyTypeByKelompokResponse>>>
    {
        private IGenericRepositoryAsync<RfCompanyTypeMap> _RfCompanyTypeMap;
                private IGenericRepositoryAsync<RfCompanyType> _RfCompanyType;
        private readonly IMapper _mapper;

        public RfCompanyTypeByKelompokCodeQueryHandler(IGenericRepositoryAsync<RfCompanyTypeMap> RfCompanyTypeMap, IGenericRepositoryAsync<RfCompanyType> RfCompanyType, IMapper mapper)
        {
            _RfCompanyTypeMap = RfCompanyTypeMap;
            _RfCompanyType = RfCompanyType;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<IEnumerable<RfCompanyTypeByKelompokResponse>>> Handle(RfCompanyTypeByKelompokCodeQuery request, CancellationToken cancellationToken)
        {
            var data = await _RfCompanyTypeMap.GetListByPredicate(x=> x.KELOMPOK_CODE == request.KELOMPOK_CODE);
            // var dataVm = _mapper.Map<IEnumerable<RfCompanyTypeByKelompokResponse>>(data.Results);
            IEnumerable<RfCompanyTypeByKelompokResponse> dataVm;
            var listResponse = new List<RfCompanyTypeByKelompokResponse>();
            var addedANL = new List<string>();

            foreach (var res in data)
            {
                var response = _mapper.Map<RfCompanyTypeByKelompokResponse>(res);

                var jenisUsaha = await _RfCompanyType.GetByIdAsync(response.ANL_CODE, "ANL_CODE");

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
            return ServiceResponse<IEnumerable<RfCompanyTypeByKelompokResponse>>.ReturnResultWith200(dataVm);
        }
    }
}