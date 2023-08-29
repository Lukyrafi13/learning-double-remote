using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.MSearchs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.MSearchs.Queries
{
    public class MSearchsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<MSearchResponseDto>>>
    {
    }

    public class GetFilterMSearchQueryHandler : IRequestHandler<MSearchsGetFilterQuery, PagedResponse<IEnumerable<MSearchResponseDto>>>
    {
        private IGenericRepositoryAsync<MSearch> _MSearch;
        private readonly IMapper _mapper;

        public GetFilterMSearchQueryHandler(IGenericRepositoryAsync<MSearch> MSearch, IMapper mapper)
        {
            _MSearch = MSearch;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<MSearchResponseDto>>> Handle(MSearchsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _MSearch.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<MSearchResponseDto>>(data.Results);
            IEnumerable<MSearchResponseDto> dataVm;
            var listResponse = new List<MSearchResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<MSearchResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<MSearchResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}