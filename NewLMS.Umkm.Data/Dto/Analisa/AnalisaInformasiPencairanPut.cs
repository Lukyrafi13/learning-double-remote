using System;

namespace NewLMS.Umkm.Data.Dto.Analisas
{
    public class AnalisaInformasiPencairanPut
    {
        public Guid Id { get; set; }

        public double Provisi { get; set; }
        public double? NilaiProvisi { get; set; }
        public double? BiayaAdmin { get; set; }
        public double? NilaiPertanggungan { get; set; }
        public double? TotalBiayaAsuransi { get; set; }
        public bool? IsLossInsurance { get; set; }
        public bool? IsLifeInsurance { get; set; }
        public bool? IsCreditInsurance { get; set; }

        public Guid? RFCaraPengikatanId { get; set; }
        public Guid? RFPengikatanKreditId { get; set; }
        public Guid? RFPolaPengembalianAngsuranId { get; set; }
        public string RFBranchesCode { get; set; }
        
    }
}
