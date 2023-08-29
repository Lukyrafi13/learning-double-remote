using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSCORiwayatKreditBJBs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFSCORiwayatKreditBJBs.Commands
{
    public class RFSCORiwayatKreditBJBPutCommand : RFSCORiwayatKreditBJBPutRequestDto, IRequest<ServiceResponse<RFSCORiwayatKreditBJBResponseDto>>
    {
    }

    public class PutRFSCORiwayatKreditBJBCommandHandler : IRequestHandler<RFSCORiwayatKreditBJBPutCommand, ServiceResponse<RFSCORiwayatKreditBJBResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSCORiwayatKreditBJB> _RFSCORiwayatKreditBJB;
        private readonly IMapper _mapper;

        public PutRFSCORiwayatKreditBJBCommandHandler(IGenericRepositoryAsync<RFSCORiwayatKreditBJB> RFSCORiwayatKreditBJB, IMapper mapper){
            _RFSCORiwayatKreditBJB = RFSCORiwayatKreditBJB;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSCORiwayatKreditBJBResponseDto>> Handle(RFSCORiwayatKreditBJBPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFSCORiwayatKreditBJB = await _RFSCORiwayatKreditBJB.GetByIdAsync(request.SCO_CODE, "SCO_CODE");
                existingRFSCORiwayatKreditBJB.SCO_CODE = request.SCO_CODE;
                existingRFSCORiwayatKreditBJB.SCO_DESC = request.SCO_DESC;
                existingRFSCORiwayatKreditBJB.CORE_CODE = request.CORE_CODE;
                existingRFSCORiwayatKreditBJB.ACTIVE = request.ACTIVE;
                
                await _RFSCORiwayatKreditBJB.UpdateAsync(existingRFSCORiwayatKreditBJB);

                var response = _mapper.Map<RFSCORiwayatKreditBJBResponseDto>(existingRFSCORiwayatKreditBJB);

                return ServiceResponse<RFSCORiwayatKreditBJBResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSCORiwayatKreditBJBResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}