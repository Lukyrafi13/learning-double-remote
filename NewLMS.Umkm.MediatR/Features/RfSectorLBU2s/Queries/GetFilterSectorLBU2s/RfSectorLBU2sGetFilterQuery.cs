using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfSectorLBU2s;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfSectorLBU2s.Queries
{
    public class RfSectorLBU2GetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfSectorLBU2Response>>>
    {
    }

    public class GetFilterRfSectorLBU2QueryHandler : IRequestHandler<RfSectorLBU2GetFilterQuery, PagedResponse<IEnumerable<RfSectorLBU2Response>>>
    {
        private IGenericRepositoryAsync<RfSectorLBU2> _rfSectorLBU2;
        private readonly IMapper _mapper;

        public GetFilterRfSectorLBU2QueryHandler(IGenericRepositoryAsync<RfSectorLBU2> rfSectorLBU2, IMapper mapper)
        {
            _rfSectorLBU2 = rfSectorLBU2;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfSectorLBU2Response>>> Handle(RfSectorLBU2GetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[] { "RfSectorLBU1" };
            var data = await _rfSectorLBU2.GetPagedReponseAsync(request, includes);
            var dataVm = _mapper.Map<IEnumerable<RfSectorLBU2Response>>(data.Results);
            return new PagedResponse<IEnumerable<RfSectorLBU2Response>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
