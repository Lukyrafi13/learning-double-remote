using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.Prospects;
using NewLMS.UMKM.Repository.GenericRepository;
using NewLMS.UMKM.Common.GenericRespository;
using System.Net;
using NewLMS.UMKM.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.Prospects.Queries
{
    public class ProspectsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<ProspectResponseDto>>>
    {
    }

    public class GetFilterProspectQueryHandler : IRequestHandler<ProspectsGetFilterQuery, PagedResponse<IEnumerable<ProspectResponseDto>>>
    {
        private IGenericRepositoryAsync<Prospect> _prospect;
        private readonly IMapper _mapper;

        public GetFilterProspectQueryHandler(IGenericRepositoryAsync<Prospect> prospect, IMapper mapper)
        {
            _prospect = prospect;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<ProspectResponseDto>>> Handle(ProspectsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[] {
                "RfCompanyGroup",
                "RfCompanyStatus",
                "RfCompanyType",
                "RfBranch",
                "RfProduct",
                "RfGender",
                "RfSectorLBU3",
                "RfOwnerCategory",
                "RfZipCode",
                "RfPlaceZipCode",
                "RfCompanyZipCode",
                "RfAppType",
                "RfTargetStatus",
            };
            var data = await _prospect.GetPagedReponseAsync(request, includes);
            // var dataVm = _mapper.Map<IEnumerable<ProspectResponseDto>>(data.Results);
            IEnumerable<ProspectResponseDto> dataVm;
            var listResponse = new List<ProspectResponseDto>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<ProspectResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<ProspectResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}