﻿using System;
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

        public string NoIdentity { get; set; }
        public string Fullname { get; set; }
        public string PlaceOfBirth { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NPWP { get; set; }
        public DateTime RequestDate { get; set; }
        public string ApplicationStatus { get; set; }
        public string SLIKResult { get; set; }
        public string SIDStatus { get; set; }

        [ForeignKey(nameof(FileUrl))]
        public Guid? SLIKDocumentUrl { get; set; }
        public string KodeRefPengguna { get; set; }
        public string TujuanPermintaan { get; set; }
        public bool? ByKesamaan { get; set; }
        public bool? ByNoIdentitas { get; set; }
        public virtual FileUrl FileUrl { get; set; }
        public virtual SLIKRequest SLIKRequest { get; set; }
    }
}