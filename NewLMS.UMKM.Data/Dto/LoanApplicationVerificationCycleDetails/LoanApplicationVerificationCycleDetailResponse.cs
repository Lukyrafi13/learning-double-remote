using NewLMS.Umkm.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.LoanApplicationVerificationCycleDetails
{
    public class LoanApplicationVerificationCycleDetailResponse
    {
        public Guid Id { get; set; }
        public Guid LoanApplicationId { get; set; }
        public string Flaging { get; set; }
        public string Description { get; set; }
        public double Total { get; set; }
        public string Unit { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }
    }
}
