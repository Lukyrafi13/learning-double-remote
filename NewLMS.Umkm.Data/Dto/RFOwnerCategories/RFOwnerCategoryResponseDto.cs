using System;

namespace NewLMS.Umkm.Data.Dto.RFOwnerCategories
{
    public class RFOwnerCategoryResponseDto
    {
        public Guid Id { get; set; }
        public string OwnCode { get; set; }
        public string OwnDesc { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
    }
}
