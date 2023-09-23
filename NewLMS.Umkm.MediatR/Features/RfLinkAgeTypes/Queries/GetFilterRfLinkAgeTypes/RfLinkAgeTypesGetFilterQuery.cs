using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfLinkAgeType;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RfLinkAgeTypes.Queries.GetFilterRfLinkAgeTypes
{
    public class RfLinkAgeTypesGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfLinkAgeTypeResponse>>>
    {
    }

    public class RfLinkAgeTypesGetFilterQueryHandler : IRequestHandler<RfLinkAgeTypesGetFilterQuery, PagedResponse<IEnumerable<RfLinkAgeTypeResponse>>>
    {
        private IGenericRepositoryAsync<RfLinkAgeType> _rfLinkAge;
        private readonly IMapper _mapper;

        public RfLinkAgeTypesGetFilterQueryHandler(IGenericRepositoryAsync<RfLinkAgeType> rfLinkAge, IMapper mapper)
        {
            _rfLinkAge = rfLinkAge;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfLinkAgeTypeResponse>>> Handle(RfLinkAgeTypesGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfLinkAge.GetPagedReponseAsync(request);
            var dataVm = _mapper.Map<IEnumerable<RfLinkAgeTypeResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfLinkAgeTypeResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
