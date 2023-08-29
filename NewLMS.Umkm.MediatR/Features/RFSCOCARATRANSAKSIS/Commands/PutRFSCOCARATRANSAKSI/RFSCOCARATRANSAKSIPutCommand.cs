using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSCOCARATRANSAKSIs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFSCOCARATRANSAKSIS.Commands
{
    public class RFSCOCARATRANSAKSIPutCommand : RFSCOCARATRANSAKSIPutRequestDto, IRequest<ServiceResponse<RFSCOCARATRANSAKSIResponseDto>>
    {

    }
    public class PutRFSCOCARATRANSKASICommandHandler : IRequestHandler<RFSCOCARATRANSAKSIPutCommand, ServiceResponse<RFSCOCARATRANSAKSIResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSCOCARATRANSAKSI> _rfSCOCARATRANSAKSI;
        private readonly IMapper _mapper;

        public PutRFSCOCARATRANSKASICommandHandler(IGenericRepositoryAsync<RFSCOCARATRANSAKSI> rfSCOCARATRANSAKSI, IMapper mapper)
        {
            _rfSCOCARATRANSAKSI = rfSCOCARATRANSAKSI;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFSCOCARATRANSAKSIResponseDto>> Handle(RFSCOCARATRANSAKSIPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFSCOCARATRANSAKSI = await _rfSCOCARATRANSAKSI.GetByIdAsync(request.SCO_CODE, "SCO_CODE");
                existingRFSCOCARATRANSAKSI.SCO_CODE = request.SCO_CODE;
                existingRFSCOCARATRANSAKSI.SCO_DESC = request.SCO_DESC;
                existingRFSCOCARATRANSAKSI.CORE_CODE = request.CORE_CODE;

                await _rfSCOCARATRANSAKSI.UpdateAsync(existingRFSCOCARATRANSAKSI);

                var response = _mapper.Map<RFSCOCARATRANSAKSIResponseDto>(existingRFSCOCARATRANSAKSI);


                return ServiceResponse<RFSCOCARATRANSAKSIResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSCOCARATRANSAKSIResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

    }
}