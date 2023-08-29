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
//     public class PrescreeningRejectCommand : PrescreeningFind, IRequest<ServiceResponse<PrescreeningProsesResponse>>
//     {
//         public string NamaUser { get; set; }
//         public Guid RFRejectId { get; set; }
//     }
//     public class PrescreeningRejectCommandHandler : IRequestHandler<PrescreeningRejectCommand, ServiceResponse<PrescreeningProsesResponse>>
//     {
//         private readonly IGenericRepositoryAsync<Prescreening> _Prescreening;
//         private readonly IGenericRepositoryAsync<Prospect> _Prospect;
//         private readonly IGenericRepositoryAsync<RFStages> _stages;
//         private readonly IGenericRepositoryAsync<ProspectStageLogs> _stageLogs;
//         private readonly IMapper _mapper;

//         public PrescreeningRejectCommandHandler(
//                 IGenericRepositoryAsync<Prescreening> Prescreening,
//                 IGenericRepositoryAsync<Prospect> Prospect,
//                 IGenericRepositoryAsync<RFStages> stages,
//                 IGenericRepositoryAsync<ProspectStageLogs> stageLogs,
//                 IMapper mapper
//             )
//         {
//             _Prescreening = Prescreening;
//             _Prospect = Prospect;
//             _stages = stages;
//             _stageLogs = stageLogs;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<PrescreeningProsesResponse>> Handle(PrescreeningRejectCommand request, CancellationToken cancellationToken)
//         {
            
//             try
//             {
//                 var Prescreening = await _Prescreening.GetByIdAsync(request.Id, "Id", 
//                     new string[] {
//                         "App",
//                         "App.Prospect",
//                         "App.Prospect.JenisProduk",
//                         "App.Prospect.TipeDebitur",
//                         "App.Prospect.JenisKelamin",
//                         "App.Prospect.JenisPermohonanKredit",
//                         "App.Prospect.KodePos",
//                         "App.Prospect.Status",
//                         "App.Prospect.SektorEkonomi",
//                         "App.Prospect.SubSektorEkonomi",
//                         "App.Prospect.SubSubSektorEkonomi",
//                         "App.Prospect.Kategori",
//                         "App.Prospect.KodeDinas",
//                         "App.Prospect.Stage"
//                     }
//                 );
//                 if (Prescreening == null){
//                     var failResp = ServiceResponse<PrescreeningProsesResponse>.Return404("Data Prescreening not found");
//                     failResp.Success = false;
//                     return failResp;
//                 }
                
//                 // Change Prescreening status
//                 var stageFound = await _stages.GetByPredicate(x=> x.Code == "0.0");
//                 var previousStage = await _stages.GetByPredicate(x=> x.Code == "4.2.2");
                
//                 if (Prescreening.App.Prospect.Stage.Code == "4.2.3"){
//                     var failResp = ServiceResponse<PrescreeningProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "Prescreening sudah diproses sebelumnya");
//                     failResp.Success = false;
//                     return failResp;
//                 }

//                 if (Prescreening.App.Prospect.Stage.Code == "0.0"){
//                     var failResp = ServiceResponse<PrescreeningProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "Prescreening sudah ditolak sebelumnya");
//                     failResp.Success = false;
//                     return failResp;
//                 }
                
//                 Prescreening.App.Prospect.RFStagesId = stageFound.StageId;
//                 Prescreening.App.Prospect.Stage = stageFound;
                
//                 await _Prospect.UpdateAsync(Prescreening.App.Prospect);

//                 // Update Prescreening History
//                 var oldLog = await _stageLogs.GetByPredicate(x=> x.ProspectId == Prescreening.App.Prospect.Id && x.StageId == previousStage.StageId);
//                 oldLog.ModifiedDate = DateTime.Now;
//                 oldLog.ExecutedDate = DateTime.Now.ToLocalTime();

//                 await _stageLogs.UpdateAsync(oldLog);

//                 var newLog = new ProspectStageLogs();
//                 newLog.ProspectId = Prescreening.App.Prospect.Id;
//                 newLog.StageId = stageFound.StageId;
//                 newLog.ExecutedBy = request.NamaUser;
//                 newLog.ModifiedDate = DateTime.Now;
//                 newLog.ExecutedDate = DateTime.Now.ToLocalTime();
//                 newLog.RFRejectId = request.RFRejectId;

//                 await _stageLogs.AddAsync(newLog);

//                 var response = new PrescreeningProsesResponse();

//                 response.PrescreeningId = Prescreening.Id;
//                 response.Stage = stageFound.Description;
//                 response.Message = "Prescreening berhasil ditolak untuk pemrosesan";

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