using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RFSectorLBU1s;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFSectorLBU1s.Queries
{
    public class RFSectorLBU1GetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFSectorLBU1Response>>>
    {
    }

    public class GetFilterRFSectorLBU1QueryHandler : IRequestHandler<RFSectorLBU1GetFilterQuery, PagedResponse<IEnumerable<RFSectorLBU1Response>>>
    {
        private IGenericRepositoryAsync<RFSectorLBU1> _rfSectorLBU1;
        private readonly IMapper _mapper;

        public GetFilterRFSectorLBU1QueryHandler(IGenericRepositoryAsync<RFSectorLBU1> rfSectorLBU1, IMapper mapper)
        {
            _rfSectorLBU1 = rfSectorLBU1;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFSectorLBU1Response>>> Handle(RFSectorLBU1GetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfSectorLBU1.GetPagedReponseAsync(request);
            var dataVm = _mapper.Map<IEnumerable<RFSectorLBU1Response>>(data.Results);
            return new PagedResponse<IEnumerable<RFSectorLBU1Response>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
