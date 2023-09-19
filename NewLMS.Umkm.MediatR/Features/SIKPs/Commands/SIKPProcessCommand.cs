using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Constants;
using NewLMS.Umkm.Data.Dto.LoanApplications;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Domain.Context;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.SIKPs.SIKP
{
    public class SIKPProcessCommand : LoanApplicationProcessRequest, IRequest<ServiceResponse<Unit>>
    {

    }

    public class SIKPProcessCommandHandler : IRequestHandler<SIKPProcessCommand, ServiceResponse<Unit>>
    {
        private IGenericRepositoryAsync<NewLMS.Umkm.Data.Entities.SIKP> _sikp;
        private IGenericRepositoryAsync<SLIKRequest> _slikRequest;
        private IGenericRepositoryAsync<SLIKRequestDebtor> _slikRequestDebtor;
        private IGenericRepositoryAsync<LoanApplicationStage> _loanApplicationStage;
        private IGenericRepositoryAsync<LoanApplicationCollateral> _loanApplicationCollateral;
        private IGenericRepositoryAsync<LoanApplicationAppraisal> _loanApplicationAppraisal;
        private readonly UserContext _userContext;
        private readonly ICurrentUserService _currentUser;
        private readonly IMapper _mapper;

        public SIKPProcessCommandHandler(IMapper mapper, IGenericRepositoryAsync<NewLMS.Umkm.Data.Entities.SIKP> sikp, ICurrentUserService currentUser, UserContext userContext, IGenericRepositoryAsync<LoanApplicationStage> loanApplicationStage, IGenericRepositoryAsync<LoanApplicationCollateral> loanApplicationCollateral, IGenericRepositoryAsync<LoanApplicationAppraisal> loanApplicationAppraisal, IGenericRepositoryAsync<SLIKRequest> slikRequest, IGenericRepositoryAsync<SLIKRequestDebtor> slikRequestDebtor)
        {
            _mapper = mapper;
            _sikp = sikp;
            _currentUser = currentUser;
            _userContext = userContext;
            _loanApplicationStage = loanApplicationStage;
            _loanApplicationCollateral = loanApplicationCollateral;
            _loanApplicationAppraisal = loanApplicationAppraisal;
            _slikRequest = slikRequest;
            _slikRequestDebtor = slikRequestDebtor;
        }

        public async Task<ServiceResponse<Unit>> Handle(SIKPProcessCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _userContext.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var sikp = await _sikp.GetByIdAsync(request.AppId, "Id", new string[] {
                    "LoanApplication.RfOwnerCategory",
                    "LoanApplication.Debtor",
                    "LoanApplication.DebtorCompany"
                });
                var loanApplicationCollaterals = await _loanApplicationCollateral.GetListByPredicate(x => x.LoanApplicationId == sikp.Id);
                var loanApplicationStageSLIK = new LoanApplicationStage
                {
                    Id = Guid.NewGuid(),
                    StageId = UMKMConst.Stages["SLIKRequest"],
                    OwnerRoleId = UMKMConst.Roles["AccountOfficerUMKM"],
                    OwnerUserId = Guid.Parse(_currentUser.Id),
                    LoanApplicationId = sikp.Id,
                    Processed = false,
                };
                var loanApplicationStageAppraisal = new LoanApplicationStage
                {
                    Id = Guid.NewGuid(),
                    StageId = UMKMConst.Stages["AppraisalAsignment"],
                    OwnerRoleId = UMKMConst.Roles["Supervisor"],
                    OwnerUserId = null,
                    LoanApplicationId = sikp.Id,
                    Processed = false,
                };

                // Create Appraisals
                foreach (LoanApplicationCollateral collateral in loanApplicationCollaterals)
                {
                    await _loanApplicationAppraisal.AddAsync(new LoanApplicationAppraisal
                    {
                        AppraisalId = Guid.NewGuid(),
                        LoanApplicationId = collateral.LoanApplicationId,
                        LoanApplicationCollateralId = collateral.Id,
                        StageId = UMKMConst.Stages["AppraisalAsignment"]
                    });
                }

                // Create SLIK
                var slikRequest = await GenerateSLIKRequest(sikp.LoanApplication);
                await _slikRequest.AddAsync(slikRequest);

                await _loanApplicationStage.AddAsync(loanApplicationStageSLIK);
                await _loanApplicationStage.AddAsync(loanApplicationStageAppraisal);

                await transaction.CommitAsync(cancellationToken);
                return ServiceResponse<Unit>.ReturnResultWith201(Unit.Value);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);
                return ServiceResponse<Unit>.ReturnException(ex);
            }

        }

        private async Task<SLIKRequest> GenerateSLIKRequest(LoanApplication loanApplication)
        {
            var slikRequest = await _slikRequest.GetByIdAsync(loanApplication.Id, "Id", new string[] { "SLIKRequestDebtors" });

            if (slikRequest != null)
            {
                var slikRequestDebtors = _slikRequestDebtor.GetListByPredicate(x => x.SLIKRequestId == slikRequest.Id);
            }
            else
            {
                slikRequest = new SLIKRequest()
                {
                    Id = loanApplication.Id,
                    BranchCode = loanApplication.BranchId,
                    StageId = UMKMConst.Stages["SLIKRequest"]
                };

                List<SLIKRequestDebtor> slikRequestDebtors = new()
                {
                    new SLIKRequestDebtor {
                        Id = Guid.NewGuid(),
                        SLIKRequestId = slikRequest.Id,
                        Fullname = loanApplication.RfOwnerCategory?.Code == "001" ? loanApplication.Debtor?.Fullname : loanApplication.DebtorCompany?.Name,
                        NPWP = loanApplication.RfOwnerCategory?.Code == "001" ? loanApplication.Debtor?.NPWP : loanApplication.DebtorCompany?.DebtorCompanyLegal?.NPWP,
                        SLIKDebtorType = loanApplication.OwnerCategoryId
                    }
                };

                slikRequest.SLIKRequestDebtors = slikRequestDebtors;
            }

            return slikRequest;
        }
    }
}

