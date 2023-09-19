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
    public class PostApprVehicleCommand : ApprVehicleSummaryRequest, IRequest<ServiceResponse<Unit>>
    {
        public Guid AppraisalGuid;
    }

    public class PostApprVehicleCommandHandler : IRequestHandler<PostApprVehicleCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<ApprWorkPaperVehicles> _appr;
        private readonly IGenericRepositoryAsync<ApprWorkPaperVehicleSummaries> _apprSummary;
        private readonly IGenericRepositoryAsync<ApprVehicleTemplate> _apprVehicle;
        private readonly IMapper _mapper;

        public PostApprVehicleCommandHandler(IGenericRepositoryAsync<ApprWorkPaperVehicles> appr,
        IMapper mapper,
        IGenericRepositoryAsync<ApprVehicleTemplate> apprVehicle,
        IGenericRepositoryAsync<ApprWorkPaperVehicleSummaries> apprSummary)
        {
            _appr = appr;
            _mapper = mapper;
            _apprVehicle = apprVehicle;
            _apprSummary = apprSummary;
        }

        public async Task<ServiceResponse<Unit>> Handle(PostApprVehicleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var apprSummary = await GetWorkPaperSummary(request.AppraisalGuid);
                var apprVehicle = await _apprVehicle.GetByIdAsync(request.AppraisalGuid, "AppraisalGuid");
                if (apprVehicle == null)
                    return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, "Data template Kendaraan kosong, isi terlebih dahulu sebelum melanjutkan");

                for (int i = 0; i < request.BaseData.Count; i++)
                {
                    var appr = await _appr.GetByPredicate(x => x.ApprWorkPaperVehicleSummaryGuid == apprSummary.ApprWorkPaperVehicleSummaryGuid && x.DataNumber == request.BaseData[i].DataNumber);
                    var apprMapped = _mapper.Map<ApprWorkPaperVehicles>(request.BaseData[i]);
                    if (appr == null)
                    {
                        apprMapped.ApprWorkPaperVehicleGuid = Guid.NewGuid();
                        apprMapped.ApprWorkPaperVehicleSummaryGuid = apprSummary.ApprWorkPaperVehicleSummaryGuid;
                        if (i == 0)
                        {
                            apprMapped.ApprVehicleTemplateGuid = apprVehicle.ApprVehicleTemplateGuid;
                        }

                        await _appr.AddAsync(apprMapped);
                    }
                    else
                    {
                        apprMapped.ApprWorkPaperVehicleGuid = appr.ApprWorkPaperVehicleGuid;
                        apprMapped.ApprWorkPaperVehicleSummaryGuid = apprSummary.ApprWorkPaperVehicleSummaryGuid;
                        if (i == 0)
                        {
                            apprMapped.ApprVehicleTemplateGuid = apprVehicle.ApprVehicleTemplateGuid;
                        }
                        apprMapped = HelperGeneral.UpdateBaseEntityTime(apprMapped, appr);

                        await _appr.UpdateAsync(apprMapped);
                    }
                }

                var apprSummaryMapped = _mapper.Map<ApprWorkPaperVehicleSummaries>(request);
                apprSummaryMapped.ApprWorkPaperVehicleSummaryGuid = apprSummary.ApprWorkPaperVehicleSummaryGuid;
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

        private async Task<ApprWorkPaperVehicleSummaries> GetWorkPaperSummary(Guid appraisalGuid)
        {
            var apprSummary = await _apprSummary.GetByIdAsync(appraisalGuid, "AppraisalGuid", new string[] {
                "ApprWorkPaperVehicles"
            });
            if (apprSummary == null)
            {
                apprSummary = new ApprWorkPaperVehicleSummaries()
                {
                    ApprWorkPaperVehicleSummaryGuid = Guid.NewGuid(),
                    AppraisalGuid = appraisalGuid
                };

                await _apprSummary.AddAsync(apprSummary);

                return await _apprSummary.GetByIdAsync(appraisalGuid, "AppraisalGuid", new string[] {
                    "ApprWorkPaperVehicles"
                });

            }
            return apprSummary;
        }
    }
}
