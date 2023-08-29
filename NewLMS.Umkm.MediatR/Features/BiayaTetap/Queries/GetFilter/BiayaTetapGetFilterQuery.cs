using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.BiayaTetaps;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.BiayaTetaps.Queries
{
    public class BiayaTetapsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<BiayaTetapResponseDto>>>
    {
    }

    public class GetFilterBiayaTetapQueryHandler : IRequestHandler<BiayaTetapsGetFilterQuery, PagedResponse<IEnumerable<BiayaTetapResponseDto>>>
    {
        private IGenericRepositoryAsync<BiayaTetap> _BiayaTetap;
        private readonly IMapper _mapper;

        public GetFilterBiayaTetapQueryHandler(IGenericRepositoryAsync<BiayaTetap> BiayaTetap, IMapper mapper)
        {
            _BiayaTetap = BiayaTetap;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<BiayaTetapResponseDto>>> Handle(BiayaTetapsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _BiayaTetap.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<BiayaTetapResponseDto>>(data.Results);
            IEnumerable<BiayaTetapResponseDto> dataVm;
            var listResponse = new List<BiayaTetapResponseDto>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<BiayaTetapResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<BiayaTetapResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}