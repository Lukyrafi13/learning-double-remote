using NewLMS.UMKM.SIKP2.Interfaces;
using NewLMS.UMKM.SIKP2.Models;

namespace NewLMS.UMKM.SIKP2.Services
{
    public class SIKPService2 : ISIKPService2
    {
        private readonly IApiService _apiService;

        public SIKPService2(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<RateAkadResponseModel> GetRateAkad(RateAkadRequestModel request)
        {
            try
            {
                var response = await _apiService.PostSIKPRateAkad(request);
                return response;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
