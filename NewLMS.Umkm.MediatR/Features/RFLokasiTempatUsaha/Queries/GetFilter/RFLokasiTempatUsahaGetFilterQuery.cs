using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFLokasiTempatUsahas;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFLokasiTempatUsahas.Queries
{
    public class RFLokasiTempatUsahasGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFLokasiTempatUsahaResponseDto>>>
    {
    }

    public class GetFilterRFLokasiTempatUsahaQueryHandler : IRequestHandler<RFLokasiTempatUsahasGetFilterQuery, PagedResponse<IEnumerable<RFLokasiTempatUsahaResponseDto>>>
    {
        private IGenericRepositoryAsync<RFLokasiTempatUsaha> _RFLokasiTempatUsaha;
        private readonly IMapper _mapper;

        public GetFilterRFLokasiTempatUsahaQueryHandler(IGenericRepositoryAsync<RFLokasiTempatUsaha> RFLokasiTempatUsaha, IMapper mapper)
        {
            _RFLokasiTempatUsaha = RFLokasiTempatUsaha;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFLokasiTempatUsahaResponseDto>>> Handle(RFLokasiTempatUsahasGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFLokasiTempatUsaha.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFLokasiTempatUsahaResponseDto>>(data.Results);
            IEnumerable<RFLokasiTempatUsahaResponseDto> dataVm;
            var listResponse = new List<RFLokasiTempatUsahaResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFLokasiTempatUsahaResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFLokasiTempatUsahaResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}