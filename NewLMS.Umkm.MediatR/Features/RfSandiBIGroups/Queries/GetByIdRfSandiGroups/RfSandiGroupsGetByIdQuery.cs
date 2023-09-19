using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RfSandiBIGroup;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RfSandiBIGroups.Queries.GetByIdRfSandiGroups
{
    public class RfSandiGroupsGetByIdQuery : IRequest<ServiceResponse<RfSandiBIGroupResponse>>
    {
        public string BIGroup { get; set; }
    }

    public class RfSandiGroupsGetByIdQueryHandler : IRequestHandler<RfSandiGroupsGetByIdQuery, ServiceResponse<RfSandiBIGroupResponse>>
    {
        private IGenericRepositoryAsync<RfSandiBIGroup> _core;
        private readonly IMapper _mapper;

        public RfSandiGroupsGetByIdQueryHandler(IGenericRepositoryAsync<RfSandiBIGroup> core, IMapper mapper)
        {
            _core = core;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfSandiBIGroupResponse>> Handle(RfSandiGroupsGetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _core.GetByIdAsync(request.BIGroup, "BIGroup");
                if (data == null)
                    return ServiceResponse<RfSandiBIGroupResponse>.Return404("Data RfSandiBIGroup not found");
                var dataVm = _mapper.Map<RfSandiBIGroupResponse>(data);
                return ServiceResponse<RfSandiBIGroupResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {

                return ServiceResponse<RfSandiBIGroupResponse>.ReturnException(ex);
            }

        }
    }
}
