using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NewLMS.UMKM.Data
{
    public class LoanApplication : BaseEntity
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20)]

        // Turunan Prospect
        public string LoanApplicationId { get; set; }
        public Guid? DebiturId { get; set; }
        public Guid? ProspectId { get; set; }


        // (KMU/KUR/Badan Usaha)

        // Legalitas Badan Usaha
        public string NomorAktaPendirian { get; set; }
        public DateTime? TanggalAktaPendirian { get; set; }
        public string NomorPendaftaran { get; set; }
        public DateTime? TanggalSK { get; set; }
        public string PerubahanAktaTerakhir { get; set; }
        public DateTime? TanggalAkta { get; set; }
        public string NomorSIUP { get; set; }
        public DateTime? TanggalSIUP { get; set; }
        public string NomorTDP { get; set; }
        public DateTime? TanggalTDP { get; set; }
        public DateTime? TanggalJatuhTempoTDP { get; set; }
        public string NomorSKDP { get; set; }
        public DateTime? TanggalSKDP { get; set; }
        public DateTime? TanggalJatuhTempoSK { get; set; }

        // Informasi Usaha
        public int? LamaUsaha { get; set; }
        public string JenisKomoditas { get; set; }


        // etc
        public string SumberData { get; set; }
        public RfBranch BookingOffice { get; set; }
        public RFPilihanPemutus PilihanPemutus { get; set; }
        public string NamaAO { get; set; }
        public string KodeCabang { get; set; }
        public string NamaCabang { get; set; }

        // Other stage
        public SlikRequest SlikRequest {get; set; }


        // Foreign keys
        public Guid? RfProductId { get; set; }
        public Guid? RfOwnerCategoryId { get; set; }
        public Guid? RFSCOReputasiTempatTinggalId { get; set; }
        public Guid? RFSCOTingkatKebutuhanId { get; set; }
        public Guid? RFSCOCaraTransaksiId { get; set; }
        public Guid? RFSCOPengelolaKeuanganId { get; set; }
        public Guid? RFSCOHutangPihakLainId { get; set; }
        public Guid? RFSCOLokTempatUsahaId { get; set; }
        public Guid? RFSCOHubunganPerbankanId { get; set; }
        public Guid? RFSCOMutasiPerBulanId { get; set; }
        public Guid? RFSCORiwayatKreditBJBId { get; set; }
        public Guid? RFSCOScoringAgunanId { get; set; }
        public Guid? RFSCOSaldoRekRataId { get; set; }
        public int? RfZipCodeId { get; set; }
        public Guid? RFEducationId { get; set; }
        public Guid? RFMaritalId { get; set; }
        public Guid? RFJobId { get; set; }
        public Guid? RFHomestaId { get; set; }
        public int? RfZipCodeKontakDaruratId { get; set; }
        public Guid? RFJobPasanganId { get; set; }
        public int? RfZipCodePasanganId { get; set; }
        public string RfBranchesId { get; set; }
        public Guid? RFMaritalKetuaId { get; set; }
        public Guid? RFEducationKetuaId { get; set; }
        public int? RfZipCodeKetuaId { get; set; }
        public Guid? RFMaritalBendaharaId { get; set; }
        public Guid? RFEducationBendaharaId { get; set; }
        public int? RfZipCodeBendaharaId { get; set; }
        public Guid? RFPilihanPemutusId { get; set; }
        public Guid? RFSiklusUsahaPokokId { get; set; }
    }
}