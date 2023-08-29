using System;

namespace NewLMS.Umkm.Data.Dto.AnalisaFasilitass
{
    public class AnalisaFasilitasResponseDto
    {
        public Guid Id { get; set; }
        public Analisa Analisa { get; set; }
        public AppFasilitasKredit AppFasilitasKredit { get; set; }
        public RFTenor JangkaWaktu { get; set; }
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
