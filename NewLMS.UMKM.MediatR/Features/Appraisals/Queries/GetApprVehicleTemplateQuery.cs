using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.AppraisalVehicle;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.Appraisals.Queries
{
    public class GetApprVehicleTemplateQuery : IRequest<ServiceResponse<ApprVehicleTemplateResponse>>
    {
        public Guid AppraisalGuid { get; set; }
    }

    public class GetApprVehicleTemplateQueryHandler : IRequestHandler<GetApprVehicleTemplateQuery, ServiceResponse<ApprVehicleTemplateResponse>>
    {
        private IGenericRepositoryAsync<ApprVehicleTemplate> _ApprVehicleTemplate;
        private IMapper _mapper;

        public GetApprVehicleTemplateQueryHandler(IGenericRepositoryAsync<ApprVehicleTemplate> ApprVehicleTemplate, IMapper mapper)
        {
            _ApprVehicleTemplate = ApprVehicleTemplate;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<ApprVehicleTemplateResponse>> Handle(GetApprVehicleTemplateQuery request, CancellationToken cancellationToken)
        {
            var data = await _ApprVehicleTemplate.GetByIdAsync(request.AppraisalGuid, "AppraisalGuid", null);
            var dataVm = _mapper.Map<ApprVehicleTemplateResponse>(data);

            return ServiceResponse<ApprVehicleTemplateResponse>.ReturnResultWith200(dataVm);
        }
    }
}
