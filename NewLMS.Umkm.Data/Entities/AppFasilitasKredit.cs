using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class AppFasilitasKredit : BaseEntity
    {
        public Guid Id { get; set; }
        [ForeignKey("AppId")]
        public App App { get; set; }
        [ForeignKey("RFJenisPermohonanKreditId")]
        public RFJenisPermohonan JenisPermohonanKredit { get; set; }
        [ForeignKey("RFLoanPurposeId")]
        public RFLoanPurpose TujuanKredit { get; set; }    
        [ForeignKey("RFSubProductId")]
        public RFSubProduct LoanType { get; set; }  
        [ForeignKey("RFNegaraPenempatanId")]
        public RFNegaraPenempatan NegaraPenempatan { get; set; }
        public float PlafondYangDiajukan { get; set; }
        [ForeignKey("RFTenorId")]
        public RFTenor TenorKredit { get; set;}
        public string TujuanPenggunaan { get; set; }
        public string TipeCicilan { get; set; }
        public float TingkatSukuBunga { get; set; }
        [ForeignKey("RFSifatKreditId")]
        public RFSifatKredit SifatKredit { get; set; }
        public float AngsuranPokok { get; set; }
        public float AngsuranBunga { get; set; }
        public float Angsuran => AngsuranPokok + AngsuranBunga;
        [ForeignKey("RFSectorLBU1Code")]
        public RFSectorLBU1 SektorEkonomiLBU { get; set; }
        [ForeignKey("RFSectorLBU2Code")]
        public RFSectorLBU2 SubSektorEkonomiLBU { get; set; }
        [ForeignKey("RFSectorLBU3Code")]
        public RFSectorLBU3 SubSubSektorEkonomiLBU { get; set; }
        
        public Guid AppId { get; set; }
        public Guid RFJenisPermohonanKreditId { get; set; }
        public Guid RFLoanPurposeId { get; set; }
        public Guid RFSubProductId { get; set; }
        public Guid? RFNegaraPenempatanId { get; set; }
        public Guid RFTenorId { get; set; }
        public Guid RFSifatKreditId { get; set; }
        public string RFSectorLBU1Code { get; set; }
        public string RFSectorLBU2Code { get; set; }
        public string RFSectorLBU3Code { get; set; }
        
    }
}