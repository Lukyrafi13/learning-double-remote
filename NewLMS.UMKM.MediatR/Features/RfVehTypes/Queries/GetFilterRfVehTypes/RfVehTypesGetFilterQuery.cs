using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfVehType;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfVehTypes.Queries.GetFilterRfVehTypes
{
    public class RfVehTypesGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfVehTypeResponse>>>
    {
    }

    public class RfVehTypesGetFilterQueryHandler : IRequestHandler<RfVehTypesGetFilterQuery, PagedResponse<IEnumerable<RfVehTypeResponse>>>
    {
        private IGenericRepositoryAsync<RfVehType> _rfVehType;
        private readonly IMapper _mapper;

        public RfVehTypesGetFilterQueryHandler(IGenericRepositoryAsync<RfVehType> rfVehType, IMapper mapper)
        {
            _rfVehType = rfVehType;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfVehTypeResponse>>> Handle(RfVehTypesGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfVehType.GetPagedReponseAsync(request);
            var dataVm = _mapper.Map<IEnumerable<RfVehTypeResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfVehTypeResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
