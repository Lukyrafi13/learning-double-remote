using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data.Entities
{
    public class ParameterGroups : BaseEntity
    {
        [Required]
        [Key]
        public Guid ParameterGroupGuid { get; set; }
        [MaxLength(10)]
        public string ParamaterGroupCode { get; set; }
        public string ParameterGroupName { get; set; }
        public string GroupMenuName { get; set; }
        public string GroupSubMenuName { get; set; }
        public string GroupDescription { get; set; }
        public bool? IsActive { get; set; }
    }
}