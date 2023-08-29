using System;
namespace NewLMS.UMKM.Data.Dto.FileDokumens
{
    public class FileDokumenPostRequestDto
    {
        public string DocumentSubType { get; set; }
        public bool? Active { get; set; }
        public Guid? PrescreeningDokumenId { get; set; }
        public Guid? FileUrlId { get; set; }
    }
}
