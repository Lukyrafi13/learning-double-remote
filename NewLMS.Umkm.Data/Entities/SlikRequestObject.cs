using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data
{
    public class SlikRequestObject : BaseEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [ForeignKey(nameof(SlikRequest))]
        public Guid SlikRequestId { get; set; }

        [ForeignKey(nameof(SlikObjectType))]
        public int? SlikObjectTypeId { get; set; }
        public string Fullname { get; set; }
        public string NPWP { get; set; }
        public string NoIdentity { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string ApplicationStatus { get; set; }
        public DateTime RequestDate { get; set; }

        [ForeignKey(nameof(FileUrl))]
        public Guid? SLIKDocumentUrl { get; set; }
        public string KodeRefPengguna { get; set; }
        public string TujuanPermintaan { get; set; }
        public string SLIKResult { get; set; }
        public bool RoboSlik { get; set; }
        public bool? Automatic { get; set; }
        public SlikRequest SlikRequest { get; set; }
        public SlikObjectType SlikObjectType { get; set; }
        public FileUrl FileUrl { get; set; }
    }
}
