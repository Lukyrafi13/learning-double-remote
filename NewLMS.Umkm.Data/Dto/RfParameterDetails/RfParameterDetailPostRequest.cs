namespace NewLMS.Umkm.Data.Dto.RfParameterDetails
{
    public class RfParameterDetailPostRequest
    {
        public int ParameterId { get; set; }
		public string Code { get; set; }
        public string CoreCode { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int Order { get; set; }
		public bool Active { get; set; }
    }
}
