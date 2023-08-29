// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.SlikRequests;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.SlikRequests.Commands
// {
//     public class SlikRequestProsesPersiapanAkadCommand : SlikRequestFind, IRequest<ServiceResponse<SlikRequestProsesResponse>>
//     {
//         public string NamaUser { get; set; }
//     }
//     public class SlikRequestProsesPersiapanAkadCommandHandler : IRequestHandler<SlikRequestProsesPersiapanAkadCommand, ServiceResponse<SlikRequestProsesResponse>>
//     {
//         private readonly IGenericRepositoryAsync<App> _App;
//         private readonly IGenericRepositoryAsync<Prospect> _Prospect;
//         private readonly IGenericRepositoryAsync<PersiapanAkad> _PersiapanAkad;
//         private readonly IGenericRepositoryAsync<SlikRequest> _SlikRequest;
//         private readonly IGenericRepositoryAsync<RFStages> _stages;
//         private readonly IGenericRepositoryAsync<ProspectStageLogs> _stageLogs;
//         private readonly IMapper _mapper;

//         public SlikRequestProsesPersiapanAkadCommandHandler(
//                 IGenericRepositoryAsync<App> App,
//                 IGenericRepositoryAsync<Prospect> Prospect,
//                 IGenericRepositoryAsync<PersiapanAkad> PersiapanAkad,
//                 IGenericRepositoryAsync<SlikRequest> SlikRequest,
//                 IGenericRepositoryAsync<RFStages> stages,
//                 IGenericRepositoryAsync<ProspectStageLogs> stageLogs,
//                 IMapper mapper
//             )
//         {
//             _App = App;
//             _Prospect = Prospect;
//             _PersiapanAkad = PersiapanAkad;
//             _SlikRequest = SlikRequest;
//             _stages = stages;
//             _stageLogs = stageLogs;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<SlikRequestProsesResponse>> Handle(SlikRequestProsesPersiapanAkadCommand request, CancellationToken cancellationToken)
//         {
            
//             try
//             {
//                 var SlikRequest = await _SlikRequest.GetByIdAsync(request.Id, "Id", 
//                     new string[] {
//                         "App",
//                         "App.Prospect",
//                         "App.Prospect.Stage"
//                     }
//                 );
//                 if (SlikRequest == null){
//                     var failResp = ServiceResponse<SlikRequestProsesResponse>.Return404("Data SlikRequest not found");
//                     failResp.Success = false;
//                     return failResp;
//                 }

//                 // Assign New PersiapanAkad
//                 var PersiapanAkad = new PersiapanAkad();

//                 PersiapanAkad.AppId = SlikRequest.AppId;
                
//                 // Change App status
//                 var stageFound = await _stages.GetByPredicate(x=> x.Code == "4.2.3");
//                 var previousStage = await _stages.GetByPredicate(x=> x.Code == "4.2.2");
                
//                 if (SlikRequest.App.Prospect.Stage.Code == "4.2.3"){
//                     var failResp = ServiceResponse<SlikRequestProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "App sudah diproses sebelumnya");
//                     failResp.Success = false;
//                     return failResp;
//                 }

//                 if (SlikRequest.App.Prospect.Stage.Code == "0.0"){
//                     var failResp = ServiceResponse<SlikRequestProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "App sudah ditolak sebelumnya");
//                     failResp.Success = false;
//                     return failResp;
//                 }
                
//                 SlikRequest.App.Prospect.RFStagesId = stageFound.StageId;
//                 SlikRequest.App.Prospect.Stage = stageFound;
                
//                 await _Prospect.UpdateAsync(SlikRequest.App.Prospect);

//                 // Update App History
//                 var oldLog = await _stageLogs.GetByPredicate(x=> x.Prospect.Id == SlikRequest.App.Prospect.Id && x.StageId == previousStage.StageId);
//                 oldLog.ModifiedDate = DateTime.Now;
//                 oldLog.ExecutedDate = DateTime.Now.ToLocalTime();

//                 await _stageLogs.UpdateAsync(oldLog);

//                 var newLog = new ProspectStageLogs();
//                 newLog.ProspectId = SlikRequest.App.Prospect.Id;
//                 newLog.StageId = stageFound.StageId;
//                 newLog.ExecutedBy = request.NamaUser;

//                 await _stageLogs.AddAsync(newLog);

//                 var newPersiapanAkad = await _PersiapanAkad.AddAsync(PersiapanAkad);

//                 var response = new SlikRequestProsesResponse();

//                 response.AppId = SlikRequest.App.Id;
//                 response.SlikRequestId = SlikRequest.Id;
//                 response.PersiapanAkadId = newPersiapanAkad.Id;
//                 response.Stage = stageFound.Description;
//                 response.Message = "SlikRequest berhasil diproses ke PersiapanAkad";

//                 return ServiceResponse<SlikRequestProsesResponse>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 var response = ServiceResponse<SlikRequestProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//                 response.Success = false;
//                 return response;
//             }
//         }
//     }
// }