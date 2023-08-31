using System;
namespace NewLMS.UMKM.Data.Dto.Apps
{
    public class AppValidateResponse
    {
        public Guid Id { get; set; }
        public bool Valid { get; set; }
        public string Message { get; set; }
    }
}
