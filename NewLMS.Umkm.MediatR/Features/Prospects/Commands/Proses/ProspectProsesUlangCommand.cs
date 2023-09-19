// using AutoMapper;
// using MediatR;
// using NewLMS.Umkm.Data.Dto.Prospects;
// using NewLMS.Umkm.Data;
// using NewLMS.Umkm.Helper;
// using NewLMS.Umkm.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.Umkm.MediatR.Features.Prospects.Commands
// {
//     public class ProspectProsesUlangCommand : ProspectFindRequestDto, IRequest<ServiceResponse<ProspectProsesResponseDto>>
//     {
//         public string NamaUser { get; set; }
//     }
//     public class ProspectProsesUlangCommandHandler : IRequestHandler<ProspectProsesUlangCommand, ServiceResponse<ProspectProsesResponseDto>>
//     {
//         private readonly IGenericRepositoryAsync<Prospect> _prospect;
//         private readonly IGenericRepositoryAsync<App> _app;
//         private readonly IGenericRepositoryAsync<RFStages> _stages;
//         private readonly IGenericRepositoryAsync<ProspectStageLogs> _stageLogs;
//         private readonly IMapper _mapper;

//         public ProspectProsesUlangCommandHandler(
//                 IGenericRepositoryAsync<Prospect> prospect,
//                 IGenericRepositoryAsync<App> app,
//                 IGenericRepositoryAsync<RFStages> stages,
//                 IGenericRepositoryAsync<ProspectStageLogs> stageLogs,
//                 IMapper mapper
//             )
//         {
//             _prospect = prospect;
//             _app = app;
//             _stages = stages;
//             _stageLogs = stageLogs;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<ProspectProsesResponseDto>> Handle(ProspectProsesUlangCommand request, CancellationToken cancellationToken)
//         {
            
//             try
//             {
//                 var prospect = await _prospect.GetByIdAsync(Guid.Parse(request.Id), "Id", 
//                     new string[] {
//                         "JenisProduk",
//                         "TipeDebitur",
//                         "JenisKelamin",
//                         "JenisPermohonanKredit",
//                         "KodePos",
//                         "Status",
//                         "SektorEkonomi",
//                         "SubSektorEkonomi",
//                         "SubSubSektorEkonomi",
//                         "Kategori",
//                         "KodeDinas",
//                         "Stage"
//                     }
//                 );
//                 if (prospect == null){
//                     var failResp = ServiceResponse<ProspectProsesResponseDto>.Return404("Data Prospect not found");
//                     failResp.Success = false;
//                     return failResp;
//                 }

//                 var countDataApp = await _app.GetCountByPredicate(x =>
//                             x.CreatedDate.Year == DateTime.Now.Year
//                             && x.CreatedDate.Month == DateTime.Now.Month
//                             );
                
//                 var appId = prospect.KodeCabang+"-"+prospect.JenisProduk.ProductType+"-"+DateTime.Now.ToString("yy")+DateTime.Now.ToString("MM")+"-"+(countDataApp+1).ToString("D4");

//                 var app = await _app.GetByPredicate(x=>x.ProspectId == prospect.Id);

//                 if (app == null){
//                     var failResp = ServiceResponse<ProspectProsesResponseDto>.Return404("Data App not found");
//                     failResp.Success = false;
//                     return failResp;
//                 }
                
//                 // Change prospect status
//                 var stageFound = await _stages.GetByPredicate(x=> x.Code == "2.0");
//                 var previousStage = await _stages.GetByPredicate(x=> x.Code == "0.0");
                
//                 if (prospect.Stage.Code == "2.0"){
//                     var failResp = ServiceResponse<ProspectProsesResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "Data sudah diproses sebelumnya");
//                     failResp.Success = false;
//                     return failResp;
//                 }

//                 if (prospect.Stage.Code != "0.0"){
//                     var failResp = ServiceResponse<ProspectProsesResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "Data bukan data yang ditolak sebelumnya");
//                     failResp.Success = false;
//                     return failResp;
//                 }
                
//                 prospect.RFStagesId = stageFound.StageId;
//                 prospect.Stage = stageFound;
                
//                 await _prospect.UpdateAsync(prospect);
                
//                 app.AplikasiId = appId;

//                 await _app.UpdateAsync(app);

//                 // Update prospect History
//                 var oldLog = await _stageLogs.GetByPredicate(x=> x.ProspectId == prospect.Id && x.StageId == previousStage.StageId);
//                 oldLog.ModifiedDate = DateTime.Now;
//                 oldLog.ExecutedDate = DateTime.Now.ToLocalTime();

//                 await _stageLogs.UpdateAsync(oldLog);

//                 var newLog = new ProspectStageLogs();
//                 newLog.ProspectId = prospect.Id;
//                 newLog.StageId = stageFound.StageId;
//                 newLog.ExecutedBy = request.NamaUser;

//                 await _stageLogs.AddAsync(newLog);

//                 var newApp = await _app.AddAsync(app);

//                 var response = new ProspectProsesResponseDto();

//                 response.AppId = newApp.Id;
//                 response.ProspectId = prospect.Id;
//                 response.Stage = stageFound.Description;
//                 response.Message = "Berhasil diproses ulang ke IDE";

//                 return ServiceResponse<ProspectProsesResponseDto>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 var response = ServiceResponse<ProspectProsesResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//                 response.Success = false;
//                 return response;
//             }
//         }
//     }
// }