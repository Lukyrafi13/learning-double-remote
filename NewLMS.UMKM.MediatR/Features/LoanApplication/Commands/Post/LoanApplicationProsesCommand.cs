// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.Apps;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.Apps.Commands
// {
//     public class AppProsesCommand : AppFind, IRequest<ServiceResponse<AppProsesResponseDto>>
//     {
//         public string NamaUser { get; set; }
//     }
//     public class AppProsesCommandHandler : IRequestHandler<AppProsesCommand, ServiceResponse<AppProsesResponseDto>>
//     {
//         private readonly IGenericRepositoryAsync<App> _App;
//         private readonly IGenericRepositoryAsync<AppKeyPerson> _AppKeyPerson;
//         private readonly IGenericRepositoryAsync<AppAgunan> _AppAgunan;
//         private readonly IGenericRepositoryAsync<Prospect> _Prospect;
//         private readonly IGenericRepositoryAsync<SlikRequest> _SlikRequest;
//         private readonly IGenericRepositoryAsync<SlikRequestObject> _SlikRequestObject;
//         private readonly IGenericRepositoryAsync<SIKPCalonDebitur> _SIKPCalonDebitur;
//         private readonly IGenericRepositoryAsync<RFStages> _stages;
//         private readonly IGenericRepositoryAsync<ProspectStageLogs> _stageLogs;
//         private readonly IMapper _mapper;

//         public AppProsesCommandHandler(
//                 IGenericRepositoryAsync<App> App,
//                 IGenericRepositoryAsync<AppKeyPerson> AppKeyPerson,
//                 IGenericRepositoryAsync<AppAgunan> AppAgunan,
//                 IGenericRepositoryAsync<Prospect> Prospect,
//                 IGenericRepositoryAsync<SlikRequest> SlikRequest,
//                 IGenericRepositoryAsync<SlikRequestObject> SlikRequestObject,
//                 IGenericRepositoryAsync<SIKPCalonDebitur> SIKPCalonDebitur,
//                 IGenericRepositoryAsync<RFStages> stages,
//                 IGenericRepositoryAsync<ProspectStageLogs> stageLogs,
//                 IMapper mapper
//             )
//         {
//             _App = App;
//             _AppKeyPerson = AppKeyPerson;
//             _AppAgunan = AppAgunan;
//             _Prospect = Prospect;
//             _SlikRequest = SlikRequest;
//             _SlikRequestObject = SlikRequestObject;
//             _SIKPCalonDebitur = SIKPCalonDebitur;
//             _stages = stages;
//             _stageLogs = stageLogs;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<AppProsesResponseDto>> Handle(AppProsesCommand request, CancellationToken cancellationToken)
//         {

//             try
//             {
//                 var App = await _App.GetByIdAsync(request.Id, "Id",
//                     new string[] {
//                         "Prospect",
//                         "Prospect.Stage",
//                         "JenisProduk",
//                         "TipeDebitur"
//                     }
//                 );
//                 if (App == null)
//                 {
//                     var failResp = ServiceResponse<AppProsesResponseDto>.Return404("Data App not found");
//                     failResp.Success = false;
//                     return failResp;
//                 }

//                 // Change App status
//                 RFStages stageFound;
//                 if (App.JenisProduk.ProductType == "KUR")
//                 {
//                     stageFound = await _stages.GetByPredicate(x => x.Code == "3.0");
//                 }
//                 else
//                 {
//                     stageFound = await _stages.GetByPredicate(x => x.Code == "4.2.1");
//                 }
//                 var previousStage = await _stages.GetByPredicate(x => x.Code == "2.0");

//                 if (App.Prospect.Stage.Code == "4.2.1")
//                 {
//                     var failResp = ServiceResponse<AppProsesResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "App sudah diproses sebelumnya");
//                     failResp.Success = false;
//                     return failResp;
//                 }

//                 if (App.Prospect.Stage.Code == "0.0")
//                 {
//                     var failResp = ServiceResponse<AppProsesResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "App sudah ditolak sebelumnya");
//                     failResp.Success = false;
//                     return failResp;
//                 }

//                 App.Prospect.RFStagesId = stageFound.StageId;
//                 App.Prospect.Stage = stageFound;

//                 await _Prospect.UpdateAsync(App.Prospect);

//                 // Update App History
//                 var oldLog = await _stageLogs.GetByPredicate(x => x.Prospect.Id == App.Prospect.Id && x.StageId == previousStage.StageId);
//                 oldLog.ModifiedDate = DateTime.Now;
//                 oldLog.ExecutedDate = DateTime.Now.ToLocalTime();

//                 await _stageLogs.UpdateAsync(oldLog);

//                 var newLog = new ProspectStageLogs();
//                 newLog.ProspectId = App.Prospect.Id;
//                 newLog.StageId = stageFound.StageId;
//                 newLog.ExecutedBy = request.NamaUser;

//                 await _stageLogs.AddAsync(newLog);

//                 var response = new AppProsesResponseDto();


//                 if (App.JenisProduk.ProductType == "KUR")
//                 {

//                     // Assign New SIKP
//                     var SIKP = new SIKPCalonDebitur();

//                     SIKP.AppId = App.Id;

