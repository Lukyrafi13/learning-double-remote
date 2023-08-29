namespace NewLMS.Umkm.Data.Dto.RFSiklusUsahas
{
    public class RFSiklusUsahaPostRequestDto
    {
        public string SiklusCode { get; set; }
        public string SiklusDesc { get; set; }
        public string CoreCode { get; set; }
        public bool? IsResiGudang { get; set; }
        public int? MCount { get; set; }
        public bool Active { get; set; }
    }
}
