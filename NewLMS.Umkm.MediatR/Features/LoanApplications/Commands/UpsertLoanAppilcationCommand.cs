using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.LoanApplications;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Domain.Context;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.MediatR.Helpers;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.LoanApplications.Commands
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
                var ownerCategory = await _parameterDetail.GetByIdAsync(request.OwnerCategoryId, "ParameterDetailId");

                var debtorCompanyId = loanApplication.DebtorCompanyId;

                switch (request.Tab)
                {
                    case "initial_data_entry":
                        var dataFasilitas = request.InitialDataEntry.DataFasilitas;
                        var creditScoring = loanApplication.LoanApplicationCreditScoring;
                        if (ownerCategory.Code == "001") // Perorangan
                        {
                            if (creditScoring == null)
                            {
                                creditScoring = _mapper.Map<LoanApplicationIDEUpsertRequest, LoanApplicationCreditScoring>(request);
                                creditScoring.Id = loanApplication.Id;
                                await _loanApplicationCreditScoring.AddAsync(creditScoring);
                            }
                            else
                            {
                                creditScoring = _mapper.Map<LoanApplicationIDEUpsertRequest, LoanApplicationCreditScoring>(request);
                                creditScoring.Id = loanApplication.Id;
                                await _loanApplicationCreditScoring.UpdateAsync(creditScoring);
                            }

                            loanApplication.DebtorCompanyId = null;
                            loanApplication = ClearLoanApplicationRelatives(loanApplication);
                            await _loanApplication.UpdateAsync(loanApplication);

                            //DebtorCompany
                            var debtorCompanyData = await _debtorCompany.GetByPredicate(x => x.Id == debtorCompanyId);
                            if (debtorCompanyData != null)
                            {
                                await _debtorCompany.DeleteAsync(debtorCompanyData);
                            }

                            //DebtorCompanyLegal
                            var debtorCompanyLegal = await _debtorCompanyLegal.GetByPredicate(x => x.Id == debtorCompanyId);
                            if (debtorCompanyLegal != null)
                            {
                                await _debtorCompanyLegal.DeleteAsync(debtorCompanyLegal);
                            }
                        }
                        else
                        {
                            var debtorId = loanApplication.DebtorId;
                            var dataDebitur = loanApplication.Debtor;

                            loanApplication.DebtorId = null;
                            loanApplication.Debtor = null;
                            loanApplication.RfOwnerCategory = null;

                            await _loanApplication.UpdateAsync(loanApplication);

                            // Kosongkan Credit Scoring
                            if (creditScoring != null)
                            {
                                await _loanApplicationCreditScoring.DeleteAsync(creditScoring);
                            }

                            // Kosongkan Data Debitur
                            if (dataDebitur != null)
                            {
                                await _debtor.DeleteAsync(dataDebitur);
                            }
                        }

                        // Remove business cycle check
                        if (!request.InitialDataEntry?.DataFasilitas?.IsBusinessCycle ?? false)
                        {
                            loanApplication.BusinessCycleId = null;
                            loanApplication.RfBusinessCycle = null;
                            loanApplication.BusinessCycleMonth = null;
                        }

                        loanApplication = _mapper.Map<LoanApplicationIDEUpsertRequest, LoanApplication>(request, loanApplication);
                        loanApplication.BookingBranchId = request.InitialDataEntry.DataFasilitas.BookingBranchId;
                        loanApplication = ClearLoanApplicationRelatives(loanApplication);
                        await _loanApplication.UpdateAsync(loanApplication);
                        break;

                    case "data_permohonan":
                        #region Debtor / DebtorCompany
                        var debtor = loanApplication.Debtor;
                        var debtorCompany = loanApplication.DebtorCompany;
                        var debtorEmergency = loanApplication.DebtorEmergency;

                        if (ownerCategory.Code == "001") // Perorangan
                        {
                            if (debtor == null)
                            {
                                debtor = _mapper.Map<LoanApplicationIDEUpsertRequest, Debtor>(request, debtor);
                                await _debtor.AddAsync(debtor);
                            }
                            else
                            {
                                debtor = _mapper.Map<LoanApplicationIDEUpsertRequest, Debtor>(request);
                                await _debtor.UpdateAsync(debtor);
                            }
                            #endregion

                            #region DebtorCouple
                            var maritalStatus = await _rfMarital.GetByIdAsync(debtor.MaritalStatusId, "MaritalCode");
                            var debtorCouple = loanApplication.Debtor?.DebtorCouple;

                            if (maritalStatus.MaritalCode == "01") // Menikah
                            {
                                if (debtorCouple == null)
                                {
                                    debtorCouple = _mapper.Map<LoanApplicationIDEUpsertRequest, DebtorCouple>(request);
                                    debtorCouple.Id = debtor.Id;
                                    await _debtorCouple.AddAsync(debtorCouple);
                                }
                                else
                                {
                                    debtorCouple = _mapper.Map<LoanApplicationIDEUpsertRequest, DebtorCouple>(request);
                                    debtorCouple.Id = debtor.Id;
                                    await _debtorCouple.UpdateAsync(debtorCouple);
                                }
                            }
                            else
                            {
                                if (debtorCouple != null) await _debtorCouple.DeleteAsync(debtorCouple);
                            }
                        }
                        else
                        {

                            if (debtorCompany == null)
                            {
                                debtorCompany = _mapper.Map<LoanApplicationIDEUpsertRequest, DebtorCompany>(request, debtorCompany);
                                debtorCompany.Id = Guid.NewGuid();
                                await _debtorCompany.AddAsync(debtorCompany);

                                loanApplication.DebtorCompany = debtorCompany;

                                await _loanApplication.UpdateAsync(loanApplication);
                            }
                            else
                            {
                                debtorCompany = _mapper.Map<LoanApplicationIDEUpsertRequest, DebtorCompany>(request);
                                if (debtorCompanyId != null) debtorCompany.Id = debtorCompanyId ?? Guid.NewGuid();
                                await _debtorCompany.UpdateAsync(debtorCompany);
                            }

                            var debtorCompanyLegal = loanApplication.DebtorCompany?.DebtorCompanyLegal;
                            if (debtorCompanyLegal == null)
                            {
                                debtorCompanyLegal = _mapper.Map<LoanApplicationIDEUpsertRequest, DebtorCompanyLegal>(request, debtorCompanyLegal);
                                debtorCompanyLegal.Id = debtorCompany.Id;
                                await _debtorCompanyLegal.AddAsync(debtorCompanyLegal);
                            }
                            else
                            {
                                debtorCompanyLegal = _mapper.Map<LoanApplicationIDEUpsertRequest, DebtorCompanyLegal>(request);
                                debtorCompanyLegal.Id = debtorCompany.Id;

                                await _debtorCompanyLegal.UpdateAsync(debtorCompanyLegal);
                            }
                        }
                        #endregion

                        #region DebtorEmergency

                        if (debtorEmergency == null)
                        {
                            debtorEmergency = _mapper.Map<LoanApplicationIDEUpsertRequest, DebtorEmergency>(request, debtorEmergency);
                            debtorEmergency.Id = loanApplication.Id;
                            await _debtorEmergency.AddAsync(debtorEmergency);
                        }
                        else
                        {

                            debtorEmergency = _mapper.Map<LoanApplicationIDEUpsertRequest, DebtorEmergency>(request);
                            debtorEmergency.Id = loanApplication.Id;
                            await _debtorEmergency.UpdateAsync(debtorEmergency);
                        }
                        #endregion
                        break;

                    case "informasi_fasilitas":
                        loanApplication.DecisionMakerId = request.DecisionMakerCode;
                        loanApplication = ClearLoanApplicationRelatives(loanApplication);
                        await _loanApplication.UpdateAsync(loanApplication);
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
        public static LoanApplication ClearLoanApplicationRelatives(LoanApplication loanApplication)
        {
            loanApplication.RfBookingBranch = null;
            loanApplication.RfBranch = null;
            loanApplication.RfBusinessCycle = null;
            loanApplication.RfOwnerCategory = null;
            loanApplication.RfProduct = null;
            loanApplication.RfSectorLBU3 = null;
            loanApplication.RfStage = null;
            loanApplication.DecisionMaker = null;
            loanApplication.LoanApplicationFacilities = null;
            loanApplication.Debtor = null;
            loanApplication.DebtorCompany = null;
            loanApplication.LoanApplicationCreditScoring = null;
            loanApplication.LoanApplicationCollaterals = null;
            loanApplication.LoanApplicationFieldSurvey = null;
            loanApplication.LoanApplicationKeyPersons = null;
            loanApplication.LoanApplicationRAC = null;
            loanApplication.LoanApplicationStages = null;
            loanApplication.LoanApplicationVerificationBusiness = null;
            loanApplication.LoanApplicationVerificationCycle = null;
            loanApplication.LoanApplicationVerificationNeed = null;
            loanApplication.Prospect = null;

            return loanApplication;
        }
    }
}
