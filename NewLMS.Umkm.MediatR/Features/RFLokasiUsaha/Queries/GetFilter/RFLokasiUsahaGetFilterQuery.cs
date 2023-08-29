using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFLokasiUsahas;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFLokasiUsahas.Queries
{
    public class RFLokasiUsahasGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFLokasiUsahaResponseDto>>>
    {
    }

    public class GetFilterRFLokasiUsahaQueryHandler : IRequestHandler<RFLokasiUsahasGetFilterQuery, PagedResponse<IEnumerable<RFLokasiUsahaResponseDto>>>
    {
        private IGenericRepositoryAsync<RFLokasiUsaha> _RFLokasiUsaha;
        private readonly IMapper _mapper;

        public GetFilterRFLokasiUsahaQueryHandler(IGenericRepositoryAsync<RFLokasiUsaha> RFLokasiUsaha, IMapper mapper)
        {
            _RFLokasiUsaha = RFLokasiUsaha;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFLokasiUsahaResponseDto>>> Handle(RFLokasiUsahasGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFLokasiUsaha.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFLokasiUsahaResponseDto>>(data.Results);
            IEnumerable<RFLokasiUsahaResponseDto> dataVm;
            var listResponse = new List<RFLokasiUsahaResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFLokasiUsahaResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFLokasiUsahaResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}