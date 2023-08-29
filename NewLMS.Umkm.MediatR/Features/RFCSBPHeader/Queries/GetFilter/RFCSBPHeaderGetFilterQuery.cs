using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFCSBPHeaders;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFCSBPHeaders.Queries
{
    public class RFCSBPHeadersGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFCSBPHeaderResponseDto>>>
    {
    }

    public class GetFilterRFCSBPHeaderQueryHandler : IRequestHandler<RFCSBPHeadersGetFilterQuery, PagedResponse<IEnumerable<RFCSBPHeaderResponseDto>>>
    {
        private IGenericRepositoryAsync<RFCSBPHeader> _RFCSBPHeader;
        private readonly IMapper _mapper;

        public GetFilterRFCSBPHeaderQueryHandler(IGenericRepositoryAsync<RFCSBPHeader> RFCSBPHeader, IMapper mapper)
        {
            _RFCSBPHeader = RFCSBPHeader;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFCSBPHeaderResponseDto>>> Handle(RFCSBPHeadersGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFCSBPHeader.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFCSBPHeaderResponseDto>>(data.Results);
            IEnumerable<RFCSBPHeaderResponseDto> dataVm;
            var listResponse = new List<RFCSBPHeaderResponseDto>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<RFCSBPHeaderResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFCSBPHeaderResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}