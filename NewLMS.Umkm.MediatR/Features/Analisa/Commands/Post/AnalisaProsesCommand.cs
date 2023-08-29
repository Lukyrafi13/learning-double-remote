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
//     public class AnalisaProsesCommand : AnalisaFind, IRequest<ServiceResponse<AnalisaProsesResponse>>
//     {
//         public string NamaUser { get; set; }
//     }
//     public class AnalisaProsesCommandHandler : IRequestHandler<AnalisaProsesCommand, ServiceResponse<AnalisaProsesResponse>>
//     {
//         private readonly IGenericRepositoryAsync<Prospect> _Prospect;
//         private readonly IGenericRepositoryAsync<Analisa> _Analisa;
//         private readonly IGenericRepositoryAsync<Review> _Review;
//         private readonly IGenericRepositoryAsync<RFStages> _stages;
//         private readonly IGenericRepositoryAsync<ProspectStageLogs> _stageLogs;
//         private readonly IMapper _mapper;

//         public AnalisaProsesCommandHandler(
//                 IGenericRepositoryAsync<Prospect> Prospect,
//                 IGenericRepositoryAsync<Survey> Survey,
//                 IGenericRepositoryAsync<Analisa> Analisa,
//                 IGenericRepositoryAsync<Review> Review,
//                 IGenericRepositoryAsync<RFStages> stages,
//                 IGenericRepositoryAsync<ProspectStageLogs> stageLogs,
//                 IMapper mapper
//             )
//         {
//             _Prospect = Prospect;
//             _Analisa = Analisa;
//             _Review = Review;
//             _stages = stages;
//             _stageLogs = stageLogs;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<AnalisaProsesResponse>> Handle(AnalisaProsesCommand request, CancellationToken cancellationToken)
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

//                 var review = await _Review.GetByPredicate(x=> x.AppId == Analisa.AppId);

//                 if (review == null){
//                     // Assign New Review
//                     review = new Review();

//                     review.AppId = Analisa.AppId;
//                     review.SurveyId = Analisa.SurveyId;
//                     review.PrescreeningId = Analisa.PrescreeningId;
//                     review.AnalisaId = Analisa.Id;
//                     review.SlikRequestId = Analisa.SlikRequestId;

//                     review = await _Review.AddAsync(review);
//                 }                
                
//                 // Change App status
//                 var stageFound = await _stages.GetByPredicate(x=> x.Code == "6.0");
//                 var previousStage = await _stages.GetByPredicate(x=> x.Code == "5.0");
                
//                 if (Analisa.App.Prospect.Stage.Code == "6.0"){
//                     var failResp = ServiceResponse<AnalisaProsesResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, "Analisa sudah diproses sebelumnya");
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
//                 response.AnalisaId = Analisa.Id;
//                 response.ReviewId = review.Id;
//                 response.Stage = stageFound.Description;
//                 response.Message = "Analisa berhasil diproses ke Review";

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