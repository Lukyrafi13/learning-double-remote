using System;
namespace NewLMS.Umkm.Data.Dto.ReviewPersiapanAkads
{
    public class ReviewPersiapanAkadProsesResponse
    {
        public Guid? AppId { get; set; }
        public Guid? ReviewPersiapanAkadId { get; set; }
        public Guid? DisbursementId { get; set; }
        public string Stage { get; set; }
        public string Message { get; set; }

    }
}
