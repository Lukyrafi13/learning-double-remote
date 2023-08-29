using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.SurveyFileUploads;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.SurveyFileUploads.Queries
{
    public class SurveyFileUploadGetQuery : SurveyFileUploadFindRequestDto, IRequest<ServiceResponse<SurveyFileUploadResponseDto>>
    {
    }

    public class SurveyFileUploadGetQueryHandler : IRequestHandler<SurveyFileUploadGetQuery, ServiceResponse<SurveyFileUploadResponseDto>>
    {
        private IGenericRepositoryAsync<SurveyFileUpload> _SurveyFileUpload;
        private readonly IMapper _mapper;

        public SurveyFileUploadGetQueryHandler(IGenericRepositoryAsync<SurveyFileUpload> SurveyFileUpload, IMapper mapper)
        {
            _SurveyFileUpload = SurveyFileUpload;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<SurveyFileUploadResponseDto>> Handle(SurveyFileUploadGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                    "Survey",
                    "FileUrl",
                };

                var data = await _SurveyFileUpload.GetByIdAsync(request.Id, "Id", includes);
                if (data == null)
                    return ServiceResponse<SurveyFileUploadResponseDto>.Return404("Data SurveyFileUpload not found");
                var response = _mapper.Map<SurveyFileUploadResponseDto>(data);
                return ServiceResponse<SurveyFileUploadResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SurveyFileUploadResponseDto>.ReturnException(ex);
            }
        }
    }
}