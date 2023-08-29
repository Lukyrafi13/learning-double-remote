using System;

namespace NewLMS.UMKM.Data.Dto.AnalisaFasilitass
{
    public class AnalisaFasilitasPostRequestDto
    {   
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
