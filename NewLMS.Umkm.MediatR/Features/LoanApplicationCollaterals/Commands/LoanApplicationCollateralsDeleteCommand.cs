using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.LoanApplicationCollaterals;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.LoanApplicationCollaterals.Commands
{
    public class LoanApplicationCollateralsDeleteCommand : LoanApplicationCollateralDeleteRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class LoanApplicationCollateralsDeleteCommandHandler : IRequestHandler<LoanApplicationCollateralsDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplicationCollateral> _loanApplicationCollateral;
        private readonly IGenericRepositoryAsync<LoanApplicationCollateralOwner> _loanApplicationCollateralOwner;
        private readonly IMapper _mapper;

        public LoanApplicationCollateralsDeleteCommandHandler(
            IGenericRepositoryAsync<LoanApplicationCollateral> loanApplicationCollateral, 
            IGenericRepositoryAsync<LoanApplicationCollateralOwner> loanApplicationCollateralOwner, 
            IMapper mapper)
        {
            _loanApplicationCollateral = loanApplicationCollateral;
            _loanApplicationCollateralOwner = loanApplicationCollateralOwner;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(LoanApplicationCollateralsDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //Delete Collateral Owner
                var loanApplictionCollateralOwner = await _loanApplicationCollateralOwner.GetByPredicate(x => x.Id == request.Id);
                if (loanApplictionCollateralOwner != null)
                {
                    await _loanApplicationCollateralOwner.DeleteAsync(loanApplictionCollateralOwner);

                    //Delete Collateral
                    var loanApplicationCollateral = await _loanApplicationCollateral.GetByPredicate(x => x.Id == request.Id);
                    if (loanApplicationCollateral != null)
                    {
                        await _loanApplicationCollateral.DeleteAsync(loanApplicationCollateral);
                    }

                }

                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnException(ex);
            }

        }
    }
}
