using NewLMS.Umkm.Data.Dto.RfParameterDetails;
using System;

namespace NewLMS.Umkm.Data.Dto.LoanApplicationAnalysts
{
    public class LoanApplicationAnalystAppInfoResponse
    {
        public Guid Id { get; set; }
        public string Regency { get; set; }
        public string Branch { get; set; }
        public string AccountOfficer { get; set; }
        public string LoanApplicationId { get; set; }
        public string Product { get; set; }
        public string Name { get; set; }
        public string NPWP { get; set; }
        public string NoIdentity { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string BookingOffice { get; set; }
        public bool IsBusinessCycle { get; set; }
        public int OwnerCategoryId { get; set; }

        public RfParameterDetailSimpleResponse RfOwnerCategory { get; set; }
    }
}
