using System;
using NewLMS.UMKM.Data;

namespace NewLMS.UMKM.Data.Dto.SPPKs
{
    public class SPPKHalamanUtamaResponse : SPPKHalamanUtamaPut
    {
        public SCJabatan JabatanSKK1 { get; set; }

        public SCJabatan JabatanSKK2 { get; set; }

        public SCJabatan JabatanSPPK1 { get; set; }

        public SCJabatan JabatanSPPK2 { get; set; }

        public SCJabatan JabatanMKK1 { get; set; }

        public SCJabatan JabatanMKK2 { get; set; }

        public SCJabatan JabatanMKK3 { get; set; }

        public SCJabatan JabatanMKK4 { get; set; }

        public SCJabatan JabatanMKK5 { get; set; }
    }
}
