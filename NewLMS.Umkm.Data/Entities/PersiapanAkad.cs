using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class PersiapanAkad : BaseEntity
    {
        public Guid Id { get; set; }

        [ForeignKey("AppId")]
        public App App { get; set; }
        [ForeignKey("SppkId")]
        public SPPK SPPK { get; set; }
        [ForeignKey("AnalisaId")]
        public Analisa Analisa { get; set; }
        [ForeignKey("PrescreeningId")]
        public Prescreening Prescreening { get; set; }

        // Biaya dan Asuransi

        public string NamaBroker { get; set; }
        public string JenisCoverage { get; set; }
        public double? PremiAsuransi { get; set; }
        public int Age => App?.Prospect?.AgeStage("9.0")??-1;
        
        public Guid AppId { get; set; }
        public Guid? SppkId { get; set; }
        public Guid? AnalisaId { get; set; }
        public Guid? PrescreeningId { get; set; }
    }
}
