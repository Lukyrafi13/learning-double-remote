using System;
namespace NewLMS.UMKM.Data.Dto.PersiapanAkads
{
    public class PersiapanAkadProsesResponse
    {
        public Guid? AppId { get; set; }
        public Guid? PersiapanAkadId { get; set; }
        public Guid? VerifikasiPersiapanAkadId { get; set; }
        public string Stage { get; set; }
        public string Message { get; set; }
    }
}
