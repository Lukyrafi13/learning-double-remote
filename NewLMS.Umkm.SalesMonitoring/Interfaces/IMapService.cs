using NewLMS.Umkm.Maps.Models;

namespace NewLMS.Umkm.Maps.Interfaces
{
    public interface IMapService
    {
        Task<UserLocationResponseModel> AddUserLocation(UserLocationRequestModel request);
    }
}
