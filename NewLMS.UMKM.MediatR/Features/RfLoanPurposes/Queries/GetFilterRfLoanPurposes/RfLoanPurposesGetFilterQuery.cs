using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfLoanPurpose;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfLoanPurposes.Queries.GetFilterRfLoanPurposes
{
    public class RfLoanPurposesGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfLoanPurposeResponse>>>
    {
    }

    public class RfLoanPurposesGetFilterQueryHandler : IRequestHandler<RfLoanPurposesGetFilterQuery, PagedResponse<IEnumerable<RfLoanPurposeResponse>>>
    {
        private IGenericRepositoryAsync<RfLoanPurpose> _rfLoanPurpose;
        private readonly IMapper _mapper;

        public RfLoanPurposesGetFilterQueryHandler(IGenericRepositoryAsync<RfLoanPurpose> rfLoanPurpose, IMapper mapper)
        {
            _rfLoanPurpose = rfLoanPurpose;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfLoanPurposeResponse>>> Handle(RfLoanPurposesGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfLoanPurpose.GetPagedReponseAsync(request);
            var dataVm = _mapper.Map<IEnumerable<RfLoanPurposeResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfLoanPurposeResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
