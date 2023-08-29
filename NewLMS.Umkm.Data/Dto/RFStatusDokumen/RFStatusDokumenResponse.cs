using System;
namespace NewLMS.Umkm.Data.Dto.RFStatusDokumens
{
    public class RFStatusDokumenResponseDto
    {
        public Guid Id { get; set; }
        public string StatusCode { get; set; }
        public string StatusDesc { get; set; }
        public bool? Active { get; set; }
    }
}
