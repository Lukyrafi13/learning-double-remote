using MediatR;
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
    public class ApprBuildingFloorDeleteCommand : IRequest<ServiceResponse<Unit>>
    {
        public Guid BuildingFloorGuid { get; set; }
    }
    public class ApprBuildingFloorDeleteCommandHandler : IRequestHandler<ApprBuildingFloorDeleteCommand, ServiceResponse<Unit>>
    {
        private IGenericRepositoryAsync<ApprBuildingFloors> _appr;

        public ApprBuildingFloorDeleteCommandHandler(IGenericRepositoryAsync<ApprBuildingFloors> appr)
        {
            _appr = appr;
        }

        public async Task<ServiceResponse<Unit>> Handle(ApprBuildingFloorDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _appr.GetByIdAsync(request.BuildingFloorGuid, "BuildingFloorGuid");
                await _appr.DeleteAsync(data);

                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {

                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
