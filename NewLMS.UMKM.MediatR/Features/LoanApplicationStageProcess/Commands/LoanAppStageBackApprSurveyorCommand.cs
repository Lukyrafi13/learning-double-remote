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
    public class LoanAppStageBackApprSurveyorCommand : LoanApplicationStageProcessRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class LoanAppStageBackApprSurveyorCommandHandler : IRequestHandler<LoanAppStageBackApprSurveyorCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplicationAppraisal> _appraisal;
        private readonly IGenericRepositoryAsync<LoanApplication> _loanApplication;
        private readonly IMapper _mapper;

        public LoanAppStageBackApprSurveyorCommandHandler(
            IGenericRepositoryAsync<LoanApplicationAppraisal> appraisal,
            IGenericRepositoryAsync<LoanApplication> loanApplication,
            IMapper mapper)
        {
            _appraisal = appraisal;
            _loanApplication = loanApplication;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(LoanAppStageBackApprSurveyorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var appraisalData = await _appraisal.GetByPredicate(x => x.LoanApplicationCollateralId == request.LoanApplicationCollateralId);
                var appraisalListData = await _appraisal.GetListByPredicate(x => x.LoanApplicationId == appraisalData.LoanApplicationId);
                if (appraisalData != null && appraisalListData.Count > 0)
                {
                    //Update All LoanApplicationCollateral Stage to IDE
                    foreach(var apprListDetail in appraisalListData)
                    {
                        apprListDetail.StageId = LMSUMKMStages.InitialData.StageId;//Appr IDE
                        await _appraisal.UpdateAsync(apprListDetail);
                    }

                    var loanApplicationData = await _loanApplication.GetByPredicate(x => x.Id == appraisalData.LoanApplicationId);
                    if(loanApplicationData != null)
                    {
                        loanApplicationData.StageId = LMSUMKMStages.InitialData.StageId;//Appr IDE
                        await _loanApplication.UpdateAsync(loanApplicationData);
                    }
                    
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
