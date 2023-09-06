using AutoMapper;
using DocumentFormat.OpenXml.Bibliography;
using MediatR;
using NewLMS.UMKM.Data.Dto.LoanApplications;
using NewLMS.UMKM.Data.Dto.RfZipCodes;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Data.Enums;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.MediatR.Features.Prospects.Queries;
using NewLMS.UMKM.MediatR.Features.RfZipCodes.Commands;
using NewLMS.UMKM.Repository.GenericRepository;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Principal;
using System.Text;
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
        private readonly IGenericRepositoryAsync<DebtorCompany> _debtorCompany;
        private readonly IGenericRepositoryAsync<DebtorCompanyLegal> _debtorCompanyLegal;
        private readonly IGenericRepositoryAsync<DebtorEmergency> _debtorEmergency;
        private readonly IMapper _mapper;

        public PostLoanApplicationIDECommandHandler(
            IGenericRepositoryAsync<LoanApplication> loanApplication,
            IGenericRepositoryAsync<LoanApplicationCreditScoring> loanApplicationCreditScoring,
            IGenericRepositoryAsync<Debtor> debtor,
            IGenericRepositoryAsync<DebtorCompany> debtorCompany,
            IGenericRepositoryAsync<DebtorCompanyLegal> debtorCompanyLegal,
            IGenericRepositoryAsync<DebtorEmergency> debtorEmergency,
            IMapper mapper)
        {
            _loanApplication = loanApplication;
            _loanApplicationCreditScoring = loanApplicationCreditScoring;
            _debtor = debtor;
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
                            if(data.OwnerCategoryId == 1 || request.InitialData.OwnerCategoryId == 1)
                            {
                                var creditScoringData = await _loanApplicationCreditScoring.GetByPredicate(
                                x => x.Id == request.Id);

                                if (creditScoringData == null)
                                {
                                    var creditScoringNew = _mapper.Map<LoanApplicationCreditScoringPostRequest, LoanApplicationCreditScoring>(request.CreditScoring);
                                    creditScoringNew.Id = Guid.NewGuid();
                                    await _loanApplicationCreditScoring.AddAsync(creditScoringNew);
                                }
                                else
                                {
                                    _mapper.Map(request.CreditScoring, creditScoringData);
                                    await _loanApplicationCreditScoring.UpdateAsync(creditScoringData);
                                }
                            }
                            break;

                        case "data_permohonan":
                            
                            //Data Debtor
                            var dataDebitur = await _debtor.GetByPredicate(x => x.Id == data.DebtorId);
                            if (dataDebitur == null)
                            {
                                var dataDebiturNew = _mapper.Map<DebtorPostRequest, Debtor>(request.Debtor);
                                dataDebiturNew.Id = Guid.NewGuid();

                                await _debtor.AddAsync(dataDebiturNew);
                            }
                            else
                            {
                                _mapper.Map(request.Debtor, dataDebitur);
                                await _debtor.UpdateAsync(dataDebitur);
                            }

                            //Data DebtorCompany
                            var debtorCompanyNewId = Guid.NewGuid();
                            var dataDebtorCompany = await _debtorCompany.GetByPredicate(x => x.Id == data.DebtorCompanyId);
                            if (dataDebtorCompany == null)
                            {
                                var dataDebtorCompanyNew = _mapper.Map<DebtorCompanyPostRequest, DebtorCompany>(request.DebtorCompany);
                                dataDebtorCompanyNew.Id = debtorCompanyNewId;

                                await _debtorCompany.AddAsync(dataDebtorCompanyNew);
                            }
                            else
                            {
                                _mapper.Map(request.DebtorCompany, dataDebitur);
                                await _debtor.UpdateAsync(dataDebitur);
                            }

                            //DebtorCompanyLegal
                            var dataDebtorCompanyLegal = await _debtorCompanyLegal.GetByPredicate(x => x.Id == data.DebtorCompanyId);
                            if (dataDebtorCompanyLegal == null)
                            {
                                var dataDebtorComapanyLegalNew = _mapper.Map<DebtorCompanyLegalPostRequest, DebtorCompanyLegal>(request.DebtorCompanyLegal);
                                dataDebtorComapanyLegalNew.Id = debtorCompanyNewId;

                                await _debtorCompanyLegal.AddAsync(dataDebtorComapanyLegalNew);
                            }
                            else
                            {
                                _mapper.Map(request.DebtorCompanyLegal, dataDebtorCompanyLegal);
                                await _debtorCompanyLegal.UpdateAsync(dataDebtorCompanyLegal);
                            }

                            //Data EmergencyContact
                            var dataDebtorEmergency = await _debtorEmergency.GetByPredicate(x => x.Id == data.DebtorEmergencyId);
                            if (dataDebtorEmergency == null)
                            {
                                var debtorEmergencyNew = _mapper.Map<DebtorEmergencyPostRequest, DebtorEmergency>(request.DebtorEmergency);
                                debtorEmergencyNew.Id = Guid.NewGuid();

                                await _debtorEmergency.AddAsync(debtorEmergencyNew);
                            }
                            else
                            {
                                _mapper.Map(request.DebtorEmergency, dataDebtorEmergency);
                                await _debtorEmergency.UpdateAsync(dataDebtorEmergency);
                            }

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
