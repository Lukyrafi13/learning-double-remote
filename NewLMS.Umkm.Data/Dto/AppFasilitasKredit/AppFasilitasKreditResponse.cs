using System;
namespace NewLMS.Umkm.Data.Dto.AppFasilitasKredits
{
    public class AppFasilitasKreditResponseDto
    {
        public Guid Id { get; set; }
        public App App { get; set; }
        public RFJenisPermohonan JenisPermohonanKredit { get; set; }
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
        public RFSectorLBU1 SektorEkonomiLBU { get; set; }
        public RFSectorLBU2 SubSektorEkonomiLBU { get; set; }
        public RFSectorLBU3 SubSubSektorEkonomiLBU { get; set; }
        public Guid AppId { get; set; }
        public Guid RFJenisPermohonanKreditId { get; set; }
        public Guid RFLoanPurpose { get; set; }
        public Guid RFSubProduct { get; set; }
        public Guid? RFNegaraPenempatanId { get; set; }
        public Guid RFTenor { get; set; }
        public Guid RFSifatKredit { get; set; }
        public string RFSectorLBU1Code { get; set; }
        public string RFSectorLBU2Code { get; set; }
        public string RFSectorLBU3Code { get; set; }
        public AnalisaFasilitas AnalisaFasilitas { get; set; }
        public AnalisaSandiOJK AnalisaSandiOJK { get; set; }

    }
}
