using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.SlikRequestObjects;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;
using System.IO;

namespace NewLMS.Umkm.MediatR.Features.SlikRequestObjects.Commands
{
    public class SlikRequestObjectUploadCommandPostCommand : SlikRequestObjectFindRequestDto, IRequest<ServiceResponse<SlikRequestObjectResponseDto>>
    {
        public IFormFile File { get; set; }
    }
    public class SlikRequestObjectUploadCommandPostCommandHandler : IRequestHandler<SlikRequestObjectUploadCommandPostCommand, ServiceResponse<SlikRequestObjectResponseDto>>
    {
        private readonly IConfiguration _appConfig;
        private readonly IGenericRepositoryAsync<SlikRequestObject> _SlikRequestObject;
        private readonly IGenericRepositoryAsync<SlikRequest> _SlikRequest;
        private readonly IGenericRepositoryAsync<FileUrl> _FileUrl;
        private readonly IMapper _mapper;

        public SlikRequestObjectUploadCommandPostCommandHandler(
            IGenericRepositoryAsync<SlikRequestObject> SlikRequestObject,
            IGenericRepositoryAsync<SlikRequest> SlikRequest,
            IGenericRepositoryAsync<FileUrl> FileUrl,
            IConfiguration appConfig,
            IMapper mapper)
        {
            _SlikRequestObject = SlikRequestObject;
            _SlikRequest = SlikRequest;
            _FileUrl = FileUrl;
            _appConfig = appConfig;
            _mapper = mapper;
        }

        
        (string root, string sub, string loanapplicationId, string documentName, string timestamp) _GetSaveDir(IFormFile file, string ForderName, string loanapplicationId, string documentName, string timestamp) => "Directory" switch
        {
            "Directory" => (_appConfig.GetValue<string>("UMKMStorage:Directory"), _GetDirByDocType(file, ForderName), loanapplicationId, documentName, timestamp),
            _ => throw new NotSupportedException()
        };

        string rootDir => "Directory" switch
        {
            "Directory" => _appConfig.GetValue<string>("UMKMStorage:Directory"),
            _ => throw new NotSupportedException()
        };

        string _GetDirByDocType(IFormFile file, String FolderName)
        {
            if (file.IsValidTypeFile())
            {
                return FolderName;
            }
            else
                return _appConfig.GetValue<string>("UMKMStorage:Folders:Default");
        }

        public async Task<ServiceResponse<SlikRequestObjectResponseDto>> Handle(SlikRequestObjectUploadCommandPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var existingSlikRequestObjectUploadCommand = await _SlikRequestObject.GetByIdAsync(request.Id, "Id");

                var includes = new string[] {
                    "App"
                };

                if (request.File != null){

                    // Check if file is PDF
                    if (!request.File.IsDocument()){
                        var responseFail = ServiceResponse<SlikRequestObjectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "Format file tidak valid, pastikan file dalam bentuk PDF");
                        responseFail.Success = false;

                        return responseFail;
                    }

                    var exisitingSlikRequest = await _SlikRequest.GetByIdAsync(existingSlikRequestObjectUploadCommand.SlikRequestId, "Id", includes);

                    var FolderName = "slikadmins/" + $"{exisitingSlikRequest.App.AplikasiId}{"_"}{Regex.Replace(exisitingSlikRequest.App.AplikasiId, "[^A-Za-z0-9]+", "_")}";
                    
                    var dir = Path.Combine(rootDir, FolderName).Replace(@"\", @"/").Replace(@"\\", @"/");
                    
                    if (!Directory.Exists(dir))
                    {
                        var createDir = Directory.CreateDirectory(dir.ToString());
                    }

                    var timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");

                    if(existingSlikRequestObjectUploadCommand.SLIKDocumentUrl != null) // Update
                    {
                        var fileUrl = await _FileUrl.GetByIdAsync((Guid)existingSlikRequestObjectUploadCommand.SLIKDocumentUrl, "Id");
                            fileUrl.Url = await request.File.SaveToLocal(_GetSaveDir(request.File, FolderName, exisitingSlikRequest.App.AplikasiId.ToString(), "SLIK", timestamp));
                            fileUrl.FileSize = request.File.Length.ToString();
                            fileUrl.FileType = await request.File.getType(_GetSaveDir(request.File, FolderName, exisitingSlikRequest.App.AplikasiId.ToString(), "SLIK", timestamp));
                        await _FileUrl.UpdateAsync(fileUrl);
                    }
                    else  // Insert
                    {
                        var FileUrl = new FileUrl
                        {
                            CreatedDate = DateTime.Now,
                            Url = await request.File.SaveToLocal(_GetSaveDir(request.File, FolderName, exisitingSlikRequest.App.AplikasiId.ToString(), "SLIK", timestamp)),
                            FileSize = request.File.Length.ToString(),
                            FileType = await request.File.getType(_GetSaveDir(request.File, FolderName, exisitingSlikRequest.App.AplikasiId.ToString(), "SLIK", timestamp))
                        };
                        var slikUrl = await _FileUrl.AddAsync(FileUrl);
                        existingSlikRequestObjectUploadCommand.SLIKDocumentUrl = slikUrl.Id;

                        await _SlikRequestObject.UpdateAsync(existingSlikRequestObjectUploadCommand);
                    }
                }

                

                // var response = _mapper.Map<SlikRequestObjectResponseDto>(returnedSlikRequestObjectUploadCommand);
                var response = _mapper.Map<SlikRequestObjectResponseDto>(existingSlikRequestObjectUploadCommand);

                return ServiceResponse<SlikRequestObjectResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                var response = ServiceResponse<SlikRequestObjectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                response.Success = false;
                return response;
            }
        }
    }
}