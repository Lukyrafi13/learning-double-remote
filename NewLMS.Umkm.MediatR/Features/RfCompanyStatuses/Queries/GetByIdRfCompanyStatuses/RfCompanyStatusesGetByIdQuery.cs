using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfCompanyGroups;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.MediatR.Features.RfCompanyGroups.Queries;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RfCompanyStatuses;

namespace NewLMS.UMKM.MediatR.Features.RfCompanyStatuses.Queries.GetByIdRfCompanyStatuses
{
    public class RfCompanyStatusesGetByIdQuery : RfCompanyStatusFindRequest, IRequest<ServiceResponse<RfCompanyStatusResponse>>
    {
    }

    public class RfCompanyStatusesGetByIdQueryHandler : IRequestHandler<RfCompanyStatusesGetByIdQuery, ServiceResponse<RfCompanyStatusResponse>>
    {
        private IGenericRepositoryAsync<RfCompanyStatus> _RfCompanyStatus;
        private readonly IMapper _mapper;

        public RfCompanyStatusesGetByIdQueryHandler(IGenericRepositoryAsync<RfCompanyStatus> RfCompanyStatus, IMapper mapper)
        {
            _RfCompanyStatus = RfCompanyStatus;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RfCompanyStatusResponse>> Handle(RfCompanyStatusesGetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RfCompanyStatus.GetByIdAsync(request.StatusCode, "StatusCode");
                if (data == null)
                    return ServiceResponse<RfCompanyStatusResponse>.Return404("Data RfComapnyStatus not found");
                var response = _mapper.Map<RfCompanyStatusResponse>(data);
                return ServiceResponse<RfCompanyStatusResponse>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RfCompanyStatusResponse>.ReturnException(ex);
            }
        }
    }
}
