using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.Surveys;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.Surveys.Commands
{
    public class SurveyProsesCommand : SurveyFind, IRequest<ServiceResponse<SurveyProsesResponse>>
    {
        public string NamaUser { get; set; }
    }
    public class SurveyProsesCommandHandler : IRequestHandler<SurveyProsesCommand, ServiceResponse<SurveyProsesResponse>>
    {
        private readonly IGenericRepositoryAsync<App> _App;
        private readonly IGenericRepositoryAsync<Prospect> _Prospect;
        private readonly IGenericRepositoryAsync<Prescreening> _Prescreening;
        private readonly IGenericRepositoryAsync<Analisa> _Analisa;
        private readonly IGenericRepositoryAsync<Survey> _Survey;
        private readonly IGenericRepositoryAsync<RFStages> _stages;
        private readonly IGenericRepositoryAsync<ProspectStageLogs> _stageLogs;
        private readonly IMapper _mapper;

        public SurveyProsesCommandHandler(
                IGenericRepositoryAsync<App> App,
                IGenericRepositoryAsync<Prospect> Prospect,
                IGenericRepositoryAsync<Prescreening> Prescreening,
                IGenericRepositoryAsync<Analisa> Analisa,
                IGenericRepositoryAsync<Survey> Survey,
                IGenericRepositoryAsync<RFStages> stages,
                IGenericRepositoryAsync<ProspectStageLogs> stageLogs,
                IMapper mapper
            )
        {
            _App = App;
            _Prospect = Prospect;
            _Prescreening = Prescreening;
            _Analisa = Analisa;
            _Survey = Survey;
            _stages = stages;
            _stageLogs = stageLogs;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<SurveyProsesResponse>> Handle(SurveyProsesCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var Survey = await _Survey.GetByIdAsync(request.Id, "Id",
                    new string[] {
                        "App",
                        "App.Prospect",
                        "App.Prospect.Stage"
                    }
                );
                if (Survey == null)
                {
                    var failResp = ServiceResponse<SurveyProsesResponse>.Return404("Data Survey not found");
                    failResp.Success = false;
                    return failResp;
                }

                // Get Prescreening
                var Prescreening = await _Prescreening.GetByIdAsync(Survey.AppId, "AppId");

                var Analisa = await _Analisa.GetByPredicate(x => x.AppId == Survey.AppId);
                if (Analisa == null)
                {
                    // Assign New Analisa
                    Analisa = new Analisa
                    {
                        AppId = Survey.AppId,
                        SurveyId = Survey.Id,
                        PrescreeningId = Prescreening.Id,
                        SlikRequestId = Prescreening.SlikRequestId,
                    };

                    Analisa = await _Analisa.AddAsync(Analisa);
                }
                
                // Change App status
                var stageFound = await _stages.GetByPredicate(x => x.Code == "5.0");
                var previousStage = await _stages.GetByPredicate(x => x.Code == "4.2.3");

                if (Survey.App.Prospect.Stage.Code == "5.0")
                {
                    var failResp = ServiceResponse<SurveyProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "Survey sudah diproses sebelumnya");
                    failResp.Success = false;
                    return failResp;
                }

                if (Survey.App.Prospect.Stage.Code == "0.0")
                {
                    var failResp = ServiceResponse<SurveyProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "Survey sudah ditolak sebelumnya");
                    failResp.Success = false;
                    return failResp;
                }

                Survey.App.Prospect.RFPreviousStagesId = previousStage.StageId;
                Survey.App.Prospect.PreviousStage = previousStage;
                Survey.App.Prospect.RFStagesId = stageFound.StageId;
                Survey.App.Prospect.Stage = stageFound;

                await _Prospect.UpdateAsync(Survey.App.Prospect);

                // Update App History
                var oldLog = await _stageLogs.GetByPredicate(x => x.Prospect.Id == Survey.App.Prospect.Id && x.StageId == previousStage.StageId);
                oldLog.ModifiedDate = DateTime.Now;
                oldLog.ExecutedDate = DateTime.Now.ToLocalTime();

                await _stageLogs.UpdateAsync(oldLog);

                var newLog = new ProspectStageLogs
                {
                    ProspectId = Survey.App.Prospect.Id,
                    StageId = stageFound.StageId,
                    ExecutedBy = request.NamaUser
                };

                await _stageLogs.AddAsync(newLog);

                var response = new SurveyProsesResponse
                {
                    AppId = Survey.App.Id,
                    SurveyId = Survey.Id,
                    AnalisaId = Analisa.Id,
                    Stage = stageFound.Description,
                    Message = "Survey berhasil diproses ke Analisa"
                };

                return ServiceResponse<SurveyProsesResponse>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                var response = ServiceResponse<SurveyProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                response.Success = false;
                return response;
            }
        }
    }
}