using System;
using System.Collections.Generic;

namespace NewLMS.UMKM.Data.Dto.SlikRequests
{
    public class SlikRequestProsesAdminResponse
    {
        public string Message { get; set; }
        public byte[] FileKontingensi { get; set; }
        public List<SlikRequestProsesResponse> ProsesResponse { get; set; }
    }
}
