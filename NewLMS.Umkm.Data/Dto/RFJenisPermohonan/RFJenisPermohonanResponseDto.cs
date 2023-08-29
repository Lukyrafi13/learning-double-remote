using System;
namespace NewLMS.Umkm.Data.Dto.RFJenisPermohonans
{
    public class RFJenisPermohonanResponseDto : BaseResponse
    {
		public Guid Id { get; set; }
		public string JenisPermohonan { get; set; }
    }
}
