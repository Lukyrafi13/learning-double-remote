﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data
{
    public class ThridParty : BaseEntity
    {
        [Key]
        [MaxLength(128)]
        [Required]
        public string Name { get; set; }
        [MaxLength(128)]
        [Required]
        public string ClientId { get; set; }
        [MaxLength(128)]
        [Required]
        public string ClientSecret { get; set; }
        [MaxLength(450)]
        [Required]
        public string UrlCallback { get; set; }
        public virtual ICollection<LogSendCallbackThirdParty> LogSendCallbackThirdParties { get; set; }
    }
}
