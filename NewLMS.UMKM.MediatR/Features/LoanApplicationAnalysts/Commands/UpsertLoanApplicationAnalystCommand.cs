using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.LoanApplicationAnalysts;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Domain.Context;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.MediatR.Helpers;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.LoanApplicationAnalysts.Commands
{
    public class UpsertLoanApplicationAnalystCommand : LoanApplicationAnalystRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class UpsertLoanApplicationAnalystCommandHandler : IRequestHandler<UpsertLoanApplicationAnalystCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplication> _loanApplication;
        private readonly IGenericRepositoryAsync<LoanApplicationBusinessInformation> _loanApplicationBusinessInformation;
        private readonly UserContext _userContext;
        private readonly IMapper _mapper;

        public UpsertLoanApplicationAnalystCommandHandler(
            IGenericRepositoryAsync<LoanApplication> loanApplication,
            IGenericRepositoryAsync<LoanApplicationBusinessInformation> loanApplicationBusinessInformation,
            IMapper mapper,
            UserContext userContext)
        {
            _loanApplication = loanApplication;
            _loanApplicationBusinessInformation = loanApplicationBusinessInformation;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<ServiceResponse<Unit>> Handle(UpsertLoanApplicationAnalystCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _userContext.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var includes = IncludesGenerator.GetLoanApplicationIncludes(request.Tab);
                var loanApplication = await _loanApplication.GetByIdAsync(request.LoanApplicationGuid, "Id", includes.ToArray());
                var loanApplicationBusinessInformation = await _loanApplicationBusinessInformation.GetByPredicate(x => x.LoanApplicationId == request.LoanApplicationGuid);

                switch (request.Tab)
                {
                    case "analisa_informasi_usaha":
                        if (loanApplicationBusinessInformation != null)
                        {
                            loanApplicationBusinessInformation = _mapper.Map(request.LoanApplicationBusinessInformation, loanApplicationBusinessInformation);
                            await _loanApplicationBusinessInformation.UpdateAsync(loanApplicationBusinessInformation);
                        }
                        if (loanApplicationBusinessInformation == null)
                        {
                            loanApplicationBusinessInformation = _mapper.Map(request.LoanApplicationBusinessInformation, loanApplicationBusinessInformation);
                            loanApplicationBusinessInformation.LoanApplicationId = request.LoanApplicationGuid;
                            await _loanApplicationBusinessInformation.AddAsync(loanApplicationBusinessInformation);
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
