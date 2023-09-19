using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Entities
{
    public class RfParameterDetail
    {
        [Key]
        [Required]
        public int ParameterDetailId { get; set; }
        
        [ForeignKey(nameof(RfParameter))]
        public int ParameterId { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public bool Active { get; set; }

        public virtual RfParameter RfParameter { get; set; }
    }
}
