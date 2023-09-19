using AutoMapper;
using MediatR;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Data.Dto.AppraisalImages;

namespace NewLMS.Umkm.MediatR.Features.AppraisalImages.Queries
{
    public class GetByIdAppraisalImagesQuery : IRequest<ServiceResponse<AppraisalImagesResponse>>
    {
        public Guid Id { get; set; }
    }

    public class GetByIdAppraisalImagesQueryHandler : IRequestHandler<GetByIdAppraisalImagesQuery, ServiceResponse<AppraisalImagesResponse>>
    {
        private readonly IGenericRepositoryAsync<Document> _repo;
        private readonly IMapper _mapper;

        public GetByIdAppraisalImagesQueryHandler(
            IGenericRepositoryAsync<Document> repo,
            IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<AppraisalImagesResponse>> Handle(GetByIdAppraisalImagesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                    "Files",
                    "Files.FileUrl"
                };
                var data = await _repo.GetByPredicate(x => x.Id == request.Id, includes);
                if (data == null)
                    return ServiceResponse<AppraisalImagesResponse>.Return404("Dokumen tidak ditemukan.");

                var dataVm = _mapper.Map<AppraisalImagesResponse>(data);
                
                foreach (var f in dataVm.Files.ToList())
                {
                    //f.FileUrl.UploadBy = dataUser.FirstName + " " + dataUser.LastName;
                    f.FileUrl.Url = f.FileUrl.Url.Replace(@"\", @"/");
                    f.FileUrl.FileName = f.FileUrl.Url.Split('/').Last();
                }

                return ServiceResponse<AppraisalImagesResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {
                return ServiceResponse<AppraisalImagesResponse>.ReturnException(ex);
            }
        }
    }
}
