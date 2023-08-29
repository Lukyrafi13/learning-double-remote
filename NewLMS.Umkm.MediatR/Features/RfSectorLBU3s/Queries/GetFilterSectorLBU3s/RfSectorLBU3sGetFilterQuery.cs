using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfSectorLBU3s;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfSectorLBU3s.Queries
{
    public class RfSectorLBU3GetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfSectorLBU3Response>>>
    {
    }

    public class GetFilterRfSectorLBU3QueryHandler : IRequestHandler<RfSectorLBU3GetFilterQuery, PagedResponse<IEnumerable<RfSectorLBU3Response>>>
    {
        private IGenericRepositoryAsync<RfSectorLBU3> _rfSectorLBU3;
        private readonly IMapper _mapper;

        public GetFilterRfSectorLBU3QueryHandler(IGenericRepositoryAsync<RfSectorLBU3> rfSectorLBU3, IMapper mapper)
        {
            _rfSectorLBU3 = rfSectorLBU3;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfSectorLBU3Response>>> Handle(RfSectorLBU3GetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[] { "RfSectorLBU2", "RfSectorLBU2.RfSectorLBU1" };
            var data = await _rfSectorLBU3.GetPagedReponseAsync(request, includes);
            var dataVm = _mapper.Map<IEnumerable<RfSectorLBU3Response>>(data.Results);
            return new PagedResponse<IEnumerable<RfSectorLBU3Response>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
