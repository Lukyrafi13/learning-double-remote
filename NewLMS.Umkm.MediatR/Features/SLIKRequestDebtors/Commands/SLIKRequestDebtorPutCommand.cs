using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.SLIKRequestDebtors;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.FileUpload.Interfaces;
using NewLMS.Umkm.FileUpload.Models;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.SLIKRequestDebtors.Commands
{
    public class SLIKRequestDebtorPutCommand : SLIKRequestDebtorPutRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class SLIKRequestDebtorPutCommandHandler : IRequestHandler<SLIKRequestDebtorPutCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<SLIKRequestDebtor> _slikRequestDebtor;
        private readonly IGenericRepositoryAsync<SLIKRequest> _slikRequest;
        private readonly IGenericRepositoryAsync<FileUrl> _fileUrl;
        private readonly ICurrentUserService _currentUserService;
        private readonly IUploadService _uploadService;
        private readonly IMapper _mapper;

        public SLIKRequestDebtorPutCommandHandler(IGenericRepositoryAsync<SLIKRequestDebtor> slikRequestDebtor, IMapper mapper, IGenericRepositoryAsync<SLIKRequest> slikRequests, IGenericRepositoryAsync<FileUrl> fileUrl, ICurrentUserService currentUserService, IUploadService uploadService)
        {
            _slikRequestDebtor = slikRequestDebtor;
            _mapper = mapper;
            _slikRequest = slikRequests;
            _fileUrl = fileUrl;
            _currentUserService = currentUserService;
            _uploadService = uploadService;
        }

        public async Task<ServiceResponse<Unit>> Handle(SLIKRequestDebtorPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var slikRequestDebtor = await _slikRequestDebtor.GetByIdAsync(request.Id) ?? throw new NullReferenceException("Data Debitur tidak ditemukan.") ?? throw new NullReferenceException("Data SLIK Debtor tidak ditemukan.");
                var slikId = slikRequestDebtor.SLIKRequestId;
                var slikRequestDebtorId = slikRequestDebtor.Id;

                slikRequestDebtor = _mapper.Map<SLIKRequestDebtor>(request);
                slikRequestDebtor.Id = slikRequestDebtorId;
                slikRequestDebtor.SLIKRequestId = slikId;

                if (request.Files != null)
                {
                    var Includes = new string[]
                    {
                        "LoanApplication",
                        "LoanApplication.Prospect",
                        "LoanApplication.Debtor",
                    };

                    var dataSlikRequest = await _slikRequest.GetByIdAsync(slikRequestDebtor.SLIKRequestId, "Id", Includes);


                    if (slikRequestDebtor.SLIKDocumentUrlId != null) // Update
                    {

                        var upload = _uploadService.Upload(new UploadRequestModel
                        {
                            Segment = "Konsumer",
                            DebtorName = dataSlikRequest.LoanApplication.Debtor.Fullname,
                            DocumentName = $"{"slikAdmin"}",
                            File = request.Files,
                            LoanApplicationId = dataSlikRequest.LoanApplication.LoanApplicationId,
                        });

                        var fileType = Path.GetExtension(request.Files.FileName);
                        fileType = fileType.Replace(".", "");
                        var fileUrl = await _fileUrl.GetByIdAsync((Guid)slikRequestDebtor.SLIKDocumentUrlId, "FileUrlId");
                        fileUrl.Url = upload.Result.Data.ToString();
                        fileUrl.FileSize = request.Files.Length.ToString();
                        fileUrl.FileType = fileType;
                        await _fileUrl.UpdateAsync(fileUrl);
                        slikRequestDebtor.SLIKDocumentUrlId = fileUrl.Id;
                    }
                    else  // Insert
                    {
                        var upload = _uploadService.Upload(new UploadRequestModel
                        {
                            Segment = "UMKM",
                            DebtorName = dataSlikRequest.LoanApplication.Debtor.Fullname,
                            DocumentName = $"{"slikAdmin"}",
                            File = request.Files,
                            LoanApplicationId = dataSlikRequest.LoanApplication.LoanApplicationId,
                        });

                        var fileType = Path.GetExtension(request.Files.FileName);
                        fileType = fileType.Replace(".", "");
                        var fileUrl = new FileUrl
                        {
                            CreatedDate = DateTime.Now,
                            CreatedBy = Guid.Parse(_currentUserService.Id),
                            Url = upload.Result.Data.ToString(),
                            FileSize = request.Files.Length.ToString(),
                            FileType = fileType,
                        };
                        var slikUrl = await _fileUrl.AddAsync(fileUrl);
                        slikRequestDebtor.SLIKDocumentUrlId = fileUrl.Id;
                    }

                }

                await _slikRequestDebtor.UpdateAsync(slikRequestDebtor);

                return ServiceResponse<Unit>.ReturnResultWith201(Unit.Value);

            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }

        }
    }
}
