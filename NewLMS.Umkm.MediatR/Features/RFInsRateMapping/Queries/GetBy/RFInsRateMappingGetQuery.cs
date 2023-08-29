using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFInsRateMappings;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFInsRateMappings.Queries
{
    public class RFInsRateMappingGetQuery : RFInsRateMappingFindRequestDto, IRequest<ServiceResponse<RFInsRateMappingResponseDto>>
    {
    }

    public class RFInsRateMappingGetQueryHandler : IRequestHandler<RFInsRateMappingGetQuery, ServiceResponse<RFInsRateMappingResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFInsRateMapping> _RFInsRateMapping;
        private readonly IMapper _mapper;

        public RFInsRateMappingGetQueryHandler(IGenericRepositoryAsync<RFInsRateMapping> RFInsRateMapping, IMapper mapper)
        {
            _RFInsRateMapping = RFInsRateMapping;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFInsRateMappingResponseDto>> Handle(RFInsRateMappingGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                };

                var data = await _RFInsRateMapping.GetByIdAsync(request.InsRateId, "InsRateId");
                if (data == null)
                    return ServiceResponse<RFInsRateMappingResponseDto>.Return404("Data RFInsRateMapping not found");
                var response = _mapper.Map<RFInsRateMappingResponseDto>(data);
                return ServiceResponse<RFInsRateMappingResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFInsRateMappingResponseDto>.ReturnException(ex);
            }
        }
    }
}