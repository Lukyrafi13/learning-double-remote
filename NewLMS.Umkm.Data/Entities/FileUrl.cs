﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace NewLMS.Umkm.Data.Entities
{
    public class FileUrl : BaseEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        public string Url { get; set; }
        public string FileSize { get; set; }
        public string FileType { get; set; }
        public string FileName { get; set; }

    }
}