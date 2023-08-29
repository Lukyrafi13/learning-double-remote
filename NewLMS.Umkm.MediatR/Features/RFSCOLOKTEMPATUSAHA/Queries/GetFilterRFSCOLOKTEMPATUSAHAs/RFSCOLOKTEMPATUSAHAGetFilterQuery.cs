using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSCOLOKTEMPATUSAHAs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFSCOLOKTEMPATUSAHAs.Queries
{
    public class RFSCOLOKTEMPATUSAHAsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFSCOLOKTEMPATUSAHAResponseDto>>>
    {
    }

    public class GetFilterRFSCOLOKTEMPATUSAHAQueryHandler : IRequestHandler<RFSCOLOKTEMPATUSAHAsGetFilterQuery, PagedResponse<IEnumerable<RFSCOLOKTEMPATUSAHAResponseDto>>>
    {
        private IGenericRepositoryAsync<RFSCOLOKTEMPATUSAHA> _RFSCOLOKTEMPATUSAHA;
        private readonly IMapper _mapper;

        public GetFilterRFSCOLOKTEMPATUSAHAQueryHandler(IGenericRepositoryAsync<RFSCOLOKTEMPATUSAHA> RFSCOLOKTEMPATUSAHA, IMapper mapper)
        {
            _RFSCOLOKTEMPATUSAHA = RFSCOLOKTEMPATUSAHA;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFSCOLOKTEMPATUSAHAResponseDto>>> Handle(RFSCOLOKTEMPATUSAHAsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFSCOLOKTEMPATUSAHA.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFSCOLOKTEMPATUSAHAResponseDto>>(data.Results);
            IEnumerable<RFSCOLOKTEMPATUSAHAResponseDto> dataVm;
            var listResponse = new List<RFSCOLOKTEMPATUSAHAResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFSCOLOKTEMPATUSAHAResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFSCOLOKTEMPATUSAHAResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}