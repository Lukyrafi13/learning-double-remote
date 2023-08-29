using NewLMS.UMKM.Maps.Models;
using Refit;

namespace NewLMS.UMKM.Maps.Interfaces
{
    public interface IApiService
    {
        [Post("/user_locations")]
        Task<UserLocationResponseModel> PostUserLocation([Body(BodySerializationMethod.Serialized)] UserLocationRequestModel request);
    }
}
