using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.Documents;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.Documents.Commands
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
                var documentFileUrl = await _documentFileUrl.GetByPredicate(c => c.FileUrlId == request.FileUrlId);
                if (documentFileUrl != null)
                {
                    await _documentFileUrl.DeleteAsync(documentFileUrl);
                }

                var fileUrl = await _fileUrl.GetByPredicate(x => x.Id == request.FileUrlId);
                if (fileUrl != null)
                {
                    await _fileUrl.DeleteAsync(fileUrl);
                }

                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch(Exception ex)
            {
                return ServiceResponse<Unit>.ReturnException(ex);
            }
        }
    }
}
