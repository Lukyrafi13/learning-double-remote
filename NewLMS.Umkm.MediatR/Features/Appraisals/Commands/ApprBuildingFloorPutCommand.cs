using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.Appraisals;
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
    public class ApprBuildingFloorPutCommand : ApprBuildingFloorPutRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class PutApprBuildingFloorCommandHandler : IRequestHandler<ApprBuildingFloorPutCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<ApprBuildingFloors> _appr;
        private readonly IMapper _mapper;

        public PutApprBuildingFloorCommandHandler(IGenericRepositoryAsync<ApprBuildingFloors> appr,
        IMapper mapper)
        {
            _appr = appr;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(ApprBuildingFloorPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _appr.GetByIdAsync(request.BuildingFloorGuid, "BuildingFloorGuid");

                data.FloorDescription = request.Description;
                data.TotalRoom = request.RoomNumber;
                data.TotalArea = request.Area;
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
