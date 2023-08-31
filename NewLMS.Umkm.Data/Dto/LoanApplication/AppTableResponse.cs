using System;
namespace NewLMS.UMKM.Data.Dto.Apps
{
    public class AppTableResponse
    {
        public Guid Id { get; set; }
        

        public string LoanApplicationId { get; set; }
        public Guid? ProspectId { get; set; }

        public Guid? RfOwnerCategoryId { get; set; }

        // etc
        public string DataSource { get; set; }

        public string NoIdentity { get; set; }
        
        public Guid? CompanyEntityGuid { get; set; }
        public RfOwnerCategory RfOwnerCategory {get; set; }
        public Debtor Debtor {get; set; }
        public Prospect Prospect {get; set; }
        public CompanyEntity CompanyEntity {get; set; }
        public RfStage LatestStage {get; set; }
    }
}
