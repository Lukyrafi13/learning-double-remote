using System;
namespace NewLMS.UMKM.Data.Dto.Apps
{
    public class AppPemohonGapoktanResponse : AppPemohonGapoktan
    {
        public RFMARITAL StatusPerkawinanKetua { get; set; }
        public RFEDUCATION PendidikanTerakhirKetua { get; set; }
        public RfZipCode KodePosKetua { get; set; }
        public RFMARITAL StatusPerkawinanBendahara { get; set; }
        public RFEDUCATION PendidikanTerakhirBendahara { get; set; }
        public RfZipCode KodePosBendahara { get; set; }
        
    }
}
