using NewLMS.UMKM.Data.Dto.RfLoanPurpose;
using NewLMS.UMKM.Data.Dto.RfProduct;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.RfSubProduct
{
    public class RfSubProductResponse : BaseResponse
    {
        public string SubProductId { get; set; }
        public string SubProductDesc { get; set; }
        public RfProductSimpleResponse RfProduct { get; set; }
        public bool? MandNPWP { get; set; }
        public RfLoanPurposeSimpleResponse RfLoanPurpose { get; set; }
        public string SIKPSkema { get; set; }
        public string SIKPParentSkema { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
    }

    public class RfSubProductSimpleResponse
    {
        public string SubProductId { get; set; }
        public string SubProductDesc { get; set; }
    }
}
