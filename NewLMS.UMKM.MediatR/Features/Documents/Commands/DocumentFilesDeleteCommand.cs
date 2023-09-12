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
    public class DocumentFilesDeleteCommand : FileDeleteRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class DocumentFilesDeleteCommandHandler : IRequestHandler<DocumentFilesDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<FileUrl> _fileUrl;
        private readonly IGenericRepositoryAsync<DocumentFileUrl> _documentFileUrl;
        private readonly IMapper _mapper;

        public DocumentFilesDeleteCommandHandler(IGenericRepositoryAsync<FileUrl> fileUrl, IGenericRepositoryAsync<DocumentFileUrl> documentFileUrl, IMapper mapper)
        {
            _fileUrl = fileUrl;
            _documentFileUrl = documentFileUrl;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(DocumentFilesDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var docId = request.DocumentId;
                var fileId = request.FileUrlId;

                var entity = await _documentFileUrl.GetByPredicate(c => c.FileUrlId == fileId && c.DocumentId == docId);
                if (entity == null)
                    return ServiceResponse<Unit>.Return404("Document File Not Found");

                entity.IsDeleted = true;

                var fileUrl = await _fileUrl.GetByIdAsync(fileId, "FileUrlId");
                if (fileUrl == null)
                    return ServiceResponse<Unit>.Return404("File Not Found");

                fileUrl.IsDeleted = true;
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
