﻿using AutoMapper;
using Bjb.DigitalBisnis.CurrentUser.Interfaces;
using DocumentFormat.OpenXml.Office2010.Word;
using MediatR;
using NewLMS.UMKM.Data.Dto.Documents;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.FileUpload.Interfaces;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.Documents.Commands
{
    public class DocumentsUpdateCommand : DocumentUpdateRequest, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DocumentsUpdateCommandHandler : IRequestHandler<DocumentsUpdateCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<Document> _documentRepo;
        private readonly IGenericRepositoryAsync<DocumentFileUrl> _documentFileUrl;
        private readonly IGenericRepositoryAsync<FileUrl> _fileUrl;
        private readonly IGenericRepositoryAsync<RfParameterDetail> _rfParameterDetail;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _userInfoToken;
        private readonly IUploadService _uploadService;
        private readonly IGenericRepositoryAsync<LoanApplication> _loanApplication;

        public DocumentsUpdateCommandHandler(
            IGenericRepositoryAsync<Document> documentRepo,
            IGenericRepositoryAsync<DocumentFileUrl> documentFileUrl,
            IGenericRepositoryAsync<FileUrl> fileUrl,
            IGenericRepositoryAsync<LoanApplication> loanApplication,
            IGenericRepositoryAsync<RfParameterDetail> rfParameterDetail,
            IMapper mapper,
            ICurrentUserService userInfoToken,
            IUploadService uploadService)
        {
            _documentRepo = documentRepo;
            _documentFileUrl = documentFileUrl;
            _fileUrl = fileUrl;
            _userInfoToken = userInfoToken;
            _mapper = mapper;
            _loanApplication = loanApplication;
            _rfParameterDetail = rfParameterDetail;
            _uploadService = uploadService;
        }

        public async Task<ServiceResponse<Unit>> Handle(DocumentsUpdateCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _documentRepo.GetByIdAsync(command.Id, "Id");
                if(entity != null)
                {
                    entity.LoanApplicationId = command.LoanApplicationId;
                    entity.DocumentType = command.DocumentType;
                    entity.DocumentNo = command.DocumentNo;
                    entity.ExpireDate = command.ExpireDate;
                    entity.DocumentStatusId = command.DocumentStatusId;
                    entity.TBODate = command.TBODate;
                    entity.TBODesc = command.TBODesc;
                    entity.Justification = command.Justification;
                    entity.DocumentId = command.DocumentId;
                };
                await _documentRepo.UpdateAsync(entity);
                
                var documentFileUrls = new List<DocumentFileUrl>();
                var fileUrls = new List<FileUrl>();

                if (command.Files != null)
                {
                    var Includes = new string[]
                    {
                        "Debtor",
                    };
                    var dataLoanApplication = await _loanApplication.GetByIdAsync(entity.LoanApplicationId, "Id", Includes);
                    var documentType = await _rfParameterDetail.GetByPredicate(x => x.ParameterDetailId == command.DocumentType);

                    command.Files.ToList().ForEach(f =>
                    {
                        var upload = _uploadService.Upload(new FileUpload.Models.UploadRequestModel
                        {
                            Segment = "UMKM",
                            DebtorName = dataLoanApplication.Debtor.Fullname,
                            DocumentName = documentType.Description,
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
                                DocumentId = command.Id,
                                FileUrlId = fileUrlId,
                                CreatedDate = DateTime.Now,
                                CreatedBy = Guid.Parse(_userInfoToken.Id),
                            });

                            fileUrls.Add(new FileUrl
                            {
                                Id = fileUrlId,
                                CreatedDate = DateTime.Now,
                                CreatedBy = Guid.Parse(_userInfoToken.Id),
                                Url = upload.Result.Data.ToString(),
                                FileName = DocumentHelper.getFileName(upload.Result.Data.ToString()),
                                FileSize = f.Length.ToString(),
                                FileType = fileType,
                            });
                        }
                    });
                }

                
                if (fileUrls.Count > 0)
                {
                    await _fileUrl.AddRangeAsync(fileUrls.ToList());

                    if (documentFileUrls.Count > 0)
                    {
                        await _documentFileUrl.AddRangeAsync(documentFileUrls.ToList());

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
