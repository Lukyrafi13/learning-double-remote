using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfCompanyGroups;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfCompanyGroups.Queries
{
    public class RfCompanyGroupGetQuery : RfCompanyGroupFindRequestDto, IRequest<ServiceResponse<RfCompanyGroupResponseDto>>
    {
    }

    public class RfCompanyGroupGetQueryHandler : IRequestHandler<RfCompanyGroupGetQuery, ServiceResponse<RfCompanyGroupResponseDto>>
    {
        private IGenericRepositoryAsync<RfCompanyGroup> _RfCompanyGroup;
        private readonly IMapper _mapper;

        public RfCompanyGroupGetQueryHandler(IGenericRepositoryAsync<RfCompanyGroup> RfCompanyGroup, IMapper mapper)
        {
            _RfCompanyGroup = RfCompanyGroup;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RfCompanyGroupResponseDto>> Handle(RfCompanyGroupGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RfCompanyGroup.GetByIdAsync(request.ANL_CODE, "ANL_CODE");
                if (data == null)
                    return ServiceResponse<RfCompanyGroupResponseDto>.Return404("Data RfCompanyGroup not found");
                var response = _mapper.Map<RfCompanyGroupResponseDto>(data);
                return ServiceResponse<RfCompanyGroupResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RfCompanyGroupResponseDto>.ReturnException(ex);
            }
        }
    }
}