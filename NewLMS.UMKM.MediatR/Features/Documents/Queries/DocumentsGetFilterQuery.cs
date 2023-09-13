using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.Documents;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.MediatR.Features.Documents.Queries
{
    public class DocumentsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<DocumentResponse>>>
    {
    }

    public class DocumentsGetFilterQueryHandler : IRequestHandler<DocumentsGetFilterQuery, PagedResponse<IEnumerable<DocumentResponse>>>
    {
        private readonly IGenericRepositoryAsync<Document> _repo;
        private readonly IGenericRepositoryAsync<User> _user;
        private readonly IMapper _mapper;

        public DocumentsGetFilterQueryHandler(
            IGenericRepositoryAsync<Document> repo, 
            IGenericRepositoryAsync<User> user, 
            IMapper mapper)
        {
            _repo = repo;
            _user = user;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<DocumentResponse>>> Handle(DocumentsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
                "RfDocumentType",
                "RfDocumentStatus",
                "RfDocument",
                "Files",
                "Files.FileUrl",
            };
            var data = await _repo.GetPagedReponseAsync(request, includes);
            var dataVm = _mapper.Map<IEnumerable<DocumentResponse>>(data.Results);

            foreach (DocumentResponse doc in dataVm)
            {
                //var uploader = "ANONYM";
                var Files = doc.Files.ToList();

                foreach (DocumentFileUrlRes files in Files)
                {
                    //var dataUser = await _user.GetByPredicate(x => x.Id == files.CreatedBy);
                    //if (dataUser != null)
                    //{
                    //    uploader = dataUser.FirstName + " " + dataUser.LastName;
                    //}
                    //files.FileUrl.UploadBy = uploader;
                    files.FileUrl.Url = files.FileUrl.Url.Replace(@"\", @"/").Replace(@"\\", @"/");
                    files.FileUrl.FileName = files.FileUrl.Url.Split('/').Last();
                }
            }

            return new PagedResponse<IEnumerable<DocumentResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
