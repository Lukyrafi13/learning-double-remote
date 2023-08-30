using System;
namespace NewLMS.UMKM.Data.Dto.AppFasilitasKredits
{
    public class AppFasilitasKreditResponseDto
    {
        public Guid Id { get; set; }
        public LoanApplication LoanApplication { get; set; }
        public RfAppType JenisPermohonanKredit { get; set; }
        public RFLoanPurpose TujuanKredit { get; set; }    
        public RFSubProduct LoanType { get; set; }
        public RFNegaraPenempatan NegaraPenempatan { get; set; }
        public float PlafondYangDiajukan { get; set; }
        public RFTenor TenorKredit { get; set;}
        public string TujuanPenggunaan { get; set; }
        public string TipeCicilan { get; set; }
        public float TingkatSukuBunga { get; set; }
        public RFSifatKredit SifatKredit { get; set; }
        public float AngsuranPokok { get; set; }
        public float AngsuranBunga { get; set; }
        public float Angsuran => AngsuranPokok + AngsuranBunga;
        public RfSectorLBU1 SektorEkonomiLBU { get; set; }
        public RfSectorLBU2 SubSektorEkonomiLBU { get; set; }
        public RfSectorLBU3 SubSubSektorEkonomiLBU { get; set; }
        public Guid AppId { get; set; }
        public Guid RfAppTypeKreditId { get; set; }
        public Guid RFLoanPurpose { get; set; }
        public Guid RFSubProduct { get; set; }
        public Guid? RFNegaraPenempatanId { get; set; }
        public Guid RFTenor { get; set; }
        public Guid RFSifatKredit { get; set; }
        public string RfSectorLBU1Code { get; set; }
        public string RfSectorLBU2Code { get; set; }
        public string RfSectorLBU3Code { get; set; }
        public AnalisaFasilitas AnalisaFasilitas { get; set; }
        public AnalisaSandiOJK AnalisaSandiOJK { get; set; }

    }
}
