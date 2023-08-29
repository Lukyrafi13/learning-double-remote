using System;
using System.Collections.Generic;

namespace NewLMS.Umkm.Data.Dto.Disbursements
{
    public class DisbursementTableResponse
    {
        public Guid Id { get; set; }

        public int Age { get; set; }

        public App App { get; set; }
        public SPPK SPPK { get; set; }
        public Analisa Analisa { get; set; }
        public Prescreening Prescreening { get; set; }
        public PersiapanAkad PersiapanAkad { get; set; }
    }
}
