using System;
namespace NewLMS.UMKM.Data.Dto.SPPKs
{
    public class SPPKProsesResponse
    {
        public Guid? AppId { get; set; }
        public Guid? SPPKId { get; set; }
        public Guid? PersiapanAkadId { get; set; }
        public string Stage { get; set; }
        public string Message { get; set; }
    }
}
