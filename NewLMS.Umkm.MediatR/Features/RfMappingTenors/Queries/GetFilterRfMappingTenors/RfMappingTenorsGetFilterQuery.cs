using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfMappingTenor;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfMappingTenors.Queries.GetFilterRfMappingTenors
{
    public class RfMappingTenorsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfMappingTenorResponse>>>
    {
    }

    public class RfMappingTenorsGetFilterQueryHandler : IRequestHandler<RfMappingTenorsGetFilterQuery, PagedResponse<IEnumerable<RfMappingTenorResponse>>>
    {
        private IGenericRepositoryAsync<RfMappingTenor> _rfMappingTenor;
        private readonly IMapper _mapper;

        public RfMappingTenorsGetFilterQueryHandler(IGenericRepositoryAsync<RfMappingTenor> rfMappingTenor, IMapper mapper)
        {
            _rfMappingTenor = rfMappingTenor;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfMappingTenorResponse>>> Handle(RfMappingTenorsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[] {
                "RfTenor",
                "RfProduct",
            };
            var data = await _rfMappingTenor.GetPagedReponseAsync(request, includes);
            var dataVm = _mapper.Map<IEnumerable<RfMappingTenorResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfMappingTenorResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
