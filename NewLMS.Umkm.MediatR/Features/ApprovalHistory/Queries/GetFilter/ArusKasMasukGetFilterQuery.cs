using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.ApprovalHistorys;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.ApprovalHistorys.Queries
{
    public class ApprovalHistorysGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<ApprovalHistoryResponseDto>>>
    {
    }

    public class GetFilterApprovalHistoryQueryHandler : IRequestHandler<ApprovalHistorysGetFilterQuery, PagedResponse<IEnumerable<ApprovalHistoryResponseDto>>>
    {
        private IGenericRepositoryAsync<ApprovalHistory> _ApprovalHistory;
        private readonly IMapper _mapper;

        public GetFilterApprovalHistoryQueryHandler(IGenericRepositoryAsync<ApprovalHistory> ApprovalHistory, IMapper mapper)
        {
            _ApprovalHistory = ApprovalHistory;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<ApprovalHistoryResponseDto>>> Handle(ApprovalHistorysGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _ApprovalHistory.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<ApprovalHistoryResponseDto>>(data.Results);
            IEnumerable<ApprovalHistoryResponseDto> dataVm;
            var listResponse = new List<ApprovalHistoryResponseDto>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<ApprovalHistoryResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<ApprovalHistoryResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}