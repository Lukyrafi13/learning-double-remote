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
    public class PutLoanApplicationVerificationCycleDetailCommand : LoanApplicationVerificationCycleDetailPutRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class PutLoanApplicationVerificationCycleDetailCommandHandler : IRequestHandler<PutLoanApplicationVerificationCycleDetailCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplicationVerificationCycleDetail> _core;
        private readonly IMapper _mapper;

        public PutLoanApplicationVerificationCycleDetailCommandHandler(IGenericRepositoryAsync<LoanApplicationVerificationCycleDetail> core, IMapper mapper)
        {
            _core = core;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(PutLoanApplicationVerificationCycleDetailCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var loanApplicationVerificationCycleDetail = await _core.GetByIdAsync(request.Id, "Id");
                if (loanApplicationVerificationCycleDetail != null)
                {
                    _mapper.Map(request, loanApplicationVerificationCycleDetail);
                    await _core.UpdateAsync(loanApplicationVerificationCycleDetail);
                }
                else
                {
                    return ServiceResponse<Unit>.Return404("Data LoanApplicationVerificationCycleDetail Not Found");
                }

                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);

            }
            catch (Exception ex)
            {

                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
