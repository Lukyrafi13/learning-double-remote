using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfLoanPurpose;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RfLoanPurposes.Queries.GetFilterRfLoanPurposes
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
