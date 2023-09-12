using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.Documents;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.Documents.Queries
{
    public class DocumentsGetByIdQuery : IRequest<ServiceResponse<DocumentResponse>>
    {
        public Guid Id { get; set; }
    }

    public class DocumentsGetByIdQueryHandler : IRequestHandler<DocumentsGetByIdQuery, ServiceResponse<DocumentResponse>>
    {
        private readonly IGenericRepositoryAsync<Document> _repo;
        private readonly IGenericRepositoryAsync<User> _user;
        private readonly IMapper _mapper;

        public DocumentsGetByIdQueryHandler(
            IGenericRepositoryAsync<Document> repo, 
            IGenericRepositoryAsync<User> user, 
            IMapper mapper)
        {
            _repo = repo;
            _user = user;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<DocumentResponse>> Handle(DocumentsGetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                    "RfDocumentType",
                    "RfDocumentStatus",
                    "RfDocument",
                    "Files",
                    "Files.FileUrl"
                };
                var data = await _repo.GetByPredicate(x => x.Id == request.Id, includes);
                if (data == null)
                    return ServiceResponse<DocumentResponse>.Return404("Dokumen tidak ditemukan.");

                var dataVm = _mapper.Map<DocumentResponse>(data);
                var dataUser = await _user.GetByIdAsync(data.CreatedBy);
                dataVm.Files.ToList().
                ForEach(async f =>
                {
                    f.FileUrl.UploadBy = dataUser.FirstName + " " + dataUser.LastName;
                    f.FileUrl.Url = f.FileUrl.Url.Replace(@"\", @"/");
                    f.FileUrl.FileName = f.FileUrl.Url.Split('/').Last();
                });

                return ServiceResponse<DocumentResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {
                return ServiceResponse<DocumentResponse>.ReturnException(ex);
            }
        }
    }
}
