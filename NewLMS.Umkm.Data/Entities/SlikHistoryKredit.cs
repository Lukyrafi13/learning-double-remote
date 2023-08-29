using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class SlikHistoryKredit : BaseEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [ForeignKey(nameof(SlikRequest))]
        public Guid SlikRequestId { get; set; }

        [MaxLength(16)]
        public string SLIKNoIdentity { get; set; }

        public string DebtorName { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
        
        [ForeignKey(nameof(RfSandiBIEconomySectorClass))]
        public Guid? RFSandiBIEconomySectorId { get; set; }

        [ForeignKey(nameof(RfSandiBIBehaviourClass))]
        public Guid? RFSandiBIBehaviourId { get; set; }

        [ForeignKey(nameof(RfSandiBIApplicationTypeClass))]
        public Guid? RFSandiBIApplicationTypeId { get; set; }

        [ForeignKey(nameof(RfCondition))]
        public Guid? RFConditionId { get; set; }

        public int PlafondLimit { get; set; }

        public float Interest { get; set; }

        public int Outstanding { get; set; }

        public DateTime? StuckDate { get; set; }

        [ForeignKey(nameof(RfSandiBICollectibilityClass))]
        public Guid? RFSandiBICollectibilityId { get; set; }

        public bool SLIKStatus { get; set; }

        [ForeignKey(nameof(RfCreditType))]
        public Guid? RFTipeKreditId { get; set; }

        public bool IsRobo { get; set; }

        [ForeignKey(nameof(SlikObjectType))]
        public int? SlikObjectTypeId { get; set; }
        public bool? BelumMemilikiSLIK { get; set; }
        public string Bank { get; set; }

        public RFTipeKredit RfCreditType { get; set; }
        public RFSANDIBI RfSandiBIEconomySectorClass { get; set; }
        public RFSANDIBI RfSandiBIBehaviourClass { get; set; }
        public RFSANDIBI RfSandiBIApplicationTypeClass { get; set; }
        public RFSANDIBI RfSandiBICollectibilityClass { get; set; }
        public RFCondition RfCondition { get; set; }
        public SlikRequest SlikRequest { get; set; }
        public SlikObjectType SlikObjectType { get; set; }
    }
}
