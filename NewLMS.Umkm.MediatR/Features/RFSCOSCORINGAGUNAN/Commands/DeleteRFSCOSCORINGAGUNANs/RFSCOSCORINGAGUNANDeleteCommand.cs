using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSCOSCORINGAGUNANs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFSCOSCORINGAGUNANs.Commands
{
    public class RFSCOSCORINGAGUNANDeleteCommand : RFSCOSCORINGAGUNANFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFSCOSCORINGAGUNANCommandHandler : IRequestHandler<RFSCOSCORINGAGUNANDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFSCOSCORINGAGUNAN> _RFSCOSCORINGAGUNAN;
        private readonly IMapper _mapper;

        public DeleteRFSCOSCORINGAGUNANCommandHandler(IGenericRepositoryAsync<RFSCOSCORINGAGUNAN> RFSCOSCORINGAGUNAN, IMapper mapper){
            _RFSCOSCORINGAGUNAN = RFSCOSCORINGAGUNAN;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFSCOSCORINGAGUNANDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFSCOSCORINGAGUNAN.GetByIdAsync(request.SCO_CODE, "SCO_CODE");
            rFProduct.IsDeleted = true;
            await _RFSCOSCORINGAGUNAN.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}