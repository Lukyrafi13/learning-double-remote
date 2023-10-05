using System.ComponentModel.DataAnnotations;

namespace NewLMS.Umkm.Data.Entities
{
    public class MSearch : BaseEntity
    {
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
    }
}
