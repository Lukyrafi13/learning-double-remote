using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Data.Dto.RFSCOCARATRANSAKSIs;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFSCOCARATRANSAKSIS.Commands
{
    public class RFSCOCARATRANSAKSISPostCommand : RFSCOCARATRANSAKSIPostRequestDto, IRequest<ServiceResponse<RFSCOCARATRANSAKSIResponseDto>>
    {

    }
    public class PostRFSCOCARATRANSAKSICommandHandler : IRequestHandler<RFSCOCARATRANSAKSISPostCommand, ServiceResponse<RFSCOCARATRANSAKSIResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSCOCARATRANSAKSI> _rfSCOCARATRANSAKSI;
        private readonly IMapper _mapper;

        public PostRFSCOCARATRANSAKSICommandHandler(IGenericRepositoryAsync<RFSCOCARATRANSAKSI> rfSCOCARATRANSAKSI, IMapper mapper)
        {
            _rfSCOCARATRANSAKSI = rfSCOCARATRANSAKSI;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSCOCARATRANSAKSIResponseDto>> Handle(RFSCOCARATRANSAKSISPostCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var rfSCOCARATRANSAKSI = new RFSCOCARATRANSAKSI();

                rfSCOCARATRANSAKSI.SCO_CODE = request.SCO_CODE;
                rfSCOCARATRANSAKSI.SCO_DESC = request.SCO_DESC;
                rfSCOCARATRANSAKSI.CORE_CODE = request.CORE_CODE;

                var returnedRfSCOCARATRANSAKSI = await _rfSCOCARATRANSAKSI.AddAsync(rfSCOCARATRANSAKSI, callSave: false);

                // var response = _mapper.Map<RfProductResponseDto>(returnedRfProduct);
                var response = _mapper.Map<RFSCOCARATRANSAKSIResponseDto>(returnedRfSCOCARATRANSAKSI);

                await _rfSCOCARATRANSAKSI.SaveChangeAsync();
                return ServiceResponse<RFSCOCARATRANSAKSIResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSCOCARATRANSAKSIResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}