using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfCondition;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfConditions.Queries.GetFilterRfConditions
{
    public class RfConditionsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfConditionResponse>>>
    {
    }

    public class RfConditionsGetFilterQueryHandler : IRequestHandler<RfConditionsGetFilterQuery, PagedResponse<IEnumerable<RfConditionResponse>>>
    {
        private IGenericRepositoryAsync<RfCondition> _rfCondition;
        private readonly IMapper _mapper;

        public RfConditionsGetFilterQueryHandler(IGenericRepositoryAsync<RfCondition> rfCondition, IMapper mapper)
        {
            _rfCondition = rfCondition;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfConditionResponse>>> Handle(RfConditionsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfCondition.GetPagedReponseAsync(request);
            var dataVm = _mapper.Map<IEnumerable<RfConditionResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfConditionResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
