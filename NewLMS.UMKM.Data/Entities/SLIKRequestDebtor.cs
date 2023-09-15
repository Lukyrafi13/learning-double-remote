using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data.Entities
{
    public class SLIKRequestDebtor : BaseEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [ForeignKey(nameof(SLIKRequest))]
        public Guid SLIKRequestId { get; set; }

        [ForeignKey(nameof(RfSLIKDebtorType))]
        public int SLIKDebtorType { get; set; }
        public string Fullname { get; set; }
        public string NPWP { get; set; }
        public string NoIdentity { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string ApplicationStatus { get; set; }
        public DateTime RequestDate { get; set; }

        public DateTime? EstablishedDate { get; set; }
        public string EstablishedLocation { get; set; }

        [ForeignKey(nameof(FileUrl))]
        public Guid? SLIKDocumentUrlId { get; set; }
        public string KodeRefPengguna { get; set; }
        public string TujuanPermintaan { get; set; }
        public string SLIKResult { get; set; }
        public bool RoboSlik { get; set; }

        public virtual RfParameterDetail RfSLIKDebtorType { get; set; }
        public virtual FileUrl FileUrl { get; set; }
        public virtual SLIKRequest SLIKRequest { get; set; }
    }
}