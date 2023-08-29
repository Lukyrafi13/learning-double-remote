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
    public class RFStatusTargetPostCommand : RFStatusTargetPostRequestDto, IRequest<ServiceResponse<RFStatusTargetResponseDto>>
    {

    }
    public class PostRFStatusTargetCommandHandler : IRequestHandler<RFStatusTargetPostCommand, ServiceResponse<RFStatusTargetResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFStatusTarget> _rfStatusTarget;
        private readonly IMapper _mapper;

        public PostRFStatusTargetCommandHandler(IGenericRepositoryAsync<RFStatusTarget> rfStatusTarget, IMapper mapper)
        {
            _rfStatusTarget = rfStatusTarget;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFStatusTargetResponseDto>> Handle(RFStatusTargetPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var rfStatusTarget = new RFStatusTarget();

                rfStatusTarget.Active = true;
                rfStatusTarget.StatusCode = request.StatusCode;
                rfStatusTarget.StatusDesc = request.StatusDesc;

                var returnedRfStatusTarget = await _rfStatusTarget.AddAsync(rfStatusTarget, callSave: false);

                // var response = _mapper.Map<RFStatusTargetResponseDto>(returnedRfStatusTarget);
                var response = new RFStatusTargetResponseDto();
                
                response.Id = returnedRfStatusTarget.Id;
                response.StatusCode = returnedRfStatusTarget.StatusCode;
                response.StatusDesc = returnedRfStatusTarget.StatusDesc;
                response.Active = returnedRfStatusTarget.Active;

                await _rfStatusTarget.SaveChangeAsync();
                return ServiceResponse<RFStatusTargetResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFStatusTargetResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}