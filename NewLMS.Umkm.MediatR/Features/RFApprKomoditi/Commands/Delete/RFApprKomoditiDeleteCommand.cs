using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFApprKomoditis;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFApprKomoditis.Commands
{
    public class RFApprKomoditiDeleteCommand : RFApprKomoditiFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DeleteRFApprKomoditiCommandHandler : IRequestHandler<RFApprKomoditiDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFApprKomoditi> _RFApprKomoditi;
        private readonly IMapper _mapper;

        public DeleteRFApprKomoditiCommandHandler(IGenericRepositoryAsync<RFApprKomoditi> RFApprKomoditi, IMapper mapper)
        {
            _RFApprKomoditi = RFApprKomoditi;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFApprKomoditiDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFApprKomoditi.GetByIdAsync(request.APPR_CODE, "APPR_CODE");
            rFProduct.IsDeleted = true;
            await _RFApprKomoditi.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}