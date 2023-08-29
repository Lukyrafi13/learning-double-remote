using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSANDIBIS;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFSANDIBIS.Queries
{
    public class RFSANDIBISGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFSANDIBIResponseDto>>>
    {
    }

    public class GetFilterRFSANDIBIQueryHandler : IRequestHandler<RFSANDIBISGetFilterQuery, PagedResponse<IEnumerable<RFSANDIBIResponseDto>>>
    {
        private IGenericRepositoryAsync<RFSANDIBI> _RFSANDIBI;
        private readonly IMapper _mapper;

        public GetFilterRFSANDIBIQueryHandler(IGenericRepositoryAsync<RFSANDIBI> RFSANDIBI, IMapper mapper)
        {
            _RFSANDIBI = RFSANDIBI;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFSANDIBIResponseDto>>> Handle(RFSANDIBISGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFSANDIBI.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFSANDIBIResponseDto>>(data.Results);
            IEnumerable<RFSANDIBIResponseDto> dataVm;
            var listResponse = new List<RFSANDIBIResponseDto>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<RFSANDIBIResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFSANDIBIResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}