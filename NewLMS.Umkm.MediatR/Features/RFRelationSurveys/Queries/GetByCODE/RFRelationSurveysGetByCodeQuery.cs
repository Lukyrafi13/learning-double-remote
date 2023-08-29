using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFRelationSurveys;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFRelationSurveys.Queries
{
    public class RFRelationSurveyGetQuery : RFRelationSurveyFindRequestDto, IRequest<ServiceResponse<RFRelationSurveyResponseDto>>
    {
    }

    public class RFRelationSurveyGetQueryHandler : IRequestHandler<RFRelationSurveyGetQuery, ServiceResponse<RFRelationSurveyResponseDto>>
    {
        private IGenericRepositoryAsync<RFRelationSurvey> _RFRelationSurveys;
        private readonly IMapper _mapper;

        public RFRelationSurveyGetQueryHandler(IGenericRepositoryAsync<RFRelationSurvey> RFRelationSurvey, IMapper mapper)
        {
            _RFRelationSurveys = RFRelationSurvey;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFRelationSurveyResponseDto>> Handle(RFRelationSurveyGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFRelationSurveys.GetByIdAsync(request.RE_CODE, "RE_CODE");
                if (data == null)
                    return ServiceResponse<RFRelationSurveyResponseDto>.Return404("Data RFRelationSurvey not found");
                var response = _mapper.Map<RFRelationSurveyResponseDto>(data);
                return ServiceResponse<RFRelationSurveyResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFRelationSurveyResponseDto>.ReturnException(ex);
            }
        }
    }
}