using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.DocumentSurveys;
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
    public class DocumentSurveyorGetByIdQuery : IRequest<ServiceResponse<DocumentSurveyResponse>>
    {
        public Guid Id { get; set; }
    }

    public class DocumentSurveyorGetByIdQueryHandler : IRequestHandler<DocumentSurveyorGetByIdQuery, ServiceResponse<DocumentSurveyResponse>>
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

        public async Task<ServiceResponse<DocumentSurveyResponse>> Handle(DocumentSurveyorGetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                    "Files",
                    "Files.FileUrl"
                };
                var data = await _repo.GetByPredicate(x => x.Id == request.Id, includes);
                if (data == null)
                    return ServiceResponse<DocumentSurveyResponse>.Return404("Dokumen tidak ditemukan.");

                var dataVm = _mapper.Map<DocumentSurveyResponse>(data);

                foreach (var f in dataVm.Files.ToList())
                {
                    //f.FileUrl.UploadBy = dataUser.FirstName + " " + dataUser.LastName;
                    f.FileUrl.Url = f.FileUrl.Url.Replace(@"\", @"/");
                    f.FileUrl.FileName = f.FileUrl.Url.Split('/').Last();
                }

                return ServiceResponse<DocumentSurveyResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {
                return ServiceResponse<DocumentSurveyResponse>.ReturnException(ex);
            }
        }
    }
}
