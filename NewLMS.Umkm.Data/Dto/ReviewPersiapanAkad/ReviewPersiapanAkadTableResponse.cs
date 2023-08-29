using System;
using System.Collections.Generic;

namespace NewLMS.Umkm.Data.Dto.ReviewPersiapanAkads
{
    public class ReviewPersiapanAkadTableResponse
    {
        public Guid Id { get; set; }

        public int Age {get; set; }

        public App App { get; set; }
        public Prescreening Prescreening { get; set; }
        public Survey Survey { get; set; }
        public SPPK SPPK { get; set; }
        public Analisa Analisa { get; set; }
        public PersiapanAkad PersiapanAkad { get; set; }
    }
}
