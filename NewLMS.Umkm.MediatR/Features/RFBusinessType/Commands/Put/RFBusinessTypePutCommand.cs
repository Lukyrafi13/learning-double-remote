using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFBusinessTypes;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFBusinessTypes.Commands
{
    public class RFBusinessTypePutCommand : RFBusinessTypePutRequestDto, IRequest<ServiceResponse<RFBusinessTypeResponseDto>>
    {
    }

    public class PutRFBusinessTypeCommandHandler : IRequestHandler<RFBusinessTypePutCommand, ServiceResponse<RFBusinessTypeResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFBusinessType> _RFBusinessType;
        private readonly IMapper _mapper;

        public PutRFBusinessTypeCommandHandler(IGenericRepositoryAsync<RFBusinessType> RFBusinessType, IMapper mapper)
        {
            _RFBusinessType = RFBusinessType;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFBusinessTypeResponseDto>> Handle(RFBusinessTypePutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFBusinessType = await _RFBusinessType.GetByIdAsync(request.BTCode, "BTCode");
                
                existingRFBusinessType.BTDesc = request.BTDesc;
                existingRFBusinessType.CoreCode = request.CoreCode;
                existingRFBusinessType.Active = request.Active;
                await _RFBusinessType.UpdateAsync(existingRFBusinessType);

                var response = _mapper.Map<RFBusinessTypeResponseDto>(existingRFBusinessType);

                return ServiceResponse<RFBusinessTypeResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFBusinessTypeResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}