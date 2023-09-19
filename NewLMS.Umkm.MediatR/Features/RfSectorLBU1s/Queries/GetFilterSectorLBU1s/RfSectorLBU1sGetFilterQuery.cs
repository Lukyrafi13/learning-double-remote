using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfSectorLBU1s;
using NewLMS.Umkm.Repository.GenericRepository;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.MediatR.Features.RFSectorLBU1s.Queries
{
    public class RFSectorLBU1GetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfSectorLBU1Response>>>
    {
    }

    public class GetFilterRFSectorLBU1QueryHandler : IRequestHandler<RFSectorLBU1GetFilterQuery, PagedResponse<IEnumerable<RfSectorLBU1Response>>>
    {
        private IGenericRepositoryAsync<RfSectorLBU1> _rfSectorLBU1;
        private readonly IMapper _mapper;

        public GetFilterRFSectorLBU1QueryHandler(IGenericRepositoryAsync<RfSectorLBU1> rfSectorLBU1, IMapper mapper)
        {
            _rfSectorLBU1 = rfSectorLBU1;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfSectorLBU1Response>>> Handle(RFSectorLBU1GetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfSectorLBU1.GetPagedReponseAsync(request);
            var dataVm = _mapper.Map<IEnumerable<RfSectorLBU1Response>>(data.Results);
            return new PagedResponse<IEnumerable<RfSectorLBU1Response>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
