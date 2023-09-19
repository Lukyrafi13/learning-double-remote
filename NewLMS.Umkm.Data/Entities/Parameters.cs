using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace NewLMS.Umkm.Data.Entities
{
    public class Parameters : BaseEntity
    {
        [Required]
        [Key]
        [Column(Order = 0)]
        public Guid ParameterGuid { get; set; }
        [ForeignKey(nameof(ParameterGroups))]
        [Column(Order = 1)]
        public Guid ParameterGroupGuid { get; set; }
        [Column(Order = 2)]
        public string ParameterKey { get; set; }
        [Column(Order = 3)]
        public string ParameterName { get; set; }
        [Column(Order = 4)]
        public bool IsActive { get; set; } = true;
        public virtual ParameterGroups ParameterGroups { get; set; }
    }
}
