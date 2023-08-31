using System;

namespace NewLMS.UMKM.Data.Dto.SPPKs
{
    public class SPPKTableResponse
    {
        public Guid Id { get; set; }

        public Analisa Analisa { get; set; }
        public LoanApplication LoanApplication { get; set; }

        public int Age { get; set; }
    }
}
