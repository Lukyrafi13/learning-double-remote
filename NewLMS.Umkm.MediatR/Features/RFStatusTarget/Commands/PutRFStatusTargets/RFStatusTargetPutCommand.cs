using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfTargetStatuss;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfTargetStatuss.Commands
{
    public class RfTargetStatusPutCommand : RfTargetStatusPutRequestDto, IRequest<ServiceResponse<RfTargetStatusResponseDto>>
    {
    }

    public class PutRfTargetStatusCommandHandler : IRequestHandler<RfTargetStatusPutCommand, ServiceResponse<RfTargetStatusResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RfTargetStatus> _rfStatusTarget;
        private readonly IMapper _mapper;

        public PutRfTargetStatusCommandHandler(IGenericRepositoryAsync<RfTargetStatus> rfStatusTarget, IMapper mapper){
            _rfStatusTarget = rfStatusTarget;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfTargetStatusResponseDto>> Handle(RfTargetStatusPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRfTargetStatus = await _rfStatusTarget.GetByIdAsync(request.StatusCode, "StatusCode");
                existingRfTargetStatus.Active = request.Active;
                existingRfTargetStatus.StatusCode = request.StatusCode;
                existingRfTargetStatus.StatusDesc = request.StatusDesc;
                
                await _rfStatusTarget.UpdateAsync(existingRfTargetStatus);

                var response = new RfTargetStatusResponseDto();
                response.Id = existingRfTargetStatus.Id;
                response.Active = existingRfTargetStatus.Active;
                response.StatusCode = existingRfTargetStatus.StatusCode;
                response.StatusDesc = existingRfTargetStatus.StatusDesc;

                return ServiceResponse<RfTargetStatusResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RfTargetStatusResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}