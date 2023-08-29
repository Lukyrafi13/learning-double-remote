using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFSCOSALDOREKRATAs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFSCOSALDOREKRATAs.Queries
{
    public class RFSCOSALDOREKRATAsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFSCOSALDOREKRATAResponseDto>>>
    {
    }

    public class GetFilterRFSCOSALDOREKRATAQueryHandler : IRequestHandler<RFSCOSALDOREKRATAsGetFilterQuery, PagedResponse<IEnumerable<RFSCOSALDOREKRATAResponseDto>>>
    {
        private IGenericRepositoryAsync<RFSCOSALDOREKRATA> _RFSCOSALDOREKRATA;
        private readonly IMapper _mapper;

        public GetFilterRFSCOSALDOREKRATAQueryHandler(IGenericRepositoryAsync<RFSCOSALDOREKRATA> RFSCOSALDOREKRATA, IMapper mapper)
        {
            _RFSCOSALDOREKRATA = RFSCOSALDOREKRATA;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFSCOSALDOREKRATAResponseDto>>> Handle(RFSCOSALDOREKRATAsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFSCOSALDOREKRATA.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFSCOSALDOREKRATAResponseDto>>(data.Results);
            IEnumerable<RFSCOSALDOREKRATAResponseDto> dataVm;
            var listResponse = new List<RFSCOSALDOREKRATAResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFSCOSALDOREKRATAResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFSCOSALDOREKRATAResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}