using System;
namespace NewLMS.UMKM.Data.Dto.LoanApplications
{
    public class LoanApplicationGetDetailTabRequest
    {
        public Guid Id { get; set; }
        public string Tab { get; set; } = "initial_data_entry";
    }
}

