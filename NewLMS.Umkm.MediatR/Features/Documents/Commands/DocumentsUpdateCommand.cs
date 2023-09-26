using AutoMapper;
using Bjb.DigitalBisnis.CurrentUser.Interfaces;
using MediatR;
using NewLMS.Umkm.Data.Dto.Documents;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.FileUpload.Interfaces;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.Documents.Commands
{
    public class DocumentsUpdateCommand : DocumentUpdateRequest, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DocumentsUpdateCommandHandler : IRequestHandler<DocumentsUpdateCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<Document> _documentRepo;
        private readonly IGenericRepositoryAsync<DocumentFileUrl> _documentFileUrl;
        private readonly IGenericRepositoryAsync<FileUrl> _fileUrl;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _userInfoToken;
        private readonly IUploadService _uploadService;
        private readonly IGenericRepositoryAsync<LoanApplication> _loanApplication;

        public DocumentsUpdateCommandHandler(
            IGenericRepositoryAsync<Document> documentRepo,
            IGenericRepositoryAsync<DocumentFileUrl> documentFileUrl,
            IGenericRepositoryAsync<FileUrl> fileUrl,
            IGenericRepositoryAsync<LoanApplication> loanApplication,
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
                    entity.DocumentCategory = command.DocumentCategory;
                };
                await _documentRepo.UpdateAsync(entity);
                
                var documentFileUrls = new List<DocumentFileUrl>();
                var fileUrls = new List<FileUrl>();

                if (command.Files != null)
                {
                    var debtorName = "";
                    var Includes = new string[]
                    {
                        "Debtor",
                        "DebtorCompany",
                    };
                    var dataLoanApplication = await _loanApplication.GetByIdAsync(entity.LoanApplicationId, "Id", Includes);
                    if(dataLoanApplication.OwnerCategoryId == 1)
                    {
                        debtorName = dataLoanApplication.Debtor.Fullname;
                    }
                    if (dataLoanApplication.OwnerCategoryId == 2)
                    {
                        debtorName = dataLoanApplication.DebtorCompany.Name;
                    }

                    command.Files.ToList().ForEach(f =>
                    {
                        var upload = _uploadService.Upload(new FileUpload.Models.UploadRequestModel
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
