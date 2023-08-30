using System;
namespace NewLMS.UMKM.Data.Dto.Apps
{
    public class AppIDEPutRequestDto
    {
        public Guid Id { get; set; }

        public Guid RfProductId { get; set; }
        public Guid RfOwnerCategoryId { get; set; }
        public bool? SiklusUsaha { get; set; }
        public int? SiklusUsahaMonth { get; set; }
		// SCO
        public Guid RFSCOReputasiTempatTinggalId { get; set; }
        public Guid RFSCOTingkatKebutuhanId { get; set; }
        public Guid RFSCOCaraTransaksiId { get; set; }
        public Guid RFSCOPengelolaKeuanganId { get; set; }
        public Guid RFSCOHutangPihakLainId { get; set; }
        public Guid RFSCOLokTempatUsahaId { get; set; }
        public Guid RFSCOHubunganPerbankanId { get; set; }
        public Guid RFSCOMutasiPerBulanId { get; set; }
        public Guid RFSCORiwayatKreditBJBId { get; set; }
        public Guid RFSCOScoringAgunanId { get; set; }
        public Guid RFSCOSaldoRekRataId { get; set; }
        // public Guid? RFSiklusUsahaId { get; set; }
        public Guid? RFSiklusUsahaPokokId { get; set; }
		// BO
        public string RFBranchesId { get; set; }

    }
}
