// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.Prescreenings;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.Prescreenings.Commands
// {
//     public class PrescreeningProsesCommand : PrescreeningFind, IRequest<ServiceResponse<PrescreeningProsesResponse>>
//     {
//         public string NamaUser { get; set; }
//     }
//     public class PrescreeningProsesCommandHandler : IRequestHandler<PrescreeningProsesCommand, ServiceResponse<PrescreeningProsesResponse>>
//     {
//         private readonly IGenericRepositoryAsync<App> _App;
//         private readonly IGenericRepositoryAsync<Prospect> _Prospect;
//         private readonly IGenericRepositoryAsync<Survey> _Survey;
//         private readonly IGenericRepositoryAsync<Prescreening> _prescreening;
//         private readonly IGenericRepositoryAsync<RFStages> _stages;
//         private readonly IGenericRepositoryAsync<ProspectStageLogs> _stageLogs;
//         private readonly IMapper _mapper;

//         public PrescreeningProsesCommandHandler(
//                 IGenericRepositoryAsync<App> App,
//                 IGenericRepositoryAsync<Prospect> Prospect,
//                 IGenericRepositoryAsync<Survey> Survey,
//                 IGenericRepositoryAsync<Prescreening> prescreening,
//                 IGenericRepositoryAsync<RFStages> stages,
//                 IGenericRepositoryAsync<ProspectStageLogs> stageLogs,
//                 IMapper mapper
//             )
//         {
//             _App = App;
//             _Prospect = Prospect;
//             _Survey = Survey;
//             _prescreening = prescreening;
//             _stages = stages;
//             _stageLogs = stageLogs;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<PrescreeningProsesResponse>> Handle(PrescreeningProsesCommand request, CancellationToken cancellationToken)
//         {

//             try
//             {
//                 var prescreening = await _prescreening.GetByIdAsync(request.Id, "Id",
//                     new string[] {
//                         "App",
//                         "App.Prospect",
//                         "App.Prospect.Stage"
//                     }
//                 );
//                 if (prescreening == null)
//                 {
//                     var failResp = ServiceResponse<PrescreeningProsesResponse>.Return404("Data Prescreening not found");
//                     failResp.Success = false;
//                     return failResp;
//                 }


//                 var survey = await _Survey.GetByPredicate(x => x.AppId == prescreening.AppId);

//                 if (survey == null)
//                 {
//                     // Assign New Survey
//                     survey = new Survey
//                     {
//                         AppId = prescreening.AppId
//                     };

//                     survey = await _Survey.AddAsync(survey);
//                 }

//                 // Change App status
//                 var stageFound = await _stages.GetByPredicate(x => x.Code == "4.2.3");
//                 var previousStage = await _stages.GetByPredicate(x => x.Code == "4.2.2");

//                 if (prescreening.App.Prospect.Stage.Code == "4.2.3")
//                 {
//                     var failResp = ServiceResponse<PrescreeningProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "Prescreening sudah diproses sebelumnya");
//                     failResp.Success = false;
//                     return failResp;
//                 }

//                 if (prescreening.App.Prospect.Stage.Code == "0.0")
//                 {
//                     var failResp = ServiceResponse<PrescreeningProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "Prescreening sudah ditolak sebelumnya");
//                     failResp.Success = false;
//                     return failResp;
//                 }

//                 prescreening.App.Prospect.RFPreviousStagesId = previousStage.StageId;
//                 prescreening.App.Prospect.PreviousStage = previousStage;
//                 prescreening.App.Prospect.RFStagesId = stageFound.StageId;
//                 prescreening.App.Prospect.Stage = stageFound;

//                 await _Prospect.UpdateAsync(prescreening.App.Prospect);

//                 // Update App History
//                 var oldLog = await _stageLogs.GetByPredicate(x => x.Prospect.Id == prescreening.App.Prospect.Id && x.StageId == previousStage.StageId);
//                 oldLog.ModifiedDate = DateTime.Now;
//                 oldLog.ExecutedDate = DateTime.Now.ToLocalTime();

//                 await _stageLogs.UpdateAsync(oldLog);

//                 var newLog = new ProspectStageLogs
//                 {
//                     ProspectId = prescreening.App.Prospect.Id,
//                     StageId = stageFound.StageId,
//                     ExecutedBy = request.NamaUser
//                 };

//                 await _stageLogs.AddAsync(newLog);

//                 var response = new PrescreeningProsesResponse
//                 {
//                     AppId = prescreening.App.Id,
//                     PrescreeningId = prescreening.Id,
//                     SurveyId = survey.Id,
//                     Stage = stageFound.Description,
//                     Message = "Prescreening berhasil diproses ke Survey"
//                 };

//                 return ServiceResponse<PrescreeningProsesResponse>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 var response = ServiceResponse<PrescreeningProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//                 response.Success = false;
//                 return response;
//             }
//         }
//     }
// }