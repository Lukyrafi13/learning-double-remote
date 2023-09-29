using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.LoanApplicationVerificationNeedDetails;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.LoanApplicationVerificationNeedDetails.Commands
{
    public class LoanApplicationVerificationNeedDetailsPostCommand : LoanApplicationVerificationNeedDetailPostRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class LoanApplicationVerificationNeedDetailsPostCommandHandler : IRequestHandler<LoanApplicationVerificationNeedDetailsPostCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplicationVerificationNeedDetail> _core;
        private readonly IMapper _mapper;

        public LoanApplicationVerificationNeedDetailsPostCommandHandler(IGenericRepositoryAsync<LoanApplicationVerificationNeedDetail> core, IMapper mapper)
        {
            _core = core;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(LoanApplicationVerificationNeedDetailsPostCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var loanApplicationVerificationNeedDetail = _mapper.Map<LoanApplicationVerificationNeedDetail>(request);
                await _core.AddAsync(loanApplicationVerificationNeedDetail);

                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);

            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }

        }
    }
}
