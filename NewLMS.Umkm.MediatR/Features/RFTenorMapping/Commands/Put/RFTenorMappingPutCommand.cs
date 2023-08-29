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
    public class RFTenorMappingPutCommand : RFTenorMappingPutRequestDto, IRequest<ServiceResponse<RFTenorMappingResponseDto>>
    {
    }

    public class PutRFTenorMappingCommandHandler : IRequestHandler<RFTenorMappingPutCommand, ServiceResponse<RFTenorMappingResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFTenorMapping> _RFTenorMapping;
        private readonly IMapper _mapper;

        public PutRFTenorMappingCommandHandler(IGenericRepositoryAsync<RFTenorMapping> RFTenorMapping, IMapper mapper){
            _RFTenorMapping = RFTenorMapping;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFTenorMappingResponseDto>> Handle(RFTenorMappingPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFTenorMapping = await _RFTenorMapping.GetByIdAsync(request.Id, "Id");
                existingRFTenorMapping.TNCode = request.TNCode;
                existingRFTenorMapping.SiklusCode = request.SiklusCode;
                existingRFTenorMapping.ProductId = request.ProductId;
                
                await _RFTenorMapping.UpdateAsync(existingRFTenorMapping);

                var response = _mapper.Map<RFTenorMappingResponseDto>(existingRFTenorMapping);

                return ServiceResponse<RFTenorMappingResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFTenorMappingResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}