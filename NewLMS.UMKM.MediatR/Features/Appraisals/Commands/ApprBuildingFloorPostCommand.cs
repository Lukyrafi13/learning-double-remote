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
    public class ApprBuildingFloorPostCommand : ApprBuildingFloorPostRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class PostApprBuildingFloorCommandHandler : IRequestHandler<ApprBuildingFloorPostCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<ApprBuildingFloors> _appr;
        private readonly IMapper _mapper;

        public PostApprBuildingFloorCommandHandler(IGenericRepositoryAsync<ApprBuildingFloors> appr,
        IMapper mapper)
        {
            _appr = appr;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(ApprBuildingFloorPostCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var apprEntity = new ApprBuildingFloors
                {
                    BuildingFloorGuid = Guid.NewGuid(),
                    ApprBuildingTemplateGuid = request.ApprBuildingTemplateGuid,
                    FloorDescription = request.Description,
                    TotalRoom = request.RoomNumber,
                    TotalArea = request.Area

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
