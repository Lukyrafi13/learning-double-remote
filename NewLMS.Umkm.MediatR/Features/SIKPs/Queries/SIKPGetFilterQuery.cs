using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.SIKPs;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.SIKPs.Queries
{
    public class GetParameterByNameQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<SIKPTableResponse>>>
    {
    }

    public class SIKPGetFilterQueryHandler : IRequestHandler<GetParameterByNameQuery, PagedResponse<IEnumerable<SIKPTableResponse>>>
    {
        private readonly IGenericRepositoryAsync<Data.Entities.SIKP> _sikp;
        private readonly IMapper _mapper;

        public SIKPGetFilterQueryHandler(IMapper mapper, IGenericRepositoryAsync<Data.Entities.SIKP> sikp)
        {
            _mapper = mapper;
            _sikp = sikp;
        }

        public async Task<PagedResponse<IEnumerable<SIKPTableResponse>>> Handle(GetParameterByNameQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]
                {
                    "SIKPRequest",
                    "LoanApplication"
                };
            request.Filters.Add(new RequestFilterParameter
            {
                Field = "Status",
                Type = "int",
                ComparisonOperator = "=",
                Value = "0"
            });

            var data = await _sikp.GetPagedReponseAsync(request, includes);
            var dataVm = _mapper.Map<IEnumerable<SIKPTableResponse>>(data.Results);
            return new PagedResponse<IEnumerable<SIKPTableResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
