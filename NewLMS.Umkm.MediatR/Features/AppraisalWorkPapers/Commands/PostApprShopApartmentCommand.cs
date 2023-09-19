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
    public class PostApprShopApartmentCommand : ApprShopApartmentSummaryRequest, IRequest<ServiceResponse<Unit>>
    {
        public Guid AppraisalGuid;
    }

    public class PostApprShopApartmentCommandHandler : IRequestHandler<PostApprShopApartmentCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<ApprWorkPaperShopApartments> _appr;
        private readonly IGenericRepositoryAsync<ApprWorkPaperShopApartmentSummaries> _apprSummary;
        private readonly IGenericRepositoryAsync<ApprBuildingTemplates> _apprBuilding;
        private readonly IMapper _mapper;

        public PostApprShopApartmentCommandHandler(IGenericRepositoryAsync<ApprWorkPaperShopApartments> appr,
        IMapper mapper,
        IGenericRepositoryAsync<ApprBuildingTemplates> apprBuilding,
        IGenericRepositoryAsync<ApprWorkPaperShopApartmentSummaries> apprSummary)
        {
            _appr = appr;
            _mapper = mapper;
            _apprBuilding = apprBuilding;
            _apprSummary = apprSummary;
        }

        public async Task<ServiceResponse<Unit>> Handle(PostApprShopApartmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var apprSummary = await GetWorkPaperSummary(request.AppraisalGuid);
                var apprBuilding = await _apprBuilding.GetByIdAsync(request.AppraisalGuid, "AppraisalGuid");
                if (apprBuilding == null)
                    return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, "Data template bangunan kosong, isi terlebih dahulu sebelum melanjutkan");

                for (int i = 0; i < request.BaseData.Count; i++)
                {
                    var appr = await _appr.GetByPredicate(x => x.ApprWorkPaperShopApartmentSummaryGuid == apprSummary.ApprWorkPaperShopApartmentSummaryGuid && x.DataNumber == request.BaseData[i].DataNumber);
                    var apprMapped = _mapper.Map<ApprWorkPaperShopApartments>(request.BaseData[i]);
                    if (appr == null)
                    {
                        apprMapped.ApprWorkPaperShopApartmentGuid = Guid.NewGuid();
                        apprMapped.ApprWorkPaperShopApartmentSummaryGuid = apprSummary.ApprWorkPaperShopApartmentSummaryGuid;
                        if (i == 0)
                        {
                            apprMapped.ApprBuildingTemplateGuid = apprBuilding.ApprEnvironmentGuid;
                        }

                        await _appr.AddAsync(apprMapped);
                    }
                    else
                    {
                        apprMapped.ApprWorkPaperShopApartmentGuid = appr.ApprWorkPaperShopApartmentGuid;
                        apprMapped.ApprWorkPaperShopApartmentSummaryGuid = apprSummary.ApprWorkPaperShopApartmentSummaryGuid;
                        if (i == 0)
                        {
                            apprMapped.ApprBuildingTemplateGuid = apprBuilding.ApprEnvironmentGuid;
                        }
                        apprMapped = HelperGeneral.UpdateBaseEntityTime(apprMapped, appr);

                        await _appr.UpdateAsync(apprMapped);
                    }
                }

                var apprSummaryMapped = _mapper.Map<ApprWorkPaperShopApartmentSummaries>(request);
                apprSummaryMapped.ApprWorkPaperShopApartmentSummaryGuid = apprSummary.ApprWorkPaperShopApartmentSummaryGuid;
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

        private async Task<ApprWorkPaperShopApartmentSummaries> GetWorkPaperSummary(Guid appraisalGuid)
        {
            var apprSummary = await _apprSummary.GetByIdAsync(appraisalGuid, "AppraisalGuid", new string[] {
                "ApprWorkPaperShopApartments"
            });
            if (apprSummary == null)
            {
                apprSummary = new ApprWorkPaperShopApartmentSummaries()
                {
                    ApprWorkPaperShopApartmentSummaryGuid = Guid.NewGuid(),
                    AppraisalGuid = appraisalGuid
                };

                await _apprSummary.AddAsync(apprSummary);

                return await _apprSummary.GetByIdAsync(appraisalGuid, "AppraisalGuid", new string[] {
                    "ApprWorkPaperShopApartments"
                });

            }
            return apprSummary;
        }
    }
}
