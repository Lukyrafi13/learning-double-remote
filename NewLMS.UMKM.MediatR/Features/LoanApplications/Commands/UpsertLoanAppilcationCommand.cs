﻿using AutoMapper;
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
                var ownerCategory = await _parameterDetail.GetByIdAsync(request.OwnerCategoryId, "ParameterDetailId");


                await _loanApplication.UpdateAsync(loanApplication);

                switch (request.Tab)
                {
                    case "initial_data_entry":

                        loanApplication = _mapper.Map<LoanApplicationIDEUpsertRequest, LoanApplication>(request);
                        var dataFasilitas = request.InitialDataEntry.DataFasilitas;

                        if (ownerCategory.Code == "001") // Perorangan
                        {
                            var creditScoring = loanApplication.LoanApplicationCreditScoring;

                            if (creditScoring == null)
                            {
                                creditScoring = _mapper.Map<LoanApplicationIDEUpsertRequest, LoanApplicationCreditScoring>(request, creditScoring);
                                creditScoring.Id = loanApplication.Id;
                                await _loanApplicationCreditScoring.AddAsync(creditScoring);
                            }
                            else
                            {
                                creditScoring = _mapper.Map<LoanApplicationIDEUpsertRequest, LoanApplicationCreditScoring>(request);
                                creditScoring.Id = loanApplication.Id;
                                await _loanApplicationCreditScoring.UpdateAsync(creditScoring);
                            }

                            //Perubahan dari Badan Usaha ke Perorangan
                            if (loanApplication.OwnerCategoryId == 2)
                            {
                                //Kosongkan Data Debitur
                                var debtorId = loanApplication.DebtorId;
                                loanApplication.DebtorId = null;
                                await _loanApplication.UpdateAsync(loanApplication);
                                var dataDebitur = await _debtor.GetByPredicate(x => x.Id == debtorId);
                                if (dataDebitur != null)
                                {
                                    await _debtor.DeleteAsync(dataDebitur);
                                }

                                //Kosongkan Credit Scoring
                                var dataCreditScoring = await _loanApplicationCreditScoring.GetByPredicate(x => x.Id == loanApplication.Id);
                                if (dataCreditScoring != null)
                                {
                                    await _loanApplicationCreditScoring.DeleteAsync(dataCreditScoring);
                                }

                                //AddDebtorCompany
                                var debtorCompanyNewId = Guid.NewGuid();
                                var dataDebtorComapanyNew = new DebtorCompany
                                {
                                    Id = debtorCompanyNewId
                                };
                                await _debtorCompany.AddAsync(dataDebtorComapanyNew);



                                loanApplication.DebtorCompanyId = debtorCompanyNewId;
                                await _loanApplication.UpdateAsync(loanApplication);
                            }

                            //Perubahan dari perorangan ke Badan Usaha
                            if (loanApplication.OwnerCategoryId == 1)
                            {
                                var debtorCompanyId = loanApplication.DebtorCompanyId;
                                loanApplication.DebtorCompanyId = null;
                                await _loanApplication.UpdateAsync(loanApplication);

                                //AddDebtor
                                var dataDebtorNewId = Guid.NewGuid();
                                var dataDebtorNew = new Debtor
                                {
                                    Id = dataDebtorNewId
                                };
                                await _debtor.AddAsync(dataDebtorNew);
                                loanApplication.DebtorId = dataDebtorNewId;
                                await _loanApplication.UpdateAsync(loanApplication);

                                //DebtorCompanyLegal
                                var debtorCompanyLegal = await _debtorCompanyLegal.GetByPredicate(x => x.Id == debtorCompanyId);
                                if (debtorCompanyLegal != null)
                                {
                                    await _debtorCompanyLegal.DeleteAsync(debtorCompanyLegal);
                                }
                                //DebtorCompany
                                var debtorCompanyData = await _debtorCompany.GetByPredicate(x => x.Id == debtorCompanyId);
                                if (debtorCompanyData != null)
                                {
                                    await _debtorCompany.DeleteAsync(debtorCompanyData);
                                }
                            }
                        }
                        break;

                    case "data_permohonan":
                        #region Debtor / DebtorCompany
                        var debtor = loanApplication.Debtor;
                        var debtorCompany = loanApplication.DebtorCompany;

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
                            var debtorCouple = debtor.DebtorCouple;

                            if (maritalStatus.MaritalCode == "01") // Menikah
                            {
                                if (debtorCouple == null)
                                {
                                    debtorCouple = _mapper.Map<LoanApplicationIDEUpsertRequest, DebtorCouple>(request, debtorCouple);
                                    debtorCouple.Id = debtor.Id;
                                    await _debtorCouple.AddAsync(debtorCouple);
                                }
                                else
                                {
                                    debtorCouple = _mapper.Map<LoanApplicationIDEUpsertRequest, DebtorCouple>(request);
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
                            }
                            else
                            {
                                debtorCompany = _mapper.Map<LoanApplicationIDEUpsertRequest, DebtorCompany>(request);
                                await _debtorCompany.UpdateAsync(debtorCompany);
                            }

                            var debtorCompanyLegal = debtorCompany.DebtorCompanyLegal;
                            if (debtorCompanyLegal.Id != Guid.Empty)
                            {
                                debtorCompanyLegal = _mapper.Map<LoanApplicationIDEUpsertRequest, DebtorCompanyLegal>(request, debtorCompanyLegal);
                                debtorCompanyLegal.Id = Guid.NewGuid();
                                await _debtorCompanyLegal.AddAsync(debtorCompanyLegal);
                            }
                            else
                            {
                                debtorCompanyLegal = _mapper.Map<LoanApplicationIDEUpsertRequest, DebtorCompanyLegal>(request);
                                await _debtorCompanyLegal.UpdateAsync(debtorCompanyLegal);
                            }
                        }
                        #endregion

                        #region DebtorEmergency
                        var debtorEmergency = loanApplication.DebtorEmergency;

                        if (debtorEmergency == null)
                        {
                            debtorEmergency = _mapper.Map<LoanApplicationIDEUpsertRequest, DebtorEmergency>(request, debtorEmergency);
                            debtorEmergency.Id = loanApplication.Id;
                            await _debtorEmergency.AddAsync(debtorEmergency);
                        }
                        else
                        {

                            debtorEmergency = _mapper.Map<LoanApplicationIDEUpsertRequest, DebtorEmergency>(request);
                            await _debtorEmergency.UpdateAsync(debtorEmergency);
                        }
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