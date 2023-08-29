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
    public class RFInsRateMappingPostCommand : RFInsRateMappingPostRequestDto, IRequest<ServiceResponse<RFInsRateMappingResponseDto>>
    {

    }
    public class RFInsRateMappingPostCommandHandler : IRequestHandler<RFInsRateMappingPostCommand, ServiceResponse<RFInsRateMappingResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFInsRateMapping> _RFInsRateMapping;
        private readonly IMapper _mapper;

        public RFInsRateMappingPostCommandHandler(IGenericRepositoryAsync<RFInsRateMapping> RFInsRateMapping, IMapper mapper)
        {
            _RFInsRateMapping = RFInsRateMapping;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFInsRateMappingResponseDto>> Handle(RFInsRateMappingPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFInsRateMapping = _mapper.Map<RFInsRateMapping>(request);

                var returnedRFInsRateMapping = await _RFInsRateMapping.AddAsync(RFInsRateMapping, callSave: false);

                // var response = _mapper.Map<RFInsRateMappingResponseDto>(returnedRFInsRateMapping);
                var response = _mapper.Map<RFInsRateMappingResponseDto>(returnedRFInsRateMapping);

                await _RFInsRateMapping.SaveChangeAsync();
                return ServiceResponse<RFInsRateMappingResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFInsRateMappingResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}