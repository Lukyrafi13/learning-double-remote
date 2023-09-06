using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfCreditType;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfCreditTypes.Queries.GetFilterRfCreditTypes
{
    public class RfCreditTypesGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfCreditTypeResponse>>>
    {
    }

    public class RfCreditTypesGetFilterQueryHandler : IRequestHandler<RfCreditTypesGetFilterQuery, PagedResponse<IEnumerable<RfCreditTypeResponse>>>
    {
        private IGenericRepositoryAsync<RfCreditType> _rfCreditType;
        private readonly IMapper _mapper;

        public RfCreditTypesGetFilterQueryHandler(IGenericRepositoryAsync<RfCreditType> rfCondition, IMapper mapper)
        {
            _rfCreditType = rfCondition;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfCreditTypeResponse>>> Handle(RfCreditTypesGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfCreditType.GetPagedReponseAsync(request);
            var dataVm = _mapper.Map<IEnumerable<RfCreditTypeResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfCreditTypeResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
