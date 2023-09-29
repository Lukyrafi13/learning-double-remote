using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Entities
{
    public class RfMappingPlafondPlacementCountry : BaseEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        
        [ForeignKey(nameof(RfPlacementCountry))]
        public string PlacementCountryCode { get; set; }
        
        [ForeignKey(nameof(ApplicationType))]
        public int? ApplicationTypeCode { get; set; }
        
        public double? MaximumPlafond { get; set; }

        public virtual RfPlacementCountry RfPlacementCountry { get; set; }
        public virtual RfParameterDetail ApplicationType { get; set; }
    }
}
