﻿using MediatR;
using NewLMS.Umkm.Data.Dto.DocumentSurveys;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.DocumentSurveys.Commands
{
    public class DocumentSurveyDeleteCommand : DocumentSurveyDeleteRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class DocumentSurveyDeleteCommandHandler : IRequestHandler<DocumentSurveyDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<Document> _repo;
        private readonly IGenericRepositoryAsync<FileUrl> _fileUrl;
        private readonly IGenericRepositoryAsync<DocumentFileUrl> _documentUrl;

        public DocumentSurveyDeleteCommandHandler(
            IGenericRepositoryAsync<Document> repo,
            IGenericRepositoryAsync<FileUrl> fileUrl,
            IGenericRepositoryAsync<DocumentFileUrl> documentUrl)
        {
            _repo = repo;
            _fileUrl = fileUrl;
            _documentUrl = documentUrl;
        }

        public async Task<ServiceResponse<Unit>> Handle(DocumentSurveyDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _repo.GetByIdAsync(request.Id, "Id");
                if (entity == null)
                    return ServiceResponse<Unit>.Return404("Document Not Found");

                await _repo.DeleteAsync(entity);

                var documentUrls = await _documentUrl.GetListByPredicate(x => x.DocumentId == request.Id);
                if (documentUrls != null)
                {
                    foreach (var docUrl in documentUrls)
                    {
                        var fileUrlId = docUrl.FileUrlId;
                        var fileUrl = await _fileUrl.GetByPredicate(x => x.Id == fileUrlId);
                        if (fileUrl != null)
                        {
                            await _documentUrl.DeleteAsync(docUrl);
                            await _fileUrl.DeleteAsync(fileUrl);
                        }
                    }
                }

                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnException(ex);
            }

        }
    }
}
