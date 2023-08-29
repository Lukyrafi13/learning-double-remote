using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class SPPK : BaseEntity
    {
        public Guid Id { get; set; }

        [ForeignKey("AppId")]
        public App App { get; set; }

        [ForeignKey("AnalisaId")]
        public Analisa Analisa { get; set; }

        // Halaman Utama
        [ForeignKey("RFJabatanSKK1Id")]
        public SCJabatan JabatanSKK1 { get; set; }

        [ForeignKey("RFJabatanSKK2Id")]
        public SCJabatan JabatanSKK2 { get; set; }

        [ForeignKey("RFJabatanSPPK1Id")]
        public SCJabatan JabatanSPPK1 { get; set; }

        [ForeignKey("RFJabatanSPPK2Id")]
        public SCJabatan JabatanSPPK2 { get; set; }

        [ForeignKey("RFJabatanMKK1Id")]
        public SCJabatan JabatanMKK1 { get; set; }

        [ForeignKey("RFJabatanMKK2Id")]
        public SCJabatan JabatanMKK2 { get; set; }

        [ForeignKey("RFJabatanMKK3Id")]
        public SCJabatan JabatanMKK3 { get; set; }

        [ForeignKey("RFJabatanMKK4Id")]
        public SCJabatan JabatanMKK4 { get; set; }

        [ForeignKey("RFJabatanMKK5Id")]
        public SCJabatan JabatanMKK5 { get; set; }

        // Halaman Utama
        public string NomorRekeningEksternalDebitur { get; set; }
        public string NomorRekeningInternalDebitur { get; set; }
        public string NomorCIFDebitur { get; set; }
        public string AtasNamaDebitur { get; set; }
        public string NomorRekeningEksternalPencairan { get; set; }
        public string NomorRekeningInternalPencairan { get; set; }
        public string NomorCIFPencairan { get; set; }
        public string AtasNamaPencairan { get; set; }
        public double? TotalPlafond { get; set; }
        public double? TotalBiayaBiaya { get; set; }
        public double? NominalYangDicairkan { get; set; }
        public string NomorRekeningEksternalBunga { get; set; }
        public string NomorRekeningInternalBunga { get; set; }
        public string NomorCIFBunga { get; set; }
        public string AtasNamaBunga { get; set; }
        public string NomorRekeningEksternalPokok { get; set; }
        public string NomorRekeningInternalPokok { get; set; }
        public string NomorCIFPokok { get; set; }
        public string AtasNamaPokok { get; set; }
        public string CatatanLainnya { get; set; }
        public string AccountOfficeCode { get; set; }
        public string NoSKK { get; set; }
        public DateTime? TanggalSKK { get; set; }
        public string NamaPejabatSKK1 { get; set; }
        public string NamaPejabatSKK2 { get; set; }
        public string NoSPPK { get; set; }
        public DateTime? TanggalSPPK { get; set; }
        public bool? SPPKDisetujuiNasabah { get; set; }
        public string NamaPejabatSPPK1 { get; set; }
        public string NamaPejabatSPPK2 { get; set; }
        public string NoMKK { get; set; }
        public DateTime? TanggalMKK { get; set; }
        public string NamaPejabatMKK1 { get; set; }
        public string NamaPejabatMKK2 { get; set; }
        public string NamaPejabatMKK3 { get; set; }
        public string NamaPejabatMKK4 { get; set; }
        public string NamaPejabatMKK5 { get; set; }
        public int Age => App?.Prospect?.AgeStage("8.0")??-1;

        public Guid AppId { get; set; }
        public Guid? AnalisaId { get; set; }

        // Halaman Utama

        public Guid? RFJabatanSKK1Id { get; set; }
        public Guid? RFJabatanSKK2Id { get; set; }
        public Guid? RFJabatanSPPK1Id { get; set; }
        public Guid? RFJabatanSPPK2Id { get; set; }
        public Guid? RFJabatanMKK1Id { get; set; }
        public Guid? RFJabatanMKK2Id { get; set; }
        public Guid? RFJabatanMKK3Id { get; set; }
        public Guid? RFJabatanMKK4Id { get; set; }
        public Guid? RFJabatanMKK5Id { get; set; }
    }
}
