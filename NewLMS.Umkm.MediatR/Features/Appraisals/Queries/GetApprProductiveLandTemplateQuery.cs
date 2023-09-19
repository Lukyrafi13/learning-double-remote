using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.AppraisalProductiveLands;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.Appraisals.Queries
{
    public class GetApprProductiveLandTemplateQuery : IRequest<ServiceResponse<ApprProductiveLandTemplateResponse>>
    {
        public Guid AppraisalGuid { get; set; }
    }

    public class GetApprProductiveLandTemplateQueryHandler : IRequestHandler<GetApprProductiveLandTemplateQuery, ServiceResponse<ApprProductiveLandTemplateResponse>>
    {
        private IGenericRepositoryAsync<ApprProductiveLandTemplate> _ApprProductiveLandTemplate;
        private IMapper _mapper;

        public GetApprProductiveLandTemplateQueryHandler(IGenericRepositoryAsync<ApprProductiveLandTemplate> ApprProductiveLandTemplate, IMapper mapper)
        {
            _ApprProductiveLandTemplate = ApprProductiveLandTemplate;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<ApprProductiveLandTemplateResponse>> Handle(GetApprProductiveLandTemplateQuery request, CancellationToken cancellationToken)
        {
            var data = await _ApprProductiveLandTemplate.GetByIdAsync(request.AppraisalGuid, "AppraisalGuid", null);
            var dataVm = _mapper.Map<ApprProductiveLandTemplateResponse>(data);

            return ServiceResponse<ApprProductiveLandTemplateResponse>.ReturnResultWith200(dataVm);
        }
    }
}
