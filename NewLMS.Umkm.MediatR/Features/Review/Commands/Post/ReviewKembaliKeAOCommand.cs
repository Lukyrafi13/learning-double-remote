// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.Reviews;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.Reviews.Commands
// {
//     public class ReviewKembaliKeAOCommand : ReviewFind, IRequest<ServiceResponse<ReviewProsesResponse>>
//     {
//         public string NamaUser { get; set; }
//     }
//     public class ReviewKembaliKeAOCommandHandler : IRequestHandler<ReviewKembaliKeAOCommand, ServiceResponse<ReviewProsesResponse>>
//     {
//         private readonly IGenericRepositoryAsync<Prospect> _Prospect;
//         private readonly IGenericRepositoryAsync<Review> _Review;
//         private readonly IGenericRepositoryAsync<Approval> _Approval;
//         private readonly IGenericRepositoryAsync<RFStages> _stages;
//         private readonly IGenericRepositoryAsync<ProspectStageLogs> _stageLogs;
//         private readonly IMapper _mapper;

//         public ReviewKembaliKeAOCommandHandler(
//                 IGenericRepositoryAsync<Prospect> Prospect,
//                 IGenericRepositoryAsync<Review> Review,
//                 IGenericRepositoryAsync<Approval> Approval,
//                 IGenericRepositoryAsync<RFStages> stages,
//                 IGenericRepositoryAsync<ProspectStageLogs> stageLogs,
//                 IMapper mapper
//             )
//         {
//             _Prospect = Prospect;
//             _Approval = Approval;
//             _Review = Review;
//             _stages = stages;
//             _stageLogs = stageLogs;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<ReviewProsesResponse>> Handle(ReviewKembaliKeAOCommand request, CancellationToken cancellationToken)
//         {
            
//             try
//             {
//                 var review = await _Review.GetByIdAsync(request.Id, "Id", 
//                     new string[] {
//                         "App",
//                         "App.Prospect",
//                         "App.Prospect.Stage"
//                     }
//                 );
//                 if (review == null){
//                     var failResp = ServiceResponse<ReviewProsesResponse>.Return404("Data Review not found");
//                     failResp.Success = false;
//                     return failResp;
//                 }
                
//                 // Change App status
//                 var stageFound = await _stages.GetByPredicate(x=> x.Code == "5.0");
//                 var previousStage = await _stages.GetByPredicate(x=> x.Code == "6.0");
                
//                 if (review.App.Prospect.Stage.Code == "5.0"){
//                     var failResp = ServiceResponse<ReviewProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "Review sudah dikembalikan sebelumnya");
//                     failResp.Success = false;
//                     return failResp;
//                 }

//                 if (review.App.Prospect.Stage.Code == "0.0"){
//                     var failResp = ServiceResponse<ReviewProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "Review sudah ditolak sebelumnya");
//                     failResp.Success = false;
//                     return failResp;
//                 }
                
//                 review.App.Prospect.RFPreviousStagesId = previousStage.StageId;
//                 review.App.Prospect.PreviousStage = previousStage;
//                 review.App.Prospect.RFStagesId = stageFound.StageId;
//                 review.App.Prospect.Stage = stageFound;
                
//                 await _Prospect.UpdateAsync(review.App.Prospect);

//                 // Update App History
//                 var oldLog = await _stageLogs.GetByPredicate(x=> x.Prospect.Id == review.App.Prospect.Id && x.StageId == previousStage.StageId);
//                 oldLog.ModifiedDate = DateTime.Now;
//                 oldLog.ExecutedDate = DateTime.Now.ToLocalTime();

//                 await _stageLogs.UpdateAsync(oldLog);

//                 var newLog = new ProspectStageLogs();
//                 newLog.ProspectId = review.App.Prospect.Id;
//                 newLog.StageId = stageFound.StageId;
//                 newLog.ExecutedBy = request.NamaUser;

//                 await _stageLogs.AddAsync(newLog);

//                 var response = new ReviewProsesResponse();

//                 response.AppId = review.App.Id;
//                 response.Stage = stageFound.Description;
//                 response.Message = "Review berhasil dikembalikan ke Analisa";

//                 return ServiceResponse<ReviewProsesResponse>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 var response = ServiceResponse<ReviewProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//                 response.Success = false;
//                 return response;
//             }
//         }
//     }
// }