using System;
namespace NewLMS.UMKM.Data.Dto.Apps
{
    public class AppPilihanPemutusResponse : AppPilihanPemutusPutRequestDto
    {
        public RFPilihanPemutus PilihanPemutus { get; set; }
    }
}
