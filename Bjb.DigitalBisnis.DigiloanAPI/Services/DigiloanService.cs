using Bjb.DigitalBisnis.DigiloanAPI.Interfaces;
using Bjb.DigitalBisnis.DigiloanAPI.Models;

namespace Bjb.DigitalBisnis.DigiloanAPI.Services
{
    public class DigiloanService : IDigiloanService
    {
        private readonly IApiService _apiService;

        public DigiloanService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<SendResultDisbursementResponseModel> SendDisbursementToDigiloan(SendResultDisbursementRequestModel request)
        {
            try
            {
                return await _apiService.SendDisbursement(request);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task<SendDocumentResponseModel> SendDocumentToDigiloan(SendDocumentRequestModel request)
        {
            try
            {
                return await _apiService.SendDocument(request);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
