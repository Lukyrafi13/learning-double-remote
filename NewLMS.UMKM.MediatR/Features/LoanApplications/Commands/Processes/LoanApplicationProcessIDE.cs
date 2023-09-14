using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.LoanApplications;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Domain.Context;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.LoanApplications.Commands.Processes
{
    public class LoanApplicationProcessIDE : LoanApplicationProcessRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class LoanApplicationProcessIDEHandler : IRequestHandler<LoanApplicationProcessIDE, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplication> _loanApplication;
        private readonly IGenericRepositoryAsync<RfParameterDetail> _parameterDetail;
        private readonly IGenericRepositoryAsync<LoanApplicationCreditScoring> _loanApplicationCreditScoring;
        private readonly IGenericRepositoryAsync<RfMarital> _rfMarital;
        private readonly IGenericRepositoryAsync<Debtor> _debtor;
        private readonly IGenericRepositoryAsync<DebtorCouple> _debtorCouple;
        private readonly IGenericRepositoryAsync<DebtorEmergency> _debtorEmergency;
        private readonly IGenericRepositoryAsync<DebtorCompany> _debtorCompany;
        private readonly IGenericRepositoryAsync<DebtorCompanyLegal> _debtorCompanyLegal;
        private readonly IGenericRepositoryAsync<SLIKRequest> _slikRequest;
        private readonly IGenericRepositoryAsync<SLIKRequestDebtor> _slikRequestDebtor;
        private readonly UserContext _userContext;
        private readonly IMapper _mapper;

        public LoanApplicationProcessIDEHandler(
            IGenericRepositoryAsync<LoanApplication> loanApplication,
            IGenericRepositoryAsync<LoanApplicationCreditScoring> loanApplicationCreditScoring,
            IGenericRepositoryAsync<RfParameterDetail> parameterDetail,
            IGenericRepositoryAsync<RfMarital> rfMarital,
            IGenericRepositoryAsync<Debtor> debtor,
            IGenericRepositoryAsync<DebtorCouple> debtorCouple,
            IGenericRepositoryAsync<DebtorEmergency> debtorEmergency,
            IGenericRepositoryAsync<DebtorCompany> debtorCompany,
            IGenericRepositoryAsync<DebtorCompanyLegal> debtorCompanyLegal,
            IMapper mapper,
            UserContext userContext,
            IGenericRepositoryAsync<SLIKRequest> slikRequest)
        {
            _loanApplication = loanApplication;
            _loanApplicationCreditScoring = loanApplicationCreditScoring;
            _parameterDetail = parameterDetail;
            _rfMarital = rfMarital;
            _debtor = debtor;
            _debtorCouple = debtorCouple;
            _debtorEmergency = debtorEmergency;
            _debtorCompany = debtorCompany;
            _debtorCompanyLegal = debtorCompanyLegal;
            _mapper = mapper;
            _userContext = userContext;
            _slikRequest = slikRequest;
        }

        public async Task<ServiceResponse<Unit>> Handle(LoanApplicationProcessIDE request, CancellationToken cancellationToken)
        {
            var transaction = await _userContext.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var loanApplication = await _loanApplication.GetByIdAsync(request.AppId, "Id") ?? throw new NullReferenceException($"LoanApplication not found, Id: {request.AppId}");

                // Update Stage

                // Create SLIKRequest (Product != KUR)
                if (loanApplication.RfProduct.ProductType != "KUR")
                {
                    var slikRequest = await GenerateSLIKRequest(loanApplication);
                    await _slikRequest.AddAsync(slikRequest);
                }
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);
                return ServiceResponse<Unit>.ReturnException(ex);
            }

            await transaction.CommitAsync(cancellationToken);
            return ServiceResponse<Unit>.ReturnResultWith201(Unit.Value);
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
                };

                var slikRequestDebtors = new List<SLIKRequestDebtor>()
                {
                    new SLIKRequestDebtor()
                    {
                        Id = Guid.NewGuid(),
                        Fullname = loanApplication.RfOwnerCategory.Code == "001" ? loanApplication.Debtor.Fullname : loanApplication.DebtorCompany.Name,
                        NPWP = loanApplication.RfOwnerCategory.Code == "001" ? loanApplication.Debtor.NPWP : loanApplication.DebtorCompany.DebtorCompanyLegal.NPWP,
                    }
                };

                slikRequest.SLIKRequestDebtors = slikRequestDebtors;
            }

            return slikRequest;
        }
    }
}
