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
//     public class SlikRequestRejectCommand : SlikRequestFind, IRequest<ServiceResponse<SlikRequestProsesResponse>>
//     {
//         public string NamaUser { get; set; }
//         public Guid RFRejectId { get; set; }
//     }
//     public class SlikRequestRejectCommandHandler : IRequestHandler<SlikRequestRejectCommand, ServiceResponse<SlikRequestProsesResponse>>
//     {
//         private readonly IGenericRepositoryAsync<SlikRequest> _SlikRequest;
//         private readonly IGenericRepositoryAsync<Prospect> _Prospect;
//         private readonly IGenericRepositoryAsync<RFStages> _stages;
//         private readonly IGenericRepositoryAsync<ProspectStageLogs> _stageLogs;
//         private readonly IMapper _mapper;

//         public SlikRequestRejectCommandHandler(
//                 IGenericRepositoryAsync<SlikRequest> SlikRequest,
//                 IGenericRepositoryAsync<Prospect> Prospect,
//                 IGenericRepositoryAsync<RFStages> stages,
//                 IGenericRepositoryAsync<ProspectStageLogs> stageLogs,
//                 IMapper mapper
//             )
//         {
//             _SlikRequest = SlikRequest;
//             _Prospect = Prospect;
//             _stages = stages;
//             _stageLogs = stageLogs;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<SlikRequestProsesResponse>> Handle(SlikRequestRejectCommand request, CancellationToken cancellationToken)
//         {
            
//             try
//             {
//                 var SlikRequest = await _SlikRequest.GetByIdAsync(request.Id, "Id", 
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
//                 if (SlikRequest == null){
//                     var failResp = ServiceResponse<SlikRequestProsesResponse>.Return404("Data SlikRequest not found");
//                     failResp.Success = false;
//                     return failResp;
//                 }
                
//                 // Change SlikRequest status
//                 var stageFound = await _stages.GetByPredicate(x=> x.Code == "0.0");
//                 var previousStage = await _stages.GetByPredicate(x=> x.Code == "4.2.1");
                
//                 if (SlikRequest.App.Prospect.Stage.Code == "4.2.2"){
//                     var failResp = ServiceResponse<SlikRequestProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "SlikRequest sudah diproses sebelumnya");
//                     failResp.Success = false;
//                     return failResp;
//                 }

//                 if (SlikRequest.App.Prospect.Stage.Code == "0.0"){
//                     var failResp = ServiceResponse<SlikRequestProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "SlikRequest sudah ditolak sebelumnya");
//                     failResp.Success = false;
//                     return failResp;
//                 }
                
//                 SlikRequest.App.Prospect.RFStagesId = stageFound.StageId;
//                 SlikRequest.App.Prospect.Stage = stageFound;
                
//                 await _Prospect.UpdateAsync(SlikRequest.App.Prospect);

//                 // Update SlikRequest History
//                 var oldLog = await _stageLogs.GetByPredicate(x=> x.ProspectId == SlikRequest.App.Prospect.Id && x.StageId == previousStage.StageId);
//                 oldLog.ModifiedDate = DateTime.Now;
//                 oldLog.ExecutedDate = DateTime.Now.ToLocalTime();

//                 await _stageLogs.UpdateAsync(oldLog);

//                 var newLog = new ProspectStageLogs();
//                 newLog.ProspectId = SlikRequest.App.Prospect.Id;
//                 newLog.StageId = stageFound.StageId;
//                 newLog.ExecutedBy = request.NamaUser;
//                 newLog.ModifiedDate = DateTime.Now;
//                 newLog.ExecutedDate = DateTime.Now.ToLocalTime();
//                 newLog.RFRejectId = request.RFRejectId;

//                 await _stageLogs.AddAsync(newLog);

//                 var response = new SlikRequestProsesResponse();

//                 response.SlikRequestId = SlikRequest.Id;
//                 response.Stage = stageFound.Description;
//                 response.Message = "SlikRequest berhasil ditolak untuk pemrosesan";

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