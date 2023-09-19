using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Entities
{
    public class DocumentFileUrl : BaseEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Document))]
        public Guid DocumentId { get; set; }

        [ForeignKey(nameof(FileUrl))]
        public Guid FileUrlId { get; set; }

        public virtual Document Document { get; set; }
        public virtual FileUrl FileUrl { get; set; }
    }
}
