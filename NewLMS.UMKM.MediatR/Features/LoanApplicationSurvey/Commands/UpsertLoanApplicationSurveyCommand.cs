using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.LoanApplicationSurvey;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Domain.Context;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.MediatR.Helpers;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.LoanApplicationSurvey.Commands
{
    public class UpsertLoanApplicationSurveyCommand : LoanApplicationSurveyUpsertRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class UpsertLoanApplicationSurveyCommandHandler : IRequestHandler<UpsertLoanApplicationSurveyCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplication> _loanApplication;
        private readonly IGenericRepositoryAsync<LoanApplicationFieldSurvey> _loanApplicationFieldSurvey;
        private readonly IGenericRepositoryAsync<LoanApplicationVerificationBusiness> _loanApplicationVerificationBusiness;
        private readonly IGenericRepositoryAsync<LoanApplicationVerificationCycle> _loanApplicationVerificationCycle;
        private readonly UserContext _userContext;
        private readonly IMapper _mapper;

        public UpsertLoanApplicationSurveyCommandHandler(
            IGenericRepositoryAsync<LoanApplication> loanApplication,
            IGenericRepositoryAsync<LoanApplicationFieldSurvey> loanApplicationFieldSurvey,
            IGenericRepositoryAsync<LoanApplicationVerificationBusiness> loanApplicationVerificationBusiness,
            IGenericRepositoryAsync<LoanApplicationVerificationCycle> loanApplicationVerificationCycle,
            IMapper mapper,
            UserContext userContext)
        {
            _loanApplication = loanApplication;
            _loanApplicationFieldSurvey = loanApplicationFieldSurvey;
            _loanApplicationVerificationBusiness = loanApplicationVerificationBusiness;
            _loanApplicationVerificationCycle = loanApplicationVerificationCycle;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<ServiceResponse<Unit>> Handle(UpsertLoanApplicationSurveyCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _userContext.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var includes = IncludesGenerator.GetLoanApplicationIncludes(request.Tab);
                var loanApplication = await _loanApplication.GetByIdAsync(request.LoanApplicationGuid, "Id", includes.ToArray());
                var loanApplicationFieldSurvey = await _loanApplicationFieldSurvey.GetByPredicate(x => x.Id == request.LoanApplicationGuid);
                var loanApplicationVerificationBusiness = await _loanApplicationVerificationBusiness.GetByPredicate(x => x.Id == request.LoanApplicationGuid);
                var loanApplicationVerificationCycle = await _loanApplicationVerificationCycle.GetByPredicate(x => x.Id == request.LoanApplicationGuid);

                var debtorCompanyId = loanApplication.DebtorCompanyId;

                switch (request.Tab)
                {
                    case "survey_ots":
                        if(loanApplicationFieldSurvey != null)
                        {
                            loanApplicationFieldSurvey = _mapper.Map(request.FieldSurvey, loanApplicationFieldSurvey);
                            await _loanApplicationFieldSurvey.UpdateAsync(loanApplicationFieldSurvey);
                        }
                        if (loanApplicationFieldSurvey == null)
                        {
                            loanApplicationFieldSurvey = _mapper.Map(request.FieldSurvey, loanApplicationFieldSurvey);
                            loanApplicationFieldSurvey.Id = request.LoanApplicationGuid;
                            await _loanApplicationFieldSurvey.AddAsync(loanApplicationFieldSurvey);
                        }
                        break;

                    case "survey_verifikasi_business":
                        if (loanApplicationVerificationBusiness != null)
                        {
                            loanApplicationVerificationBusiness = _mapper.Map(request.LoanApplicationVerificationBusiness, loanApplicationVerificationBusiness);
                            await _loanApplicationVerificationBusiness.UpdateAsync(loanApplicationVerificationBusiness);
                        }
                        if (loanApplicationVerificationBusiness == null)
                        {
                            loanApplicationVerificationBusiness = _mapper.Map(request.LoanApplicationVerificationBusiness, loanApplicationVerificationBusiness);
                            loanApplicationVerificationBusiness.Id = request.LoanApplicationGuid;
                            await _loanApplicationVerificationBusiness.AddAsync(loanApplicationVerificationBusiness);
                        }
                        break;

                    case "survey_verifikasi_siklus":
                        if (loanApplicationVerificationCycle != null)
                        {
                            loanApplicationVerificationCycle = _mapper.Map(request.LoanApplicationVerificationCycle, loanApplicationVerificationCycle);
                            await _loanApplicationVerificationCycle.UpdateAsync(loanApplicationVerificationCycle);
                        }
                        if (loanApplicationVerificationCycle == null)
                        {
                            loanApplicationVerificationCycle = _mapper.Map(request.LoanApplicationVerificationCycle, loanApplicationVerificationCycle);
                            loanApplicationVerificationCycle.Id = request.LoanApplicationGuid;
                            await _loanApplicationVerificationCycle.AddAsync(loanApplicationVerificationCycle);
                        }
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
