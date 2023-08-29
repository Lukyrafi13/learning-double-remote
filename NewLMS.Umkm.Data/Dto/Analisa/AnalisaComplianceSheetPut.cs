using System;
namespace NewLMS.UMKM.Data.Dto.Analisas
{
    public class AnalisaComplianceSheetPut
    {
        public Guid Id { get; set; }
        public DateTime? TanggalPengecekan { get; set; }
        public Guid? RFCSBPDetailHubunganId { get; set; }
        public Guid? RFCSBPDetailPengecekanId { get; set; }
        public Guid? RFCSBPDetailProfileId { get; set; }
        public Guid? RFCSBPDetailBenturanId { get; set; }
    }
}
