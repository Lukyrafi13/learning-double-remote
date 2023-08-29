using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFCaraPengikatans;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFCaraPengikatans.Queries
{
    public class RFCaraPengikatansGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFCaraPengikatanResponseDto>>>
    {
    }

    public class GetFilterRFCaraPengikatanQueryHandler : IRequestHandler<RFCaraPengikatansGetFilterQuery, PagedResponse<IEnumerable<RFCaraPengikatanResponseDto>>>
    {
        private IGenericRepositoryAsync<RFCaraPengikatan> _RFCaraPengikatan;
        private readonly IMapper _mapper;

        public GetFilterRFCaraPengikatanQueryHandler(IGenericRepositoryAsync<RFCaraPengikatan> RFCaraPengikatan, IMapper mapper)
        {
            _RFCaraPengikatan = RFCaraPengikatan;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFCaraPengikatanResponseDto>>> Handle(RFCaraPengikatansGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFCaraPengikatan.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFCaraPengikatanResponseDto>>(data.Results);
            IEnumerable<RFCaraPengikatanResponseDto> dataVm;
            var listResponse = new List<RFCaraPengikatanResponseDto>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<RFCaraPengikatanResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFCaraPengikatanResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}