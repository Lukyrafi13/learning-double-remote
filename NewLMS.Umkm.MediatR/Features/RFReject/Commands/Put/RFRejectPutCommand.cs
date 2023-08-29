using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFRejects;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFRejects.Commands
{
    public class RFRejectPutCommand : RFRejectPutRequestDto, IRequest<ServiceResponse<RFRejectResponseDto>>
    {
    }

    public class PutRFRejectCommandHandler : IRequestHandler<RFRejectPutCommand, ServiceResponse<RFRejectResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFReject> _RFReject;
        private readonly IMapper _mapper;

        public PutRFRejectCommandHandler(IGenericRepositoryAsync<RFReject> RFReject, IMapper mapper)
        {
            _RFReject = RFReject;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFRejectResponseDto>> Handle(RFRejectPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFReject = await _RFReject.GetByIdAsync(request.RjCode, "RjCode");
                
                existingRFReject.RjCode = request.RjCode;
                existingRFReject.RjDesc = request.RjDesc;
                existingRFReject.CoreCode = request.CoreCode;
                existingRFReject.Priority = request.Priority;
                await _RFReject.UpdateAsync(existingRFReject);

                var response = _mapper.Map<RFRejectResponseDto>(existingRFReject);

                return ServiceResponse<RFRejectResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFRejectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}