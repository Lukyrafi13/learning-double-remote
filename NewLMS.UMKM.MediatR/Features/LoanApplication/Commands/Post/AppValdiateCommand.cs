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
// using System.Linq;

// namespace NewLMS.UMKM.MediatR.Features.Apps.Commands
// {
//     public class AppValidateCommand : AppFind, IRequest<ServiceResponse<AppValidateResponse>>
//     {

//     }
//     public class AppValidateCommandHandler : IRequestHandler<AppValidateCommand, ServiceResponse<AppValidateResponse>>
//     {
//         private readonly IGenericRepositoryAsync<App> _App;
//         private readonly IGenericRepositoryAsync<RFMARITAL> _RFMARITAL;
//         private readonly IGenericRepositoryAsync<AppKeyPerson> _AppKeyPerson;
//         private readonly IGenericRepositoryAsync<AppAgunan> _AppAgunan;
//         private readonly IGenericRepositoryAsync<AppFasilitasKredit> _AppFasilitasKredit;
//         private readonly IMapper _mapper;

//         public AppValidateCommandHandler(
//             IGenericRepositoryAsync<App> App,
//             IGenericRepositoryAsync<RFMARITAL> RFMARITAL,
//             IGenericRepositoryAsync<AppKeyPerson> AppKeyPerson,
//             IGenericRepositoryAsync<AppAgunan> AppAgunan,
//             IGenericRepositoryAsync<AppFasilitasKredit> AppFasilitasKredit,
//             IMapper mapper)
//         {
//             _App = App;
//             _AppKeyPerson = AppKeyPerson;
//             _AppAgunan = AppAgunan;
//             _AppFasilitasKredit = AppFasilitasKredit;
//             _RFMARITAL = RFMARITAL;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<AppValidateResponse>> Handle(AppValidateCommand request, CancellationToken cancellationToken)
//         {

//             try
//             {
//                 var App = await _App.GetByIdAsync(request.Id, "Id", new string[] { "JenisProduk", "TipeDebitur" });
//                 var invalidCounter = 0;
//                 var errorMessage = "";

//                 // Tab IDE
//                 if (App.SiklusUsaha ?? false)
//                 {
//                     invalidCounter += App.RFSiklusUsahaPokokId != null ? 0 : 1;
//                     invalidCounter += App.SiklusUsahaMonth != null ? 0 : 1;
//                 }

//                 invalidCounter += App.RfBranchesId != null ? 0 : 1;


//                 if (App.JenisProduk.ProductType == "KUR")
//                 {
//                     if (App.TipeDebitur.OwnDesc.ToLower() == "Perorangan".ToLower())
//                     {

//                         invalidCounter += App.RFSCOReputasiTempatTinggalId != null ? 0 : 1;
//                         invalidCounter += App.RFSCOTingkatKebutuhanId != null ? 0 : 1;
//                         invalidCounter += App.RFSCOCaraTransaksiId != null ? 0 : 1;
//                         invalidCounter += App.RFSCOPengelolaKeuanganId != null ? 0 : 1;
//                         invalidCounter += App.RFSCOHutangPihakLainId != null ? 0 : 1;
//                         invalidCounter += App.RFSCOLokTempatUsahaId != null ? 0 : 1;
//                         invalidCounter += App.RFSCOHubunganPerbankanId != null ? 0 : 1;
//                         invalidCounter += App.RFSCOMutasiPerBulanId != null ? 0 : 1;
//                         invalidCounter += App.RFSCORiwayatKreditBJBId != null ? 0 : 1;
//                         invalidCounter += App.RFSCOScoringAgunanId != null ? 0 : 1;
//                         invalidCounter += App.RFSCOSaldoRekRataId != null ? 0 : 1;
//                     }
//                 }

//                 if (invalidCounter > 1 && errorMessage == "")
//                 {
//                     errorMessage += " Data IDE belum lengkap";
//                 }

//                 // Data Pemohon
//                 if (App.JenisProduk.ProductType == "KUR")
//                 {
//                     if (App.TipeDebitur.OwnDesc.ToLower() == "Perorangan".ToLower())
//                     {

