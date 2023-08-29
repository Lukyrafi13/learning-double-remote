using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFSCOTINGKATKEBUTUHANs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFSCOTINGKATKEBUTUHANs.Commands
{
    public class RFSCOTINGKATKEBUTUHANPutCommand : RFSCOTINGKATKEBUTUHANPutRequestDto, IRequest<ServiceResponse<RFSCOTINGKATKEBUTUHANResponseDto>>
    {
    }

    public class PutRFSCOTINGKATKEBUTUHANCommandHandler : IRequestHandler<RFSCOTINGKATKEBUTUHANPutCommand, ServiceResponse<RFSCOTINGKATKEBUTUHANResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSCOTINGKATKEBUTUHAN> _RFSCOTINGKATKEBUTUHAN;
        private readonly IMapper _mapper;

        public PutRFSCOTINGKATKEBUTUHANCommandHandler(IGenericRepositoryAsync<RFSCOTINGKATKEBUTUHAN> RFSCOTINGKATKEBUTUHAN, IMapper mapper)
        {
            _RFSCOTINGKATKEBUTUHAN = RFSCOTINGKATKEBUTUHAN;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSCOTINGKATKEBUTUHANResponseDto>> Handle(RFSCOTINGKATKEBUTUHANPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFSCOTINGKATKEBUTUHAN = await _RFSCOTINGKATKEBUTUHAN.GetByIdAsync(request.SCO_CODE, "SCO_CODE");
                existingRFSCOTINGKATKEBUTUHAN.SCO_CODE = request.SCO_CODE;
                existingRFSCOTINGKATKEBUTUHAN.SCO_DESC = request.SCO_DESC;
                existingRFSCOTINGKATKEBUTUHAN.CORE_CODE = request.CORE_CODE;
                existingRFSCOTINGKATKEBUTUHAN.ACTIVE = request.ACTIVE;

                await _RFSCOTINGKATKEBUTUHAN.UpdateAsync(existingRFSCOTINGKATKEBUTUHAN);

                var response = _mapper.Map<RFSCOTINGKATKEBUTUHANResponseDto>(existingRFSCOTINGKATKEBUTUHAN);

                return ServiceResponse<RFSCOTINGKATKEBUTUHANResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSCOTINGKATKEBUTUHANResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}