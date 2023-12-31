﻿using Bjb.DigitalBisnis.FileUpload.Interfaces;
using Bjb.DigitalBisnis.FileUpload.Models;
using MediatR;
using NewLMS.Umkm.Data.Dto.DocumentSurveys;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.DocumentSurveys.Commands
{
    public class DocumentSurveyUploadCommand : DocumentSurveyUploadRequest, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DocumentSurveyUploadCommandHandler : IRequestHandler<DocumentSurveyUploadCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<Document> _documentRepo;
        private readonly IGenericRepositoryAsync<DocumentFileUrl> _documentFileUrl;
        private readonly IGenericRepositoryAsync<FileUrl> _fileUrl;
        private readonly IGenericRepositoryAsync<LoanApplication> _loanApplication;
        private readonly ICurrentUserService _userInfoToken;
        private readonly IUploadService _uploadService;

        public DocumentSurveyUploadCommandHandler(
            IGenericRepositoryAsync<Document> documentRepo,
            IGenericRepositoryAsync<DocumentFileUrl> documentFileUrl,
            IGenericRepositoryAsync<FileUrl> fileUrl,
            IGenericRepositoryAsync<LoanApplication> loanApplication,
            ICurrentUserService userInfoToken,
            IUploadService uploadService)
        {
            _documentRepo = documentRepo;
            _documentFileUrl = documentFileUrl;
            _fileUrl = fileUrl;
            _loanApplication = loanApplication;
            _userInfoToken = userInfoToken;
            _uploadService = uploadService;
        }

        public async Task<ServiceResponse<Unit>> Handle(DocumentSurveyUploadCommand command, CancellationToken cancellationToken)
        {

            try
            {
                var documentId = Guid.NewGuid();
                var documentRepo = new Document
                {
                    Id = documentId,
                    LoanApplicationId = command.LoanApplicationId,
                    DocumentType = command.DocumentType,
                    Title = command.Title,
                    CreatedDate = command.UploadDate,
                };

                var documentFileUrls = new List<DocumentFileUrl>();
                var fileUrls = new List<FileUrl>();

                if (command.Files != null)
                {
                    var Includes = new string[]
                    {
                       "Debtor",
                       "DebtorCompany",
                    };
                    var dataLoanApplication = await _loanApplication.GetByIdAsync(command.LoanApplicationId, "Id", Includes);
                    var debtorName = "";
                    if (dataLoanApplication.OwnerCategoryId == 1)
                    {
                        debtorName = dataLoanApplication.Debtor.Fullname;
                    }
                    if (dataLoanApplication.OwnerCategoryId == 2)
                    {
                        debtorName = dataLoanApplication.DebtorCompany.Name;
                    }

                    command.Files.ToList().ForEach(f =>
                    {
                        var upload = _uploadService.Upload(new UploadRequestModel
                        {
                            Segment = "UMKM",
                            DebtorName = debtorName,
                            DocumentName = command.DocumentType,
                            File = f,
                            LoanApplicationId = dataLoanApplication.LoanApplicationId,
                        });

                        if (upload != null)
                        {
                            var fileType = Path.GetExtension(f.FileName);
                            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                            var fileUrlId = Guid.NewGuid();

                            fileType = fileType.Replace(".", "");
                            documentFileUrls.Add(new DocumentFileUrl
                            {
                                Id = Guid.NewGuid(),
                                DocumentId = documentId,
                                FileUrlId = fileUrlId,
                                CreatedDate = command.UploadDate,
                                CreatedBy = Guid.Parse(_userInfoToken.Id),
                            });

                            fileUrls.Add( new FileUrl
                            {
                                Id = fileUrlId,
                                CreatedDate = command.UploadDate,
                                CreatedBy = Guid.Parse(_userInfoToken.Id),
                                Url = upload.Result.Data.ToString(),
                                FileName = DocumentHelper.getFileName(upload.Result.Data.ToString()),
                                FileSize = f.Length.ToString(),
                                FileType = fileType,
                            });
                        }
                        else
                        {
                            throw new Exception("Gagal Upload");
                        }
                    });
                }

                await _documentRepo.AddAsync(documentRepo);
                if (fileUrls.Count > 0)
                {
                    await _fileUrl.AddRangeAsync(fileUrls);

                    if (documentFileUrls.Count > 0)
                    {
                        await _documentFileUrl.AddRangeAsync(documentFileUrls);
                    }
                }


                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
