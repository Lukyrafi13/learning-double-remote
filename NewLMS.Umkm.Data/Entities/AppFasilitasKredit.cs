using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class LoanApplicationCreditFacility : BaseEntity
    {
        public Guid Id { get; set; }
        [ForeignKey("LoanApplicationId")]
        public LoanApplication LoanApplication { get; set; }
        [ForeignKey("RfLoanApplicationTypeKreditId")]
        public RfAppType JenisPermohonanKredit { get; set; }
        [ForeignKey("RFLoanPurposeId")]
        public RFLoanPurpose TujuanKredit { get; set; }    
        [ForeignKey("RFSubProductId")]
        public RFSubProduct LoanType { get; set; }  
        [ForeignKey("RFNegaraPenempatanId")]
        public RFPlacementCountry NegaraPenempatan { get; set; }
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
        [ForeignKey("RfSectorLBU1Code")]
        public RfSectorLBU1 SektorEkonomiLBU { get; set; }
        [ForeignKey("RfSectorLBU2Code")]
        public RfSectorLBU2 SubSektorEkonomiLBU { get; set; }
        [ForeignKey("RfSectorLBU3Code")]
        public RfSectorLBU3 SubSubSektorEkonomiLBU { get; set; }
        
        public Guid LoanApplicationId { get; set; }
        public Guid RfLoanApplicationTypeKreditId { get; set; }
        public Guid RFLoanPurposeId { get; set; }
        public Guid RFSubProductId { get; set; }
        public Guid? RFNegaraPenempatanId { get; set; }
        public Guid RFTenorId { get; set; }
        public Guid RFSifatKreditId { get; set; }
        public string RfSectorLBU1Code { get; set; }
        public string RfSectorLBU2Code { get; set; }
        public string RfSectorLBU3Code { get; set; }
        
    }
}