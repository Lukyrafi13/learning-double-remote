using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFTenorMappings;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFTenorMappings.Commands
{
    public class RFTenorMappingPostCommand : RFTenorMappingPostRequestDto, IRequest<ServiceResponse<RFTenorMappingResponseDto>>
    {

    }
    public class PostRFTenorMappingCommandHandler : IRequestHandler<RFTenorMappingPostCommand, ServiceResponse<RFTenorMappingResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFTenorMapping> _RFTenorMapping;
        private readonly IMapper _mapper;

        public PostRFTenorMappingCommandHandler(IGenericRepositoryAsync<RFTenorMapping> RFTenorMapping, IMapper mapper)
        {
            _RFTenorMapping = RFTenorMapping;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFTenorMappingResponseDto>> Handle(RFTenorMappingPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFTenorMapping = _mapper.Map<RFTenorMapping>(request);

                var returnedRFTenorMapping = await _RFTenorMapping.AddAsync(RFTenorMapping, callSave: false);

                // var response = _mapper.Map<RFTenorMappingResponseDto>(returnedRFTenorMapping);
                var response = _mapper.Map<RFTenorMappingResponseDto>(returnedRFTenorMapping);

                await _RFTenorMapping.SaveChangeAsync();
                return ServiceResponse<RFTenorMappingResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFTenorMappingResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}