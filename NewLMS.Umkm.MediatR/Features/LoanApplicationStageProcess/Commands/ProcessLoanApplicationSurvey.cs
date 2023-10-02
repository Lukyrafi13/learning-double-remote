using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.LoanApplicationStageProcess;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.LoanApplicationStageProcess.Commands
{
    public class ProcessLoanApplicationSurvey : LoanApplicationProcessStageRequest, IRequest<ServiceResponse<Unit>>
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
                var loanApplication = await _loanApplication.GetByPredicate(x => x.Id == request.Id);
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
