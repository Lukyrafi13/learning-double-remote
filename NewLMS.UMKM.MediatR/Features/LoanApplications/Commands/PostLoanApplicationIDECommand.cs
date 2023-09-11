using AutoMapper;
using DocumentFormat.OpenXml.Bibliography;
using MediatR;
using NewLMS.UMKM.Data.Dto.LoanApplications;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Data.Enums;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.LoanApplications.Commands
{
    public class PostLoanApplicationIDECommand : LoanApplicationIDEPostRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class PostLoanApplicationIDECommandHandler : IRequestHandler<PostLoanApplicationIDECommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplication> _loanApplication;
        private readonly IGenericRepositoryAsync<LoanApplicationCreditScoring> _loanApplicationCreditScoring;
        private readonly IGenericRepositoryAsync<Debtor> _debtor;
        private readonly IGenericRepositoryAsync<DebtorCouple> _debtorCouple;
        private readonly IGenericRepositoryAsync<DebtorCompany> _debtorCompany;
        private readonly IGenericRepositoryAsync<DebtorCompanyLegal> _debtorCompanyLegal;
        private readonly IGenericRepositoryAsync<DebtorEmergency> _debtorEmergency;
        private readonly IMapper _mapper;

        public PostLoanApplicationIDECommandHandler(
            IGenericRepositoryAsync<LoanApplication> loanApplication,
            IGenericRepositoryAsync<LoanApplicationCreditScoring> loanApplicationCreditScoring,
            IGenericRepositoryAsync<Debtor> debtor,
            IGenericRepositoryAsync<DebtorCouple> debtorCouple,
            IGenericRepositoryAsync<DebtorCompany> debtorCompany,
            IGenericRepositoryAsync<DebtorCompanyLegal> debtorCompanyLegal,
            IGenericRepositoryAsync<DebtorEmergency> debtorEmergency,
            IMapper mapper)
        {
            _loanApplication = loanApplication;
            _loanApplicationCreditScoring = loanApplicationCreditScoring;
            _debtor = debtor;
            _debtorCouple = debtorCouple;
            _debtorCompany = debtorCompany;
            _debtorCompanyLegal = debtorCompanyLegal;
            _debtorEmergency = debtorEmergency;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(PostLoanApplicationIDECommand request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _loanApplication.GetByPredicate(x => x.Id == request.Id);
                if (data == null)
                {
                    return ServiceResponse<Unit>.Return404("Data Not Found");
                }
                else
                {
                    switch (request.Tab)
                    {
                        case "initial_data_entry":
                            //Update Loan Application Data
                            data.ProductId = request.InitialData.ProductId;
                            data.OwnerCategoryId = request.InitialData.OwnerCategoryId;
                            data.IsBusinessCycle = request.InitialData.IsBusinessCycle;
                            data.BusinessCycleId = request.InitialData.BusinessCycleId;
                            data.BusinessCycleMonth = request.InitialData.BusinessCycleMonth;
                            data.BookingBranchId = request.InitialData.BookingBranchId;

                            await _loanApplication.UpdateAsync(data);

                            //Credit Scoring jika Tipe Debitur Perorangan
                            if (request.InitialData.OwnerCategoryId == 1)
                            {
                                var creditScoringData = await _loanApplicationCreditScoring.GetByPredicate(
                                x => x.Id == request.Id);

                                if (creditScoringData == null)
                                {
                                    var creditScoringNew = _mapper.Map<LoanApplicationCreditScoringPostRequest, LoanApplicationCreditScoring>(request.CreditScoring);
                                    creditScoringNew.Id = data.Id;
                                    await _loanApplicationCreditScoring.AddAsync(creditScoringNew);
                                }
                                else
                                {
                                    _mapper.Map(request.CreditScoring, creditScoringData);
                                    await _loanApplicationCreditScoring.UpdateAsync(creditScoringData);
                                }
                            }

                            //Perubahan dari Badan Usaha ke Perorangan
                            if (data.OwnerCategoryId == 2)
                            {
                                //Kosongkan Data Debitur
                                var debtorId = data.DebtorId;
                                data.DebtorId = null;
                                await _loanApplication.UpdateAsync(data);
                                var dataDebitur = await _debtor.GetByPredicate(x => x.Id == debtorId);
                                if (dataDebitur != null)
                                {
                                    await _debtor.DeleteAsync(dataDebitur);
                                }

                                //Kosongkan Credit Scoring
                                var dataCreditScoring = await _loanApplicationCreditScoring.GetByPredicate(x => x.Id == data.Id);
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


                                
                                data.DebtorCompanyId = debtorCompanyNewId;
                                await _loanApplication.UpdateAsync(data);
                            }

                            //Perubahan dari perorangan ke Badan Usaha
                            if(data.OwnerCategoryId == 1)
                            {
                                var debtorCompanyId = data.DebtorCompanyId;
                                data.DebtorCompanyId = null;
                                await _loanApplication.UpdateAsync(data);

                                //AddDebtor
                                var dataDebtorNewId = Guid.NewGuid();
                                var dataDebtorNew = new Debtor
                                {
                                    Id = dataDebtorNewId
                                };
                                await _debtor.AddAsync(dataDebtorNew);
                                data.DebtorId = dataDebtorNewId;
                                await _loanApplication.UpdateAsync(data);

                                //DebtorCompanyLegal
                                var debtorCompanyLegal = await _debtorCompanyLegal.GetByPredicate(x => x.Id == debtorCompanyId);
                                if (debtorCompanyLegal != null)
                                {
                                    await _debtorCompanyLegal.DeleteAsync(debtorCompanyLegal);
                                }
                                //DebtorCompany
                                var debtorCompany = await _debtorCompany.GetByPredicate(x => x.Id == debtorCompanyId);
                                if (debtorCompany != null)
                                {
                                    await _debtorCompany.DeleteAsync(debtorCompany);
                                }
                                    
                            }
                            

                            break;

                        case "data_permohonan":
                            
                            //Data Debtor
                            if(data.OwnerCategoryId == 1)//jika perorangan
                            {
                                //Update Debitur
                                var dataDebitur = await _debtor.GetByPredicate(x => x.Id == data.DebtorId);
                                if (dataDebitur != null)
                                {
                                    _mapper.Map(request.Debtor, dataDebitur);
                                    await _debtor.UpdateAsync(dataDebitur);
                                }
                                if(request.Debtor.MaritalStatusId == "01")
                                {
                                    var dataDebtorCouple = await _debtorCouple.GetByPredicate(x => x.Id == data.DebtorId);
                                    if(dataDebtorCouple != null)
                                    {
                                        _mapper.Map(request.Debtor.DebtorCouple, dataDebtorCouple);
                                        await _debtorCouple.UpdateAsync(dataDebtorCouple);
                                    }
                                    if(dataDebtorCouple == null)
                                    {
                                        var dataDebtorCoupleNew = _mapper.Map<DebtorCouplePostRequest, DebtorCouple>(request.Debtor.DebtorCouple);
                                        dataDebtorCoupleNew.Id = data.DebtorId?? Guid.Empty;
                                        await _debtorCouple.AddAsync(dataDebtorCoupleNew);
                                    }
                                }
                                if (request.Debtor.MaritalStatusId == "02" || request.Debtor.MaritalStatusId == "03")
                                {
                                    var dataDebtorCouple = await _debtorCouple.GetByPredicate(x => x.Id == data.DebtorId);
                                    if (dataDebtorCouple != null)
                                    {
                                        await _debtorCouple.DeleteAsync(dataDebtorCouple);
                                    }
                                }
                            }

                            //jika badan usaha
                            if (data.OwnerCategoryId == 2)
                            {
                                //Data DebtorCompany
                                var dataDebtorCompany = await _debtorCompany.GetByPredicate(x => x.Id == data.DebtorCompanyId);
                                if(dataDebtorCompany != null)
                                {
                                    //Update Debtor Company
                                    _mapper.Map(request.DebtorCompany, dataDebtorCompany);
                                    await _debtorCompany.UpdateAsync(dataDebtorCompany);

                                    //DebtorCompanyLegal
                                    var dataDebtorCompanyLegal = await _debtorCompanyLegal.GetByPredicate(x => x.Id == dataDebtorCompany.Id);
                                    if (dataDebtorCompanyLegal != null)
                                    {
                                        //Update Debtor Company Legal
                                        _mapper.Map(request.DebtorCompanyLegal, dataDebtorCompanyLegal);
                                        await _debtorCompanyLegal.UpdateAsync(dataDebtorCompanyLegal);
                                    }
                                    if (dataDebtorCompanyLegal == null) 
                                    {
                                        //CompanyLegalNew
                                        var dataDebtorComapanyLegalNew = _mapper.Map<DebtorCompanyLegalPostRequest, DebtorCompanyLegal>(request.DebtorCompanyLegal);
                                        dataDebtorComapanyLegalNew.Id = dataDebtorCompany.Id;
                                        await _debtorCompanyLegal.AddAsync(dataDebtorComapanyLegalNew);
                                    }
                                }
                            }

                            //Data EmergencyContact
                            var dataDebtorEmergency = await _debtorEmergency.GetByPredicate(x => x.Id == data.DebtorEmergencyId);
                            if (dataDebtorEmergency != null)
                            {
                                //Update Emergency Contact
                                _mapper.Map(request.DebtorEmergency, dataDebtorEmergency);
                                await _debtorEmergency.UpdateAsync(dataDebtorEmergency);
                            }
                            if (dataDebtorEmergency == null)
                            {
                                //Add Emergency Contact
                                var debtorEmergencyNew = _mapper.Map<DebtorEmergencyPostRequest, DebtorEmergency>(request.DebtorEmergency);
                                var debtorEmergencyNewId = Guid.NewGuid();
                                debtorEmergencyNew.Id = debtorEmergencyNewId;
                                await _debtorEmergency.AddAsync(debtorEmergencyNew);

                                data.DebtorEmergencyId = debtorEmergencyNewId;

                            }

                            await _loanApplication.UpdateAsync(data);
                            break;

                        default:
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                return ServiceResponse<Unit>.ReturnException(ex);
            }
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}
