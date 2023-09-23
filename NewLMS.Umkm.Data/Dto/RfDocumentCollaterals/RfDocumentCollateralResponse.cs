using NewLMS.Umkm.Data.Dto.RfCollateralBC;
using NewLMS.Umkm.Data.Dto.RfDocument;
using NewLMS.Umkm.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.RfDocumentCollateral
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
