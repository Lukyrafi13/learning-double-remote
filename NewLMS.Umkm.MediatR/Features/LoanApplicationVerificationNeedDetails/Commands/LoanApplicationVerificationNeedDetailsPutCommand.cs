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
    public class LoanApplicationVerificationNeedDetailsPutCommand : LoanApplicationVerificationNeedDetailPutRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class LoanApplicationVerificationNeedDetailsPutCommandHandler : IRequestHandler<LoanApplicationVerificationNeedDetailsPutCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplicationVerificationNeedDetail> _core;
        private readonly IMapper _mapper;

        public LoanApplicationVerificationNeedDetailsPutCommandHandler(IGenericRepositoryAsync<LoanApplicationVerificationNeedDetail> core, IMapper mapper)
        {
            _core = core;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(LoanApplicationVerificationNeedDetailsPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var loanApplicationVerificationNeedDetail = await _core.GetByIdAsync(request.Id, "Id");
                if (loanApplicationVerificationNeedDetail != null)
                {
                    _mapper.Map(request, loanApplicationVerificationNeedDetail);
                    await _core.UpdateAsync(loanApplicationVerificationNeedDetail);
                }
                else
                {
                    return ServiceResponse<Unit>.Return404("Data LoanApplicationVerificationNeedDetail Not Found");
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
