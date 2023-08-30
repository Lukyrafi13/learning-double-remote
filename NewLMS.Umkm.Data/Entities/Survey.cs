using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class Survey : BaseEntity
    {
        public Guid Id { get; set; }

        [ForeignKey("LoanApplicationId")]
        public LoanApplication LoanApplication { get; set; }
        [ForeignKey("RFRelationSurveyId")]
        public RFRelationSurvey HubunganDebitur { get; set; }
        [ForeignKey("RfOwnerCategoryId")]
        public RfOwnerCategory BentukBadanUsaha { get; set; }
        [ForeignKey("RFOwnerOTSId")]
        public RFOwnerOTS StatusTempatUsaha { get; set; }
        // [ForeignKey("RFBusinessTypeId")]
        // public RFBusinessType BidangUsaha { get; set; }
        [ForeignKey("RFBidangUsahaKURId")]
        public RFBidangUsahaKUR BidangUsahaKUR { get; set; }
        [ForeignKey("RfZipCodeId")]
        public RfZipCode KodePos { get; set; }
        [ForeignKey("RFKepemilikanUsahaId")]
        public RFKepemilikanUsaha KepemilikanTempatUsaha { get; set; }
        [ForeignKey("RFLamaUsahaLainId")]
        public RFLamaUsahaLain LamaMenempatiLokasi { get; set; }
        public DateTime? TanggalSurvey { get; set; }
        public string NamaSurveyor { get; set; }
        public string NamaVerifikator { get; set; }
        public string OrangDitemui { get; set; }
        public string NamaPerusahaan { get; set; }
        public string NoTelpPerusahaan { get; set; }
        public int? LamaTahunBerdiri { get; set; }
        public int? LamaBulanBerdiri { get; set; }
        public int? JumlahKaryawan { get; set; }
        public int? JumlahCabang { get; set; }
        public bool? AlamatSamaDenganDebitur { get; set; }
        public string AlamatSurveyor { get; set; }
        public string ProvinsiSurveyor { get; set; }
        public string KabupatenKotaSurveyor { get; set; }
        public string KecamatanSurveyor { get; set; }
        public string KelurahanSurveyor { get; set; }
        public string KesimpulanHasil { get; set; }
        public double? OmsetWawancara { get; set; }
        public double? OmsetObservasi { get; set; }
        public double? OmsetData { get; set; }
        public double? OmsetDiambil { get; set; }
        public double? PenjualanTahunan { get; set; }
        public double? KekayaanBersihDiluarTempatUsaha { get; set; }
        public string DasarPertimbangan { get; set; }
        public double? GPMWawancara { get; set; }
        public double? GPMObservasi { get; set; }
        public double? GPMStandar { get; set; }
        public double? BiayaTenagaKerja { get; set; }
        public double? BiayaListrik { get; set; }
        public double? BiayaAir { get; set; }
        public double? BiayaTelpon { get; set; }
        public double? BiayaHP { get; set; }
        public double? BiayaOperasional { get; set; }
        public double? BiayaRumahTanggaWawancara { get; set; }
        public double? BiayaRumahTanggaHasilVerifikasi { get; set; }
        public double? ModalKerjaStokBarang { get; set; }
        public double? ModalKerjaPiutang { get; set; }
        public double? ModalKerjaHutang { get; set; }
        public bool? SesuaiTargetMarket { get; set; }
        public bool? MasukRadiusCabang { get; set; }
        public bool? UsahaMilikSendiri { get; set; }

        public Guid LoanApplicationId { get; set; }
        public Guid? RFRelationSurveyId { get; set; }
        public Guid? RfOwnerCategoryId { get; set; }
        public Guid? RFOwnerOTSId { get; set; }
        // public Guid? RFBusinessTypeId { get; set; }
        public Guid? RFBidangUsahaKURId { get; set; }
        public int? RfZipCodeId { get; set; }
        public Guid? RFKepemilikanUsahaId { get; set; }
        public Guid? RFLamaUsahaLainId { get; set; }

        public ICollection<ArusKasMasuk> ArusKasMasuks { get;}
        public ICollection<BiayaInvestasi> BiayaInvestasis { get;}
        public ICollection<BiayaTetap> BiayaTetaps { get;}
        public ICollection<BiayaVariabel> BiayaVariabels { get;}
        public ICollection<BiayaVariabelTenagaKerja> BiayaVariabelTenagaKerjas { get;}

        public InformasiOmset InformasiOmset { get; }

        public double? GPMTerendah => Math.Min(Math.Min(GPMObservasi ?? 0.00, GPMWawancara ?? 0.00), GPMStandar ?? 0.00);
        public double? BiayaRumahTanggaKeseluruhan => ((OmsetDiambil ?? 0.00) - HPPNilai - (TotalBiayaUsaha ?? 0.00)) * 10 / 100;
        public double? TotalBiayaUsaha => (BiayaTenagaKerja ?? 0.00) + (BiayaListrik ?? 0.00) + (BiayaAir ?? 0.00) + (BiayaTelpon ?? 0.00) + (BiayaHP ?? 0.00) + (BiayaOperasional ?? 0.00);
        public double? HPPPersen => 100 - (GPMTerendah ?? 0.00);
        public double? HPPNilai => (OmsetDiambil ?? 0.00) * (HPPPersen ?? 0.00) / 100;
        public double? BiayaRumahTanggaTertinggi => Math.Max(Math.Max(BiayaRumahTanggaWawancara ?? 0.00, BiayaRumahTanggaHasilVerifikasi ?? 0.00), BiayaRumahTanggaKeseluruhan ?? 0.00);
        
    }
}