using Bjb.DigitalBisnis.DigiloanAPI.Models;
using Refit;

namespace Bjb.DigitalBisnis.DigiloanAPI.Interfaces
{
    public interface IApiService
    {
        [Post("/callback/signed-document")]
        Task<SendDocumentResponseModel> SendDocument([Body(BodySerializationMethod.Serialized)] SendDocumentRequestModel request);
        [Post("/callback/disbursement")]
        Task<SendResultDisbursementResponseModel> SendDisbursement([Body(BodySerializationMethod.Serialized)] SendResultDisbursementRequestModel request);
    }
}
