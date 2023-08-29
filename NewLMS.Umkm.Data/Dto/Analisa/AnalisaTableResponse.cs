using System;
using System.Collections.Generic;

namespace NewLMS.Umkm.Data.Dto.Analisas
{
    public class AnalisaTableResponse
    {
        public Guid Id { get; set; }
        public int Age { get; set; }

        public App App { get; set; }
        public Prescreening Prescreening { get; set; }
        public Survey Survey { get; set; }
        public SlikRequest SlikRequest { get; set; }
    }
}
