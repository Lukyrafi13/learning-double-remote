using System;

namespace NewLMS.UMKM.Data.Dto.SlikRequestObjects
{
    public class SlikRequestObjectPostRequestDto
    {
        public Guid SlikRequestId { get; set; }

        public int? SlikObjectTypeId { get; set; }
        public string Fullname { get; set; }
        public string NPWP { get; set; }
        public string NoIdentity { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string ApplicationStatus { get; set; }
        public DateTime RequestDate { get; set; }
        public Guid? SLIKDocumentUrl { get; set; }
        public string KodeRefPengguna { get; set; }
        public string TujuanPermintaan { get; set; }
        public string SLIKResult { get; set; }
        public bool RoboSlik { get; set; }
        public bool? Automatic { get; set; }
    }
}
