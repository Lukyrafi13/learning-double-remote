using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewLMS.UMKM.Data;

namespace NewLMS.Umkm.Data.Entities
{
    public class GeneratedFileGroups : BaseEntity
    {
        [Key]
        [Required]
        public Guid GeneratedFileGroupGuid { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [MaxLength(5)]
        public string GeneratedFileGroupCode { get; set; }
        public string GeneratedFileGroupName { get; set; }
        public bool IsActive { get; set; }
    }
}
