using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.LoanApplicationCollaterals;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.LoanApplicationCollaterals.Commands
{
    public class LoanApplicationCollateralsPostCommand : LoanApplicationCollateralAndOwnerPostRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class LoanApplicationCollateralsPostCommandHandler : IRequestHandler<LoanApplicationCollateralsPostCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplicationCollateral> _loanApplicationCollateral;
        private readonly IGenericRepositoryAsync<LoanApplicationCollateralOwner> _loanApplicationCollateralOwner;
        private readonly IMapper _mapper;

        public LoanApplicationCollateralsPostCommandHandler(
            IGenericRepositoryAsync<LoanApplicationCollateral> loanApplicationCollateral,
            IGenericRepositoryAsync<LoanApplicationCollateralOwner> loanApplicationCollateralOwner,
            IMapper mapper)
        {
            _loanApplicationCollateral = loanApplicationCollateral;
            _loanApplicationCollateralOwner = loanApplicationCollateralOwner;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(LoanApplicationCollateralsPostCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //Collateral
                var loanApplicationCollateralNewGuid = Guid.NewGuid();
                var loanApplicationCollateral = _mapper.Map<LoanApplicationCollateral>(request.LoanApplicationCollateral);
                loanApplicationCollateral.Id = loanApplicationCollateralNewGuid;
                await _loanApplicationCollateral.AddAsync(loanApplicationCollateral);

                //CollateralOwner
                var loanApplicationCollateralOwner = _mapper.Map<LoanApplicationCollateralOwner>(request.LoanApplicationCollateralOwner);
                loanApplicationCollateralOwner.Id = loanApplicationCollateralNewGuid;
                await _loanApplicationCollateralOwner.AddAsync(loanApplicationCollateralOwner);

                return ServiceResponse<Unit>.ReturnResultWith201(Unit.Value);

            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }

        }
    }
}
