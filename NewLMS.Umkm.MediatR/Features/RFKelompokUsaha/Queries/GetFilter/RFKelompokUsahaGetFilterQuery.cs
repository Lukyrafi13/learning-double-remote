using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFKelompokUsahas;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFKelompokUsahas.Queries
{
    public class RFKelompokUsahasGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFKelompokUsahaResponseDto>>>
    {
    }

    public class GetFilterRFKelompokUsahaQueryHandler : IRequestHandler<RFKelompokUsahasGetFilterQuery, PagedResponse<IEnumerable<RFKelompokUsahaResponseDto>>>
    {
        private IGenericRepositoryAsync<RFKelompokUsaha> _RFKelompokUsaha;
        private readonly IMapper _mapper;

        public GetFilterRFKelompokUsahaQueryHandler(IGenericRepositoryAsync<RFKelompokUsaha> RFKelompokUsaha, IMapper mapper)
        {
            _RFKelompokUsaha = RFKelompokUsaha;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFKelompokUsahaResponseDto>>> Handle(RFKelompokUsahasGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFKelompokUsaha.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFKelompokUsahaResponseDto>>(data.Results);
            IEnumerable<RFKelompokUsahaResponseDto> dataVm;
            var listResponse = new List<RFKelompokUsahaResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFKelompokUsahaResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFKelompokUsahaResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}