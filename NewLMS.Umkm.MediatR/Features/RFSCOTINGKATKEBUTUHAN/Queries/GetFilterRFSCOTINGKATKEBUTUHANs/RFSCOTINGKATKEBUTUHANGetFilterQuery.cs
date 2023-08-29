using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSCOTINGKATKEBUTUHANs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFSCOTINGKATKEBUTUHANs.Queries
{
    public class RFSCOTINGKATKEBUTUHANsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFSCOTINGKATKEBUTUHANResponseDto>>>
    {
    }

    public class GetFilterRFSCOTINGKATKEBUTUHANQueryHandler : IRequestHandler<RFSCOTINGKATKEBUTUHANsGetFilterQuery, PagedResponse<IEnumerable<RFSCOTINGKATKEBUTUHANResponseDto>>>
    {
        private IGenericRepositoryAsync<RFSCOTINGKATKEBUTUHAN> _RFSCOTINGKATKEBUTUHAN;
        private readonly IMapper _mapper;

        public GetFilterRFSCOTINGKATKEBUTUHANQueryHandler(IGenericRepositoryAsync<RFSCOTINGKATKEBUTUHAN> RFSCOTINGKATKEBUTUHAN, IMapper mapper)
        {
            _RFSCOTINGKATKEBUTUHAN = RFSCOTINGKATKEBUTUHAN;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFSCOTINGKATKEBUTUHANResponseDto>>> Handle(RFSCOTINGKATKEBUTUHANsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFSCOTINGKATKEBUTUHAN.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFSCOTINGKATKEBUTUHANResponseDto>>(data.Results);
            IEnumerable<RFSCOTINGKATKEBUTUHANResponseDto> dataVm;
            var listResponse = new List<RFSCOTINGKATKEBUTUHANResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFSCOTINGKATKEBUTUHANResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFSCOTINGKATKEBUTUHANResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}