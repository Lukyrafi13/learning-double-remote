using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewLMS.Umkm.Data
{
    public class RFJenisPermohonan : BaseEntity
    {
        [Key]
        [Required]
		public Guid Id { get; set; }
		public string JenisPermohonan { get; set; }
	}
}
