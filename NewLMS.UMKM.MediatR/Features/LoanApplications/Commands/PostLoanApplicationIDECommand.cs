using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.LoanApplications;
using NewLMS.UMKM.Data.Dto.RfZipCodes;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.MediatR.Features.Prospects.Queries;
using NewLMS.UMKM.MediatR.Features.RfZipCodes.Commands;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IMapper _mapper;

        public PostLoanApplicationIDECommandHandler(
            IGenericRepositoryAsync<LoanApplication> loanApplication,
            IGenericRepositoryAsync<LoanApplicationCreditScoring> loanApplicationCreditScoring,
            IMapper mapper)
        {
            _loanApplication = loanApplication;
            _loanApplicationCreditScoring = loanApplicationCreditScoring;
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

                            //Credit Scoring
                            var creditScoringData = await _loanApplicationCreditScoring.GetByPredicate(
                                x => x.Id == request.Id);

                            if (creditScoringData == null)
                            {
                                var newCreditScoringData = new LoanApplicationCreditScoring
                                {
                                    Id = request.Id,
                                    ScoResidentialReputationId = request.CreditScoring.ScoResidentialReputationId,
                                    ScoBankRelationId = request.CreditScoring.ScoBankRelationId,
                                    ScoBJBCreditHistoryId = request.CreditScoring.ScoBJBCreditHistoryId,
                                    ScoTransacMethodId = request.CreditScoring.ScoTransacMethodId,
                                    ScoAverageAccBalanceId = request.CreditScoring.ScoAverageAccBalanceId,
                                    ScoNeedLevelId = request.CreditScoring.ScoNeedLevelId,
                                    ScoFinanceManagerId = request.CreditScoring.ScoFinanceManagerId,
                                    ScoBusinesLocationId = request.CreditScoring.ScoBusinesLocationId,
                                    ScoOtherPartyDebtId = request.CreditScoring.ScoOtherPartyDebtId,
                                    ScoCollateralId = request.CreditScoring.ScoCollateralId,
                                };

                                await _loanApplicationCreditScoring.AddAsync(newCreditScoringData);
                            }
                            else
                            {
                                creditScoringData.ScoResidentialReputationId = request.CreditScoring.ScoResidentialReputationId;
                                creditScoringData.ScoBankRelationId = request.CreditScoring.ScoBankRelationId;
                                creditScoringData.ScoBJBCreditHistoryId = request.CreditScoring.ScoBJBCreditHistoryId;
                                creditScoringData.ScoTransacMethodId = request.CreditScoring.ScoTransacMethodId;
                                creditScoringData.ScoAverageAccBalanceId = request.CreditScoring.ScoAverageAccBalanceId;
                                creditScoringData.ScoNeedLevelId = request.CreditScoring.ScoNeedLevelId;
                                creditScoringData.ScoFinanceManagerId = request.CreditScoring.ScoFinanceManagerId;
                                creditScoringData.ScoBusinesLocationId = request.CreditScoring.ScoBusinesLocationId;
                                creditScoringData.ScoOtherPartyDebtId = request.CreditScoring.ScoOtherPartyDebtId;
                                creditScoringData.ScoCollateralId = request.CreditScoring.ScoCollateralId;
                            
                                await _loanApplicationCreditScoring.UpdateAsync(creditScoringData);
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
