using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class RfBranches : BaseEntity
    {
        [Key]
        [Required]
        public string Code { get; set; }
        public string Name { get; set; }
        public string Dati { get; set; }
        public string GroupBranch { get; set; }
        public string Kanwil { get; set; }
        public string KanwilName { get; set; }
        public string KanwilOri { get; set; }
        public string Kc { get; set; }
        public string KcName { get; set; }
        public string Kcp { get; set; }
        public string OfficeType { get; set; }
        public string OriKanwilName { get; set; }
        public string Sandi { get; set; }

    }
}