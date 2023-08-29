using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFRelationSurveys;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFRelationSurveys.Commands
{
    public class RFRelationSurveyPutCommand : RFRelationSurveyPutRequestDto, IRequest<ServiceResponse<RFRelationSurveyResponseDto>>
    {
    }

    public class PutRFRelationSurveysCommandHandler : IRequestHandler<RFRelationSurveyPutCommand, ServiceResponse<RFRelationSurveyResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFRelationSurvey> _RFRelationSurveys;
        private readonly IMapper _mapper;

        public PutRFRelationSurveysCommandHandler(IGenericRepositoryAsync<RFRelationSurvey> RFRelationSurvey, IMapper mapper)
        {
            _RFRelationSurveys = RFRelationSurvey;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFRelationSurveyResponseDto>> Handle(RFRelationSurveyPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFRelationSurveys = await _RFRelationSurveys.GetByIdAsync(request.RE_CODE, "RE_CODE");
                existingRFRelationSurveys.RE_CODE = request.RE_CODE;
                existingRFRelationSurveys.RE_DESC = request.RE_DESC;
                existingRFRelationSurveys.CORE_CODE = request.CORE_CODE;
                existingRFRelationSurveys.ACTIVE = request.ACTIVE;

                await _RFRelationSurveys.UpdateAsync(existingRFRelationSurveys);

                var response = _mapper.Map<RFRelationSurveyResponseDto>(existingRFRelationSurveys);

                return ServiceResponse<RFRelationSurveyResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFRelationSurveyResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}