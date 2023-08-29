using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.Surveys;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.Surveys.Queries
{
    public class SurveyOTSGetQuery : SurveyFind, IRequest<ServiceResponse<SurveyOTSResponse>>
    {
    }

    public class SurveyOTSGetQueryHandler : IRequestHandler<SurveyOTSGetQuery, ServiceResponse<SurveyOTSResponse>>
    {
        private IGenericRepositoryAsync<Survey> _Survey;
        private readonly IMapper _mapper;

        public SurveyOTSGetQueryHandler(IGenericRepositoryAsync<Survey> Survey, IMapper mapper)
        {
            _Survey = Survey;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<SurveyOTSResponse>> Handle(SurveyOTSGetQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
                "App",
                "HubunganDebitur",
                "BentukBadanUsaha",
                "StatusTempatUsaha",
                "BidangUsahaKUR",
                "KodePos",
            };

            var data = await _Survey.GetByIdAsync(request.Id, "Id", includes);

            var response = _mapper.Map<SurveyOTSResponse>(data);

            return ServiceResponse<SurveyOTSResponse>.ReturnResultWith200(response);
        }
    }
}