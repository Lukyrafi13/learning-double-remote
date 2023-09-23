using NewLMS.Umkm.FileUpload.Models;

namespace NewLMS.Umkm.FileUpload.Interfaces
{
    public interface IUploadService
    {
        Task<UploadResponseModel> Upload(UploadRequestModel request);
        Task<GenerateFileResponseModel> GenerateFile(GenerateFileRequestModel request);
    }
}
