using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfStages;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfStages.Queries
{
    public class RfStageGetQuery : RfStageFindRequestDto, IRequest<ServiceResponse<RfStageResponseDto>>
    {
    }

    public class RfStageGetQueryHandler : IRequestHandler<RfStageGetQuery, ServiceResponse<RfStageResponseDto>>
    {
        private IGenericRepositoryAsync<RfStage> _RfStage;
        private readonly IMapper _mapper;

        public RfStageGetQueryHandler(IGenericRepositoryAsync<RfStage> RfStage, IMapper mapper)
        {
            _RfStage = RfStage;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RfStageResponseDto>> Handle(RfStageGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RfStage.GetByIdAsync(request.StageId, "StageId");
                if (data == null)
                    return ServiceResponse<RfStageResponseDto>.Return404("Data RfStage not found");
                var response = _mapper.Map<RfStageResponseDto>(data);
                return ServiceResponse<RfStageResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RfStageResponseDto>.ReturnException(ex);
            }
        }
    }
}