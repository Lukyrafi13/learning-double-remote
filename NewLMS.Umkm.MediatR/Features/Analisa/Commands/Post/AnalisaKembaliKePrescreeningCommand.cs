// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.Analisas;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.Analisas.Commands
// {
//     public class AnalisaKembaliKePrescreeningCommand : AnalisaFind, IRequest<ServiceResponse<AnalisaProsesResponse>>
//     {
//         public string NamaUser { get; set; }
//     }
//     public class AnalisaKembaliKePrescreeningCommandHandler : IRequestHandler<AnalisaKembaliKePrescreeningCommand, ServiceResponse<AnalisaProsesResponse>>
//     {
//         private readonly IGenericRepositoryAsync<Prospect> _Prospect;
//         private readonly IGenericRepositoryAsync<Analisa> _Analisa;
//         private readonly IGenericRepositoryAsync<RFStages> _stages;
//         private readonly IGenericRepositoryAsync<ProspectStageLogs> _stageLogs;
//         private readonly IMapper _mapper;

//         public AnalisaKembaliKePrescreeningCommandHandler(
//                 IGenericRepositoryAsync<Prospect> Prospect,
//                 IGenericRepositoryAsync<Analisa> Analisa,
//                 IGenericRepositoryAsync<RFStages> stages,
//                 IGenericRepositoryAsync<ProspectStageLogs> stageLogs,
//                 IMapper mapper
//             )
//         {
//             _Prospect = Prospect;
//             _Analisa = Analisa;
//             _stages = stages;
//             _stageLogs = stageLogs;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<AnalisaProsesResponse>> Handle(AnalisaKembaliKePrescreeningCommand request, CancellationToken cancellationToken)
//         {
            
//             try
//             {
//                 var Analisa = await _Analisa.GetByIdAsync(request.Id, "Id", 
//                     new string[] {
//                         "App",
//                         "App.Prospect",
//                         "App.Prospect.Stage"
//                     }
//                 );
//                 if (Analisa == null){
//                     var failResp = ServiceResponse<AnalisaProsesResponse>.Return404("Data Analisa not found");
//                     failResp.Success = false;
//                     return failResp;
//                 }
                
//                 // Change App status
//                 var stageFound = await _stages.GetByPredicate(x=> x.Code == "4.2.2");
//                 var previousStage = await _stages.GetByPredicate(x=> x.Code == "5.0");
                
//                 if (Analisa.App.Prospect.Stage.Code == "4.2.2"){
//                     var failResp = ServiceResponse<AnalisaProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "Analisa sudah dikembalikan sebelumnya");
//                     failResp.Success = false;
//                     return failResp;
//                 }

//                 if (Analisa.App.Prospect.Stage.Code == "0.0"){
//                     var failResp = ServiceResponse<AnalisaProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "Analisa sudah ditolak sebelumnya");
//                     failResp.Success = false;
//                     return failResp;
//                 }
                
//                 Analisa.App.Prospect.RFPreviousStagesId = previousStage.StageId;
//                 Analisa.App.Prospect.PreviousStage = previousStage;
//                 Analisa.App.Prospect.RFStagesId = stageFound.StageId;
//                 Analisa.App.Prospect.Stage = stageFound;
                
//                 await _Prospect.UpdateAsync(Analisa.App.Prospect);

//                 // Update App History
//                 var oldLog = await _stageLogs.GetByPredicate(x=> x.Prospect.Id == Analisa.App.Prospect.Id && x.StageId == previousStage.StageId);
//                 oldLog.ModifiedDate = DateTime.Now;
//                 oldLog.ExecutedDate = DateTime.Now.ToLocalTime();

//                 await _stageLogs.UpdateAsync(oldLog);

//                 var newLog = new ProspectStageLogs();
//                 newLog.ProspectId = Analisa.App.Prospect.Id;
//                 newLog.StageId = stageFound.StageId;
//                 newLog.ExecutedBy = request.NamaUser;

//                 await _stageLogs.AddAsync(newLog);

//                 var response = new AnalisaProsesResponse();

//                 response.AppId = Analisa.App.Id;
//                 response.Stage = stageFound.Description;
//                 response.Message = "Analisa berhasil dikembalikan ke Prescreening";

//                 return ServiceResponse<AnalisaProsesResponse>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 var response = ServiceResponse<AnalisaProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//                 response.Success = false;
//                 return response;
//             }
//         }
//     }
// }