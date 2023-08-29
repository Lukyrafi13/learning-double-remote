using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFJumlahPegawais;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFJumlahPegawais.Queries
{
    public class RFJumlahPegawaisGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFJumlahPegawaiResponseDto>>>
    {
    }

    public class GetFilterRFJumlahPegawaiQueryHandler : IRequestHandler<RFJumlahPegawaisGetFilterQuery, PagedResponse<IEnumerable<RFJumlahPegawaiResponseDto>>>
    {
        private IGenericRepositoryAsync<RFJumlahPegawai> _RFJumlahPegawai;
        private readonly IMapper _mapper;

        public GetFilterRFJumlahPegawaiQueryHandler(IGenericRepositoryAsync<RFJumlahPegawai> RFJumlahPegawai, IMapper mapper)
        {
            _RFJumlahPegawai = RFJumlahPegawai;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFJumlahPegawaiResponseDto>>> Handle(RFJumlahPegawaisGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFJumlahPegawai.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFJumlahPegawaiResponseDto>>(data.Results);
            IEnumerable<RFJumlahPegawaiResponseDto> dataVm;
            var listResponse = new List<RFJumlahPegawaiResponseDto>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<RFJumlahPegawaiResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFJumlahPegawaiResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}