using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfParameterDetail;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfParameterDetails.Queries.GetFilterRfParameterDetails
{
    public class RfParameterDetailsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfParameterDetailResponse>>>
    {
    }

    public class RfParameterDetailsGetFilterQueryHandler : IRequestHandler<RfParameterDetailsGetFilterQuery, PagedResponse<IEnumerable<RfParameterDetailResponse>>>
    {
        private IGenericRepositoryAsync<RfParameterDetail> _rfParameterDetail;
        private readonly IMapper _mapper;

        public RfParameterDetailsGetFilterQueryHandler(IGenericRepositoryAsync<RfParameterDetail> rfParameterDetail, IMapper mapper)
        {
            _rfParameterDetail = rfParameterDetail;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfParameterDetailResponse>>> Handle(RfParameterDetailsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfParameterDetail.GetPagedReponseAsync(request);
            var dataVm = _mapper.Map<IEnumerable<RfParameterDetailResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfParameterDetailResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
