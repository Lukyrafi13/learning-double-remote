using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data
{
    public class RfParameterDetail : BaseEntity
    {
        [Key]
        [Required]		
		public int ParameterDetailId { get; set; }
        [ForeignKey(nameof(RfParameter))]		
		public int ParameterId { get; set; }
		public string Code { get; set; }
        public string CoreCode { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int Order { get; set; }
		public bool Active { get; set; }
        [MaxLength(50)]
        public virtual RfParameter RfParameter { get; set; }
    }
}
