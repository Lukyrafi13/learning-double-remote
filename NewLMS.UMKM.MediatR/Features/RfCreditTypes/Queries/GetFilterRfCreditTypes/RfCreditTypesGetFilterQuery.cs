using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfCreditType;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RfCreditTypes.Queries.GetFilterRfCreditTypes
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
