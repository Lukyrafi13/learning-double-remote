using System;
namespace NewLMS.UMKM.Data.Dto.RFKodeDinass
{
    public class RFKodeDinasResponseDto : BaseResponse
    {
        public Guid Id { get; set; }
        public string KodeDinas { get; set; }
        public string Mitra { get; set; }
        public string SektorEkonomi { get; set; }
        public string Budidaya { get; set; }
        public bool Active { get; set; }
    }
}
