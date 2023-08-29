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
    public class RFRelationSurveyDeleteCommand : RFRelationSurveyFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DeleteRFRelationSurveysCommandHandler : IRequestHandler<RFRelationSurveyDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFRelationSurvey> _RFRelationSurveys;
        private readonly IMapper _mapper;

        public DeleteRFRelationSurveysCommandHandler(IGenericRepositoryAsync<RFRelationSurvey> RFRelationSurvey, IMapper mapper)
        {
            _RFRelationSurveys = RFRelationSurvey;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFRelationSurveyDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFRelationSurveys.GetByIdAsync(request.RE_CODE, "RE_CODE");
            rFProduct.IsDeleted = true;
            await _RFRelationSurveys.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}