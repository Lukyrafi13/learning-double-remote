using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Domain.Context;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using NewLMS.Umkm.Data.Constants;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.MediatR.Features.SIKPs.SIKP;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.LoanApplications.Commands.Processes
{
    public class LoanApplicationProcessIDE : IRequest<ServiceResponse<Unit>>
    {
        public Guid AppId { get; set; }
    }

    public class LoanApplicationProcessIDEHandler : IRequestHandler<LoanApplicationProcessIDE, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplication> _loanApplication;
        private readonly IGenericRepositoryAsync<LoanApplicationStage> _loanApplicationStage;
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
        private readonly IGenericRepositoryAsync<NewLMS.Umkm.Data.Entities.SIKP> _sikp;
        private readonly IGenericRepositoryAsync<SIKPRequest> _sikpRequest;
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
            IGenericRepositoryAsync<SLIKRequest> slikRequest,
            IGenericRepositoryAsync<LoanApplicationStage> loanApplicationStage,
            IGenericRepositoryAsync<Data.Entities.SIKP> sikp,
            IGenericRepositoryAsync<SIKPRequest> sikpRequest)
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
            _loanApplicationStage = loanApplicationStage;
            _sikp = sikp;
            _sikpRequest = sikpRequest;
        }

        public async Task<ServiceResponse<Unit>> Handle(LoanApplicationProcessIDE request, CancellationToken cancellationToken)
        {
            var transaction = await _userContext.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var includes = new string[]
                    {
                        "RfOwnerCategory",
                        "RfProduct",
                        "Debtor.RfResidenceStatus",
                        "Debtor.RfZipCode",
                        "Debtor.RfJob",
                        "Debtor.RfGender",
                        "Debtor.RfEducation",
                        "Debtor.RfMarital",
                        "Debtor.DebtorCouple.RfZipCode",
                        "Debtor.DebtorCouple.RfJob",
                        "DebtorCompany.DebtorCompanyLegal",
                        "DebtorCompany.RfZipCode",
                        "DebtorEmergency.RfZipCode",
                        "LoanApplicationCollaterals.RfCollateralBC",
                        "LoanApplicationCollaterals.RfDocument",
                        "LoanApplicationCollaterals.LoanApplicationCollateralOwner",
                        "LoanApplicationFacilities"
                    };
                var loanApplication = await _loanApplication.GetByIdAsync(request.AppId, "Id", includes) ?? throw new NullReferenceException($"LoanApplication not found, Id: {request.AppId}");
                var skipSikp = loanApplication.RfProduct.ProductType != "KUR" || (loanApplication.RfProduct.ProductType != "KUR" && loanApplication.LoanApplicationCollaterals.Count < 1);

                // Update Stage

                // Create SLIKRequest (Product != KUR)
                if (skipSikp)
                {
                    var slikRequest = await GenerateSLIKRequest(loanApplication);
                    await _slikRequest.AddAsync(slikRequest);
                }
                // Create SIKP (RfProduct == KUR)
                if (!skipSikp)
                {
                    var sikpCount = await _sikp.GetCountByPredicate(x => x.CreatedDate.Year == DateTime.Now.Year && x.CreatedDate.Month == DateTime.Now.Month);
                    var sikpRegist = $"{loanApplication.BranchId}/{sikpCount + 1:D4}/{loanApplication.CreatedDate:MM/yy}";

                    var sikp = new Data.Entities.SIKP
                    {
                        Id = loanApplication.Id,
                        RegistrationNumber = null
                    };
                    await _sikp.AddAsync(sikp);

                    // Create SIKP Request
                    var sikpRequest = _mapper.Map<LoanApplication, SIKPRequest>(loanApplication);
                    sikpRequest.Id = sikp.Id;
                    sikpRequest.DebtorRfZipCode = null;
                    sikpRequest.DebtorCompanyRfZipCode = null;
                    await _sikpRequest.AddAsync(sikpRequest);
                }

                var loanApplicationStage = new LoanApplicationStage()
                {
                    Id = Guid.NewGuid(),
                    LoanApplicationId = loanApplication.Id,
                    StageId = UMKMConst.Stages["SIKPChecking"],
                    OwnerRoleId = Guid.Parse("CB409959-9416-4C35-9AE8-EB905C3DE1AC"),
                    OwnerUserId = loanApplication.CreatedBy,
                    Processed = false,
                    ProcessedBy = loanApplication.CreatedBy,
                    ProcessedDate = DateTime.Now,
                };
                await _loanApplicationStage.AddAsync(loanApplicationStage);
                loanApplication.Status = Data.Enums.EnumLoanApplicationStatus.Processed;
                loanApplication.LoanApplicationCollaterals = null;
                await _loanApplication.UpdateAsync(loanApplication);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
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
