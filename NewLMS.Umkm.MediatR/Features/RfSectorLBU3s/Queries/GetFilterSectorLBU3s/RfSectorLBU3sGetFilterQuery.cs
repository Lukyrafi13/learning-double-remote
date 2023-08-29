using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RFSectorLBU3s;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFSectorLBU3s.Queries
{
    public class RFSectorLBU3GetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFSectorLBU3Response>>>
    {
    }

    public class GetFilterRFSectorLBU3QueryHandler : IRequestHandler<RFSectorLBU3GetFilterQuery, PagedResponse<IEnumerable<RFSectorLBU3Response>>>
    {
        private IGenericRepositoryAsync<RFSectorLBU3> _rfSectorLBU3;
        private readonly IMapper _mapper;

        public GetFilterRFSectorLBU3QueryHandler(IGenericRepositoryAsync<RFSectorLBU3> rfSectorLBU3, IMapper mapper)
        {
            _rfSectorLBU3 = rfSectorLBU3;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFSectorLBU3Response>>> Handle(RFSectorLBU3GetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[] { "RFSectorLBU2", "RFSectorLBU2.RFSectorLBU1" };
            var data = await _rfSectorLBU3.GetPagedReponseAsync(request, includes);
            var dataVm = _mapper.Map<IEnumerable<RFSectorLBU3Response>>(data.Results);
            return new PagedResponse<IEnumerable<RFSectorLBU3Response>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
