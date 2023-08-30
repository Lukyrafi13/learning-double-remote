using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NewLMS.UMKM.Data
{
    public class App : BaseEntity
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20)]

        // Turunan Prospect
        public string AplikasiId { get; set; }
        [ForeignKey("DebiturId")]
        public Debitur Debitur { get; set; }
        [ForeignKey("RfProductId")]
        public RfProduct JenisProduk { get; set; }
        [ForeignKey("ProspectId")]
        public Prospect Prospect { get; set; }
        [ForeignKey("RfOwnerCategoryId")]
        public RfOwnerCategory TipeDebitur { get; set; }

        // Credit Scoring
        [ForeignKey("RFSCOReputasiTempatTinggalId")]
        public RFSCOREPUTASITEMPATTINGGAL ReputasiTempatTinggal { get; set; }
        [ForeignKey("RFSCOTingkatKebutuhanId")]
        public RFSCOTINGKATKEBUTUHAN TingkatKebutuhan { get; set; }
        [ForeignKey("RFSCOCaraTransaksiId")]
        public RFSCOCARATRANSAKSI CaraTransaksi { get; set; }
        [ForeignKey("RFSCOPengelolaKeuanganId")]
        public RFSCOPENGELOLAKEUANGAN PengelolaKeuangan { get; set; }
        [ForeignKey("RFSCOHutangPihakLainId")]
        public RFSCOHUTANGPIHAKLAIN HutangPihakLain { get; set; }
        [ForeignKey("RFSCOLokTempatUsahaId")]
        public RFSCOLOKTEMPATUSAHA LokTempatUsaha { get; set; }
        [ForeignKey("RFSCOHubunganPerbankanId")]
        public RFSCOHUBUNGANPERBANKAN HubunganPerbankan { get; set; }
        [ForeignKey("RFSCOMutasiPerBulanId")]
        public RFSCOMUTASIPERBULAN MutasiPerBulan { get; set; }
        [ForeignKey("RFSCORiwayatKreditBJBId")]
        public RFSCORiwayatKreditBJB RiwayatKreditBJB { get; set; }
        [ForeignKey("RFSCOScoringAgunanId")]
        public RFSCOSCORINGAGUNAN ScoringAgunan { get; set; }
        [ForeignKey("RFSCOSaldoRekRataId")]
        public RFSCOSALDOREKRATA SaldoRekRata { get; set; }
        [ForeignKey("RFSiklusUsahaId")]
        public int? SiklusUsahaMonth { get; set; }
        public RfBusinessPrimaryCycle SiklusUsahaPokok { get; set; }
        public bool? SiklusUsaha { get; set; }

        public string NamaCustomer { get; set; }
        public string TempatLahir { get; set; }
        public DateTime? TanggalLahir { get; set; }
        public string NomorKTP { get; set; }
        public DateTime? BerlakuSampaiDengan { get; set; }
        public bool? SeumurHidup { get; set; }
        public string NomorTelpon { get; set; }
        // public Guid? KewarganegaraanId { get; set; }
        public string Alamat { get; set; }
        [ForeignKey("RfZipCodeId")]
        public RfZipCode KodePos { get; set; }
        public string Kelurahan { get; set; }
        public string Kecamatan { get; set; }
        public string KabupatenKota { get; set; }
        public string Propinsi { get; set; }
        public string NamaKontakDarurat { get; set; }
        public string NoTelpKontakDarurat { get; set; }
        public string NPWP { get; set; }

        // (KMU/KUR/Perorangan)
        public string NamaIbuKandung { get; set; }
        public string RT { get; set; }
        public string RW { get; set; }
        public int? LamaTinggal { get; set; }
        public int? JumlahTanggungan { get; set; }
        [ForeignKey("RFHomestaId")]
        public RFHOMESTA StatusTempatTinggal { get; set; }
        [ForeignKey("RFEducationId")]
        public RFEDUCATION PendidikanTerakhir { get; set; }
        [ForeignKey("RFMaritalId")]
        public RFMARITAL StatusPerkawinan { get; set; }
        [ForeignKey("RFJobId")]
        public RFJOB DataPekerjaan { get; set; }
        public string NoKTPKontakDarurat { get; set; }
        public string AlamatKontakDarurat { get; set; }
        public string RTKontakDarurat { get; set; }
        public string RWKontakDarurat { get; set; }
        [ForeignKey("RfZipCodeKontakDaruratId")]
        public RfZipCode KodePosKontakDarurat { get; set; }
        public string KelurahanKontakDarurat { get; set; }
        public string KecamatanKontakDarurat { get; set; }
        public string KabupatenKotaKontakDarurat { get; set; }
        public string PropinsiKontakDarurat { get; set; }
        // Kalau sudah menikah 
        public string NomorAktaNikah { get; set; }
        public DateTime? TanggalAktaNikah { get; set; }
        public string PembuatAktaNikah { get; set; }
        public string NamaLengkapPasangan { get; set; }
        public string NoKTPPasangan { get; set; }
        public string NPWPPasangan { get; set; }
        [ForeignKey("RFJobPasanganId")]
        public RFJOB DataPekerjaanPasangan { get; set; }
        public string TempatLahirPasangan { get; set; }
        public DateTime? TanggalLahirPasangan { get; set; }
        public bool AlamatSamaDenganDebitur { get; set; }
        public string AlamatPasangan { get; set; }
        public string RTPasangan { get; set; }
        public string RWPasangan { get; set; }
        [ForeignKey("RfZipCodePasanganId")]
        public RfZipCode KodePosPasangan { get; set; }
        public string KelurahanPasangan { get; set; }
        public string KecamatanPasangan { get; set; }
        public string KabupatenKotaPasangan { get; set; }
        public string PropinsiPasangan { get; set; }

        // (KMU/KUR/Badan Usaha)

        // Legalitas Badan Usaha

        public string NomorAktaPendirian { get; set; }
        public DateTime? TanggalAktaPendirian { get; set; }
        public string NomorPendaftaran { get; set; }
        public DateTime? TanggalSK { get; set; }
        public string PerubahanAktaTerakhir { get; set; }
        public DateTime? TanggalAkta { get; set; }
        public string NomorSIUP { get; set; }
        public DateTime? TanggalSIUP { get; set; }
        public string NomorTDP { get; set; }
        public DateTime? TanggalTDP { get; set; }
        public DateTime? TanggalJatuhTempoTDP { get; set; }
        public string NomorSKDP { get; set; }
        public DateTime? TanggalSKDP { get; set; }
        public DateTime? TanggalJatuhTempoSK { get; set; }

        // (KRG - Gapoktan, Kelompok Tani, Koperasi)

        public int? JumlahAnggota { get; set; }
        public string PemilikBarang { get; set; }
        // Ketua
        public string NamaLengkapKetua { get; set; }
        public string TempatLahirKetua { get; set; }
        public DateTime? TanggalLahirKetua { get; set; }
        public string JabatanKetua { get; set; }
        public string NoKTPKetua { get; set; }
        public DateTime? MasaBerlakuKTPKetua { get; set; }
        public string NPWPKetua { get; set; }
        [ForeignKey("RFMaritalKetuaId")]
        public RFMARITAL StatusPerkawinanKetua { get; set; }
        [ForeignKey("RFEducationKetuaId")]
        public RFEDUCATION PendidikanTerakhirKetua { get; set; }
        public string NoTelpKetua { get; set; }
        public string AlamatKetua { get; set; }
        [ForeignKey("RfZipCodeKetuaId")]
        public RfZipCode KodePosKetua { get; set; }
        public string KelurahanKetua { get; set; }
        public string KecamatanKetua { get; set; }
        public string KabupatenKotaKetua { get; set; }
        public string PropinsiKetua { get; set; }
        // Bendahara
        public string NamaLengkapBendahara { get; set; }
        public string TempatLahirBendahara { get; set; }
        public DateTime? TanggalLahirBendahara { get; set; }
        public string JabatanBendahara { get; set; }
        public string NoKTPBendahara { get; set; }
        public DateTime? MasaBerlakuKTPBendahara { get; set; }
        public string NPWPBendahara { get; set; }
        [ForeignKey("RFMaritalBendaharaId")]
        public RFMARITAL StatusPerkawinanBendahara { get; set; }
        [ForeignKey("RFEducationBendaharaId")]
        public string NoTelpBendahara { get; set; }
        public RFEDUCATION PendidikanTerakhirBendahara { get; set; }
        public string AlamatBendahara { get; set; }
        [ForeignKey("RfZipCodeBendaharaId")]
        public RfZipCode KodePosBendahara { get; set; }
        public string KelurahanBendahara { get; set; }
        public string KecamatanBendahara { get; set; }
        public string KabupatenKotaBendahara { get; set; }
        public string PropinsiBendahara { get; set; }

        // Informasi Usaha
        public int? LamaUsaha { get; set; }
        public string JenisKomoditas { get; set; }

        // (KRG - Perorangan)

        public string NoResi { get; set; }
        public string NoSeriResiGudang { get; set; }
        public string NamaPemilikResi { get; set; }
        public DateTime? TglTerbitResi { get; set; }
        public DateTime? TglJatuhTempoResiGudang { get; set; }
        public string JenisBarang { get; set; }
        public double? JumlahBarangKg { get; set; }
        public double? NilaiBarang { get; set; }
        public string LokasiGudangPenyimpanan { get; set; }
        public string NamaLengkapPengelola { get; set; }
        public string NoKTPPengelola { get; set; }
        public DateTime? TglLahirPengelola { get; set; }


        // etc
        public string SumberData { get; set; }
        [ForeignKey("RfBranchesId")]
        public RfBranch BookingOffice { get; set; }
        [ForeignKey("RFPilihanPemutusId")]
        public RFPilihanPemutus PilihanPemutus { get; set; }
        public string NamaAO { get; set; }
        public string KodeCabang { get; set; }
        public string NamaCabang { get; set; }

        // Other stage
        public SlikRequest SlikRequest {get; set; }


        // Foreign keys
        public Guid? DebiturId { get; set; }
        public Guid? RfProductId { get; set; }
        public Guid? RfOwnerCategoryId { get; set; }
        public Guid? RFSCOReputasiTempatTinggalId { get; set; }
        public Guid? RFSCOTingkatKebutuhanId { get; set; }
        public Guid? RFSCOCaraTransaksiId { get; set; }
        public Guid? RFSCOPengelolaKeuanganId { get; set; }
        public Guid? RFSCOHutangPihakLainId { get; set; }
        public Guid? RFSCOLokTempatUsahaId { get; set; }
        public Guid? RFSCOHubunganPerbankanId { get; set; }
        public Guid? RFSCOMutasiPerBulanId { get; set; }
        public Guid? RFSCORiwayatKreditBJBId { get; set; }
        public Guid? RFSCOScoringAgunanId { get; set; }
        public Guid? RFSCOSaldoRekRataId { get; set; }
        public int? RfZipCodeId { get; set; }
        public Guid? RFEducationId { get; set; }
        public Guid? RFMaritalId { get; set; }
        public Guid? RFJobId { get; set; }
        public Guid? RFHomestaId { get; set; }
        public int? RfZipCodeKontakDaruratId { get; set; }
        public Guid? RFJobPasanganId { get; set; }
        public int? RfZipCodePasanganId { get; set; }
        public string? RfBranchesId { get; set; }
        public Guid? ProspectId { get; set; }
        public Guid? RFMaritalKetuaId { get; set; }
        public Guid? RFEducationKetuaId { get; set; }
        public int? RfZipCodeKetuaId { get; set; }
        public Guid? RFMaritalBendaharaId { get; set; }
        public Guid? RFEducationBendaharaId { get; set; }
        public int? RfZipCodeBendaharaId { get; set; }
        public Guid? RFPilihanPemutusId { get; set; }
        // public Guid? RFSiklusUsahaId { get; set; }
        public Guid? RFSiklusUsahaPokokId { get; set; }
    }
}