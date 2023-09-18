using NewLMS.UMKM.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.LoanApplicationVerificationCycles
{
    public class LoanApplicationVerificationCyclePostRequest
    {
        public Guid Id { get; set; }

        //Informasi Omset
        public int? BusinessLandFormCode { get; set; }
        public int? BusinessLandAreaCode { get; set; }
        public double LandArea { get; set; }
        public int? BusinessCapacityCode { get; set; }
        public double BusinessLandCapacity { get; set; }
        public double AnnualSales { get; set; }
        public double NetWorthOfPlaceBusiness { get; set; }
    }
}
