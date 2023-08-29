using System;
namespace NewLMS.Umkm.Data.Dto.Apps
{
    public class AppPemohonGapoktanResponse : AppPemohonGapoktan
    {
        public RFMARITAL StatusPerkawinanKetua { get; set; }
        public RFEDUCATION PendidikanTerakhirKetua { get; set; }
        public RFZipCode KodePosKetua { get; set; }
        public RFMARITAL StatusPerkawinanBendahara { get; set; }
        public RFEDUCATION PendidikanTerakhirBendahara { get; set; }
        public RFZipCode KodePosBendahara { get; set; }
        
    }
}
