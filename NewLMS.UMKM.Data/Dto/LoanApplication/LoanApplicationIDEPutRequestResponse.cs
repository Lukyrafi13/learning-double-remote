using System;
namespace NewLMS.UMKM.Data.Dto.LoanApplications
{
    public class LoanApplicationIDEPutRequestDtoResponse : LoanApplicationIDEPutRequestDto
    {
        public RfBusinessPrimaryCycle RfBusinessPrimaryCycle { get; set; }
        public LoanApplication LoanApplication { get; set; }
        public RfParameterDetail RFSCOReputasiTempatTinggal { get; set; }
        public RfParameterDetail RFSCOTingkatKebutuhan { get; set; }
        public RfParameterDetail RFSCOCaraTransaksi { get; set; }
        public RfParameterDetail RFSCOPengelolaKeuangan { get; set; }
        public RfParameterDetail RFSCOHutangPihakLain { get; set; }
        public RfParameterDetail RFSCOLokTempatUsaha { get; set; }
        public RfParameterDetail RFSCOHubunganPerbankan { get; set; }
        public RfParameterDetail RFSCOMutasiPerBulan { get; set; }
        public RfParameterDetail RFSCORiwayatKreditBJB { get; set; }
        public RfParameterDetail RFSCOScoringAgunan { get; set; }
        public RfParameterDetail RFSCOSaldoRekRata { get; set; }
        // public RFSiklusUsaha SiklusUsahaMonth { get; set; }
    }
}
