using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFStatusTargets;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFStatusTargets.Queries
{
    public class RFStatusTargetsGetByStatusCodeQuery : RFStatusTargetFindRequestDto, IRequest<ServiceResponse<RFStatusTargetResponseDto>>
    {
    }

    public class GetByStatusCodeRFStatusTargetQueryHandler : IRequestHandler<RFStatusTargetsGetByStatusCodeQuery, ServiceResponse<RFStatusTargetResponseDto>>
    {
        private IGenericRepositoryAsync<RFStatusTarget> _rfStatusTarget;
        private readonly IMapper _mapper;

        public GetByStatusCodeRFStatusTargetQueryHandler(IGenericRepositoryAsync<RFStatusTarget> rfStatusTarget, IMapper mapper)
        {
            _rfStatusTarget = rfStatusTarget;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFStatusTargetResponseDto>> Handle(RFStatusTargetsGetByStatusCodeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _rfStatusTarget.GetByIdAsync(request.StatusCode, "StatusCode");
                if (data == null)
                    return ServiceResponse<RFStatusTargetResponseDto>.Return404("Data RFStatusTarget not found");
                var response = new RFStatusTargetResponseDto();
                
                response.Id = data.Id;
                response.Active = data.Active;
                response.StatusCode = data.StatusCode;
                response.StatusDesc = data.StatusDesc;
                return ServiceResponse<RFStatusTargetResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFStatusTargetResponseDto>.ReturnException(ex);
            }
        }
    }
}