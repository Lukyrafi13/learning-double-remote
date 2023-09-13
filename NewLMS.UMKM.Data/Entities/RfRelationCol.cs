using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Entities
{
    public class RfRelationCol : BaseEntity
    {
        [Key]
        [Required]
        public string RelationColCode { get; set; }
        public string RelationColDesc { get; set; }
        public bool Spouse { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
        
    }
}
