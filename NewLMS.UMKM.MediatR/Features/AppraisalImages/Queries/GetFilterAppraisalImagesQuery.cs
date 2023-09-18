using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Data.Dto.AppraisalImages;
using NewLMS.UMKM.Data.Dto.Documents;

namespace NewLMS.UMKM.MediatR.Features.AppraisalImages.Queries
{
    public class GetFilterAppraisalImagesQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<AppraisalImagesResponse>>>
    {
    }

    public class GetFilterAppraisalImagesQueryHandler : IRequestHandler<GetFilterAppraisalImagesQuery, PagedResponse<IEnumerable<AppraisalImagesResponse>>>
    {
        private readonly IGenericRepositoryAsync<Document> _repo;
        private readonly IGenericRepositoryAsync<User> _user;
        private readonly IMapper _mapper;

        public GetFilterAppraisalImagesQueryHandler(
            IGenericRepositoryAsync<Document> repo,
            IGenericRepositoryAsync<User> user,
            IMapper mapper)
        {
            _repo = repo;
            _user = user;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<AppraisalImagesResponse>>> Handle(GetFilterAppraisalImagesQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
                "Files",
                "Files.FileUrl",
            };
            var data = await _repo.GetPagedReponseAsync(request, includes);
            var dataVm = _mapper.Map<IEnumerable<AppraisalImagesResponse>>(data.Results);

            foreach (AppraisalImagesResponse doc in dataVm)
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

            return new PagedResponse<IEnumerable<AppraisalImagesResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
