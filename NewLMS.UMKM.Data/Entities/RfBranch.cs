using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data.Entities
{
    public class RfBranch : BaseEntity
    {
        [Key]
        [Required]
        [MaxLength(4)]
        public string Code { get; set; }
        public string Name { get; set; }
        [MaxLength(3)]
        public string Kcp { get; set; }
        [MaxLength(4)]
        public string Kc { get; set; }
        [MaxLength(4)]
        public string KanwilOri { get; set; }
        [MaxLength(50)]
        public string OriKanwilName { get; set; }
        [MaxLength(4)]
        public string Kanwil { get; set; }
        [MaxLength(50)]
        public string KanwilName { get; set; }
        [MaxLength(4)]
        public string GroupBranch { get; set; }
        [MaxLength(50)]
        public string Dati { get; set; }
        [MaxLength(10)]
        public string Sandi { get; set; }
        [MaxLength(50)]
        public string KcName { get; set; }
        public string OfficeType { get; set; }

    }
}