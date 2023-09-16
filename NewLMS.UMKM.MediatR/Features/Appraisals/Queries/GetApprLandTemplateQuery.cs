using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.Appraisals;
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
    public class GetApprLandTemplateQuery : IRequest<ServiceResponse<ApprLandTemplateResponse>>
    {
        public Guid AppraisalGuid { get; set; }
    }

    public class GetApprLandTemplateQueryHandler : IRequestHandler<GetApprLandTemplateQuery, ServiceResponse<ApprLandTemplateResponse>>
    {
        private IGenericRepositoryAsync<ApprLandTemplates> _ApprLandTemplate;
        private IMapper _mapper;

        public GetApprLandTemplateQueryHandler(IGenericRepositoryAsync<ApprLandTemplates> ApprLandTemplate, IMapper mapper)
        {
            _ApprLandTemplate = ApprLandTemplate;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<ApprLandTemplateResponse>> Handle(GetApprLandTemplateQuery request, CancellationToken cancellationToken)
        {
            var data = await _ApprLandTemplate.GetByIdAsync(request.AppraisalGuid, "AppraisalGuid", new string[] {
                "EnvLocationFK", "EnvGrowthFK", "EnvDensityFK", "EnvLandPriceFK",
                "ChangeToFutureFK", "ResidentialMajorityFK", "EnvEaseOfAccessFK", "EnvShoppingFK",
                "EnvSchoolFK", "EnvTransportFK", "EnvRecreationalFK", "EnvCrimeSecurityFK",
                "EnvFireSafetyFK", "EnvDisasterSafetyFK", "EntranceWayTypeFK", "EnvironmentWayTypeFK",
                "DrainaseTypeFK", "SidewalkFK", "StreetLightFK", "TopografiFK", "LandTypeFK",
                "GreeningFK", "ArrangementFK", "WaterDisposalFK", "FloodRiskFK", "FireRiskFK", "SkewerFK",
                "HighVoltageFK", "CertificateTypeFK", "LandShapeFK", "WilayahVillages",
                "WilayahVillages.WilayahDistricts",
                "WilayahVillages.WilayahDistricts.WilayahRegencies",
                "WilayahVillages.WilayahDistricts.WilayahRegencies.WilayahProvinces"
            });
            var dataVm = _mapper.Map<ApprLandTemplateResponse>(data);

            return ServiceResponse<ApprLandTemplateResponse>.ReturnResultWith200(dataVm);

        }
    }
}
