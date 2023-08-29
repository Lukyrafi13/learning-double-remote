using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.Prospects;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.Prospects.Queries
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
                "JenisProduk",
                "TipeDebitur",
                "JenisKelamin",
                "JenisPermohonanKredit",
                "KodePos",
                "Status",
                "SektorEkonomi",
                "SubSektorEkonomi",
                "SubSubSektorEkonomi",
                "Kategori",
                "KodeDinas",
                "Stage",
                "KodePosUsaha",
                "KodePosTempat",
                "KelompokBidangUsaha",
                "JenisUsaha",
                "ProspectStageLogs",
                "ProspectStageLogs.RFStages",
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