using System;
using System.Collections.Generic;

namespace NewLMS.Umkm.Data.Dto.PersiapanAkads
{
    public class PersiapanAkadTableResponse
    {
        public Guid Id { get; set; }

        public int Age  { get; set; }

        public App App { get; set; }
        public SPPK SPPK { get; set; }
        public Analisa Analisa { get; set; }
        public Prescreening Prescreening { get; set; }

        public Guid AppId { get; set; }
        public Guid? SppkId { get; set; }
        public Guid? AnalisaId { get; set; }
        public Guid? PrescreeningId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
