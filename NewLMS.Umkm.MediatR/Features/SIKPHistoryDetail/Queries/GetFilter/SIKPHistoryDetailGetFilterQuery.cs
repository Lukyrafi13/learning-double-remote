using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.SIKPHistoryDetails;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.SIKPHistoryDetails.Queries
{
    public class SIKPHistoryDetailsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<SIKPHistoryDetailResponseDto>>>
    {
    }

    public class GetFilterSIKPHistoryDetailQueryHandler : IRequestHandler<SIKPHistoryDetailsGetFilterQuery, PagedResponse<IEnumerable<SIKPHistoryDetailResponseDto>>>
    {
        private IGenericRepositoryAsync<SIKPHistoryDetail> _SIKPHistoryDetail;
        private readonly IMapper _mapper;

        public GetFilterSIKPHistoryDetailQueryHandler(IGenericRepositoryAsync<SIKPHistoryDetail> SIKPHistoryDetail, IMapper mapper)
        {
            _SIKPHistoryDetail = SIKPHistoryDetail;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<SIKPHistoryDetailResponseDto>>> Handle(SIKPHistoryDetailsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
                "SIKPHistory",
            };

            var data = await _SIKPHistoryDetail.GetPagedReponseAsync(request, includes);
            // var dataVm = _mapper.Map<IEnumerable<SIKPHistoryDetailResponseDto>>(data.Results);
            IEnumerable<SIKPHistoryDetailResponseDto> dataVm;
            var listResponse = new List<SIKPHistoryDetailResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<SIKPHistoryDetailResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<SIKPHistoryDetailResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}