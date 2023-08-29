using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfTargetStatuses;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfTargetStatuses.Commands
{
    public class RfTargetStatusPostCommand : RfTargetStatusPostRequestDto, IRequest<ServiceResponse<RfTargetStatusResponseDto>>
    {

    }
    public class PostRfTargetStatusCommandHandler : IRequestHandler<RfTargetStatusPostCommand, ServiceResponse<RfTargetStatusResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RfTargetStatus> _rfStatusTarget;
        private readonly IMapper _mapper;

        public PostRfTargetStatusCommandHandler(IGenericRepositoryAsync<RfTargetStatus> rfStatusTarget, IMapper mapper)
        {
            _rfStatusTarget = rfStatusTarget;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfTargetStatusResponseDto>> Handle(RfTargetStatusPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var rfStatusTarget = new RfTargetStatus();

                rfStatusTarget.Active = true;
                rfStatusTarget.StatusCode = request.StatusCode;
                rfStatusTarget.StatusDesc = request.StatusDesc;

                var returnedRfStatusTarget = await _rfStatusTarget.AddAsync(rfStatusTarget, callSave: false);

                // var response = _mapper.Map<RfTargetStatusResponseDto>(returnedRfStatusTarget);
                var response = new RfTargetStatusResponseDto();
                
                response.Id = returnedRfStatusTarget.Id;
                response.StatusCode = returnedRfStatusTarget.StatusCode;
                response.StatusDesc = returnedRfStatusTarget.StatusDesc;
                response.Active = returnedRfStatusTarget.Active;

                await _rfStatusTarget.SaveChangeAsync();
                return ServiceResponse<RfTargetStatusResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RfTargetStatusResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}