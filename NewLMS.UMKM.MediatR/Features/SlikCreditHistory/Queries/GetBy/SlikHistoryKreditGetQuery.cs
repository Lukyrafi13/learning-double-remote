using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.SlikCreditHistorys;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.SlikCreditHistorys.Queries
{
    public class SlikCreditHistoryGetQuery : SlikCreditHistoryFindRequestDto, IRequest<ServiceResponse<SlikCreditHistoryResponseDto>>
    {
    }

    public class SlikCreditHistoryGetQueryHandler : IRequestHandler<SlikCreditHistoryGetQuery, ServiceResponse<SlikCreditHistoryResponseDto>>
    {
        private IGenericRepositoryAsync<SlikCreditHistory> _SlikCreditHistory;
        private readonly IMapper _mapper;

        public SlikCreditHistoryGetQueryHandler(IGenericRepositoryAsync<SlikCreditHistory> SlikCreditHistory, IMapper mapper)
        {
            _SlikCreditHistory = SlikCreditHistory;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<SlikCreditHistoryResponseDto>> Handle(SlikCreditHistoryGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                    "RfCreditType",
                    "RfSandiBIEconomySectorClass",
                    "RfSandiBIBehaviourClass",
                    "RfSandiBIApplicationTypeClass",
                    "RfSandiBICollectibilityClass",
                    "RfCondition",
                    "SlikRequest",
                    "SlikObjectType",
                };

                var data = await _SlikCreditHistory.GetByIdAsync(request.Id, "Id", includes);
                if (data == null)
                    return ServiceResponse<SlikCreditHistoryResponseDto>.Return404("Data SlikCreditHistory not found");
                var response = _mapper.Map<SlikCreditHistoryResponseDto>(data);
                return ServiceResponse<SlikCreditHistoryResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SlikCreditHistoryResponseDto>.ReturnException(ex);
            }
        }
    }
}