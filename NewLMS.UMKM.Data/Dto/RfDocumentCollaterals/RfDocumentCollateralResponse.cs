using NewLMS.UMKM.Data.Dto.RfCollateralBC;
using NewLMS.UMKM.Data.Dto.RfDocument;
using NewLMS.UMKM.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.RfDocumentCollateral
{
    public class RfDocumentCollateralResponse : BaseResponse
    {
        public Guid DocumentCollateralCode { get; set; }
        public RfDocumentSimpleResponse RfDocument { get; set; }
        public RfCollateralBCSimpleResponse RfCollateralBC { get; set; }
        public bool Active { get; set; }
    }

    public class RfDocumentCollateralSimpleResponse
    {
        public Guid DocumentCollateralCode { get; set; }
        public RfDocumentSimpleResponse RfDocument { get; set; }
        public RfCollateralBCSimpleResponse RfCollateralBC { get; set; }
    }
}
