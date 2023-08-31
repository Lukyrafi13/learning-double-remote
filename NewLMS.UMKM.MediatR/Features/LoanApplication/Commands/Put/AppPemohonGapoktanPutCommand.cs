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
//     public class AppPemohonGapoktanPutCommand : AppPemohonGapoktan, IRequest<ServiceResponse<Unit>>
//     {

//     }
//     public class AppPemohonGapoktanPutCommandHandler : IRequestHandler<AppPemohonGapoktanPutCommand, ServiceResponse<Unit>>
//     {
//         private readonly IGenericRepositoryAsync<App> _app;
//         private readonly IGenericRepositoryAsync<RfZipCode> _zipCode;
//         private readonly IMapper _mapper;

//         public AppPemohonGapoktanPutCommandHandler(
//             IGenericRepositoryAsync<App> app,
//             IGenericRepositoryAsync<RfZipCode> zipCode,
//             IMapper mapper)
//         {
//             _app = app;
//             _zipCode = zipCode;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<Unit>> Handle(AppPemohonGapoktanPutCommand request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var existingApp = await _app.GetByIdAsync(request.Id, "Id");
                
//                 existingApp.Id = request.Id;
//                 existingApp.NamaCustomer = request.NamaCustomer;
//                 existingApp.NomorTelpon = request.NomorTelpon;
//                 existingApp.JumlahAnggota = request.JumlahAnggota;
//                 existingApp.PemilikBarang = request.PemilikBarang;
//                 existingApp.TanggalAktaPendirian = request.TanggalAktaPendirian;
//                 existingApp.NPWP = request.NPWP;
//                 existingApp.Alamat = request.Alamat;
//                 existingApp.RfZipCodeId = request.RfZipCodeId;
//                 existingApp.Kelurahan = request.Kelurahan;
//                 existingApp.Kecamatan = request.Kecamatan;
//                 existingApp.KabupatenKota = request.KabupatenKota;
//                 existingApp.Propinsi = request.Propinsi;
//                 existingApp.NamaLengkapKetua = request.NamaLengkapKetua;
//                 existingApp.TempatLahirKetua = request.TempatLahirKetua;
//                 existingApp.TanggalLahirKetua = request.TanggalLahirKetua;
//                 existingApp.JabatanKetua = request.JabatanKetua;
//                 existingApp.NoKTPKetua = request.NoKTPKetua;
//                 existingApp.MasaBerlakuKTPKetua = request.MasaBerlakuKTPKetua;
//                 existingApp.NPWPKetua = request.NPWPKetua;
//                 existingApp.NoTelpKetua = request.NoTelpKetua;
//                 existingApp.AlamatKetua = request.AlamatKetua;
//                 existingApp.KelurahanKetua = request.KelurahanKetua;
//                 existingApp.KecamatanKetua = request.KecamatanKetua;
//                 existingApp.KabupatenKotaKetua = request.KabupatenKotaKetua;
//                 existingApp.PropinsiKetua = request.PropinsiKetua;
//                 existingApp.NamaLengkapBendahara = request.NamaLengkapBendahara;
//                 existingApp.TempatLahirBendahara = request.TempatLahirBendahara;
//                 existingApp.TanggalLahirBendahara = request.TanggalLahirBendahara;
//                 existingApp.JabatanBendahara = request.JabatanBendahara;
//                 existingApp.NoKTPBendahara = request.NoKTPBendahara;
//                 existingApp.MasaBerlakuKTPBendahara = request.MasaBerlakuKTPBendahara;
//                 existingApp.NPWPBendahara = request.NPWPBendahara;
//                 existingApp.NoTelpBendahara = request.NoTelpBendahara;
//                 existingApp.AlamatBendahara = request.AlamatBendahara;
//                 existingApp.KelurahanBendahara = request.KelurahanBendahara;
//                 existingApp.KecamatanBendahara = request.KecamatanBendahara;
//                 existingApp.KabupatenKotaBendahara = request.KabupatenKotaBendahara;
//                 existingApp.PropinsiBendahara = request.PropinsiBendahara;
//                 existingApp.LamaUsaha = request.LamaUsaha;
//                 existingApp.JenisKomoditas = request.JenisKomoditas;
//                 existingApp.RFMaritalKetuaId = request.RFMaritalKetuaId;
//                 existingApp.RFEducationKetuaId = request.RFEducationKetuaId;
//                 existingApp.RfZipCodeKetuaId = request.RfZipCodeKetuaId;
//                 existingApp.RFMaritalBendaharaId = request.RFMaritalBendaharaId;
//                 existingApp.RFEducationBendaharaId = request.RFEducationBendaharaId;
//                 existingApp.RfZipCodeBendaharaId = request.RfZipCodeBendaharaId;
                
//                 await _app.UpdateAsync(existingApp);
//                 return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//             }
//         }
//     }
// }