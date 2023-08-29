using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFSCOSALDOREKRATAs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFSCOSALDOREKRATAs.Commands
{
    public class RFSCOSALDOREKRATADeleteCommand : RFSCOSALDOREKRATAFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFSCOSALDOREKRATACommandHandler : IRequestHandler<RFSCOSALDOREKRATADeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFSCOSALDOREKRATA> _RFSCOSALDOREKRATA;
        private readonly IMapper _mapper;

        public DeleteRFSCOSALDOREKRATACommandHandler(IGenericRepositoryAsync<RFSCOSALDOREKRATA> RFSCOSALDOREKRATA, IMapper mapper){
            _RFSCOSALDOREKRATA = RFSCOSALDOREKRATA;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFSCOSALDOREKRATADeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFSCOSALDOREKRATA.GetByIdAsync(request.SCO_CODE, "SCO_CODE");
            rFProduct.IsDeleted = true;
            await _RFSCOSALDOREKRATA.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}