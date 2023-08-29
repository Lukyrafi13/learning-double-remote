using NewLMS.UMKM.Maps.Interfaces;
using NewLMS.UMKM.Maps.Models;

namespace NewLMS.UMKM.Maps.Services
{
    public class MapService : IMapService
    {
        private readonly IApiService _apiService;

        public MapService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<UserLocationResponseModel> AddUserLocation(UserLocationRequestModel request)
        {
            try
            {
                return await _apiService.PostUserLocation(request);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
