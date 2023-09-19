using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.AppraisalWorkPapers;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.MediatR.Helpers;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.AppraisalWorkPapers.Commands
{
    public class ApprLandBuildingPostCommand : ApprLandBuildingSummaryRequest, IRequest<ServiceResponse<Unit>>
    {
        public Guid AppraisalGuid;
    }

    public class ApprLandBuildingPostCommandHandler : IRequestHandler<ApprLandBuildingPostCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<ApprWorkPaperLandBuildingSummaries> _apprSummary;
        private readonly IGenericRepositoryAsync<ApprWorkPaperLandBuildings> _appr;
        private readonly IGenericRepositoryAsync<ApprBuildingTemplates> _apprBuilding;
        private readonly IGenericRepositoryAsync<ApprLandTemplates> _apprLand;
        private readonly IMapper _mapper;

        public ApprLandBuildingPostCommandHandler(IGenericRepositoryAsync<ApprWorkPaperLandBuildings> appr,
        IMapper mapper,
        IGenericRepositoryAsync<ApprWorkPaperLandBuildingSummaries> apprSummary,
        IGenericRepositoryAsync<ApprBuildingTemplates> apprBuilding,
        IGenericRepositoryAsync<ApprLandTemplates> apprLand)
        {
            _appr = appr;
            _mapper = mapper;
            _apprSummary = apprSummary;
            _apprBuilding = apprBuilding;
            _apprLand = apprLand;
        }

        public async Task<ServiceResponse<Unit>> Handle(ApprLandBuildingPostCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var apprSummary = await getWorkPaperSummary(request.AppraisalGuid);
                var apprBuilding = await _apprBuilding.GetByIdAsync(request.AppraisalGuid, "AppraisalGuid");
                if (apprBuilding == null)
                    return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, "Data template bangunan kosong, isi terlebih dahulu sebelum melanjutkan");
                var apprLand = await _apprLand.GetByIdAsync(request.AppraisalGuid, "AppraisalGuid");
                if (apprLand == null)
                    return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, "Data template tanah kosong, isi terlebih dahulu sebelum melanjutkan");

                for (int i = 0; i < request.BaseData.Count; i++)
                {
                    var appr = await _appr.GetByPredicate(x => x.ApprWorkPaperLandBuildingSummaryGuid == apprSummary.ApprWorkPaperLandBuildingSummaryGuid && x.DataNumber == request.BaseData[i].DataNumber);
                    var apprMapped = _mapper.Map<ApprWorkPaperLandBuildings>(request.BaseData[i]);
                    if (appr == null)
                    {
                        apprMapped.ApprWorkPaperLandBuildingGuid = Guid.NewGuid();
                        apprMapped.ApprWorkPaperLandBuildingSummaryGuid = apprSummary.ApprWorkPaperLandBuildingSummaryGuid;
                        if (i == 0)
                        {
                            apprMapped.ApprBuildingTemplateGuid = apprBuilding.ApprEnvironmentGuid;
                            apprMapped.ApprLandTemplateGuid = apprLand.ApprLandTemplateGuid;
                        }

                        await _appr.AddAsync(apprMapped);
                    }
                    else
                    {
                        apprMapped.ApprWorkPaperLandBuildingGuid = appr.ApprWorkPaperLandBuildingGuid;
                        apprMapped.ApprWorkPaperLandBuildingSummaryGuid = apprSummary.ApprWorkPaperLandBuildingSummaryGuid;
                        if (i == 0)
                        {
                            apprMapped.ApprBuildingTemplateGuid = apprBuilding.ApprEnvironmentGuid;
                            apprMapped.ApprLandTemplateGuid = apprLand.ApprLandTemplateGuid;
                        }
                        apprMapped = HelperGeneral.UpdateBaseEntityTime(apprMapped, appr);

                        await _appr.UpdateAsync(apprMapped);
                    }
                }

                var apprSummaryMapped = _mapper.Map<ApprWorkPaperLandBuildingSummaries>(request);
                apprSummaryMapped.ApprWorkPaperLandBuildingSummaryGuid = apprSummary.ApprWorkPaperLandBuildingSummaryGuid;
                apprSummaryMapped.AppraisalGuid = apprSummary.AppraisalGuid;
                apprSummaryMapped = HelperGeneral.UpdateBaseEntityTime(apprSummaryMapped, apprSummary);
                await _apprSummary.UpdateAsync(apprSummaryMapped);

                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        private async Task<ApprWorkPaperLandBuildingSummaries> getWorkPaperSummary(Guid appraisalGuid)
        {
            var apprSummary = await _apprSummary.GetByIdAsync(appraisalGuid, "AppraisalGuid", new string[] {
                "ApprWorkPaperLandBuildings"
            });
            if (apprSummary == null)
            {
                apprSummary = new ApprWorkPaperLandBuildingSummaries()
                {
                    ApprWorkPaperLandBuildingSummaryGuid = Guid.NewGuid(),
                    AppraisalGuid = appraisalGuid
                };

                await _apprSummary.AddAsync(apprSummary);

                return await _apprSummary.GetByIdAsync(appraisalGuid, "AppraisalGuid", new string[] {
                    "ApprWorkPaperLandBuildings"
                });

            }
            return apprSummary;
        }
    }
}
