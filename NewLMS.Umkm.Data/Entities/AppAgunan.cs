using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class AppAgunan : BaseEntity
    {
        public Guid Id { get; set; }
        [ForeignKey("AppId")]
        public App App { get; set; }
        [ForeignKey("RFMappingAgunan2Id")]
        public RFMappingAgunan2 JenisJaminan { get; set; }
        [ForeignKey("RFDocumentId")]
        public RFDocument DokumenKepemilikan { get; set; }
        public string NomorDokumen { get; set; }
        public DateTime? TglTerbitDokumen { get; set; }
        public DateTime? TglExpireDokumen { get; set; }
        public string PenerbitDokumen { get; set; }

        // Vehicle
        [ForeignKey("RFJenisKendaraanAgunanId")]
        public RFJenisKendaraanAgunan JenisKendaraan { get; set; }
        [ForeignKey("RFVehMakerId")]
        public RFVEHMAKER Manufaktur { get; set; }
        [ForeignKey("RFVehClassId")]
        public RFVEHCLASS Type { get; set; }
        [ForeignKey("RFVehModelId")]
        public RFVehModel Model { get; set; }
        public string TahunProduksi { get; set; }
        public string NomorMesin { get; set; }
        public string NomorRangka { get; set; }
        public string KotaDomisiliBerdasarkanSTNK { get; set; }

        // Girik/Leter C - Kios/Los/Dasaran/Lapak
        public string NamaLokasiPasar { get; set; }
        public string NoSuratUkur { get; set; }
        public string NoSuratUkurGambarSituasi { get; set; }
        public string AlamatAgunan { get; set; }
        [ForeignKey("RfZipCodeAgunanId")]
        public RfZipCode KodePosAgunan { get; set; }
        public string KelurahanAgunan { get; set; }
        public string KecamatanAgunan { get; set; }
        public string KabupatenKotaAgunan { get; set; }
        public string PropinsiAgunan { get; set; }
        public string KelurahanDokumenAgunan { get; set; }
        public string KecamatanDokumenAgunan { get; set; }
        public string KabupatenKotaDokumenAgunan { get; set; }
        public string PropinsiDokumenAgunan { get; set; }

        // Izin Hak Pemakaian Lainnya - Kios/Los/Dasaran/Lapak
        public string NamaPemegangHak { get; set; }
        public string LetakTanah { get; set; }
        public string PeringkatHT { get; set; }
        public DateTime? TanggalSuratUkur { get; set; }

        // Akta Jual Beli/Sertifkat HGP/SPTB/Tanah Adat - Rumah Tapak
        public double? LuasTanah { get; set; }
        public double? LuasBangunan { get; set; }
        public string IzinMendirikanBangunan { get; set; }
        public string NoObjekPajak { get; set; }
        public string NilaiNJOPPBB { get; set; }
        [ForeignKey("RFJenisAktaId")]
        public RFJenisAkta JenisAkta { get; set; }
        public string BatasUtara { get; set; }
        public string BatasSelatan { get; set; }
        public string BatasBarat { get; set; }
        public string BatasTimur { get; set; }

        // Pemilik Debitur
        public bool? AgunanMilikDebitur { get; set; }
        [ForeignKey("RFRelationColId")]
        public RFRelationCol HubunganDenganDebitur { get; set; }
        public string HubunganLainnya { get; set; }
        public string NamaPemilik { get; set; }
        public string TempatLahirPemilik { get; set; }
        public DateTime? TanggalLahirPemilik { get; set; }
        public string NomorIDPemilik { get; set; }
        public DateTime? BerlakuSampaiDengan { get; set; }
        public bool? SeumurHidup { get; set; }
        public string Alamat { get; set; }
        [ForeignKey("RfZipCodeId")]
        public RfZipCode KodePos { get; set; }
        public string Kelurahan { get; set; }
        public string Kecamatan { get; set; }
        public string KabupatenKota { get; set; }
        public string Propinsi { get; set; }
        public string NPWPPemilik { get; set; }
        public string PekerjaanPemilik { get; set; }
        [ForeignKey("RFMaritalId")]
        public RFMARITAL StatusPernikahan { get; set; }
        public string NamaKontakDarurat { get; set; }
        public string NoTelpKontakDarurat { get; set; }

        // Pasangan
        public string NamaPasangan { get; set; }
        public string TempatLahirPasangan { get; set; }
        public DateTime? TanggalLahirPasangan { get; set; }
        public string NomorKTPPasangan { get; set; }
        public DateTime? BerlakuSampaiDenganPasangan { get; set; }
        public string AlamatPasangan { get; set; }
        [ForeignKey("RfZipCodePasanganId")]
        public RfZipCode KodePosPasangan { get; set; }
        public string KelurahanPasangan { get; set; }
        public string KecamatanPasangan { get; set; }
        public string KabupatenKotaPasangan { get; set; }
        public string PropinsiPasangan { get; set; }
        public bool? SeumurHidupPasangan { get; set; }
        public string NPWPPasangan { get; set; }
        public string PekerjaanPasangan { get; set; }

        public Guid AppId { get; set; }
        public Guid? RFMappingAgunan2Id { get; set; }
        public Guid? RFJenisKendaraanAgunanId { get; set; }
        public Guid? RFDocumentId { get; set; }
        public Guid? RFVehMakerId { get; set; }
        public Guid? RFVehClassId { get; set; }
        public Guid? RFVehModelId { get; set; }
        public Guid? RFRelationColId { get; set; }
        public Guid? RFMaritalId { get; set; }
        public Guid? RFJenisAktaId { get; set; }
        public int? RfZipCodeId { get; set; }
        public int? RfZipCodeAgunanId { get; set; }
        public int? RfZipCodePasanganId { get; set; }
    }
}