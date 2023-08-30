using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RfParameters;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RfParameters.Queries.GetFilterParameters
{
    public class RfParameterGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfParameterResponse>>>
    {
    }

    public class GetFilterRfParameterQueryHandler : IRequestHandler<RfParameterGetFilterQuery, PagedResponse<IEnumerable<RfParameterResponse>>>
    {
        private IGenericRepositoryAsync<RfParameter> _rfParameter;
        private readonly IMapper _mapper;

        public GetFilterRfParameterQueryHandler(IGenericRepositoryAsync<RfParameter> rfParameter, IMapper mapper)
        {
            _rfParameter = rfParameter;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfParameterResponse>>> Handle(RfParameterGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[] {
                    "RfParameterDetails" };
            var data = await _rfParameter.GetPagedReponseAsync(request, includes);
            var dataVm = _mapper.Map<IEnumerable<RfParameterResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfParameterResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
