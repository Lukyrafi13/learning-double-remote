using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFRelationSurveys;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFRelationSurveys.Commands
{
    public class RFRelationSurveyPostCommand : RFRelationSurveyPostRequestDto, IRequest<ServiceResponse<RFRelationSurveyResponseDto>>
    {

    }
    public class PostRFRelationSurveysCommandHandler : IRequestHandler<RFRelationSurveyPostCommand, ServiceResponse<RFRelationSurveyResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFRelationSurvey> _RFRelationSurveys;
        private readonly IMapper _mapper;

        public PostRFRelationSurveysCommandHandler(IGenericRepositoryAsync<RFRelationSurvey> RFRelationSurvey, IMapper mapper)
        {
            _RFRelationSurveys = RFRelationSurvey;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFRelationSurveyResponseDto>> Handle(RFRelationSurveyPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFRelationSurvey = _mapper.Map<RFRelationSurvey>(request);

                var returnedRFRelationSurveys = await _RFRelationSurveys.AddAsync(RFRelationSurvey, callSave: false);

                // var response = _mapper.Map<RFRelationSurveyResponseDto>(returnedRFRelationSurveys);
                var response = _mapper.Map<RFRelationSurveyResponseDto>(returnedRFRelationSurveys);

                await _RFRelationSurveys.SaveChangeAsync();
                return ServiceResponse<RFRelationSurveyResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFRelationSurveyResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}