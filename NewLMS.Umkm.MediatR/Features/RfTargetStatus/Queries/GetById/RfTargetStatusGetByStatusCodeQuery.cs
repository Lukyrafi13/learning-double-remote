using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfTargetStatuses;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfTargetStatuses.Queries
{
    public class RfTargetStatusGetByStatusCodeQuery : RfTargetStatusFindRequestDto, IRequest<ServiceResponse<RfTargetStatusResponseDto>>
    {
    }

    public class GetByStatusCodeRfTargetStatusQueryHandler : IRequestHandler<RfTargetStatusGetByStatusCodeQuery, ServiceResponse<RfTargetStatusResponseDto>>
    {
        private IGenericRepositoryAsync<RfTargetStatus> _rfStatusTarget;
        private readonly IMapper _mapper;

        public GetByStatusCodeRfTargetStatusQueryHandler(IGenericRepositoryAsync<RfTargetStatus> rfStatusTarget, IMapper mapper)
        {
            _rfStatusTarget = rfStatusTarget;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RfTargetStatusResponseDto>> Handle(RfTargetStatusGetByStatusCodeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _rfStatusTarget.GetByIdAsync(request.StatusCode, "StatusCode");
                if (data == null)
                    return ServiceResponse<RfTargetStatusResponseDto>.Return404("Data RfTargetStatus not found");
                var response = new RfTargetStatusResponseDto();
                
                response.Id = data.Id;
                response.Active = data.Active;
                response.StatusCode = data.StatusCode;
                response.StatusDesc = data.StatusDesc;
                return ServiceResponse<RfTargetStatusResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RfTargetStatusResponseDto>.ReturnException(ex);
            }
        }
    }
}