using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RfParameterDetails;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RfParameterDetails.Queries.GetFilterRfParameterDetails
{
    public class RfParameterDetailGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfParameterDetailResponse>>>
    {
    }

    public class GetFilterRfParameterDetailQueryHandler : IRequestHandler<RfParameterDetailGetFilterQuery, PagedResponse<IEnumerable<RfParameterDetailResponse>>>
    {
        private IGenericRepositoryAsync<RfParameterDetail> _rfParameterDetail;
        private readonly IMapper _mapper;

        public GetFilterRfParameterDetailQueryHandler(IGenericRepositoryAsync<RfParameterDetail> rfParameterDetail, IMapper mapper)
        {
            _rfParameterDetail = rfParameterDetail;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfParameterDetailResponse>>> Handle(RfParameterDetailGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[] { "RfParameter" };
            var data = await _rfParameterDetail.GetPagedReponseAsync(request, includes);
            var dataVm = _mapper.Map<IEnumerable<RfParameterDetailResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfParameterDetailResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
