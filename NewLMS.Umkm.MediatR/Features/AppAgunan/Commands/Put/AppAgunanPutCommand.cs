// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.AppAgunans;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.AppAgunans.Commands
// {
//     public class AppAgunanPutCommand : AppAgunanPutRequestDto, IRequest<ServiceResponse<AppAgunanResponseDto>>
//     {
//     }

//     public class PutAppAgunanCommandHandler : IRequestHandler<AppAgunanPutCommand, ServiceResponse<AppAgunanResponseDto>>
//     {
//         private readonly IGenericRepositoryAsync<AppAgunan> _AppAgunan;
//         private readonly IMapper _mapper;

//         public PutAppAgunanCommandHandler(IGenericRepositoryAsync<AppAgunan> AppAgunan, IMapper mapper)
//         {
//             _AppAgunan = AppAgunan;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<AppAgunanResponseDto>> Handle(AppAgunanPutCommand request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var existingAppAgunan = await _AppAgunan.GetByIdAsync(request.Id, "Id");
//                 var replacedAgunan = _mapper.Map<AppAgunan>(request);
                
//                 replacedAgunan.Id = existingAppAgunan.Id;

//                 existingAppAgunan.AppId = request.AppId;
//                 existingAppAgunan.RFMappingAgunan2Id = request.RFMappingAgunan2Id;
//                 existingAppAgunan.RFDocumentId = request.RFDocumentId;
//                 existingAppAgunan.NomorDokumen = request.NomorDokumen;
//                 existingAppAgunan.TglTerbitDokumen = request.TglTerbitDokumen;
//                 existingAppAgunan.TglExpireDokumen = request.TglExpireDokumen;
//                 existingAppAgunan.PenerbitDokumen = request.PenerbitDokumen;

//                 existingAppAgunan.RFJenisKendaraanAgunanId = request.RFJenisKendaraanAgunanId;
//                 existingAppAgunan.RFVehMakerId = request.RFVehMakerId;
//                 existingAppAgunan.RFVehClassId = request.RFVehClassId;
//                 existingAppAgunan.RFVehModelId = request.RFVehModelId;
//                 existingAppAgunan.TahunProduksi = request.TahunProduksi;
//                 existingAppAgunan.NomorMesin = request.NomorMesin;
//                 existingAppAgunan.NomorRangka = request.NomorRangka;
//                 existingAppAgunan.KotaDomisiliBerdasarkanSTNK = request.KotaDomisiliBerdasarkanSTNK;

//                 existingAppAgunan.NamaLokasiPasar = request.NamaLokasiPasar;
//                 existingAppAgunan.NoSuratUkur = request.NoSuratUkur;
//                 existingAppAgunan.NoSuratUkurGambarSituasi = request.NoSuratUkurGambarSituasi;
//                 existingAppAgunan.AlamatAgunan = request.AlamatAgunan;
//                 existingAppAgunan.RfZipCodeAgunanId = request.RfZipCodeAgunanId;
//                 existingAppAgunan.KelurahanAgunan = request.KelurahanAgunan;
//                 existingAppAgunan.KecamatanAgunan = request.KecamatanAgunan;
//                 existingAppAgunan.KabupatenKotaAgunan = request.KabupatenKotaAgunan;
//                 existingAppAgunan.PropinsiDokumenAgunan = request.PropinsiDokumenAgunan;
//                 existingAppAgunan.KelurahanDokumenAgunan = request.KelurahanDokumenAgunan;
//                 existingAppAgunan.KecamatanDokumenAgunan = request.KecamatanDokumenAgunan;
//                 existingAppAgunan.KabupatenKotaDokumenAgunan = request.KabupatenKotaDokumenAgunan;
//                 existingAppAgunan.PropinsiDokumenAgunan = request.PropinsiDokumenAgunan;

//                 existingAppAgunan.NamaPemegangHak = request.NamaPemegangHak;
//                 existingAppAgunan.LetakTanah = request.LetakTanah;
//                 existingAppAgunan.PeringkatHT = request.PeringkatHT;
//                 existingAppAgunan.TanggalSuratUkur = request.TanggalSuratUkur;
                
//                 existingAppAgunan.LuasTanah = request.LuasTanah;
//                 existingAppAgunan.LuasBangunan = request.LuasBangunan;
//                 existingAppAgunan.IzinMendirikanBangunan = request.IzinMendirikanBangunan;
//                 existingAppAgunan.NoObjekPajak = request.NoObjekPajak;
//                 existingAppAgunan.NilaiNJOPPBB = request.NilaiNJOPPBB;

//                 existingAppAgunan.AgunanMilikDebitur = request.AgunanMilikDebitur;
//                 existingAppAgunan.RFRelationColId = request.RFRelationColId;
//                 existingAppAgunan.NamaPemilik = request.NamaPemilik;
//                 existingAppAgunan.NomorIDPemilik = request.NomorIDPemilik;
//                 existingAppAgunan.BerlakuSampaiDengan = request.BerlakuSampaiDengan;
//                 existingAppAgunan.SeumurHidup = request.SeumurHidup;
//                 existingAppAgunan.Alamat = request.Alamat;
//                 existingAppAgunan.RfZipCodeId = request.RfZipCodeId;
//                 existingAppAgunan.Kelurahan = request.Kelurahan;
//                 existingAppAgunan.Kecamatan = request.Kecamatan;
//                 existingAppAgunan.KabupatenKota = request.KabupatenKota;
//                 existingAppAgunan.Propinsi = request.Propinsi;
                
//                 existingAppAgunan.NamaPasangan = request.NamaPasangan;
//                 existingAppAgunan.TempatLahirPasangan = request.TempatLahirPasangan;
//                 existingAppAgunan.TanggalLahirPasangan = request.TanggalLahirPasangan;
//                 existingAppAgunan.NomorKTPPasangan = request.NomorKTPPasangan;
//                 existingAppAgunan.BerlakuSampaiDenganPasangan = request.BerlakuSampaiDenganPasangan;
//                 existingAppAgunan.AlamatPasangan = request.AlamatPasangan;
//                 existingAppAgunan.KelurahanPasangan = request.KelurahanPasangan;
//                 existingAppAgunan.KecamatanPasangan = request.KecamatanPasangan;
//                 existingAppAgunan.KabupatenKotaPasangan = request.KabupatenKotaPasangan;
//                 existingAppAgunan.PropinsiPasangan = request.PropinsiPasangan;
//                 existingAppAgunan.SeumurHidupPasangan = request.SeumurHidupPasangan;
//                 existingAppAgunan.NPWPPasangan = request.NPWPPasangan;
//                 existingAppAgunan.PekerjaanPasangan = request.PekerjaanPasangan;
//                 existingAppAgunan.RfZipCodePasanganId = request.RfZipCodePasanganId;
//                 existingAppAgunan.NamaKontakDarurat = request.NamaKontakDarurat;
//                 existingAppAgunan.NoTelpKontakDarurat = request.NoTelpKontakDarurat;

//                 await _AppAgunan.UpdateAsync(replacedAgunan);

//                 var response = _mapper.Map<AppAgunanResponseDto>(replacedAgunan);

//                 return ServiceResponse<AppAgunanResponseDto>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<AppAgunanResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//             }
//         }
//     }
// }