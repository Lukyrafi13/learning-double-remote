using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Entities
{
    public class Document : BaseEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        
        [ForeignKey(nameof(LoanApplication))]
        public Guid LoanApplicationId { get; set; }

        [ForeignKey(nameof(RfDocumentType))]
        public int DocumentType { get; set; }

        public string DocumentNo { get; set; }
        
        public DateTime? ExpireDate { get; set; }

        [ForeignKey(nameof(RfDocumentStatus))]
        public int? DocumentStatusId { get; set; }
        
        public DateTime? TBODate { get; set; }
        
        public string TBODesc { get; set; }
        
        public string Justification { get; set; }

        [ForeignKey(nameof(RfDocument))]
        public string DocumentId { get; set; }

        public virtual LoanApplication LoanApplication { get; set; }
        public virtual RfParameterDetail RfDocumentType { get; set; }
        public virtual RfParameterDetail RfDocumentStatus { get; set; }
        public virtual RfDocument RfDocument { get; set; }
        public virtual ICollection<DocumentFileUrl> Files { get; set; }
    }
}
