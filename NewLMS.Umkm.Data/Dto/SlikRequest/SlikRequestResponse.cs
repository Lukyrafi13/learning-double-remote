using System;
using System.Collections.Generic;

namespace NewLMS.UMKM.Data.Dto.SlikRequests
{
    public class SlikRequestTableResponse
    {
        public Guid Id { get; set; }
        public int Age { get; set; }

        public ICollection<SlikRequestObject> SlikRequestObjects { get; set; }

        public LoanApplication LoanApplication { get; set; }
    }
}
