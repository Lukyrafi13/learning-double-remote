using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFRejects;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFRejects.Commands
{
    public class RFRejectPostCommand : RFRejectPostRequestDto, IRequest<ServiceResponse<RFRejectResponseDto>>
    {

    }
    public class RFRejectPostCommandHandler : IRequestHandler<RFRejectPostCommand, ServiceResponse<RFRejectResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFReject> _RFReject;
        private readonly IMapper _mapper;

        public RFRejectPostCommandHandler(IGenericRepositoryAsync<RFReject> RFReject, IMapper mapper)
        {
            _RFReject = RFReject;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFRejectResponseDto>> Handle(RFRejectPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFReject = _mapper.Map<RFReject>(request);

                var returnedRFReject = await _RFReject.AddAsync(RFReject, callSave: false);

                // var response = _mapper.Map<RFRejectResponseDto>(returnedRFReject);
                var response = _mapper.Map<RFRejectResponseDto>(returnedRFReject);

                await _RFReject.SaveChangeAsync();
                return ServiceResponse<RFRejectResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFRejectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}