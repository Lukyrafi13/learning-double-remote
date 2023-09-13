using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfCreditNature;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfCreditNatures.Queries.GetFilterRfCreditNatures
{
    public class RfCreditNaturesGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfCreditNatureResponse>>>
    {
    }

    public class RfCreditNaturesGetFilterQueryHandler : IRequestHandler<RfCreditNaturesGetFilterQuery, PagedResponse<IEnumerable<RfCreditNatureResponse>>>
    {
        private IGenericRepositoryAsync<RfCreditNature> _rfCreditNature;
        private readonly IMapper _mapper;

        public RfCreditNaturesGetFilterQueryHandler(IGenericRepositoryAsync<RfCreditNature> rfCreditNature, IMapper mapper)
        {
            _rfCreditNature = rfCreditNature;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfCreditNatureResponse>>> Handle(RfCreditNaturesGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfCreditNature.GetPagedReponseAsync(request);
            var dataVm = _mapper.Map<IEnumerable<RfCreditNatureResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfCreditNatureResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
