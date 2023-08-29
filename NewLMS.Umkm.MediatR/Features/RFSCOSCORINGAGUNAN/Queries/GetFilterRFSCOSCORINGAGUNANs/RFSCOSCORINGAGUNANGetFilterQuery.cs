using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSCOSCORINGAGUNANs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFSCOSCORINGAGUNANs.Queries
{
    public class RFSCOSCORINGAGUNANsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFSCOSCORINGAGUNANResponseDto>>>
    {
    }

    public class GetFilterRFSCOSCORINGAGUNANQueryHandler : IRequestHandler<RFSCOSCORINGAGUNANsGetFilterQuery, PagedResponse<IEnumerable<RFSCOSCORINGAGUNANResponseDto>>>
    {
        private IGenericRepositoryAsync<RFSCOSCORINGAGUNAN> _RFSCOSCORINGAGUNAN;
        private readonly IMapper _mapper;

        public GetFilterRFSCOSCORINGAGUNANQueryHandler(IGenericRepositoryAsync<RFSCOSCORINGAGUNAN> RFSCOSCORINGAGUNAN, IMapper mapper)
        {
            _RFSCOSCORINGAGUNAN = RFSCOSCORINGAGUNAN;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFSCOSCORINGAGUNANResponseDto>>> Handle(RFSCOSCORINGAGUNANsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFSCOSCORINGAGUNAN.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFSCOSCORINGAGUNANResponseDto>>(data.Results);
            IEnumerable<RFSCOSCORINGAGUNANResponseDto> dataVm;
            var listResponse = new List<RFSCOSCORINGAGUNANResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFSCOSCORINGAGUNANResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFSCOSCORINGAGUNANResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}