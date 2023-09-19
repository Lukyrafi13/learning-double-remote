using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.LoanApplicationVerificationCycleDetails;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.LoanApplicationVerificationCycleDetails.Commands
{
    public class PostLoanApplicationVerificationCycleDetailCommand : LoanApplicationVerificationCycleDetailPostRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class PostLoanApplicationVerificationCycleDetailCommandHandler : IRequestHandler<PostLoanApplicationVerificationCycleDetailCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplicationVerificationCycleDetail> _core;
        private readonly IMapper _mapper;

        public PostLoanApplicationVerificationCycleDetailCommandHandler(IGenericRepositoryAsync<LoanApplicationVerificationCycleDetail> core, IMapper mapper)
        {
            _core = core;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(PostLoanApplicationVerificationCycleDetailCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var loanApplicationVerificationCycleDetail = _mapper.Map<LoanApplicationVerificationCycleDetail>(request);
                await _core.AddAsync(loanApplicationVerificationCycleDetail);

                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);

            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }

        }
    }
}
