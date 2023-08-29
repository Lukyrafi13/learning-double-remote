using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFTenorMappings;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFTenorMappings.Queries
{
    public class RFTenorMappingGetQuery : RFTenorMappingFindRequestDto, IRequest<ServiceResponse<RFTenorMappingResponseDto>>
    {
    }

    public class RFTenorMappingGetQueryHandler : IRequestHandler<RFTenorMappingGetQuery, ServiceResponse<RFTenorMappingResponseDto>>
    {
        private IGenericRepositoryAsync<RFTenorMapping> _RFTenorMapping;
        private readonly IMapper _mapper;

        public RFTenorMappingGetQueryHandler(IGenericRepositoryAsync<RFTenorMapping> RFTenorMapping, IMapper mapper)
        {
            _RFTenorMapping = RFTenorMapping;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFTenorMappingResponseDto>> Handle(RFTenorMappingGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFTenorMapping.GetByIdAsync(request.Id, "Id");
                if (data == null)
                    return ServiceResponse<RFTenorMappingResponseDto>.Return404("Data RFTenorMapping not found");
                var response = _mapper.Map<RFTenorMappingResponseDto>(data);
                return ServiceResponse<RFTenorMappingResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFTenorMappingResponseDto>.ReturnException(ex);
            }
        }
    }
}