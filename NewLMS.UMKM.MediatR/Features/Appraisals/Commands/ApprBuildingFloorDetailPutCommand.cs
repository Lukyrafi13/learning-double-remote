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
    public class ApprBuildingFloorDetailPutCommand : ApprBuildingFloorDetailPutRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class PutApprBuildingFloorDetailCommandHandler : IRequestHandler<ApprBuildingFloorDetailPutCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<ApprBuildingFloorDetails> _appr;
        private readonly IMapper _mapper;

        public PutApprBuildingFloorDetailCommandHandler(IGenericRepositoryAsync<ApprBuildingFloorDetails> appr,
        IMapper mapper)
        {
            _appr = appr;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(ApprBuildingFloorDetailPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _appr.GetByIdAsync(request.BuildingFloorDetailGuid, "BuildingFloorDetailGuid");

                data.FloorDescription = request.Description;
                data.RoomName = request.RoomName;
                data.RoomArea = double.Parse(request.Area);
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
