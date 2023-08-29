using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFAlamatUsahaSamaDenganAplikasis;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFAlamatUsahaSamaDenganAplikasis.Queries
{
    public class RFAlamatUsahaSamaDenganAplikasisGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFAlamatUsahaSamaDenganAplikasiResponseDto>>>
    {
    }

    public class GetFilterRFAlamatUsahaSamaDenganAplikasiQueryHandler : IRequestHandler<RFAlamatUsahaSamaDenganAplikasisGetFilterQuery, PagedResponse<IEnumerable<RFAlamatUsahaSamaDenganAplikasiResponseDto>>>
    {
        private IGenericRepositoryAsync<AlamatUsahaSamaDenganAplikasi> _RFAlamatUsahaSamaDenganAplikasi;
        private readonly IMapper _mapper;

        public GetFilterRFAlamatUsahaSamaDenganAplikasiQueryHandler(IGenericRepositoryAsync<AlamatUsahaSamaDenganAplikasi> RFAlamatUsahaSamaDenganAplikasi, IMapper mapper)
        {
            _RFAlamatUsahaSamaDenganAplikasi = RFAlamatUsahaSamaDenganAplikasi;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFAlamatUsahaSamaDenganAplikasiResponseDto>>> Handle(RFAlamatUsahaSamaDenganAplikasisGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFAlamatUsahaSamaDenganAplikasi.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFAlamatUsahaSamaDenganAplikasiResponseDto>>(data.Results);
            IEnumerable<RFAlamatUsahaSamaDenganAplikasiResponseDto> dataVm;
            var listResponse = new List<RFAlamatUsahaSamaDenganAplikasiResponseDto>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<RFAlamatUsahaSamaDenganAplikasiResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFAlamatUsahaSamaDenganAplikasiResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}