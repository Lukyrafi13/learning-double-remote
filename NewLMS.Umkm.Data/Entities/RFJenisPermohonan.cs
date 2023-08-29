using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewLMS.UMKM.Data
{
    public class RfAppType : BaseEntity
    {
        [Key]
        [Required]
		public Guid Id { get; set; }
		public string Type { get; set; }
	}
}
