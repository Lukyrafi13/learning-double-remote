using System;
using System.Collections.Generic;

namespace NewLMS.Umkm.Data.Dto.Prescreenings
{
    public class PrescreeningTableResponse
    {
        public Guid Id { get; set; }

        public DateTime TanggalRequest { get; set; }
        public string StatusSLIK { get; set; }
        public int Age { get; set; }

        public App App { get; set; }
        public RFZipCode KodePos { get; set; }
        public SlikRequest SlikRequest { get; set; }

        public List<RFColLateralBC> ListJenisAgunan { get; set; }
    }
}
