using NewLMS.Umkm.Maps.Models;
using Refit;

namespace NewLMS.Umkm.Maps.Interfaces
{
    public interface IApiService
    {
        [Post("/user_locations")]
        Task<UserLocationResponseModel> PostUserLocation([Body(BodySerializationMethod.Serialized)] UserLocationRequestModel request);
    }
}
