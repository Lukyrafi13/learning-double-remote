using System;
namespace NewLMS.UMKM.Data.Dto.VerifikasiPersiapanAkads
{
    public class VerifikasiPersiapanAkadProsesResponse
    {
        public Guid? AppId { get; set; }
        public Guid? VerifikasiPersiapanAkadId { get; set; }
        public Guid? ReviewPersiapanAkadId { get; set; }
        public string Stage { get; set; }
        public string Message { get; set; }
    }
}