//                         invalidCounter += App.NamaCustomer != null ? 0 : 1;
//                         invalidCounter += App.TempatLahir != null ? 0 : 1;
//                         invalidCounter += App.TanggalLahir != null ? 0 : 1;
//                         invalidCounter += App.NomorKTP != null ? 0 : 1;
//                         invalidCounter += App.SeumurHidup != null ? 0 : 1;
//                         invalidCounter += App.NomorTelpon != null ? 0 : 1;
//                         invalidCounter += App.RFEducationId != null ? 0 : 1;
//                         invalidCounter += App.NamaIbuKandung != null ? 0 : 1;
//                         invalidCounter += App.JumlahTanggungan != null ? 0 : 1;
//                         invalidCounter += App.NPWP != null ? 0 : 1;
//                         invalidCounter += App.RFMaritalId != null ? 0 : 1;
//                         invalidCounter += App.RFJobId != null ? 0 : 1;

//                         // check marital
//                         if (App.RFMaritalId != null)
//                         {
//                             var marital = await _RFMARITAL.GetByIdAsync((Guid)App.RFMaritalId, "Id");

//                             if (marital.MR_DESCSIKP.ToLower() == "Kawin".ToLower())
//                             {
//                                 invalidCounter += App.NomorAktaNikah != null ? 0 : 1;
//                                 invalidCounter += App.TanggalAktaNikah != null ? 0 : 1;
//                                 invalidCounter += App.PembuatAktaNikah != null ? 0 : 1;
//                                 invalidCounter += App.RFJobPasanganId != null ? 0 : 1;
//                                 invalidCounter += App.NamaLengkapPasangan != null ? 0 : 1;
//                                 invalidCounter += App.NoKTPPasangan != null ? 0 : 1;
//                                 invalidCounter += App.NPWPPasangan != null ? 0 : 1;
//                                 invalidCounter += App.RFJobPasanganId != null ? 0 : 1;
//                                 invalidCounter += App.TempatLahirPasangan != null ? 0 : 1;
//                                 invalidCounter += App.TanggalLahirPasangan != null ? 0 : 1;
//                                 invalidCounter += App.AlamatPasangan != null ? 0 : 1;
//                                 invalidCounter += App.RfZipCodePasanganId != null ? 0 : 1;
//                                 invalidCounter += App.PropinsiPasangan != null ? 0 : 1;
//                                 invalidCounter += App.KabupatenKotaPasangan != null ? 0 : 1;
//                                 invalidCounter += App.KecamatanPasangan != null ? 0 : 1;
//                                 invalidCounter += App.KelurahanPasangan != null ? 0 : 1;

//                             }
//                         }


//                         invalidCounter += App.NamaKontakDarurat != null ? 0 : 1;
//                         invalidCounter += App.NomorKTP != null ? 0 : 1;
//                         invalidCounter += App.Alamat != null ? 0 : 1;
//                         invalidCounter += App.RfZipCodeId != null ? 0 : 1;
//                         invalidCounter += App.Propinsi != null ? 0 : 1;
//                         invalidCounter += App.KabupatenKota != null ? 0 : 1;
//                         invalidCounter += App.Kecamatan != null ? 0 : 1;
//                         invalidCounter += App.Kelurahan != null ? 0 : 1;


//                         if (invalidCounter > 1 && errorMessage == "")
//                         {
//                             errorMessage += " Data pemohon belum lengkap";
//                         }
//                     }


//                     if (App.TipeDebitur.OwnDesc.ToLower() == "Badan Usaha".ToLower())
//                     {
//                         invalidCounter += App.NamaCustomer != null ? 0 : 1;
//                         invalidCounter += App.Alamat != null ? 0 : 1;
//                         invalidCounter += App.RfZipCodeId != null ? 0 : 1;
//                         invalidCounter += App.Propinsi != null ? 0 : 1;
//                         invalidCounter += App.KabupatenKota != null ? 0 : 1;
//                         invalidCounter += App.Kecamatan != null ? 0 : 1;
//                         invalidCounter += App.Kelurahan != null ? 0 : 1;
//                         invalidCounter += App.NomorTelpon != null ? 0 : 1;

