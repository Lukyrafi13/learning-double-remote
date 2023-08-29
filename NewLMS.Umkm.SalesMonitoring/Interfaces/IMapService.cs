using NewLMS.UMKM.Maps.Models;

namespace NewLMS.UMKM.Maps.Interfaces
{
    public interface IMapService
    {
        Task<UserLocationResponseModel> AddUserLocation(UserLocationRequestModel request);
    }
}
