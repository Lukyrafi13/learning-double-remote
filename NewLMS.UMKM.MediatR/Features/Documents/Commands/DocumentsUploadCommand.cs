using Bjb.DigitalBisnis.CurrentUser.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
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
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.Documents.Commands
{
    public class DocumentsUploadCommand : DocumentUploadRequest, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DocumentsUploadCommandHandler : IRequestHandler<DocumentsUploadCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<Document> _documentRepo;
        private readonly IGenericRepositoryAsync<DocumentFileUrl> _documentFileUrl;
        private readonly IGenericRepositoryAsync<FileUrl> _fileUrl;
        private readonly IGenericRepositoryAsync<LoanApplication> _loanApplication;
        private readonly IGenericRepositoryAsync<RfParameterDetail> _rfParameterDetail;
        private readonly ICurrentUserService _userInfoToken;
        private readonly IConfiguration _appConfig;
        private readonly IUploadService _uploadService;

        public DocumentsUploadCommandHandler(
            IGenericRepositoryAsync<Document> documentRepo,
            IGenericRepositoryAsync<DocumentFileUrl> documentFileUrl,
            IGenericRepositoryAsync<FileUrl> fileUrl,
            IGenericRepositoryAsync<LoanApplication> loanApplication,
            IGenericRepositoryAsync<RfParameterDetail> rfParameterDetail,
            IConfiguration appConfig, 
            ICurrentUserService userInfoToken,
            IUploadService uploadService)
        {
            _documentRepo = documentRepo;
            _documentFileUrl = documentFileUrl;
            _fileUrl = fileUrl;
            _loanApplication = loanApplication;
            _rfParameterDetail = rfParameterDetail;
            _userInfoToken = userInfoToken;
            _appConfig = appConfig;
            _uploadService = uploadService;
        }

        public async Task<ServiceResponse<Unit>> Handle(DocumentsUploadCommand command, CancellationToken cancellationToken)
        {

            try
            {
                var documentId = Guid.NewGuid();
                var entity = new Document()
                {
                    DocumentId = command.DocumentId,
                    LoanApplicationId = command.LoanApplicationId,
                    DocumentType = command.DocumentType,
                };

                var documentFileUrls = new System.Collections.Generic.List<DocumentFileUrl>();
                var fileUrls = new System.Collections.Generic.List<FileUrl>();

                if (command.Files != null)
                {
                    var Includes = new string[]
                    {
                       "FkRfDebtor",
                    };

                    var dataLoanApplication = await _loanApplication.GetByIdAsync(command.LoanApplicationId, "Id", Includes);
                    var documentType = await _rfParameterDetail.GetByPredicate(x => x.ParameterDetailId == command.DocumentType);
                    command.Files.ToList().ForEach(f =>
                    {
                        var upload = _uploadService.Upload(new FileUpload.Models.UploadRequestModel
                        {
                            Segment = "KprKkb",
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
                                DocumentId = documentId,
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

                await _documentRepo.AddAsync(entity);
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
