using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.DocumentSurveyors;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.DocumentSurveyors.Queries
{
    public class DocumentSurveyorsGetByIdQuery : IRequest<ServiceResponse<DocumentSurveyorResponse>>
    {
        public Guid Id { get; set; }
    }

    public class DocumentSurveyorGetByIdQueryHandler : IRequestHandler<DocumentSurveyorsGetByIdQuery, ServiceResponse<DocumentSurveyorResponse>>
    {
        private readonly IGenericRepositoryAsync<Data.Entities.Document> _repo;
        private readonly IMapper _mapper;

        public DocumentSurveyorGetByIdQueryHandler(
            IGenericRepositoryAsync<Data.Entities.Document> repo,
            IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<DocumentSurveyorResponse>> Handle(DocumentSurveyorsGetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                    "Files",
                    "Files.FileUrl"
                };
                var data = await _repo.GetByPredicate(x => x.Id == request.Id, includes);
                if (data == null)
                    return ServiceResponse<DocumentSurveyorResponse>.Return404("Dokumen tidak ditemukan.");

                var dataVm = _mapper.Map<DocumentSurveyorResponse>(data);

                foreach (var f in dataVm.Files.ToList())
                {
                    //f.FileUrl.UploadBy = dataUser.FirstName + " " + dataUser.LastName;
                    f.FileUrl.Url = f.FileUrl.Url.Replace(@"\", @"/");
                    f.FileUrl.FileName = f.FileUrl.Url.Split('/').Last();
                }

                return ServiceResponse<DocumentSurveyorResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {
                return ServiceResponse<DocumentSurveyorResponse>.ReturnException(ex);
            }
        }
    }
}
