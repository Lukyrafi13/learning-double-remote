// using AutoMapper;
// using MediatR;
// using NewLMS.Umkm.Data.Dto.ReviewPersiapanAkads;
// using NewLMS.Umkm.Data;
// using NewLMS.Umkm.Helper;
// using NewLMS.Umkm.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.Umkm.MediatR.Features.ReviewPersiapanAkads.Commands
// {
//     public class ReviewPersiapanAkadProsesCommand : ReviewPersiapanAkadFind, IRequest<ServiceResponse<ReviewPersiapanAkadProsesResponse>>
//     {
//         public string NamaUser { get; set; }
//     }
//     public class ReviewPersiapanAkadProsesCommandHandler : IRequestHandler<ReviewPersiapanAkadProsesCommand, ServiceResponse<ReviewPersiapanAkadProsesResponse>>
//     {
//         private readonly IGenericRepositoryAsync<Prospect> _Prospect;
//         private readonly IGenericRepositoryAsync<ReviewPersiapanAkad> _ReviewPersiapanAkad;
//         private readonly IGenericRepositoryAsync<ReviewPersiapanAkad> _ReviewPersiapanAkad;
//         private readonly IGenericRepositoryAsync<RFStages> _stages;
//         private readonly IGenericRepositoryAsync<ProspectStageLogs> _stageLogs;
//         private readonly IMapper _mapper;

//         public ReviewPersiapanAkadProsesCommandHandler(
//                 IGenericRepositoryAsync<Prospect> Prospect,
//                 IGenericRepositoryAsync<ReviewPersiapanAkad> ReviewPersiapanAkad,
//                 IGenericRepositoryAsync<ReviewPersiapanAkad> ReviewPersiapanAkad,
//                 IGenericRepositoryAsync<RFStages> stages,
//                 IGenericRepositoryAsync<ProspectStageLogs> stageLogs,
//                 IMapper mapper
//             )
//         {
//             _Prospect = Prospect;
//             _ReviewPersiapanAkad = ReviewPersiapanAkad;
//             _ReviewPersiapanAkad = ReviewPersiapanAkad;
//             _stages = stages;
//             _stageLogs = stageLogs;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<ReviewPersiapanAkadProsesResponse>> Handle(ReviewPersiapanAkadProsesCommand request, CancellationToken cancellationToken)
//         {

//             try
//             {
//                 var ReviewPersiapanAkad = await _ReviewPersiapanAkad.GetByIdAsync(request.Id, "Id",
//                     new string[] {
//                         "App",
//                         "App.Prospect",
//                         "App.Prospect.Stage"
//                     }
//                 );
//                 if (ReviewPersiapanAkad == null)
//                 {
//                     var failResp = ServiceResponse<ReviewPersiapanAkadProsesResponse>.Return404("Data ReviewPersiapanAkad not found");
//                     failResp.Success = false;
//                     return failResp;
//                 }

//                 // Assign New ReviewPersiapanAkad
//                 var ReviewPersiapanAkad = new ReviewPersiapanAkad();

//                 ReviewPersiapanAkad.AppId = ReviewPersiapanAkad.AppId;
//                 ReviewPersiapanAkad.SppkId = ReviewPersiapanAkad.SppkId;
//                 ReviewPersiapanAkad.AnalisaId = ReviewPersiapanAkad.AnalisaId;
//                 ReviewPersiapanAkad.PrescreeningId = ReviewPersiapanAkad.PrescreeningId;
//                 ReviewPersiapanAkad.PersiapanAkadId = ReviewPersiapanAkad.PersiapanAkadId;

//                 // Change App status
//                 var stageFound = await _stages.GetByPredicate(x => x.Code == "8.0");
//                 var previousStage = await _stages.GetByPredicate(x => x.Code == "7.0");

//                 if (ReviewPersiapanAkad.App.Prospect.Stage.Code == "8.0")
//                 {
//                     var failResp = ServiceResponse<ReviewPersiapanAkadProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "ReviewPersiapanAkad sudah diproses sebelumnya");
//                     failResp.Success = false;
//                     return failResp;
//                 }

//                 if (ReviewPersiapanAkad.App.Prospect.Stage.Code == "0.0")
//                 {
//                     var failResp = ServiceResponse<ReviewPersiapanAkadProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "ReviewPersiapanAkad sudah ditolak sebelumnya");
//                     failResp.Success = false;
//                     return failResp;
//                 }

//                 ReviewPersiapanAkad.App.Prospect.RFStagesId = stageFound.StageId;
//                 ReviewPersiapanAkad.App.Prospect.Stage = stageFound;

//                 await _Prospect.UpdateAsync(ReviewPersiapanAkad.App.Prospect);

//                 // Update App History
//                 var oldLog = await _stageLogs.GetByPredicate(x => x.Prospect.Id == ReviewPersiapanAkad.App.Prospect.Id && x.StageId == previousStage.StageId);
//                 oldLog.ModifiedDate = DateTime.Now;
//                 oldLog.ExecutedDate = DateTime.Now.ToLocalTime();

//                 await _stageLogs.UpdateAsync(oldLog);

//                 var newLog = new ProspectStageLogs();
//                 newLog.ProspectId = ReviewPersiapanAkad.App.Prospect.Id;
//                 newLog.StageId = stageFound.StageId;
//                 newLog.ExecutedBy = request.NamaUser;

//                 await _stageLogs.AddAsync(newLog);

//                 var newReviewPersiapanAkad = await _ReviewPersiapanAkad.AddAsync(ReviewPersiapanAkad);

//                 var response = new ReviewPersiapanAkadProsesResponse();

//                 response.AppId = ReviewPersiapanAkad.App.Id;
//                 response.ReviewPersiapanAkadId = ReviewPersiapanAkad.Id;
//                 response.ReviewPersiapanAkadId = newReviewPersiapanAkad.Id;
//                 response.Stage = stageFound.Description;
//                 response.Message = "ReviewPersiapanAkad berhasil diproses ke ReviewReviewPersiapanAkad";

//                 return ServiceResponse<ReviewPersiapanAkadProsesResponse>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 var response = ServiceResponse<ReviewPersiapanAkadProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//                 response.Success = false;
//                 return response;
//             }
//         }
//     }
// }