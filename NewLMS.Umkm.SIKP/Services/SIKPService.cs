using Microsoft.Extensions.Configuration;
using NewLMS.Umkm.SIKP.Interfaces;
using NewLMS.Umkm.SIKP.Models;

namespace NewLMS.Umkm.SIKP.Services
{
    public class SIKPService : ISIKPService
    {
        private readonly IApiService _apiService;
        private readonly IConfiguration _configuration;
        private const string CONFIGURATION_NAME = "SIKP";

        public SIKPService(IApiService apiService, IConfiguration configuration)
        {
            _apiService = apiService;
            _configuration = configuration;
        }

        public string GetAppCode(){
            SIKPModel option = new();
            _configuration.GetSection(CONFIGURATION_NAME).Bind(option);

            return option.Code;
        }

        public async Task<CalonDebiturResponseModelHeader> GetCalonDebitur(string nik)
        {
            try
            {
                var response = await _apiService.GetSIKPCalonDebitur(nik, GetAppCode());
                return response;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<LimitAkadResponseModelHeader> GetLimitAkadSkemaSektor(LimitAkadRequestModel requestModel)
        {
            try
            {
                var response = await _apiService.GetSIKPLimitAkadSkemaSektor(requestModel, GetAppCode());
                return response;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<PlafonResponseModelHeader> GetPlafon(string nik)
        {
            try
            {
                var response = await _apiService.GetSIKPPlafon(nik, GetAppCode());
                return response;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<PostCalonDebiturResponseModelHeader> PostCalonDebitur(PostCalonDebiturRequestModel requestModel)
        {
            try
            {
                var response = await _apiService.PostSIKPCalonDebitur(requestModel, GetAppCode());
                return response;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<RateAkadResponseModelHeader> GetRateAkad(RateAkadRequestModel request)
        {
            try
            {
                var response = await _apiService.PostSIKPRateAkad(request, GetAppCode());
                return response;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
