using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFOwnerOTSs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFOwnerOTSs.Commands
{
    public class RFOwnerOTSPutCommand : RFOwnerOTSPutRequestDto, IRequest<ServiceResponse<RFOwnerOTSResponseDto>>
    {
    }

    public class RFOwnerOTSPutCommandHandler : IRequestHandler<RFOwnerOTSPutCommand, ServiceResponse<RFOwnerOTSResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFOwnerOTS> _RFOwnerOTS;
        private readonly IMapper _mapper;

        public RFOwnerOTSPutCommandHandler(IGenericRepositoryAsync<RFOwnerOTS> RFOwnerOTS, IMapper mapper)
        {
            _RFOwnerOTS = RFOwnerOTS;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFOwnerOTSResponseDto>> Handle(RFOwnerOTSPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFOwnerOTS = await _RFOwnerOTS.GetByIdAsync(request.OWN_CODE, "OWN_CODE");
                
                existingRFOwnerOTS.OWN_DESC = request.OWN_DESC;
                existingRFOwnerOTS.CORE_CODE = request.CORE_CODE;
                existingRFOwnerOTS.Active = request.Active;

                await _RFOwnerOTS.UpdateAsync(existingRFOwnerOTS);

                var response = _mapper.Map<RFOwnerOTSResponseDto>(existingRFOwnerOTS);

                return ServiceResponse<RFOwnerOTSResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFOwnerOTSResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}