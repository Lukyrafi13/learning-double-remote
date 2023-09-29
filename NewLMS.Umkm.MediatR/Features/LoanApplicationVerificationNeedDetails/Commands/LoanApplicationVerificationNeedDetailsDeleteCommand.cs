using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.LoanApplicationVerificationNeedDetails;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.LoanApplicationVerificationNeedDetails.Commands
{
    public class LoanApplicationVerificationNeedDetailsDeleteCommand : LoanApplicationVerificationNeedDetailDeleteRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class LoanApplicationVerificationNeedDetailsDeleteCommandHandler : IRequestHandler<LoanApplicationVerificationNeedDetailsDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplicationVerificationNeedDetail> _core;
        private readonly IMapper _mapper;

        public LoanApplicationVerificationNeedDetailsDeleteCommandHandler(IGenericRepositoryAsync<LoanApplicationVerificationNeedDetail> core, IMapper mapper)
        {
            _core = core;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(LoanApplicationVerificationNeedDetailsDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var loanApplicationVerificationNeedDetail = await _core.GetByPredicate(x => x.Id == request.Id);
                await _core.DeleteAsync(loanApplicationVerificationNeedDetail);
                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnException(ex);
            }

        }
    }
}
