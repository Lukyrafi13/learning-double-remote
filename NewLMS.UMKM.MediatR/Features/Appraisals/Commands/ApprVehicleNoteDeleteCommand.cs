using MediatR;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.Appraisals.Commands
{
    public class ApprVehicleNoteDeleteCommand : IRequest<ServiceResponse<Unit>>
    {
        public Guid VehicleNoteGuid { get; set; }
    }
    public class ApprVehicleNoteDeleteCommandHandler : IRequestHandler<ApprVehicleNoteDeleteCommand, ServiceResponse<Unit>>
    {
        private IGenericRepositoryAsync<ApprVehicleNote> _appr;

        public ApprVehicleNoteDeleteCommandHandler(IGenericRepositoryAsync<ApprVehicleNote> appr)
        {
            _appr = appr;
        }

        public async Task<ServiceResponse<Unit>> Handle(ApprVehicleNoteDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _appr.GetByIdAsync(request.VehicleNoteGuid, "VehicleNoteGuid");
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
