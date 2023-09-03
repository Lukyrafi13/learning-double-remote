using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.Prospects;
using NewLMS.UMKM.Repository.GenericRepository;
using NewLMS.UMKM.Common.GenericRespository;
using System.Net;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.MediatR.Features.Prospects.Queries
{
    public class ProspectsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<ProspectTableResponse>>>
    {
    }

    public class GetFilterProspectQueryHandler : IRequestHandler<ProspectsGetFilterQuery, PagedResponse<IEnumerable<ProspectTableResponse>>>
    {
        private IGenericRepositoryAsync<Prospect> _prospect;
        private readonly IMapper _mapper;

        public GetFilterProspectQueryHandler(IGenericRepositoryAsync<Prospect> prospect, IMapper mapper)
        {
            _prospect = prospect;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<ProspectTableResponse>>> Handle(ProspectsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[] {
                "RfProduct"
            };
            var data = await _prospect.GetPagedReponseAsync(request, includes);
            // var dataVm = _mapper.Map<IEnumerable<TableProspectResponse>>(data.Results);
            IEnumerable<ProspectTableResponse> dataVm;
            var listResponse = new List<ProspectTableResponse>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<ProspectTableResponse>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<ProspectTableResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}