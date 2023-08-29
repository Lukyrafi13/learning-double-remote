using System;
namespace NewLMS.Umkm.Data.Dto.Apps
{
    public class AppPemohonBadanUsahaResponse : AppPemohonBadanUsaha
    {
        public RFZipCode KodePos { get; set; }
        public RFZipCode KodePosKontakDarurat { get; set; }

    }
}
