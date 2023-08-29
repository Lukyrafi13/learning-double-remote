using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using NewLMS.UMKM.Data;

namespace NewLMS.UMKM.Domain.FUSE.Entites
{
    public class Test : BaseEntity
    {
        [Key]
        [Required]
        [Column(Order = 0)]
        public int PlafondId { get; set; }
        [Column(Order = 1)]
        public string PlafondName { get; set; }
    }
}