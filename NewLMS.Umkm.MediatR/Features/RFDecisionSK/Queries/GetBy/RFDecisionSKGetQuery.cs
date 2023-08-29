using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFDecisionSKs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFDecisionSKs.Queries
{
    public class RFDecisionSKGetQuery : RFDecisionSKFindRequestDto, IRequest<ServiceResponse<RFDecisionSKResponseDto>>
    {
    }

    public class RFDecisionSKGetQueryHandler : IRequestHandler<RFDecisionSKGetQuery, ServiceResponse<RFDecisionSKResponseDto>>
    {
        private IGenericRepositoryAsync<RFDecisionSK> _RFDecisionSK;
        private readonly IMapper _mapper;

        public RFDecisionSKGetQueryHandler(IGenericRepositoryAsync<RFDecisionSK> RFDecisionSK, IMapper mapper)
        {
            _RFDecisionSK = RFDecisionSK;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFDecisionSKResponseDto>> Handle(RFDecisionSKGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFDecisionSK.GetByIdAsync(request.DEC_CODE, "DEC_CODE");
                if (data == null)
                    return ServiceResponse<RFDecisionSKResponseDto>.Return404("Data RFDecisionSK not found");
                var response = _mapper.Map<RFDecisionSKResponseDto>(data);
                return ServiceResponse<RFDecisionSKResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFDecisionSKResponseDto>.ReturnException(ex);
            }
        }
    }
}