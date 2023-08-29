using System;

namespace NewLMS.UMKM.Data.Dto.SPPKs
{
    public class SPPKTableResponse
    {
        public Guid Id { get; set; }

        public Analisa Analisa { get; set; }
        public App App { get; set; }

        public int Age { get; set; }
    }
}
