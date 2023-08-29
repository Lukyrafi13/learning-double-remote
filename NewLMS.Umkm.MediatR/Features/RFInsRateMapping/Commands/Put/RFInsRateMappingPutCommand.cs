using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFInsRateMappings;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFInsRateMappings.Commands
{
    public class RFInsRateMappingPutCommand : RFInsRateMappingPutRequestDto, IRequest<ServiceResponse<RFInsRateMappingResponseDto>>
    {
    }

    public class PutRFInsRateMappingCommandHandler : IRequestHandler<RFInsRateMappingPutCommand, ServiceResponse<RFInsRateMappingResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFInsRateMapping> _RFInsRateMapping;
        private readonly IMapper _mapper;

        public PutRFInsRateMappingCommandHandler(IGenericRepositoryAsync<RFInsRateMapping> RFInsRateMapping, IMapper mapper)
        {
            _RFInsRateMapping = RFInsRateMapping;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFInsRateMappingResponseDto>> Handle(RFInsRateMappingPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFInsRateMapping = await _RFInsRateMapping.GetByIdAsync(request.TPLCode, "TPLCode");
                
                existingRFInsRateMapping = _mapper.Map<RFInsRateMappingPutRequestDto, RFInsRateMapping>(request, existingRFInsRateMapping);

                await _RFInsRateMapping.UpdateAsync(existingRFInsRateMapping);

                var response = _mapper.Map<RFInsRateMappingResponseDto>(existingRFInsRateMapping);

                return ServiceResponse<RFInsRateMappingResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFInsRateMappingResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}