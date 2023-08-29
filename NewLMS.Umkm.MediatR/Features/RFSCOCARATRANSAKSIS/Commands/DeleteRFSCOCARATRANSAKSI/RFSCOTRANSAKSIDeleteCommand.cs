using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using NewLMS.UMKM.Data.Dto.RFSCOCARATRANSAKSIs;

namespace NewLMS.UMKM.MediatR.Features.RFSCOCARATRANSAKSIS.Commands
{
    public class RFSCOCARATRANSAKSIDeleteCommand : RFSCOCARATRANSAKSIFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DeleteRFSCOCARATRANSAKSICommandHandler : IRequestHandler<RFSCOCARATRANSAKSIDeleteCommand, ServiceResponse<Unit>>

    {
        private readonly IGenericRepositoryAsync<RFSCOCARATRANSAKSI> _rfSCOCARATRANSAKSI;
        private readonly IMapper _mapper;

        public DeleteRFSCOCARATRANSAKSICommandHandler(IGenericRepositoryAsync<RFSCOCARATRANSAKSI> rfSCOCARATRANSAKSI, IMapper mapper)
        {
            _rfSCOCARATRANSAKSI = rfSCOCARATRANSAKSI;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFSCOCARATRANSAKSIDeleteCommand request, CancellationToken cancellationToken)
        {
            var rfSCOCARATRANSAKSI = await _rfSCOCARATRANSAKSI.GetByIdAsync(request.SCO_CODE, "SCO_CODE");
            rfSCOCARATRANSAKSI.IsDeleted = true;
            await _rfSCOCARATRANSAKSI.UpdateAsync(rfSCOCARATRANSAKSI);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }

    }
}




