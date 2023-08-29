using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class AnalisaPinjamanDariBank : BaseEntity
    {
        public Guid Id { get; set; }        
        [ForeignKey("AnalisaId")]
        public Analisa Analisa { get; set; }
        public string NamaBank { get; set; }
        public bool? PinjamanInternal { get; set; }
        public string NamaFasilitas { get; set; }
        [ForeignKey("RFLoanPurposeId")]
        public RFLoanPurpose TujuanPinjaman { get; set; }
        public bool? FasilitasTakeOver { get; set; }
        public double? Plafond { get; set; }
        public double? Outstanding { get; set; }
        public DateTime? TanggalMulaiAkad { get; set; }
        public string PinjamanAtasNama { get; set; }
        public string HubunganDengaDebitur { get; set; }
        public double? Tenor { get; set; }
        public double? Bunga { get; set; }
        public double? Angsuran { get; set; }
        public string BIKolektibilitas { get; set; }
        public double? LamaHariMenunggak { get; set; }

        public Guid AnalisaId { get; set; }
        public Guid? RFLoanPurposeId { get; set; }
    }
}