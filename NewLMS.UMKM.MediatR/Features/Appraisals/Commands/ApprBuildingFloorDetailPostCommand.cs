using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.Appraisals;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.Appraisals.Commands
{
    public class ApprBuildingFloorDetailPostCommand : ApprBuildingFloorDetailPostRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class PostApprBuildingFloorDetailCommandHandler : IRequestHandler<ApprBuildingFloorDetailPostCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<ApprBuildingFloorDetails> _appr;
        private readonly IGenericRepositoryAsync<ApprBuildingFloors> _apprParent;
        private readonly IGenericRepositoryAsync<ApprBuildingTemplates> _apprBuilding;
        private readonly IMapper _mapper;

        public PostApprBuildingFloorDetailCommandHandler(IGenericRepositoryAsync<ApprBuildingFloorDetails> appr,
        IMapper mapper,
        IGenericRepositoryAsync<ApprBuildingFloors> apprParent,
        IGenericRepositoryAsync<ApprBuildingTemplates> apprBuilding)
        {
            _appr = appr;
            _mapper = mapper;
            _apprParent = apprParent;
            _apprBuilding = apprBuilding;
        }

        public async Task<ServiceResponse<Unit>> Handle(ApprBuildingFloorDetailPostCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var apprEntity = new ApprBuildingFloorDetails
                {
                    BuildingFloorDetailGuid = Guid.NewGuid(),
                    ApprBuildingFloorGuid = request.ApprBuildingFloorGuid,
                    FloorDescription = request.Description,
                    RoomName = request.RoomName,
                    RoomArea = request.Area
                };

                await _appr.AddAsync(apprEntity);

                var apprEntities = await _appr.GetListByPredicate(x => x.ApprBuildingFloorGuid == request.ApprBuildingFloorGuid && !x.IsDeleted);
                int? totalRoom = 0;
                double? totalArea = 0.0;
                if (apprEntities != null && apprEntities.Count > 0)
                {
                    var selectTotalArea = apprEntities.Select(x => x.RoomArea);
                    if (selectTotalArea != null)
                    {
                        totalRoom = selectTotalArea.Count();
                        totalArea = selectTotalArea.Sum();
                    }
                }

                var appr = await _apprParent.GetByIdAsync(request.ApprBuildingFloorGuid, "BuildingFloorGuid");
                if (appr != null)
                {
                    appr.TotalRoom = totalRoom;
                    appr.TotalArea = totalArea;
                    await _apprParent.UpdateAsync(appr);

                    var apprBuilding = await _apprBuilding.GetByIdAsync(appr.ApprBuildingTemplateGuid, "ApprEnvironmentGuid");
                    var apprBuildingFloors = await _apprParent.GetListByPredicate(x => x.ApprBuildingTemplateGuid == appr.ApprBuildingTemplateGuid && !x.IsDeleted);
                    if (apprBuildingFloors != null && apprBuildingFloors.Count > 0)
                    {
                        var totalAreaAll = apprBuildingFloors?.Select(x => x.TotalArea);
                        if (totalAreaAll != null && totalAreaAll.Count() > 0)
                        {
                            apprBuilding.TotalBuildingArea = totalAreaAll.Sum();
                            await _apprBuilding.UpdateAsync(apprBuilding);
                        }
                    }
                }

                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
