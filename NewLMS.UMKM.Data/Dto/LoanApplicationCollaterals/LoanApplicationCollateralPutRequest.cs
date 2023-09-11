using NewLMS.UMKM.Data.Dto.LoanApplicationCollateralOwners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.LoanApplicationCollaterals
{
    public class LoanApplicationCollateralAndOwnerPutRequest
    {
        public LoanApplicationCollateralPutRequest LoanApplicationCollateral { get; set; }
        public LoanApplicationCollateralOwnerRequest LoanApplicationCollateralOwner { get; set; }
    }

    public class LoanApplicationCollateralPutRequest : LoanApplicationCollateralRequest
    {
        public Guid Id { get; set; }
    }
}
