using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.Appraisals;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.Appraisals.Queries
{
    public class GetApprBuildingFloorDetailQuery : IRequest<ServiceResponse<IEnumerable<ApprBuildingFloorDetailResponse>>>
    {
        public Guid BuildingFloorGuid { get; set; }
    }

    public class GetApprBuildingFloorDetailQueryHandler : IRequestHandler<GetApprBuildingFloorDetailQuery, ServiceResponse<IEnumerable<ApprBuildingFloorDetailResponse>>>
    {
        private IGenericRepositoryAsync<ApprBuildingFloorDetails> _ApprBuildingFloor;
        private IMapper _mapper;

        public GetApprBuildingFloorDetailQueryHandler(IGenericRepositoryAsync<ApprBuildingFloorDetails> ApprBuildingFloorDetail, IMapper mapper)
        {
            _ApprBuildingFloor = ApprBuildingFloorDetail;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<IEnumerable<ApprBuildingFloorDetailResponse>>> Handle(GetApprBuildingFloorDetailQuery request, CancellationToken cancellationToken)
        {
            var data = await _ApprBuildingFloor.GetListByPredicate(x => x.ApprBuildingFloorGuid == request.BuildingFloorGuid, null);
            var dataVm = _mapper.Map<IEnumerable<ApprBuildingFloorDetailResponse>>(data);

            return ServiceResponse<IEnumerable<ApprBuildingFloorDetailResponse>>.ReturnResultWith200(dataVm);
        }
    }
}
