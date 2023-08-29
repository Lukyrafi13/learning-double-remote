using System;
namespace NewLMS.UMKM.Data.Dto.SlikRequests
{
    public class SlikRequestProsesResponse
    {
        public Guid? AppId { get; set; }
        public Guid? SlikRequestId { get; set; }
        public Guid? PrescreeningId { get; set; }
        public Guid? PersiapanAkadId { get; set; }
        public string Stage { get; set; }
        public string Message { get; set; }
    }
}
