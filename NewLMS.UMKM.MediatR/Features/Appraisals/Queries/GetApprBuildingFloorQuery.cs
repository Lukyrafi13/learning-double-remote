using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.Appraisals;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.Appraisals.Queries
{
    public class GetApprBuildingFloorQuery : IRequest<ServiceResponse<ApprBuildingFloorResponse>>
    {
        public Guid BuildingTemplateGuid { get; set; }
    }

    public class GetApprBuildingFloorQueryHandler : IRequestHandler<GetApprBuildingFloorQuery, ServiceResponse<ApprBuildingFloorResponse>>
    {
        private IGenericRepositoryAsync<ApprBuildingFloors> _ApprBuildingFloor;
        private IGenericRepositoryAsync<ApprBuildingTemplates> _apprBuilding;
        private IMapper _mapper;

        public GetApprBuildingFloorQueryHandler(IGenericRepositoryAsync<ApprBuildingFloors> ApprBuildingFloor, IMapper mapper, IGenericRepositoryAsync<ApprBuildingTemplates> apprBuilding)
        {
            _ApprBuildingFloor = ApprBuildingFloor;
            _mapper = mapper;
            _apprBuilding = apprBuilding;
        }
        public async Task<ServiceResponse<ApprBuildingFloorResponse>> Handle(GetApprBuildingFloorQuery request, CancellationToken cancellationToken)
        {
            var dataVm = new ApprBuildingFloorResponse
            {
                Floors = new()
            };
            var data = await _ApprBuildingFloor.GetListByPredicate(x => x.ApprBuildingTemplateGuid == request.BuildingTemplateGuid, new string[] {
                "ApprBuildingTemplates"
            });
            if (data != null && data.Count > 0)
            {
                dataVm.Floors = _mapper.Map<List<ApprBuildingFloorEntityResponse>>(data);

                var singleData = data[0];
                var apprBuilding = await _apprBuilding.GetByIdAsync(singleData.ApprBuildingTemplateGuid, "ApprEnvironmentGuid");
                if (apprBuilding != null)
                {
                    dataVm.ApprBuildingTemplateGuid = apprBuilding.ApprEnvironmentGuid;
                    dataVm.TotalBuildingArea = apprBuilding.TotalBuildingArea;
                }

            }

            return ServiceResponse<ApprBuildingFloorResponse>.ReturnResultWith200(dataVm);
        }
    }
}