//                         invalidCounter += App.NamaKontakDarurat != null ? 0 : 1;
//                         invalidCounter += App.AlamatKontakDarurat != null ? 0 : 1;
//                         invalidCounter += App.RfZipCodeKontakDaruratId != null ? 0 : 1;
//                         invalidCounter += App.PropinsiKontakDarurat != null ? 0 : 1;
//                         invalidCounter += App.KabupatenKotaKontakDarurat != null ? 0 : 1;
//                         invalidCounter += App.KecamatanKontakDarurat != null ? 0 : 1;
//                         invalidCounter += App.KelurahanKontakDarurat != null ? 0 : 1;
//                         invalidCounter += App.NoTelpKontakDarurat != null ? 0 : 1;

//                         invalidCounter += App.NomorAktaPendirian != null ? 0 : 1;
//                         invalidCounter += App.TanggalAktaPendirian != null ? 0 : 1;
//                         invalidCounter += App.NomorAktaPendirian != null ? 0 : 1;
//                         invalidCounter += App.TanggalSK != null ? 0 : 1;
//                         invalidCounter += App.NPWP != null ? 0 : 1;
//                         invalidCounter += App.PerubahanAktaTerakhir != null ? 0 : 1;
//                         invalidCounter += App.TanggalAkta != null ? 0 : 1;
//                         invalidCounter += App.NomorSIUP != null ? 0 : 1;
//                         invalidCounter += App.TanggalSIUP != null ? 0 : 1;
//                         invalidCounter += App.NomorTDP != null ? 0 : 1;
//                         invalidCounter += App.TanggalTDP != null ? 0 : 1;
//                         invalidCounter += App.TanggalJatuhTempoTDP != null ? 0 : 1;
//                         invalidCounter += App.NomorSKDP != null ? 0 : 1;
//                         invalidCounter += App.TanggalSKDP != null ? 0 : 1;
//                         invalidCounter += App.TanggalJatuhTempoSK != null ? 0 : 1;
//                         if (invalidCounter > 1 && errorMessage == "")
//                         {
//                             errorMessage += " Data pemohon belum lengkap";
//                         }

//                         // Check App Key Person
//                         invalidCounter += (await _AppKeyPerson.GetListByPredicate(x => x.AppId == App.Id)).Count > 0 ? 0 : 1;
//                         if (invalidCounter > 1 && errorMessage == "")
//                         {
//                             errorMessage += " Data Key Person masih kosong";
//                         }
//                     }

//                     invalidCounter += App.RFPilihanPemutusId != null ? 0 : 1;
//                     if (invalidCounter > 1 && errorMessage == "")
//                     {
//                         errorMessage += " Data pemutus belum lengkap";
//                     }

//                     var ListFasilitasKredit = await _AppFasilitasKredit.GetListByPredicate(x => x.AppId == App.Id);

//                     invalidCounter += ListFasilitasKredit.Count > 0 ? 0 : 1;

//                     if (invalidCounter > 1 && errorMessage == "")
//                     {
//                         errorMessage += " Data Fasilitas Kredit masih kosong";
//                     }

//                     var jumlahAgunan = (await _AppAgunan.GetListByPredicate(x => x.AppId == App.Id)).Count;
//                     invalidCounter += jumlahAgunan > 0 ? 0 : ListFasilitasKredit.Sum(x=>x.PlafondYangDiajukan) > 100000000? 1 : 0;

//                     if (invalidCounter > 1 && errorMessage == "")
//                     {
//                         errorMessage += " Data agunan masih kosong dan jumlah plafon melebihi 100 juta";
//                     }
//                 }

//                 var valid = invalidCounter == 0;

//                 var message = valid ? "App Valid" : "App Invalid";

//                 var response = new AppValidateResponse
//                 {
//                     Id = request.Id,
//                     valid = valid,
//                     message = message + errorMessage
//                 };

//                 return ServiceResponse<AppValidateResponse>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<AppValidateResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//             }
//         }
//     }
// }