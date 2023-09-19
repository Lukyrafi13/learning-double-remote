using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Entities
{
    public class RfSandiBIGroup : BaseEntity
    {
        [Key]
        [Required]
        [MaxLength(3)]
        public string BIGroup { get; set; }

        public string BIDesc { get; set; }

        //public virtual ICollection<RfSandiBI> RfSandiBIs { get; set; }
    }
}