//                     SIKP.RfOwnerCategoryId = App.RfOwnerCategoryId;
//                     SIKP.NoKTP = App.NomorKTP;
//                     SIKP.RfSectorLBU1Code = App.Prospect.RfSectorLBU1Code;
//                     SIKP.RfSectorLBU2Code = App.Prospect.RfSectorLBU2Code;
//                     SIKP.RfSectorLBU3Code = App.Prospect.RfSectorLBU3Code;
//                     SIKP.NPWP = App.NPWP;
//                     SIKP.NamaDebitur = App.NamaCustomer;
//                     SIKP.TanggalLahir = App.TanggalLahir;
//                     SIKP.RfGenderId = App.Prospect.RfGenderId;
//                     SIKP.RFMaritalId = App.RFMaritalId;
//                     SIKP.RFEducationId = App.RFEducationId;
//                     SIKP.RFJobId = App.RFJobId;
//                     SIKP.Alamat = App.Alamat;
//                     SIKP.Propinsi = App.Propinsi;
//                     SIKP.KabupatenKota = App.KabupatenKota;
//                     SIKP.Kecamatan = App.Kecamatan;
//                     SIKP.Kelurahan = App.Kelurahan;
//                     SIKP.RfZipCodeId = App.RfZipCodeId;

//                     SIKP.AlamatUsaha = App.Prospect.AlamatUsaha;
//                     SIKP.PropinsiUsaha = App.Prospect.PropinsiUsaha;
//                     SIKP.KabupatenKotaUsaha = App.Prospect.KabupatenKotaUsaha;
//                     SIKP.KecamatanUsaha = App.Prospect.KecamatanUsaha;
//                     SIKP.KelurahanUsaha = App.Prospect.KelurahanUsaha;
//                     SIKP.RfZipCodeUsahaId = App.Prospect.RfZipCodeUsahaId;


//                     var newSIKP = await _SIKPCalonDebitur.AddAsync(SIKP);
//                     response.SIKPId = newSIKP.Id;
//                 }
//                 else
//                 {

//                     var SlikRequest = new SlikRequest
//                     {
//                         ProcessStatus = 0,
//                         AdminVerified = 0,
//                     };

//                     SlikRequest.AppId = App.Id;

//                     var newSlikRequest = await _SlikRequest.AddAsync(SlikRequest);
//                     response.SLIKId = SlikRequest.Id;

//                     // Input pemohon
//                     if (App.JenisProduk.ProductType.ToLower() == "KMU".ToLower())
//                     {
//                         if (App.TipeDebitur.OwnDesc.ToLower() == "Perorangan".ToLower())
//                         {
//                             // Tipe Debitur
//                             var SilkReqObj = new SlikRequestObject
//                             {
//                                 SlikObjectTypeId = 1,
//                                 SlikRequestId = SlikRequest.Id,
//                                 Fullname = App.NamaCustomer,
//                                 NPWP = App.NPWP,
//                                 NoIdentity = App.NomorKTP,
//                                 DateOfBirth = (DateTime)App.TanggalLahir,
//                                 PlaceOfBirth = App.TempatLahir,
//                                 ApplicationStatus = "Perorangan",
//                                 RoboSlik = false,
//                             };

//                             await _SlikRequestObject.AddAsync(SilkReqObj);
//                         }
//                         if (App.TipeDebitur.OwnDesc.ToLower() == "Badan Usaha".ToLower())
//                         {
//                             // Key Person
//                             var AppKeyPersons = await _AppKeyPerson.GetListByPredicate(x => x.AppId == App.Id);

//                             foreach (var appKeyPerson in AppKeyPersons)
//                             {
//                                 var SilkReqObj = new SlikRequestObject
//                                 {
//                                     SlikObjectTypeId = 1,
//                                     SlikRequestId = SlikRequest.Id,
//                                     Fullname = appKeyPerson.Nama,
//                                     NPWP = appKeyPerson.NPWP,
//                                     NoIdentity = appKeyPerson.NoKTP,
//                                     DateOfBirth = (DateTime)appKeyPerson.TanggalLahir,
//                                     PlaceOfBirth = appKeyPerson.TempatLahir,
//                                     ApplicationStatus = "Perorangan",
//                                     RoboSlik = false,
//                                 };
//                                 await _SlikRequestObject.AddAsync(SilkReqObj);
//                             }
//                         }
//                     }

//                     // Pemilik Agunan
//                     var agunans = await _AppAgunan.GetListByPredicate(x => x.AppId == App.Id);

//                     foreach (var agunan in agunans)
//                     {
//                         var SilkReqObj = new SlikRequestObject
//                         {
//                             SlikObjectTypeId = 1,
//                             SlikRequestId = SlikRequest.Id,
//                             Fullname = agunan.NamaPemilik,
//                             NPWP = agunan.NPWPPemilik,
//                             NoIdentity = agunan.NomorIDPemilik,
//                             DateOfBirth = (DateTime)agunan.TanggalLahirPemilik,
//                             PlaceOfBirth = agunan.TempatLahirPemilik,
//                             ApplicationStatus = "Perorangan",
//                             RoboSlik = false,
//                         };
//                         await _SlikRequestObject.AddAsync(SilkReqObj);
//                     }
//                 }

//                 response.AppId = App.Id;
//                 response.Stage = stageFound.Description;
//                 response.Message = "App berhasil diproses ke SLIK";

//                 return ServiceResponse<AppProsesResponseDto>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 var response = ServiceResponse<AppProsesResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//                 response.Success = false;
//                 return response;
//             }
//         }
//     }
// }