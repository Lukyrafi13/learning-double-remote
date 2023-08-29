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
    public class SurveyRejectCommand : SurveyFind, IRequest<ServiceResponse<SurveyProsesResponse>>
    {
        public string NamaUser { get; set; }
        public Guid RFRejectId { get; set; }
    }
    public class SurveyRejectCommandHandler : IRequestHandler<SurveyRejectCommand, ServiceResponse<SurveyProsesResponse>>
    {
        private readonly IGenericRepositoryAsync<Survey> _Survey;
        private readonly IGenericRepositoryAsync<Prospect> _Prospect;
        private readonly IGenericRepositoryAsync<RFStages> _stages;
        private readonly IGenericRepositoryAsync<ProspectStageLogs> _stageLogs;
        private readonly IMapper _mapper;

        public SurveyRejectCommandHandler(
                IGenericRepositoryAsync<Survey> Survey,
                IGenericRepositoryAsync<Prospect> Prospect,
                IGenericRepositoryAsync<RFStages> stages,
                IGenericRepositoryAsync<ProspectStageLogs> stageLogs,
                IMapper mapper
            )
        {
            _Survey = Survey;
            _Prospect = Prospect;
            _stages = stages;
            _stageLogs = stageLogs;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<SurveyProsesResponse>> Handle(SurveyRejectCommand request, CancellationToken cancellationToken)
        {
            
            try
            {
                var Survey = await _Survey.GetByIdAsync(request.Id, "Id", 
                    new string[] {
                        "App",
                        "App.Prospect",
                        "App.Prospect.JenisProduk",
                        "App.Prospect.TipeDebitur",
                        "App.Prospect.JenisKelamin",
                        "App.Prospect.JenisPermohonanKredit",
                        "App.Prospect.KodePos",
                        "App.Prospect.Status",
                        "App.Prospect.SektorEkonomi",
                        "App.Prospect.SubSektorEkonomi",
                        "App.Prospect.SubSubSektorEkonomi",
                        "App.Prospect.Kategori",
                        "App.Prospect.KodeDinas",
                        "App.Prospect.Stage"
                    }
                );
                if (Survey == null){
                    var failResp = ServiceResponse<SurveyProsesResponse>.Return404("Data Survey not found");
                    failResp.Success = false;
                    return failResp;
                }
                
                // Change Survey status
                var stageFound = await _stages.GetByPredicate(x=> x.Code == "0.0");
                var previousStage = await _stages.GetByPredicate(x=> x.Code == "4.2.3");
                
                if (Survey.App.Prospect.Stage.Code == "5.0"){
                    var failResp = ServiceResponse<SurveyProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "Survey sudah diproses sebelumnya");
                    failResp.Success = false;
                    return failResp;
                }

                if (Survey.App.Prospect.Stage.Code == "0.0"){
                    var failResp = ServiceResponse<SurveyProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "Survey sudah ditolak sebelumnya");
                    failResp.Success = false;
                    return failResp;
                }
                
                Survey.App.Prospect.RFStagesId = stageFound.StageId;
                Survey.App.Prospect.Stage = stageFound;
                
                await _Prospect.UpdateAsync(Survey.App.Prospect);

                // Update Survey History
                var oldLog = await _stageLogs.GetByPredicate(x=> x.ProspectId == Survey.App.Prospect.Id && x.StageId == previousStage.StageId);
                oldLog.ModifiedDate = DateTime.Now;
                oldLog.ExecutedDate = DateTime.Now.ToLocalTime();

                await _stageLogs.UpdateAsync(oldLog);

                var newLog = new ProspectStageLogs();
                newLog.ProspectId = Survey.App.Prospect.Id;
                newLog.StageId = stageFound.StageId;
                newLog.ExecutedBy = request.NamaUser;
                newLog.ModifiedDate = DateTime.Now;
                newLog.ExecutedDate = DateTime.Now.ToLocalTime();
                newLog.RFRejectId = request.RFRejectId;

                await _stageLogs.AddAsync(newLog);

                var response = new SurveyProsesResponse();

                response.SurveyId = Survey.Id;
                response.Stage = stageFound.Description;
                response.Message = "Survey berhasil ditolak untuk pemrosesan";

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