using Bjb.DigitalBisnis.DigiloanAPI.Models;

namespace Bjb.DigitalBisnis.DigiloanAPI.Interfaces
{
    public interface IDigiloanService
    {
        Task<SendDocumentResponseModel> SendDocumentToDigiloan(SendDocumentRequestModel request);
        Task<SendResultDisbursementResponseModel> SendDisbursementToDigiloan(SendResultDisbursementRequestModel request);
    }
}
