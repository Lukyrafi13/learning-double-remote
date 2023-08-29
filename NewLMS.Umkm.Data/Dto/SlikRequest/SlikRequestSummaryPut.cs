using System;
namespace NewLMS.UMKM.Data.Dto.SlikRequests
{
    public class SlikRequestSummaryPut
    {
        public Guid Id { get; set; }

        public string Comment { get; set; }
        public bool? MembacaDanMemahami { get; set; }
        
        public Guid? AppId { get; set; }
    }
}
