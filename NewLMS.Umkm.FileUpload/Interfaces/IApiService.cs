using NewLMS.Umkm.FileUpload.Models;
using Refit;

namespace NewLMS.Umkm.FileUpload.Interfaces
{
    public interface IApiService
    {
        [Multipart]
        [Post("/upload")]
        Task<UploadResponseModel> Upload(string segment,string debtorName,string loanApplicationId,string documentName,StreamPart File);
        [Multipart]
        [Post("/generate-file")]
        Task<GenerateFileResponseModel> GenerateFile(string segment,string debtorName, string loanApplicationId, string fileTemplate, StreamPart File);
    }
}
