using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.LoanApplications;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Domain.Context;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.MediatR.Helpers;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.LoanApplications.Commands
{
    public class UpsertLoanApplicationIDECommand : LoanApplicationIDEUpsertRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class UpsertLoanApplicationIDECommandHandler : IRequestHandler<UpsertLoanApplicationIDECommand, ServiceResponse<Unit>>
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
        private readonly UserContext _userContext;
        private readonly IMapper _mapper;

        public UpsertLoanApplicationIDECommandHandler(
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
            UserContext userContext)
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
        }

        public async Task<ServiceResponse<Unit>> Handle(UpsertLoanApplicationIDECommand request, CancellationToken cancellationToken)
        {
            var transaction = await _userContext.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var includes = IncludesGenerator.GetLoanApplicationIncludes(request.Tab);
                var loanApplication = await _loanApplication.GetByIdAsync(request.AppId, "Id", includes.ToArray());

                loanApplication = _mapper.Map<LoanApplicationIDEUpsertRequest, LoanApplication>(request, loanApplication);
                var ownerCategory = await _parameterDetail.GetByIdAsync(request.OwnerCategoryId, "ParameterDetailId");

                await _loanApplication.UpdateAsync(loanApplication);

                switch (request.Tab)
                {
                    case "initial_data_entry":
                        var dataFasilitas = request.InitialDataEntry.DataFasilitas;

                        if (ownerCategory.Code == "001") // Perorangan
                        {
                            var creditScoring = loanApplication.LoanApplicationCreditScoring;
                            creditScoring = _mapper.Map<LoanApplicationIDEUpsertRequest, LoanApplicationCreditScoring>(request, creditScoring);
                            if (creditScoring.Id == Guid.Empty)
                            {
                                creditScoring.Id = loanApplication.Id;
                                await _loanApplicationCreditScoring.AddAsync(creditScoring);
                            }
                            else
                            {
                                await _loanApplicationCreditScoring.UpdateAsync(creditScoring);
                            }
                        }
                        break;

                    case "data_permohonan":
                        #region Debtor / DebtorCompany
                        var debtor = loanApplication.Debtor;
                        var debtorCompany = loanApplication.DebtorCompany;

                        if (ownerCategory.Code == "001") // Perorangan
                        {
                            debtor = _mapper.Map<LoanApplicationIDEUpsertRequest, Debtor>(request, debtor);

                            if (debtor.Id == Guid.Empty)
                            {
                                await _debtor.AddAsync(debtor);
                            }
                            else
                            {
                                await _debtor.UpdateAsync(debtor);
                            }
                            #endregion

                            #region DebtorCouple
                            var maritalStatus = await _rfMarital.GetByIdAsync(debtor.MaritalStatusId, "MaritalCode");
                            var debtorCouple = debtor.DebtorCouple;
                            debtorCouple = _mapper.Map<LoanApplicationIDEUpsertRequest, DebtorCouple>(request, debtorCouple);

                            if (maritalStatus.MaritalCode == "01") // Menikah
                            {
                                if (debtorCouple.Id == Guid.Empty)
                                {
                                    await _debtorCouple.AddAsync(debtorCouple);
                                }
                                else
                                {
                                    await _debtorCouple.UpdateAsync(debtorCouple);
                                }
                            }
                            else
                            {
                                if (debtorCouple.Id != Guid.Empty) await _debtorCouple.DeleteAsync(debtorCouple);
                            }
                        }
                        else
                        {
                            debtorCompany = _mapper.Map<LoanApplicationIDEUpsertRequest, DebtorCompany>(request, debtorCompany);

                            if (debtorCompany.Id == Guid.Empty)
                            {
                                await _debtorCompany.AddAsync(debtorCompany);
                            }
                            else
                            {
                                await _debtorCompany.UpdateAsync(debtorCompany);
                            }

                            var debtorCompanyLegal = debtorCompany.DebtorCompanyLegal;
                            debtorCompanyLegal = _mapper.Map<LoanApplicationIDEUpsertRequest, DebtorCompanyLegal>(request, debtorCompanyLegal);
                            if (debtorCompanyLegal.Id != Guid.Empty)
                            {
                                await _debtorCompanyLegal.AddAsync(debtorCompanyLegal);
                            }
                            else
                            {
                                await _debtorCompanyLegal.UpdateAsync(debtorCompanyLegal);
                            }
                        }
                        #endregion

                        #region DebtorEmergency
                        var debtorEmergency = loanApplication.DebtorEmergency;
                        debtorEmergency = _mapper.Map<LoanApplicationIDEUpsertRequest, DebtorEmergency>(request, debtorEmergency);

                        if (debtorEmergency.Id == Guid.Empty)
                        {
                            await _debtorEmergency.AddAsync(debtorEmergency);
                        }
                        else { await _debtorEmergency.UpdateAsync(debtorEmergency); }
                        #endregion
                        break;
                    default:
                        break;
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
    }
}
