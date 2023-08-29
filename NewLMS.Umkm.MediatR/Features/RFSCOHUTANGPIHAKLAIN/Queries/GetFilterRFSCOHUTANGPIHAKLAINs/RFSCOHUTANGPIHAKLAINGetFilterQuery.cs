using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSCOHUTANGPIHAKLAINs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFSCOHUTANGPIHAKLAINs.Queries
{
    public class RFSCOHUTANGPIHAKLAINsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFSCOHUTANGPIHAKLAINResponseDto>>>
    {
    }

    public class GetFilterRFSCOHUTANGPIHAKLAINQueryHandler : IRequestHandler<RFSCOHUTANGPIHAKLAINsGetFilterQuery, PagedResponse<IEnumerable<RFSCOHUTANGPIHAKLAINResponseDto>>>
    {
        private IGenericRepositoryAsync<RFSCOHUTANGPIHAKLAIN> _RFSCOHUTANGPIHAKLAIN;
        private readonly IMapper _mapper;

        public GetFilterRFSCOHUTANGPIHAKLAINQueryHandler(IGenericRepositoryAsync<RFSCOHUTANGPIHAKLAIN> RFSCOHUTANGPIHAKLAIN, IMapper mapper)
        {
            _RFSCOHUTANGPIHAKLAIN = RFSCOHUTANGPIHAKLAIN;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFSCOHUTANGPIHAKLAINResponseDto>>> Handle(RFSCOHUTANGPIHAKLAINsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFSCOHUTANGPIHAKLAIN.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFSCOHUTANGPIHAKLAINResponseDto>>(data.Results);
            IEnumerable<RFSCOHUTANGPIHAKLAINResponseDto> dataVm;
            var listResponse = new List<RFSCOHUTANGPIHAKLAINResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFSCOHUTANGPIHAKLAINResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFSCOHUTANGPIHAKLAINResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}