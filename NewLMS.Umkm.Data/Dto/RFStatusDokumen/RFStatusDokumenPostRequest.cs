using System;
namespace NewLMS.Umkm.Data.Dto.RFStatusDokumens
{
    public class RFStatusDokumenPostRequestDto
    {
        public string StatusCode { get; set; }
        public string StatusDesc { get; set; }
        public bool? Active { get; set; }
    }
}
