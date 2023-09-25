using NewLMS.Umkm.Data.Dto.RfDocument;
using NewLMS.Umkm.Data.Dto.RfParameterDetails;
using NewLMS.Umkm.Data.Dto.RfProducts;
using NewLMS.Umkm.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.RfMappingDocumentPrescreenings
{
    public class RfMappingDocumentPrescreeningResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public string DocumentType { get; set; }
        public string ProductId { get; set; }
        public int? OwnerCategoryId { get; set; }
        public string DocumentCode { get; set; }

        public virtual RfProductSimpleResponse RfProduct { get; set; }
        public virtual RfParameterDetailSimpleResponse OwnerCategory { get; set; }
        public virtual RfDocumentSimpleResponse RfDocument { get; set; }
    }
}
