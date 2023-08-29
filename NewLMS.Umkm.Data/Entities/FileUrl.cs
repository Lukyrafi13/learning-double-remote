using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace NewLMS.Umkm.Data
{
    public class FileUrl : BaseEntity
    {
        [Key]
        [Required]

        [Column(Order = 1)]
        public Guid Id { get; set; }

        [Column(Order = 2)]
        public string Url { get; set; }

        [Column(Order = 3)]
        public string FileSize { get; set; }

        [Column(Order = 4)]
        public string FileType { get; set; }

    }
}
