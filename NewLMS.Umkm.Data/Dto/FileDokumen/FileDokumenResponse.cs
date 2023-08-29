using System;
namespace NewLMS.UMKM.Data.Dto.FileDokumens
{
    public class FileDokumenResponseDto
    {
        public Guid Id { get; set; }
        public PrescreeningDokumen PrescreeningDokumen { get; set; }
        public FileUrl FileUrl { get; set; }
        public string DocumentSubType { get; set; }
        public bool? Active { get; set; }

        public Guid? PrescreeningDokumenId { get; set; }
        public Guid? FileUrlId { get; set; }
    }
}
