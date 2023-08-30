using System;
namespace NewLMS.UMKM.Data.Dto.Apps
{
    public class AppPemohonBadanUsahaResponse : AppPemohonBadanUsaha
    {
        public RfZipCode KodePos { get; set; }
        public RfZipCode KodePosKontakDarurat { get; set; }

    }
}
