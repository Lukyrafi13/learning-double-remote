using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using NewLMS.UMKM.Data;
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

namespace NewLMS.UMKM.MediatR.Features.Documents.Queries
{
    public class DocumentsGetByIdQuery : IRequest<ServiceResponse<DocumentResponse>>
    {
        public Guid DocumentId { get; set; }
    }

    /// <summary>
    /// Query Handler Document By Id
    /// </summary>
    public class DocumentsGetByIdQueryHandler : IRequestHandler<DocumentsGetByIdQuery, ServiceResponse<DocumentResponse>>
    {
        private readonly IGenericRepositoryAsync<Document> _repo;
        private readonly IGenericRepositoryAsync<User> _user;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public DocumentsGetByIdQueryHandler(IGenericRepositoryAsync<Document> repo, IGenericRepositoryAsync<User> user, IMapper mapper, IConfiguration config)
        {
            _repo = repo;
            _user = user;
            _mapper = mapper;
            _config = config;
        }

        public async Task<ServiceResponse<DocumentResponse>> Handle(DocumentsGetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                    "Files",
                    "Files.FileUrl"
                };
                var data = await _repo.GetByIdAsync(request.DocumentId, "DocumentId", includes);

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
