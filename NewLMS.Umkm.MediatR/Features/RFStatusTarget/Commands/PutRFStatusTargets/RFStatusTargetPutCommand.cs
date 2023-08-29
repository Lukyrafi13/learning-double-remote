using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFStatusTargets;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFStatusTargets.Commands
{
    public class RFStatusTargetPutCommand : RFStatusTargetPutRequestDto, IRequest<ServiceResponse<RFStatusTargetResponseDto>>
    {
    }

    public class PutRFStatusTargetCommandHandler : IRequestHandler<RFStatusTargetPutCommand, ServiceResponse<RFStatusTargetResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFStatusTarget> _rfStatusTarget;
        private readonly IMapper _mapper;

        public PutRFStatusTargetCommandHandler(IGenericRepositoryAsync<RFStatusTarget> rfStatusTarget, IMapper mapper){
            _rfStatusTarget = rfStatusTarget;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFStatusTargetResponseDto>> Handle(RFStatusTargetPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFStatusTarget = await _rfStatusTarget.GetByIdAsync(request.StatusCode, "StatusCode");
                existingRFStatusTarget.Active = request.Active;
                existingRFStatusTarget.StatusCode = request.StatusCode;
                existingRFStatusTarget.StatusDesc = request.StatusDesc;
                
                await _rfStatusTarget.UpdateAsync(existingRFStatusTarget);

                var response = new RFStatusTargetResponseDto();
                response.Id = existingRFStatusTarget.Id;
                response.Active = existingRFStatusTarget.Active;
                response.StatusCode = existingRFStatusTarget.StatusCode;
                response.StatusDesc = existingRFStatusTarget.StatusDesc;

                return ServiceResponse<RFStatusTargetResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFStatusTargetResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}