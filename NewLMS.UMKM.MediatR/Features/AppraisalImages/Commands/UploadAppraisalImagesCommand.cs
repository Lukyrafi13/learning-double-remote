using Bjb.DigitalBisnis.CurrentUser.Interfaces;
using MediatR;
using NewLMS.UMKM.Data.Dto.AppraisalImages;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.FileUpload.Interfaces;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.AppraisalImages.Commands
{
    public class UploadAppraisalImagesCommand : AppraisalImagesUploadRequest, IRequest<ServiceResponse<Unit>>
    {

    }

    public class UploadAppraisalImagesCommandHandler : IRequestHandler<UploadAppraisalImagesCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<Document> _documentRepo;
        private readonly IGenericRepositoryAsync<DocumentFileUrl> _documentFileUrl;
        private readonly IGenericRepositoryAsync<FileUrl> _fileUrl;
        private readonly IGenericRepositoryAsync<LoanApplication> _loanApplication;
        private readonly IGenericRepositoryAsync<LoanApplicationAppraisal> _loanApplicationAppraisal;
        private readonly IGenericRepositoryAsync<RfParameterDetail> _rfParameterDetail;
        private readonly ICurrentUserService _userInfoToken;
        private readonly IUploadService _uploadService;

        public UploadAppraisalImagesCommandHandler(
            IGenericRepositoryAsync<Document> documentRepo,
            IGenericRepositoryAsync<DocumentFileUrl> documentFileUrl,
            IGenericRepositoryAsync<FileUrl> fileUrl,
            IGenericRepositoryAsync<LoanApplication> loanApplication,
            IGenericRepositoryAsync<LoanApplicationAppraisal> loanApplicationAppraisal,
            IGenericRepositoryAsync<RfParameterDetail> rfParameterDetail,
            ICurrentUserService userInfoToken,
            IUploadService uploadService)
        {
            _documentRepo = documentRepo;
            _documentFileUrl = documentFileUrl;
            _fileUrl = fileUrl;
            _loanApplication = loanApplication;
            _loanApplicationAppraisal = loanApplicationAppraisal;
            _rfParameterDetail = rfParameterDetail;
            _userInfoToken = userInfoToken;
            _uploadService = uploadService;
        }

        public async Task<ServiceResponse<Unit>> Handle(UploadAppraisalImagesCommand command, CancellationToken cancellationToken)
        {

            try
            {
                var loanApplicationAppraisal = await _loanApplicationAppraisal.GetByPredicate(x => x.AppraisalId == command.AppraisalGuid);
                var documentId = Guid.NewGuid();
                var documentRepo = new Document
                {
                    Id = documentId,
                    LoanApplicationId = loanApplicationAppraisal.LoanApplicationId,
                    AppraisalGuid = command.AppraisalGuid,
                    DocumentType = command.DocumentType,
                    Title = command.Title,
                };

                var fileUrls = new FileUrl();
                var documentFileUrls = new DocumentFileUrl();

                if (command.Files != null)
                {
                    var Includes = new string[]
                    {
                       "Debtor",
                       "DebtorCompany",
                    };
                    var dataLoanApplication = await _loanApplication.GetByIdAsync(loanApplicationAppraisal.LoanApplicationId, "Id", Includes);
                    var documentType = await _rfParameterDetail.GetByPredicate(x => x.ParameterDetailId == command.DocumentType);
                    var debtorName = "";
                    if(dataLoanApplication.OwnerCategoryId == 1)
                    {
                        debtorName = dataLoanApplication.Debtor.Fullname;
                    }
                    if (dataLoanApplication.OwnerCategoryId == 2)
                    {
                        debtorName = dataLoanApplication.DebtorCompany.Name;
                    }

                    var upload = _uploadService.Upload(new FileUpload.Models.UploadRequestModel
                    {
                        Segment = "UMKM",
                        DebtorName = debtorName,
                        DocumentName = documentType.Description,
                        File = command.Files,
                        LoanApplicationId = dataLoanApplication.LoanApplicationId,
                    });

                    if (upload != null)
                    {
                        var fileType = Path.GetExtension(command.Files.FileName);
                        var timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                        var fileUrlId = Guid.NewGuid();

                        fileType = fileType.Replace(".", "");
                        documentFileUrls = new DocumentFileUrl
                        {
                            Id = Guid.NewGuid(),
                            DocumentId = documentId,
                            FileUrlId = fileUrlId,
                            CreatedDate = DateTime.Now,
                            CreatedBy = Guid.Parse(_userInfoToken.Id),
                        };

                        fileUrls = new FileUrl
                        {
                            Id = fileUrlId,
                            CreatedDate = DateTime.Now,
                            CreatedBy = Guid.Parse(_userInfoToken.Id),
                            Url = upload.Result.Data.ToString(),
                            FileName = DocumentHelper.getFileName(upload.Result.Data.ToString()),
                            FileSize = command.Files.Length.ToString(),
                            FileType = fileType,
                        };
                    }
                    else
                    {
                        throw new Exception("Gagal Upload");
                    }
                }

                await _documentRepo.AddAsync(documentRepo);
                await _fileUrl.AddAsync(fileUrls);
                await _documentFileUrl.AddAsync(documentFileUrls);


                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
