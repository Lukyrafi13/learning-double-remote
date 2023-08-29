using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfSectorLBU1s;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfSectorLBU1s.Queries
{
    public class RfSectorLBU1GetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfSectorLBU1Response>>>
    {
    }

    public class GetFilterRfSectorLBU1QueryHandler : IRequestHandler<RfSectorLBU1GetFilterQuery, PagedResponse<IEnumerable<RfSectorLBU1Response>>>
    {
        private IGenericRepositoryAsync<RfSectorLBU1> _rfSectorLBU1;
        private readonly IMapper _mapper;

        public GetFilterRfSectorLBU1QueryHandler(IGenericRepositoryAsync<RfSectorLBU1> rfSectorLBU1, IMapper mapper)
        {
            _rfSectorLBU1 = rfSectorLBU1;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfSectorLBU1Response>>> Handle(RfSectorLBU1GetFilterQuery request, CancellationToken cancellationToken)
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
