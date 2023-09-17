using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.AppraisalVehicle;
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
    public class ApprVehicleNotePutCommand : ApprVehicleNotePutRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class ApprVehicleNotePutCommandHandler : IRequestHandler<ApprVehicleNotePutCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<ApprVehicleNote> _appr;
        private readonly IMapper _mapper;

        public ApprVehicleNotePutCommandHandler(IGenericRepositoryAsync<ApprVehicleNote> appr,
        IMapper mapper)
        {
            _appr = appr;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(ApprVehicleNotePutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _appr.GetByIdAsync(request.VehicleNoteGuid, "VehicleNoteGuid");

                data.VehiclePart = request.VehiclePart;
                data.Note = request.Note;
                data.ModifiedDate = DateTime.Now;
                await _appr.UpdateAsync(data);
                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
