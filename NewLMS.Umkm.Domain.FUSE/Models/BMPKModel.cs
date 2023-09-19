namespace NewLMS.Umkm.Domain.FUSE.Models
{
    public class BMPKModel
    {
        
        public int BMPKId { get; set; }
        public DateTime? Periode { get; set; }
        public double? ModalInti { get; set; }
        public double? ModalPelengkap { get; set; }
        public decimal? PctGroup { get; set; }
        public decimal? PctInfrastruktur { get; set; }
        public decimal? PctPihakTerkait { get; set; }
        public decimal? PctTidakTerkait { get; set; }
        public decimal? PctMaxPortofolio { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}