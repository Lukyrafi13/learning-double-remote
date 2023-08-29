using System;
namespace NewLMS.Umkm.Data.Dto.Apps
{
    public class AppPilihanPemutusResponse : AppPilihanPemutusPutRequestDto
    {
        public RFPilihanPemutus PilihanPemutus { get; set; }
    }
}
