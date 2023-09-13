using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfBusinessType;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfBusinessTypes.Queries.GetFilterRfBusinessTypes
{
    public class RfBusinessTypeGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfBusinessTypeResponse>>>
    {
    }

    public class RfBusinessTypeGetFilterQueryHandler : IRequestHandler<RfBusinessTypeGetFilterQuery, PagedResponse<IEnumerable<RfBusinessTypeResponse>>>
    {
        private IGenericRepositoryAsync<RfBusinessType> _rfBusinessType;
        private readonly IMapper _mapper;

        public RfBusinessTypeGetFilterQueryHandler(IGenericRepositoryAsync<RfBusinessType> rfBusinessType, IMapper mapper)
        {
            _rfBusinessType = rfBusinessType;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfBusinessTypeResponse>>> Handle(RfBusinessTypeGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfBusinessType.GetPagedReponseAsync(request);
            var dataVm = _mapper.Map<IEnumerable<RfBusinessTypeResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfBusinessTypeResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
