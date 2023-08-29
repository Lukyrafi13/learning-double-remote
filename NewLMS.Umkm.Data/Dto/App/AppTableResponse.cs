using System;
namespace NewLMS.UMKM.Data.Dto.Apps
{
    public class AppTableResponse
    {
        public Guid Id { get; set; }
        public string AplikasiId { get; set; }
        public string CustomerName { get; set; }
        public string BookingOffice { get; set; }
        public string NamaAO { get; set; }
        public string ProductLengkap { get; set; }
        public string Product { get; set; }
        public string Aging { get; set; }
        public int Age { get; set; }
        public string SumberData { get; set; }
        public RFStages Stage { get; set; }
    }
}
