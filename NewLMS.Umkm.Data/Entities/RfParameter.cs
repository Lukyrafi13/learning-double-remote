using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data
{
    public class RfParameter: BaseEntity
	{
        [Key]
        [Required]
		public int ParameterId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public bool Active { get; set; }
		public virtual ICollection<RfParameterDetail> RfParameterDetails { get; set; }
	}
}
