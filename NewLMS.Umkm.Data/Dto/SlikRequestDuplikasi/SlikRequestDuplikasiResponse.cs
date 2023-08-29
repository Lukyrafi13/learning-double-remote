using System.Collections.Generic;
using NewLMS.Umkm.Data.Dto.MSearchs;

namespace NewLMS.Umkm.Data.Dto.SlikRequestDuplikasis
{
    public class SlikRequestDuplikasiResponse
    {
        public SlikRequestDuplikasiLMSResponse Internal { get; set; }
        public SlikRequestDuplikasiLMSResponse Core { get; set; }
        public SlikRequestDuplikasiLMSResponse DHN { get; set; }
    }

    public class SlikRequestDuplikasiDetailResponse
    {
        public bool IsDuplicate { get; set; }
        public List<MSearchResponse> MSearch { get; set; }
    }

    public class SlikRequestDuplikasiLMSResponse : SlikRequestDuplikasiDetailResponse
    {

    }
    public class SlikRequestDuplikasiCoreResponse : SlikRequestDuplikasiDetailResponse
    {

    }
    public class SlikRequestDuplikasiDHNResponse : SlikRequestDuplikasiDetailResponse
    {

    }
}