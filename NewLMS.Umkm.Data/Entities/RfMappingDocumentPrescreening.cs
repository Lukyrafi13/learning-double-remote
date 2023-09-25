using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Entities
{
    public class RfMappingDocumentPrescreening : BaseEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        public string DocumentType { get; set; }

        [ForeignKey(nameof(RfProduct))]
        public string ProductId { get; set; }

        [ForeignKey(nameof(OwnerCategory))]
        public int? OwnerCategoryId { get; set; }
        
        [ForeignKey(nameof(RfDocument))]
        public string DocumentCode { get; set; }

        public virtual RfProduct RfProduct { get; set; }
        public virtual RfParameterDetail OwnerCategory { get; set; }
        public virtual RfDocument RfDocument { get; set; }
    }
}
