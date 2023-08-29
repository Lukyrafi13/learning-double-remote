using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFApprKomoditis;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFApprKomoditis.Commands
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