using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class AnalisaFasilitas : BaseEntity
    {
        public Guid Id { get; set; }
        [ForeignKey("AnalisaId")]
        public Analisa Analisa { get; set; }
        [ForeignKey("AppFasilitasKreditId")]
        public AppFasilitasKredit AppFasilitasKredit { get; set; }
        [ForeignKey("RFTenorId")]
        public RFTenor JangkaWaktu { get; set; }
        [ForeignKey("RFSubProductId")]
        public RFSubProduct SkimKredit { get; set; }
        
        public double? Fasilitas { get; set; }
        public double? SukuBunga { get; set; }
        public double? Angsuran { get; set; }
        public double? SelfFinancing { get; set; }

        public Guid AnalisaId { get; set; }
        public Guid? AppFasilitasKreditId { get; set; }
        public Guid? RFTenorId { get; set; }
        public Guid? RFSubProductId { get; set; }
    }
}