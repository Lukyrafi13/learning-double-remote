using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFStagess;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFStagess.Queries
{
    public class RFStagesGetQuery : RFStagesFindRequestDto, IRequest<ServiceResponse<RFStagesResponseDto>>
    {
    }

    public class RFStagesGetQueryHandler : IRequestHandler<RFStagesGetQuery, ServiceResponse<RFStagesResponseDto>>
    {
        private IGenericRepositoryAsync<RFStages> _RFStages;
        private readonly IMapper _mapper;

        public RFStagesGetQueryHandler(IGenericRepositoryAsync<RFStages> RFStages, IMapper mapper)
        {
            _RFStages = RFStages;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFStagesResponseDto>> Handle(RFStagesGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFStages.GetByIdAsync(request.StageId, "StageId");
                if (data == null)
                    return ServiceResponse<RFStagesResponseDto>.Return404("Data RFStages not found");
                var response = _mapper.Map<RFStagesResponseDto>(data);
                return ServiceResponse<RFStagesResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFStagesResponseDto>.ReturnException(ex);
            }
        }
    }
}