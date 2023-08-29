using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFJenisLinkAges;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFJenisLinkAges.Queries
{
    public class RFJenisLinkAgesGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFJenisLinkAgeResponseDto>>>
    {
    }

    public class RFJenisLinkAgesGetFilterQueryHandler : IRequestHandler<RFJenisLinkAgesGetFilterQuery, PagedResponse<IEnumerable<RFJenisLinkAgeResponseDto>>>
    {
        private IGenericRepositoryAsync<RFJenisLinkAge> _RFJenisLinkAge;
        private readonly IMapper _mapper;

        public RFJenisLinkAgesGetFilterQueryHandler(IGenericRepositoryAsync<RFJenisLinkAge> RFJenisLinkAge, IMapper mapper)
        {
            _RFJenisLinkAge = RFJenisLinkAge;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFJenisLinkAgeResponseDto>>> Handle(RFJenisLinkAgesGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
            };

            var data = await _RFJenisLinkAge.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFJenisLinkAgeResponseDto>>(data.Results);
            IEnumerable<RFJenisLinkAgeResponseDto> dataVm;
            var listResponse = new List<RFJenisLinkAgeResponseDto>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<RFJenisLinkAgeResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFJenisLinkAgeResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}