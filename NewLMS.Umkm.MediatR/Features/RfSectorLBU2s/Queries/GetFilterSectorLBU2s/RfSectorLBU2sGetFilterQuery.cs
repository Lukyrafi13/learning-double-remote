using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RFSectorLBU2s;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFSectorLBU2s.Queries
{
    public class RFSectorLBU2GetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFSectorLBU2Response>>>
    {
    }

    public class GetFilterRFSectorLBU2QueryHandler : IRequestHandler<RFSectorLBU2GetFilterQuery, PagedResponse<IEnumerable<RFSectorLBU2Response>>>
    {
        private IGenericRepositoryAsync<RFSectorLBU2> _rfSectorLBU2;
        private readonly IMapper _mapper;

        public GetFilterRFSectorLBU2QueryHandler(IGenericRepositoryAsync<RFSectorLBU2> rfSectorLBU2, IMapper mapper)
        {
            _rfSectorLBU2 = rfSectorLBU2;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFSectorLBU2Response>>> Handle(RFSectorLBU2GetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[] { "RFSectorLBU1" };
            var data = await _rfSectorLBU2.GetPagedReponseAsync(request, includes);
            var dataVm = _mapper.Map<IEnumerable<RFSectorLBU2Response>>(data.Results);
            return new PagedResponse<IEnumerable<RFSectorLBU2Response>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
