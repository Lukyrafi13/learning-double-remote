using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfCompanyTypeMaps;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfCompanyTypeMaps.Queries
{
    public class RfCompanyTypeMapGetQuery : RfCompanyTypeMapFindRequestDto, IRequest<ServiceResponse<RfCompanyTypeMapResponseDto>>
    {
    }

    public class RfCompanyTypeMapGetQueryHandler : IRequestHandler<RfCompanyTypeMapGetQuery, ServiceResponse<RfCompanyTypeMapResponseDto>>
    {
        private IGenericRepositoryAsync<RfCompanyTypeMap> _RfCompanyTypeMap;
        private IGenericRepositoryAsync<RfCompanyType> _RfCompanyType;
        private readonly IMapper _mapper;

        public RfCompanyTypeMapGetQueryHandler(IGenericRepositoryAsync<RfCompanyTypeMap> RfCompanyTypeMap, IGenericRepositoryAsync<RfCompanyType> RfCompanyType, IMapper mapper)
        {
            _RfCompanyTypeMap = RfCompanyTypeMap;
            _RfCompanyType = RfCompanyType;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RfCompanyTypeMapResponseDto>> Handle(RfCompanyTypeMapGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RfCompanyTypeMap.GetByIdAsync(request.Id, "Id");
                if (data == null)
                    return ServiceResponse<RfCompanyTypeMapResponseDto>.Return404("Data RfCompanyTypeMap not found");
                var response = _mapper.Map<RfCompanyTypeMapResponseDto>(data);

                var jenisUsaha = await _RfCompanyType.GetByIdAsync(response.ANL_CODE, "ANL_CODE");

                if (jenisUsaha != null){
                    response.ANL_DESC = jenisUsaha.ANL_DESC;
                    response.ANL_ACTIVE = jenisUsaha.ACTIVE??false;
                }

                return ServiceResponse<RfCompanyTypeMapResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RfCompanyTypeMapResponseDto>.ReturnException(ex);
            }
        }
    }
}