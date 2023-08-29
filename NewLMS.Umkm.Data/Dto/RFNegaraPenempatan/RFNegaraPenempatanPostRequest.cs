namespace NewLMS.Umkm.Data.Dto.RFNegaraPenempatans
{
    public class RFNegaraPenempatanPostRequestDto
    {
        public string NegaraCode { get; set; }
        public string NegaraDesc { get; set; }
        public string CoreCode { get; set; }
        public bool? ShowKUR { get; set; }
        public double? Kurs { get; set; }
        public bool? Active { get; set; }
    }
}
