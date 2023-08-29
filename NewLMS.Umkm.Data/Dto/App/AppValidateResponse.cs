using System;
namespace NewLMS.UMKM.Data.Dto.Apps
{
    public class AppValidateResponse
    {
        public Guid Id { get; set; }
        public bool valid { get; set; }
        public string message { get; set; }
    }
}
