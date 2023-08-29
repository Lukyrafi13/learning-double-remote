using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.SPPKFileUploads;
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

namespace NewLMS.Umkm.MediatR.Features.SPPKFileUploads.Commands
{
    public class SPPKFileUploadPostCommand : SPPKFileUploadPostRequestDto, IRequest<ServiceResponse<SPPKFileUploadResponseDto>>
    {
        public IFormFile File { get; set; }
    }
    public class SPPKFileUploadPostCommandHandler : IRequestHandler<SPPKFileUploadPostCommand, ServiceResponse<SPPKFileUploadResponseDto>>
    {
        private readonly IGenericRepositoryAsync<SPPKFileUpload> _SPPKFileUpload;
        private readonly IGenericRepositoryAsync<FileUrl> _FileUrl;
        private readonly IGenericRepositoryAsync<SPPK> _SPPK;
        private readonly IMapper _mapper;
        private readonly IConfiguration _appConfig;

        public SPPKFileUploadPostCommandHandler(
            IGenericRepositoryAsync<SPPKFileUpload> SPPKFileUpload,
            IGenericRepositoryAsync<FileUrl> FileUrl,
            IGenericRepositoryAsync<SPPK> SPPK,
            IConfiguration appConfig,
            IMapper mapper)
        {
            _SPPKFileUpload = SPPKFileUpload;
            _FileUrl = FileUrl;
            _SPPK = SPPK;
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

        string _GetDirByDocType(IFormFile file, string FolderName)
        {
            if (file.IsValidTypeFile())
            {
                return FolderName;
            }
            else
                return _appConfig.GetValue<string>("UMKMStorage:Folders:Default");

        }

        public async Task<ServiceResponse<SPPKFileUploadResponseDto>> Handle(SPPKFileUploadPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var SPPKFileUpload = _mapper.Map<SPPKFileUpload>(request);

                if (request.File != null)
                {
                    var includes = new string[]
                    {
                        "App",
                        "App.Prospect",
                        "App.TipeDebitur",
                        "App.Prospect.Stage",
                        "App.BookingOffice",
                    };
                    var SPPK = await _SPPK.GetByIdAsync(request.SPPKId, "Id", includes);

                    var FolderName = "documents/" + $"{SPPK.App.AplikasiId}{"_"}{Regex.Replace(SPPK.App.Prospect.NamaCustomer, "[^A-Za-z0-9]+", "_")}";
                    var timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");

                    var dir = Path.Combine(rootDir, FolderName).Replace(@"\", @"/").Replace(@"\\", @"/");

                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir.ToString());
                    }

                    var FileId = Guid.NewGuid();

                    var fileURL = new FileUrl
                    {
                        Id = FileId,
                        Url = await request.File.SaveToLocal(_GetSaveDir(request.File, FolderName, SPPK.App.Id.ToString(), request.Judul, timestamp)),
                        FileSize = request.File.Length.ToString(),
                        FileType = await request.File.getType(_GetSaveDir(request.File, FolderName, SPPK.App.Id.ToString(), request.Judul, timestamp))
                    };

                    SPPKFileUpload.FileUrlId = FileId;

                    var returnedFileUrl = await _FileUrl.AddAsync(fileURL);

                }

                var returnedSPPKFileUpload = await _SPPKFileUpload.AddAsync(SPPKFileUpload, callSave: false);

                // var response = _mapper.Map<SPPKFileUploadResponseDto>(returnedSPPKFileUpload);
                var response = _mapper.Map<SPPKFileUploadResponseDto>(returnedSPPKFileUpload);

                await _SPPKFileUpload.SaveChangeAsync();
                return ServiceResponse<SPPKFileUploadResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SPPKFileUploadResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}