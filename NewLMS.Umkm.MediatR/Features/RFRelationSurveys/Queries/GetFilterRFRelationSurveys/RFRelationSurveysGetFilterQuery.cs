using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFRelationSurveys;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFRelationSurveys.Queries
{
    public class RFRelationSurveysGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFRelationSurveyResponseDto>>>
    {
    }

    public class GetFilterRFRelationSurveysQueryHandler : IRequestHandler<RFRelationSurveysGetFilterQuery, PagedResponse<IEnumerable<RFRelationSurveyResponseDto>>>
    {
        private IGenericRepositoryAsync<RFRelationSurvey> _RFRelationSurveys;
        private readonly IMapper _mapper;

        public GetFilterRFRelationSurveysQueryHandler(IGenericRepositoryAsync<RFRelationSurvey> RFRelationSurvey, IMapper mapper)
        {
            _RFRelationSurveys = RFRelationSurvey;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFRelationSurveyResponseDto>>> Handle(RFRelationSurveysGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFRelationSurveys.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFRelationSurveyResponseDto>>(data.Results);
            IEnumerable<RFRelationSurveyResponseDto> dataVm;
            var listResponse = new List<RFRelationSurveyResponseDto>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<RFRelationSurveyResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFRelationSurveyResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}