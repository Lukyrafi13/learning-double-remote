using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFJenisUsahaYangDihindaris;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFJenisUsahaYangDihindaris.Queries
{
    public class RFJenisUsahaYangDihindarisGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFJenisUsahaYangDihindariResponseDto>>>
    {
    }

    public class GetFilterRFJenisUsahaYangDihindariQueryHandler : IRequestHandler<RFJenisUsahaYangDihindarisGetFilterQuery, PagedResponse<IEnumerable<RFJenisUsahaYangDihindariResponseDto>>>
    {
        private IGenericRepositoryAsync<RFJenisUsahaYangDihindari> _RFJenisUsahaYangDihindari;
        private readonly IMapper _mapper;

        public GetFilterRFJenisUsahaYangDihindariQueryHandler(IGenericRepositoryAsync<RFJenisUsahaYangDihindari> RFJenisUsahaYangDihindari, IMapper mapper)
        {
            _RFJenisUsahaYangDihindari = RFJenisUsahaYangDihindari;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFJenisUsahaYangDihindariResponseDto>>> Handle(RFJenisUsahaYangDihindarisGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFJenisUsahaYangDihindari.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFJenisUsahaYangDihindariResponseDto>>(data.Results);
            IEnumerable<RFJenisUsahaYangDihindariResponseDto> dataVm;
            var listResponse = new List<RFJenisUsahaYangDihindariResponseDto>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<RFJenisUsahaYangDihindariResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFJenisUsahaYangDihindariResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}