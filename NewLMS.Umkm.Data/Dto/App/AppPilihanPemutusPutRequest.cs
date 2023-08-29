using System;
namespace NewLMS.Umkm.Data.Dto.Apps
{
    public class AppPilihanPemutusPutRequestDto
    {
        public Guid Id { get; set; }
        public Guid? RFPilihanPemutusId { get; set; }
    }
}
