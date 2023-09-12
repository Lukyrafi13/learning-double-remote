using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.Documents;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.Documents.Commands
{
    public class DocumentsDeleteCommand : DocumentDeleteRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class DocumentsDeleteCommandHandler : IRequestHandler<DocumentsDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<Document> _repo;
        private readonly IGenericRepositoryAsync<FileUrl> _fileUrl;
        private readonly IGenericRepositoryAsync<DocumentFileUrl> _documentUrl;
        private readonly IMapper _mapper;

        public DocumentsDeleteCommandHandler(IGenericRepositoryAsync<Document> repo, IGenericRepositoryAsync<FileUrl> fileUrl, IGenericRepositoryAsync<DocumentFileUrl> documentUrl, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
            _fileUrl = fileUrl;
            _documentUrl = documentUrl;
        }

        public async Task<ServiceResponse<Unit>> Handle(DocumentsDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _repo.GetByIdAsync(request.Id, "DocumentId");
                if (entity == null)
                    return ServiceResponse<Unit>.Return404("Document Not Found");

                var documentUrl = await _documentUrl.GetByIdAsync(request.Id, "DocumentId");
                if (documentUrl == null)
                    return ServiceResponse<Unit>.Return404("DocumentURL Not Found");

                var fileUrl = await _fileUrl.GetByIdAsync(documentUrl.FileUrlId, "FileUrlId");
                if (fileUrl == null)
                    return ServiceResponse<Unit>.Return404("FileUrl Not Found");


                entity.IsDeleted = true;
                documentUrl.IsDeleted = true;
                fileUrl.IsDeleted = true;

                await _documentUrl.UpdateAsync(documentUrl);
                await _repo.UpdateAsync(entity);
                await _fileUrl.UpdateAsync(fileUrl);


                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch(Exception ex)
            {
                return ServiceResponse<Unit>.ReturnException(ex);
            }
            
        }
    }
}
