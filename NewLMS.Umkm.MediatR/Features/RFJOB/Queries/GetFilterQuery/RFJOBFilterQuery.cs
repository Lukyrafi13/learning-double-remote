using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RFJOBs;
using NewLMS.Umkm.Repository.GenericRepository;
using AutoMapper;
using NewLMS.Umkm.Data;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFJOBs.Queries
{
    public class GetByRFJOBFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFJOBResponseDto>>>
    {
    }

    public class GetByRFJOBFilterQueryHandler : IRequestHandler<GetByRFJOBFilterQuery, PagedResponse<IEnumerable<RFJOBResponseDto>>>
    {
        private IGenericRepositoryAsync<RFJOB> _RFJOB;
        private readonly IMapper _mapper;

        public GetByRFJOBFilterQueryHandler(IGenericRepositoryAsync<RFJOB> RFJOB, IMapper mapper)
        {
            _RFJOB = RFJOB;
            _mapper = mapper;
        }
        public async
        Task<PagedResponse<IEnumerable<RFJOBResponseDto>>> Handle(GetByRFJOBFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFJOB.GetPagedReponseAsync(request);
            
            IEnumerable<RFJOBResponseDto> dataVm;
            var listResponse = new List<RFJOBResponseDto>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<RFJOBResponseDto>(res);
                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFJOBResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}