using System;
namespace NewLMS.Umkm.Data.Dto.Analisas
{
    public class AnalisaProsesResponse
    {
        public Guid? AppId { get; set; }
        public Guid? AnalisaId { get; set; }
        public Guid? ReviewId { get; set; }
        public string Stage { get; set; }
        public string Message { get; set; }
    }
}
