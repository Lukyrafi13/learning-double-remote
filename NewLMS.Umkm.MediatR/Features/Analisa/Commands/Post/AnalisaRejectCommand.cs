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
//     public class AnalisaRejectCommand : AnalisaFind, IRequest<ServiceResponse<AnalisaProsesResponse>>
//     {
//         public string NamaUser { get; set; }
//         public Guid RFRejectId { get; set; }
//     }
//     public class AnalisaRejectCommandHandler : IRequestHandler<AnalisaRejectCommand, ServiceResponse<AnalisaProsesResponse>>
//     {
//         private readonly IGenericRepositoryAsync<Analisa> _Analisa;
//         private readonly IGenericRepositoryAsync<Prospect> _Prospect;
//         private readonly IGenericRepositoryAsync<RFStages> _stages;
//         private readonly IGenericRepositoryAsync<ProspectStageLogs> _stageLogs;
//         private readonly IMapper _mapper;

//         public AnalisaRejectCommandHandler(
//                 IGenericRepositoryAsync<Analisa> Analisa,
//                 IGenericRepositoryAsync<Prospect> Prospect,
//                 IGenericRepositoryAsync<RFStages> stages,
//                 IGenericRepositoryAsync<ProspectStageLogs> stageLogs,
//                 IMapper mapper
//             )
//         {
//             _Analisa = Analisa;
//             _Prospect = Prospect;
//             _stages = stages;
//             _stageLogs = stageLogs;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<AnalisaProsesResponse>> Handle(AnalisaRejectCommand request, CancellationToken cancellationToken)
//         {
            
//             try
//             {
//                 var Analisa = await _Analisa.GetByIdAsync(request.Id, "Id", 
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
//                 if (Analisa == null){
//                     var failResp = ServiceResponse<AnalisaProsesResponse>.Return404("Data Analisa not found");
//                     failResp.Success = false;
//                     return failResp;
//                 }
                
//                 // Change Analisa status
//                 var stageFound = await _stages.GetByPredicate(x=> x.Code == "0.0");
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
                
//                 Analisa.App.Prospect.RFStagesId = stageFound.StageId;
//                 Analisa.App.Prospect.Stage = stageFound;
                
//                 await _Prospect.UpdateAsync(Analisa.App.Prospect);

//                 // Update Analisa History
//                 var oldLog = await _stageLogs.GetByPredicate(x=> x.ProspectId == Analisa.App.Prospect.Id && x.StageId == previousStage.StageId);
//                 oldLog.ModifiedDate = DateTime.Now;
//                 oldLog.ExecutedDate = DateTime.Now.ToLocalTime();

//                 await _stageLogs.UpdateAsync(oldLog);

//                 var newLog = new ProspectStageLogs();
//                 newLog.ProspectId = Analisa.App.Prospect.Id;
//                 newLog.StageId = stageFound.StageId;
//                 newLog.ExecutedBy = request.NamaUser;
//                 newLog.ModifiedDate = DateTime.Now;
//                 newLog.ExecutedDate = DateTime.Now.ToLocalTime();
//                 newLog.RFRejectId = request.RFRejectId;

//                 await _stageLogs.AddAsync(newLog);

//                 var response = new AnalisaProsesResponse();

//                 response.AnalisaId = Analisa.Id;
//                 response.Stage = stageFound.Description;
//                 response.Message = "Analisa berhasil ditolak untuk pemrosesan";

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