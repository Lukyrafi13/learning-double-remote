using System;
namespace NewLMS.UMKM.Data.Dto.SlikCreditHistorys
{
    public class SlikCreditHistoryResponseDto
    {
        public Guid Id { get; set; }
        public Guid SlikRequestId { get; set; }
        public string SLIKNoIdentity { get; set; }
        public string DebtorName { get; set; }
        public string Bank { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid? RFSandiBIEconomySectorId { get; set; }
        public Guid? RFSandiBIBehaviourId { get; set; }
        public Guid? RFSandiBIApplicationTypeId { get; set; }
        public Guid? RFConditionId { get; set; }
        public int PlafondLimit { get; set; }
        public float Interest { get; set; }
        public int Outstanding { get; set; }
        public DateTime? StuckDate { get; set; }
        public Guid? RFSandiBICollectibilityId { get; set; }
        public bool SLIKStatus { get; set; }
        public Guid? RfCreditTypeId { get; set; }
        public bool IsRobo { get; set; }
        public int? SlikObjectTypeId { get; set; }
        public RfCreditType RfCreditType { get; set; }
        public RFSANDIBI RfSandiBIEconomySectorClass { get; set; }
        public RFSANDIBI RfSandiBIBehaviourClass { get; set; }
        public RFSANDIBI RfSandiBIApplicationTypeClass { get; set; }
        public RFSANDIBI RfSandiBICollectibilityClass { get; set; }
        public RFCondition RfCondition { get; set; }
        public SlikRequest SlikRequest { get; set; }
        public SlikObjectType SlikObjectType { get; set; }
    }
}
