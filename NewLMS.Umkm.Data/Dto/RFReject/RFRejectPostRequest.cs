namespace NewLMS.UMKM.Data.Dto.RFRejects
{
    public class RFRejectPostRequestDto
    {
        public string RjCode { get; set; }
        public string RjDesc { get; set; }
        public string CoreCode { get; set; }
        public int? Priority { get; set; }
        public bool Active { get; set; }
    }
}
