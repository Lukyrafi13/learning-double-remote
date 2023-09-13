using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfTenor;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfTernors.Queries.GetFilterRfTenors
{
    public class RfTenorsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfTenorResponse>>>
    {
    }

    public class RfTenorsGetFilterQueryHandler : IRequestHandler<RfTenorsGetFilterQuery, PagedResponse<IEnumerable<RfTenorResponse>>>
    {
        private IGenericRepositoryAsync<RfTenor> _rfTenor;
        private readonly IMapper _mapper;

        public RfTenorsGetFilterQueryHandler(IGenericRepositoryAsync<RfTenor> rfTenor, IMapper mapper)
        {
            _rfTenor = rfTenor;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfTenorResponse>>> Handle(RfTenorsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[] {
                "RfProduct",
            };
            var data = await _rfTenor.GetPagedReponseAsync(request, includes);
            var dataVm = _mapper.Map<IEnumerable<RfTenorResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfTenorResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
