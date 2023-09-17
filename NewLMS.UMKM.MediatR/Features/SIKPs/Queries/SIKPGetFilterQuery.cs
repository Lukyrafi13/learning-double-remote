using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.SIKPs;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.SIKPs.Queries
{
    public class GetParameterByNameQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<SIKPTableResponse>>>
    {
    }

    public class SIKPGetFilterQueryHandler : IRequestHandler<GetParameterByNameQuery, PagedResponse<IEnumerable<SIKPTableResponse>>>
    {
        private IGenericRepositoryAsync<Data.Entities.SIKP> _sikp;
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
            var data = await _sikp.GetPagedReponseAsync(request, includes);
            var dataVm = _mapper.Map<IEnumerable<SIKPTableResponse>>(data.Results);
            return new PagedResponse<IEnumerable<SIKPTableResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
