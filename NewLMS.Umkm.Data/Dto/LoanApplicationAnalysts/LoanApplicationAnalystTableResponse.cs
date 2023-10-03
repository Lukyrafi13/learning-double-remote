using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.LoanApplicationAnalysts
{
    public class LoanApplicationAnalystTableResponse
    {
        public Guid Id { get; set; }
        public string LoanApplicationId { get; set; }
        public DateTime RequestDate { get; set; }
        public string SlikStatus { get; set; }
        public string DebtorName { get; set; }
        public DateTime? DebtorDateOfBirth { get; set; }
    }
}
