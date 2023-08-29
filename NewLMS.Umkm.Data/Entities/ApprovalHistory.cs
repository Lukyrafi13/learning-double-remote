using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class ApprovalHistory : BaseEntity
    {
        public Guid Id { get; set; }

        [ForeignKey("ApprovalId")]
        public Approval Approval { get; set; }
        public Guid? ApprovalId { get; set; }
        public string ApprovalHistoryBy { get; set; }
        public DateTime TanggalMasuk { get; set; }
        public int ApprovalHistorySeq { get; set; }

    }
}
