using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NewLMS.UMKM.Data
{
    public class MSearch : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        public int Id {get;set;}
        [MaxLength(50)]
        public string TypeId { get; set; }
        [MaxLength(20)]
        public string SearchType { get; set; }
        [MaxLength(20)]
        public string SearchId { get; set; }
        [MaxLength(100)]
        public string SearchDesc { get; set; }
        [MaxLength(5)]
        public string ResultType { get; set; }
        [MaxLength(50)]
        public string VariableSystem { get; set; }
        [MaxLength(500)]
        public string VariableFields { get; set; }
        [MaxLength(500)]
        public string VariableCondition { get; set; }
        [MaxLength(50)]
        public string ResultSystem { get; set; }
        [MaxLength(100)]
        public string ResultKey { get; set; }
        [MaxLength(2000)]
        public string ResultCondition { get; set; }
        public bool Active { get; set; }
    }
}