using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.AppAgunans;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.LoanApplicationCollaterals.Commands
{
    public class LoanAppCollateralDeleteCommand : AppAgunanFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class LoanAppCollateralDeleteCommandHandler : LoanAppCollateralDeleteCommand, IRequest<ServiceResponse<Unit>>
    {
    }

    public class AppAgunanDeleteCommandHandler : IRequestHandler<LoanAppCollateralDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplicationCollateral> _loanAppCollateral;
        private readonly IMapper _mapper;

        public AppAgunanDeleteCommandHandler(IGenericRepositoryAsync<LoanApplicationCollateral> loanAppCollateral, IMapper mapper)
        {
            _loanAppCollateral = loanAppCollateral;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(LoanAppCollateralDeleteCommand request, CancellationToken cancellationToken)
        {
            var otherFinance = await _loanAppCollateral.GetByIdAsync(request.Id, "Id");
            await _loanAppCollateral.DeleteAsync(otherFinance);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}