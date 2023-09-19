using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Entities
{
    public class RfCompanyType : BaseEntity
    {
        [Key]
        [Required]
        public string CompanyTypeId {get;set;}
        public string CompanyTypeDesc {get;set;}

        [ForeignKey(nameof(ParamCompanyGroup))]
        public int? CompanyGroupId {get;set;}

        public virtual RfParameterDetail ParamCompanyGroup { get; set; }
    }
}
