using NewLMS.Umkm.SIKP.Interfaces;
using NewLMS.Umkm.SIKP.Models;

namespace NewLMS.Umkm.SIKP.Services
{
    public class SIKPService : ISIKPService
    {
        private readonly IApiService _apiService;

        public SIKPService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<CalonDebiturResponseModel> GetCalonDebitur(string nik)
        {
            try
            {
                var response = await _apiService.GetSIKPCalonDebitur(nik);
                return response;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<LimitAkadResponseModel> GetLimitAkadSkemaSektor(LimitAkadRequestModel requestModel)
        {
            try
            {
                var response = await _apiService.GetSIKPLimitAkadSkemaSektor(requestModel);
                return response;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<PlafonResponseModel> GetPlafon(string nik)
        {
            try
            {
                var response = await _apiService.GetSIKPPlafon(nik);
                return response;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<PostCalonDebiturResponseModel> PostCalonDebitur(PostCalonDebiturRequestModel requestModel)
        {
            try
            {
                var response = await _apiService.PostSIKPCalonDebitur(requestModel);
                return response;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
