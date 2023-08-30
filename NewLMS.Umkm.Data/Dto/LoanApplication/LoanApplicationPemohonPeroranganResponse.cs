using System;
namespace NewLMS.UMKM.Data.Dto.LoanApplications
{
    public class LoanApplicationPemohonPeroranganResponse : LoanApplicationPemohonPerorangan
    {
        public RFEDUCATION PendidikanTerakhir { get; set; }
        public RFMARITAL StatusPerkawinan { get; set; }
        public RFJOB DataPekerjaan { get; set; }
        public RfZipCode KodePos { get; set; }
        public RFHOMESTA StatusTempatTinggal { get; set; }
        public RfZipCode KodePosKontakDarurat { get; set; }
        public RFJOB DataPekerjaanPasangan { get; set; }
        public RfZipCode KodePosPasangan { get; set; }

    }
}
