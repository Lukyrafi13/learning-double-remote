using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.LoanApplicationKeyPersons;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.LoanApplicationVerificationCycleDetails.Commands
{
    public class DeleteLoanApplicationVerificationCycleDetailCommand : LoanApplicationKeyPersonDeleteRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class DeleteLoanApplicationVerificationCycleDetailCommandHandler : IRequestHandler<DeleteLoanApplicationVerificationCycleDetailCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplicationVerificationCycleDetail> _core;
        private readonly IMapper _mapper;

        public DeleteLoanApplicationVerificationCycleDetailCommandHandler(IGenericRepositoryAsync<LoanApplicationVerificationCycleDetail> core, IMapper mapper)
        {
            _core = core;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(DeleteLoanApplicationVerificationCycleDetailCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var loanApplicationVerificationCycleDetail = await _core.GetByPredicate(x => x.Id == request.Id);
                await _core.DeleteAsync(loanApplicationVerificationCycleDetail);
                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnException(ex);
            }

        }
    }
}
