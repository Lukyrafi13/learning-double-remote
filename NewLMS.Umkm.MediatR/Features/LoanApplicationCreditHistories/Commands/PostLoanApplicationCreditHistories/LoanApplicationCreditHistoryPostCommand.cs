using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.LoanApplicationCreditHistory;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.LoanApplicationCreditHistories.Commands.PostLoanApplicationCreditHistories
{
    public class LoanApplicationCreditHistoryPostCommand : LoanApplicationCreditHistoryPostRequest, IRequest<ServiceResponse<Unit>>
    {
    }


    public class PostLoanApplicationCreditHistoryCommandHandler : IRequestHandler<LoanApplicationCreditHistoryPostCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplicationCreditHistory> _loanApplicationCreditHistory;
        private readonly IMapper _mapper;

        public PostLoanApplicationCreditHistoryCommandHandler(IGenericRepositoryAsync<LoanApplicationCreditHistory> loanApplicationCreditHistory, IMapper mapper)
        {
            _loanApplicationCreditHistory = loanApplicationCreditHistory;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(LoanApplicationCreditHistoryPostCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var LoanApplicationCreditHistory = _mapper.Map<LoanApplicationCreditHistory>(request);
                LoanApplicationCreditHistory.IsRobo = false;

                await _loanApplicationCreditHistory.AddAsync(LoanApplicationCreditHistory);
                return ServiceResponse<Unit>.ReturnResultWith201(Unit.Value);
            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
