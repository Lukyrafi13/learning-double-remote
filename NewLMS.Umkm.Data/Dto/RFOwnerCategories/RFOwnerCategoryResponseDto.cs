using System;

namespace NewLMS.UMKM.Data.Dto.RFOwnerCategories
{
    public class RfOwnerCategoryResponseDto
    {
        public Guid Id { get; set; }
        public string OwnCode { get; set; }
        public string OwnDesc { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
    }
}
