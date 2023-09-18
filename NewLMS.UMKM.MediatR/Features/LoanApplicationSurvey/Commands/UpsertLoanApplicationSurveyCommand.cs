using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.LoanApplicationSurvey;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Domain.Context;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.MediatR.Helpers;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.LoanApplicationSurvey.Commands
{
    public class UpsertLoanApplicationSurveyCommand : LoanApplicationSurveyUpsertRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class UpsertLoanApplicationSurveyCommandHandler : IRequestHandler<UpsertLoanApplicationSurveyCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplication> _loanApplication;
        private readonly IGenericRepositoryAsync<LoanApplicationFieldSurvey> _loanApplicationFieldSurvey;
        private readonly UserContext _userContext;
        private readonly IMapper _mapper;

        public UpsertLoanApplicationSurveyCommandHandler(
            IGenericRepositoryAsync<LoanApplication> loanApplication,
            IGenericRepositoryAsync<LoanApplicationFieldSurvey> loanApplicationFieldSurvey,
            IMapper mapper,
            UserContext userContext)
        {
            _loanApplication = loanApplication;
            _loanApplicationFieldSurvey = loanApplicationFieldSurvey;
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
