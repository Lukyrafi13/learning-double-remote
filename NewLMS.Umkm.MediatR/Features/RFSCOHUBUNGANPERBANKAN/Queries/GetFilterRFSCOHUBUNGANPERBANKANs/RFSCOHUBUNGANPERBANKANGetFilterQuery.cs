using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSCOHUBUNGANPERBANKANs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFSCOHUBUNGANPERBANKANs.Queries
{
    public class RFSCOHUBUNGANPERBANKANsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFSCOHUBUNGANPERBANKANResponseDto>>>
    {
    }

    public class GetFilterRFSCOHUBUNGANPERBANKANQueryHandler : IRequestHandler<RFSCOHUBUNGANPERBANKANsGetFilterQuery, PagedResponse<IEnumerable<RFSCOHUBUNGANPERBANKANResponseDto>>>
    {
        private IGenericRepositoryAsync<RFSCOHUBUNGANPERBANKAN> _RFSCOHUBUNGANPERBANKAN;
        private readonly IMapper _mapper;

        public GetFilterRFSCOHUBUNGANPERBANKANQueryHandler(IGenericRepositoryAsync<RFSCOHUBUNGANPERBANKAN> RFSCOHUBUNGANPERBANKAN, IMapper mapper)
        {
            _RFSCOHUBUNGANPERBANKAN = RFSCOHUBUNGANPERBANKAN;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFSCOHUBUNGANPERBANKANResponseDto>>> Handle(RFSCOHUBUNGANPERBANKANsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFSCOHUBUNGANPERBANKAN.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFSCOHUBUNGANPERBANKANResponseDto>>(data.Results);
            IEnumerable<RFSCOHUBUNGANPERBANKANResponseDto> dataVm;
            var listResponse = new List<RFSCOHUBUNGANPERBANKANResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFSCOHUBUNGANPERBANKANResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFSCOHUBUNGANPERBANKANResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}