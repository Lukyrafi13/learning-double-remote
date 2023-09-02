using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfSubProduct;
using NewLMS.UMKM.Data.Dto.RfTransportationType;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.MediatR.Features.RfSubProducts.Queries.GetFilterRfSubProducts;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfTransportationTypes.Queries.GetFilterRfTransportationTypes
{
    public class RfTransportationTypesGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfTransportationTypeResponse>>>
    {
    }

    public class RfTransportationTypesGetFilterQueryHandler : IRequestHandler<RfTransportationTypesGetFilterQuery, PagedResponse<IEnumerable<RfTransportationTypeResponse>>>
    {
        private IGenericRepositoryAsync<RfTransportationType> _rfTrasnportationType;
        private readonly IMapper _mapper;

        public RfTransportationTypesGetFilterQueryHandler(IGenericRepositoryAsync<RfTransportationType> rfTransportationType, IMapper mapper)
        {
            _rfTrasnportationType = rfTransportationType;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfTransportationTypeResponse>>> Handle(RfTransportationTypesGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfTrasnportationType.GetPagedReponseAsync(request);
            var dataVm = _mapper.Map<IEnumerable<RfTransportationTypeResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfTransportationTypeResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
