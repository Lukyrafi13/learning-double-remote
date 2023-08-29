using System;
namespace NewLMS.Umkm.Data.Dto.Apps
{
    public class AppPemohonPeroranganResponse : AppPemohonPerorangan
    {
        public RFEDUCATION PendidikanTerakhir { get; set; }
        public RFMARITAL StatusPerkawinan { get; set; }
        public RFJOB DataPekerjaan { get; set; }
        public RFZipCode KodePos { get; set; }
        public RFHOMESTA StatusTempatTinggal { get; set; }
        public RFZipCode KodePosKontakDarurat { get; set; }
        public RFJOB DataPekerjaanPasangan { get; set; }
        public RFZipCode KodePosPasangan { get; set; }

    }
}
