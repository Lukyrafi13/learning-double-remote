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
// using System.Collections.Generic;

// namespace NewLMS.UMKM.MediatR.Features.SlikRequests.Commands
// {
//     public class SlikRequestKembaliKeIDEMultipleCommand : IRequest<ServiceResponse<List<SlikRequestProsesResponse>>>
//     {
//         public List<Guid> ListIds { get; set; }
//         public string NamaUser { get; set; }
//     }
//     public class SlikRequestKembaliKeIDEMultipleCommandHandler : IRequestHandler<SlikRequestKembaliKeIDEMultipleCommand, ServiceResponse<List<SlikRequestProsesResponse>>>
//     {
//         private readonly IGenericRepositoryAsync<Prospect> _Prospect;
//         private readonly IGenericRepositoryAsync<SlikRequest> _SlikRequest;
//         private readonly IGenericRepositoryAsync<RFStages> _stages;
//         private readonly IGenericRepositoryAsync<ProspectStageLogs> _stageLogs;
//         private readonly IMapper _mapper;

//         public SlikRequestKembaliKeIDEMultipleCommandHandler(
//                 IGenericRepositoryAsync<Prospect> Prospect,
//                 IGenericRepositoryAsync<SlikRequest> SlikRequest,
//                 IGenericRepositoryAsync<RFStages> stages,
//                 IGenericRepositoryAsync<ProspectStageLogs> stageLogs,
//                 IMapper mapper
//             )
//         {
//             _Prospect = Prospect;
//             _SlikRequest = SlikRequest;
//             _stages = stages;
//             _stageLogs = stageLogs;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<List<SlikRequestProsesResponse>>> Handle(SlikRequestKembaliKeIDEMultipleCommand request, CancellationToken cancellationToken)
//         {

//             try
//             {
//                 var responseList = new List<SlikRequestProsesResponse>();

//                 foreach (var Id in request.ListIds)
//                 {
//                     var SlikRequest = await _SlikRequest.GetByIdAsync(Id, "Id",
//                         new string[] {
//                         "App",
//                         "App.Prospect",
//                         "App.Prospect.Stage"
//                         }
//                     );
//                     if (SlikRequest == null)
//                     {
//                         var failResp = ServiceResponse<SlikRequestProsesResponse>.Return404("Data SlikRequest not found");
//                         failResp.Success = false;
//                         failResp.Data.Message = "Data SlikRequest not found";
//                         failResp.Data.SlikRequestId = Id;
//                         responseList.Add(failResp.Data);
//                         continue;
//                     }

//                     // Change App status
//                     var stageFound = await _stages.GetByPredicate(x => x.Code == "2.0");
//                     var previousStage = await _stages.GetByPredicate(x => x.Code == "4.2.1");

//                     if (SlikRequest.App.Prospect.Stage.Code == "2.0")
//                     {
//                         var failResp = ServiceResponse<SlikRequestProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "SlikRequest sudah dikembalikan sebelumnya");
//                         failResp.Success = false;
//                         failResp.Data.Message = "Data SlikRequest not found";
//                         failResp.Data.SlikRequestId = Id;
//                         responseList.Add(failResp.Data);
//                         continue;
//                     }

//                     if (SlikRequest.App.Prospect.Stage.Code == "0.0")
//                     {
//                         var failResp = ServiceResponse<SlikRequestProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "SlikRequest sudah ditolak sebelumnya");
//                         failResp.Success = false;
//                         failResp.Data.Message = "Data SlikRequest not found";
//                         failResp.Data.SlikRequestId = Id;
//                         responseList.Add(failResp.Data);
//                         continue;
//                     }

//                     SlikRequest.App.Prospect.RFPreviousStagesId = previousStage.StageId;
//                     SlikRequest.App.Prospect.PreviousStage = previousStage;
//                     SlikRequest.App.Prospect.RFStagesId = stageFound.StageId;
//                     SlikRequest.App.Prospect.Stage = stageFound;

//                     await _Prospect.UpdateAsync(SlikRequest.App.Prospect);

//                     // Update App History
//                     var oldLog = await _stageLogs.GetByPredicate(x => x.Prospect.Id == SlikRequest.App.Prospect.Id && x.StageId == previousStage.StageId);
//                     oldLog.ModifiedDate = DateTime.Now;
//                     oldLog.ExecutedDate = DateTime.Now.ToLocalTime();

//                     await _stageLogs.UpdateAsync(oldLog);

//                     var newLog = new ProspectStageLogs();
//                     newLog.ProspectId = SlikRequest.App.Prospect.Id;
//                     newLog.StageId = stageFound.StageId;
//                     newLog.ExecutedBy = request.NamaUser;

//                     await _stageLogs.AddAsync(newLog);

//                     var response = new SlikRequestProsesResponse();

//                     response.AppId = SlikRequest.App.Id;
//                     response.Stage = stageFound.Description;
//                     response.Message = "SlikRequest berhasil dikembalikan ke IDE";

//                     responseList.Add(response);
//                 }

//                 return ServiceResponse<List<SlikRequestProsesResponse>>.ReturnResultWith200(responseList);
//             }
//             catch (Exception ex)
//             {
//                 var response = ServiceResponse<List<SlikRequestProsesResponse>>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//                 response.Success = false;
//                 return response;
//             }
//         }
//     }
// }