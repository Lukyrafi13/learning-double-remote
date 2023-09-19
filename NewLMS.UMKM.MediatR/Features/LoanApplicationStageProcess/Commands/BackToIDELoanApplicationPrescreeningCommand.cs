using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.LoanApplicationStageProcess;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.LoanApplicationStageProcess.Commands
{
    public class BackToIDELoanApplicationPrescreeningCommand : LoanApplicationProcessStageRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class BackToIDELoanApplicationPrescreeningCommandHandler : IRequestHandler<BackToIDELoanApplicationPrescreeningCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplication> _loanApplication;
        private readonly IMapper _mapper;

        public BackToIDELoanApplicationPrescreeningCommandHandler(
            IGenericRepositoryAsync<LoanApplication> loanApplication,
            IMapper mapper)
        {
            _loanApplication = loanApplication;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(BackToIDELoanApplicationPrescreeningCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var loanApplicationData = await _loanApplication.GetByPredicate(x => x.Id == request.LoanApplicationGuid);
                if (loanApplicationData != null)
                {
                    loanApplicationData.StageId = LMSUMKMStages.InitialData.StageId;
                    await _loanApplication.UpdateAsync(loanApplicationData);
                }
                else
                {
                    return ServiceResponse<Unit>.Return404("Data Tidak Ditemukan, Gagal Proses Stage");
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
