using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.AppraisalVehicle;
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
    public class ApprVehicleNotePostCommand : ApprVehicleNotePostRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class ApprVehicleNotePostCommandHandler : IRequestHandler<ApprVehicleNotePostCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<ApprVehicleNote> _appr;
        private readonly IMapper _mapper;

        public ApprVehicleNotePostCommandHandler(IGenericRepositoryAsync<ApprVehicleNote> appr,
        IMapper mapper)
        {
            _appr = appr;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(ApprVehicleNotePostCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var apprEntity = new ApprVehicleNote
                {
                    VehicleNoteGuid = Guid.NewGuid(),
                    ApprVehicleTemplateGuid = request.ApprVehicleTemplateGuid,
                    VehiclePart = request.VehiclePart,
                    Note = request.Note

                };
                await _appr.AddAsync(apprEntity);
                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
