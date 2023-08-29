using System;
namespace NewLMS.Umkm.Data.Dto.Analisas
{
    public class AnalisaComplianceSheetResponse : AnalisaComplianceSheetPut
    {
        
        public DateTime? PeriodeBMPK { get; set; }
        public DateTime? PeriodeSBDK { get; set; }
        public double? ModalBank { get; set; }
        public double? ModalInti { get; set; }
        public double? BMPK { get; set; }
        public double? BMPKBUMN { get; set; }
        public double? Inhouse { get; set; }
        public double? PenyediaanDanaBesar { get; set; }

        public double? HPDKKorporasi { get; set; }
        public double? HPDKRitel { get; set; }
        public double? HPDKMikro { get; set; }
        public double? HPDKKPR { get; set; }
        public double? HPDKNonKPR { get; set; }
        public double? BOKorporasi { get; set; }
        public double? BORitel { get; set; }
        public double? BOMikro { get; set; }
        public double? BOKPR { get; set; }
        public double? BONonKPR { get; set; }
        public double? MKKorporasi { get; set; }
        public double? MKRitel { get; set; }
        public double? MKMikro { get; set; }
        public double? MKKPR { get; set; }
        public double? MKNonKPR { get; set; }
        public double? SBDKKorporasi { get; set; }
        public double? SBDKRitel { get; set; }
        public double? SBDKMikro { get; set; }
        public double? SBDKKPR { get; set; }
        public double? SBDKNonKPR { get; set; }
        
        public RFCSBPDetail HubunganBank { get; set; }
        public RFCSBPDetail PengecekanBJB { get; set; }
        public RFCSBPDetail ProfileNasabah { get; set; }
        public RFCSBPDetail BenturanKepentingan { get; set; }
    }
}
