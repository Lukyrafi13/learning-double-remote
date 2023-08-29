using System;

namespace NewLMS.Umkm.Data.Dto.AppFasilitasKredits
{
    public class AppFasilitasKreditPostRequestDto
    {
        public float PlafondYangDiajukan { get; set; }
        public string TujuanPenggunaan { get; set; }
        public string TipeCicilan { get; set; }
        public float TingkatSukuBunga { get; set; }
        public float AngsuranPokok { get; set; }
        public float AngsuranBunga { get; set; }
        public float Angsuran => AngsuranPokok + AngsuranBunga;
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
