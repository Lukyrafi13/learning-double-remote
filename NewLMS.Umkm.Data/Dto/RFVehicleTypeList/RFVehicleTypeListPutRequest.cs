using System;

namespace NewLMS.UMKM.Data.Dto.RFVehicleTypeLists
{
    public class RFVehicleTypeListPutRequestDto : RFVehicleTypeListPostRequestDto
    {
        public Guid Id { get; set; }
    }
}
