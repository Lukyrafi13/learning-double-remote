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

namespace NewLMS.UMKM.MediatR.Features.RfCompanyTypeMaps.Queries
{
    public class RfCompanyTypeMapsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfCompanyTypeMapResponseDto>>>
    {
    }

    public class GetFilterRfCompanyTypeMapQueryHandler : IRequestHandler<RfCompanyTypeMapsGetFilterQuery, PagedResponse<IEnumerable<RfCompanyTypeMapResponseDto>>>
    {
        private IGenericRepositoryAsync<RfCompanyTypeMap> _RfCompanyTypeMap;
                private IGenericRepositoryAsync<RfCompanyType> _RfCompanyType;
        private readonly IMapper _mapper;

        public GetFilterRfCompanyTypeMapQueryHandler(IGenericRepositoryAsync<RfCompanyTypeMap> RfCompanyTypeMap, IGenericRepositoryAsync<RfCompanyType> RfCompanyType, IMapper mapper)
        {
            _RfCompanyTypeMap = RfCompanyTypeMap;
            _RfCompanyType = RfCompanyType;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfCompanyTypeMapResponseDto>>> Handle(RfCompanyTypeMapsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RfCompanyTypeMap.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RfCompanyTypeMapResponseDto>>(data.Results);
            IEnumerable<RfCompanyTypeMapResponseDto> dataVm;
            var listResponse = new List<RfCompanyTypeMapResponseDto>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<RfCompanyTypeMapResponseDto>(res);

                var jenisUsaha = await _RfCompanyType.GetByIdAsync(response.ANL_CODE, "ANL_CODE");

                if (jenisUsaha != null){
                    response.ANL_DESC = jenisUsaha.ANL_DESC;
                    response.ANL_ACTIVE = jenisUsaha.ACTIVE??false;
                }

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RfCompanyTypeMapResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}