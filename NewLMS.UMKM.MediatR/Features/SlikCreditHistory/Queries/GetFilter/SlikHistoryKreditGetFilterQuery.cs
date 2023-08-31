using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.SlikCreditHistorys;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.SlikCreditHistorys.Queries
{
    public class SlikCreditHistorysGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<SlikCreditHistoryResponseDto>>>
    {
    }

    public class GetFilterSlikCreditHistoryQueryHandler : IRequestHandler<SlikCreditHistorysGetFilterQuery, PagedResponse<IEnumerable<SlikCreditHistoryResponseDto>>>
    {
        private IGenericRepositoryAsync<SlikCreditHistory> _SlikCreditHistory;
        private readonly IMapper _mapper;

        public GetFilterSlikCreditHistoryQueryHandler(IGenericRepositoryAsync<SlikCreditHistory> SlikCreditHistory, IMapper mapper)
        {
            _SlikCreditHistory = SlikCreditHistory;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<SlikCreditHistoryResponseDto>>> Handle(SlikCreditHistorysGetFilterQuery request, CancellationToken cancellationToken)
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

            var data = await _SlikCreditHistory.GetPagedReponseAsync(request, includes);
            // var dataVm = _mapper.Map<IEnumerable<SlikCreditHistoryResponseDto>>(data.Results);
            IEnumerable<SlikCreditHistoryResponseDto> dataVm;
            var listResponse = new List<SlikCreditHistoryResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<SlikCreditHistoryResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<SlikCreditHistoryResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}