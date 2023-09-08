using System;

namespace NewLMS.UMKM.Data.Dto.LoanApplicationCollaterals
{
    public class LoanApplicationCollateralRequest
    {
        public Guid Id { get; set; }
        public Guid LoanApplicationId { get; set; }
        public string CollateralBCId { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime DocumentReleaseDate { get; set; }
        public DateTime? DocumentExpireDate { get; set; }
        public string DocumentPublisher { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Neighborhoods { get; set; }
        public int ZipCodeId { get; set; }
    }
}

