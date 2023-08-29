using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.SIKPHistorys;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.SIKPHistorys.Queries
{
    public class SIKPHistorysGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<SIKPHistoryResponseDto>>>
    {
    }

    public class GetFilterSIKPHistoryQueryHandler : IRequestHandler<SIKPHistorysGetFilterQuery, PagedResponse<IEnumerable<SIKPHistoryResponseDto>>>
    {
        private IGenericRepositoryAsync<SIKPHistory> _SIKPHistory;
        private IGenericRepositoryAsync<SIKPHistoryDetail> _SIKPHistoryDetail;
        private readonly IMapper _mapper;

        public GetFilterSIKPHistoryQueryHandler(
            IGenericRepositoryAsync<SIKPHistory> SIKPHistory,
            IGenericRepositoryAsync<SIKPHistoryDetail> SIKPHistoryDetail,
            IMapper mapper)
        {
            _SIKPHistory = SIKPHistory;
            _SIKPHistoryDetail = SIKPHistoryDetail;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<SIKPHistoryResponseDto>>> Handle(SIKPHistorysGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
                "SubSubSektorEkonomiLBU"
            };

            var data = await _SIKPHistory.GetPagedReponseAsync(request, includes);
            // var dataVm = _mapper.Map<IEnumerable<SIKPHistoryResponseDto>>(data.Results);
            IEnumerable<SIKPHistoryResponseDto> dataVm;
            var listResponse = new List<SIKPHistoryResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<SIKPHistoryResponseDto>(res);

                var firstDetail = (await _SIKPHistoryDetail.GetListByPredicate(x=> x.SIKPHistoryId == res.Id))[0];
                
                response.AkadDiizinkan = firstDetail.MaxJumlahAkad - firstDetail.JumlahAkad;
                response.RateAkad = firstDetail.RateAkad;
                response.LimitAktif = firstDetail.LimitAktif;

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<SIKPHistoryResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}