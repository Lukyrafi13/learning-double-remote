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
    public class ProcessLoanApplicationSurvey : LoanApplicationProcessRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class ProcessLoanApplicationSurveyHandler : IRequestHandler<ProcessLoanApplicationSurvey, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplication> _loanApplication;
        private readonly IMapper _mapper;

        public ProcessLoanApplicationSurveyHandler(
            IGenericRepositoryAsync<LoanApplication> loanApplication,
            IMapper mapper)
        {
            _loanApplication = loanApplication;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(ProcessLoanApplicationSurvey request, CancellationToken cancellationToken)
        {
            try
            {
                var loanApplication = await _loanApplication.GetByPredicate(x => x.Id == request.LoanApplicationGuid);
                if (loanApplication != null)
                {
                    loanApplication.StageId = LMSUMKMStages.Analisa.StageId;
                    await _loanApplication.UpdateAsync(loanApplication);
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
