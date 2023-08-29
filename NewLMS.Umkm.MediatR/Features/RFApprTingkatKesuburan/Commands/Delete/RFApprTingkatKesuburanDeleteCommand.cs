using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFApprTingkatKesuburans;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFApprTingkatKesuburans.Commands
{
    public class RFApprTingkatKesuburanDeleteCommand : RFApprTingkatKesuburanFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DeleteRFApprTingkatKesuburanCommandHandler : IRequestHandler<RFApprTingkatKesuburanDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFApprTingkatKesuburan> _RFApprTingkatKesuburan;
        private readonly IMapper _mapper;

        public DeleteRFApprTingkatKesuburanCommandHandler(IGenericRepositoryAsync<RFApprTingkatKesuburan> RFApprTingkatKesuburan, IMapper mapper)
        {
            _RFApprTingkatKesuburan = RFApprTingkatKesuburan;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFApprTingkatKesuburanDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFApprTingkatKesuburan.GetByIdAsync(request.APPR_CODE, "APPR_CODE");
            rFProduct.IsDeleted = true;
            await _RFApprTingkatKesuburan.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}