using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFKategoris;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFKategoris.Queries
{
    public class RFKategorisGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFKategoriResponseDto>>>
    {
    }

    public class GetFilterRFKategoriQueryHandler : IRequestHandler<RFKategorisGetFilterQuery, PagedResponse<IEnumerable<RFKategoriResponseDto>>>
    {
        private IGenericRepositoryAsync<RFKategori> _RFKategori;
        private readonly IMapper _mapper;

        public GetFilterRFKategoriQueryHandler(IGenericRepositoryAsync<RFKategori> RFKategori, IMapper mapper)
        {
            _RFKategori = RFKategori;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFKategoriResponseDto>>> Handle(RFKategorisGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFKategori.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFKategoriResponseDto>>(data.Results);
            IEnumerable<RFKategoriResponseDto> dataVm;
            var listResponse = new List<RFKategoriResponseDto>();

            foreach (var result in data.Results){
                var response = _mapper.Map<RFKategoriResponseDto>(result);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFKategoriResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}