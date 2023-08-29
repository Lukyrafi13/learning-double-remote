using System;
using System.Collections.Generic;

namespace NewLMS.UMKM.Data.Dto.VerifikasiPersiapanAkads
{
    public class VerifikasiPersiapanAkadTableResponse
    {
        public Guid Id { get; set; }
        public SPPK SPPK { get; set; }

        public int Age { get; set; }

        public App App { get; set; }
        public Prescreening Prescreening { get; set; }
        public Survey Survey { get; set; }
        public Analisa Analisa { get; set; }
        public PersiapanAkad PersiapanAkad { get; set; }
    }
}
