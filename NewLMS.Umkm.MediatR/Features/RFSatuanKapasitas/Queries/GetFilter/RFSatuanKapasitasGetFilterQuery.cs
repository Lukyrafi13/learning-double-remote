using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSatuanKapasitass;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFSatuanKapasitass.Queries
{
    public class RFSatuanKapasitassGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFSatuanKapasitasResponseDto>>>
    {
    }

    public class GetFilterRFSatuanKapasitasQueryHandler : IRequestHandler<RFSatuanKapasitassGetFilterQuery, PagedResponse<IEnumerable<RFSatuanKapasitasResponseDto>>>
    {
        private IGenericRepositoryAsync<RFSatuanKapasitas> _RFSatuanKapasitas;
        private readonly IMapper _mapper;

        public GetFilterRFSatuanKapasitasQueryHandler(IGenericRepositoryAsync<RFSatuanKapasitas> RFSatuanKapasitas, IMapper mapper)
        {
            _RFSatuanKapasitas = RFSatuanKapasitas;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFSatuanKapasitasResponseDto>>> Handle(RFSatuanKapasitassGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFSatuanKapasitas.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFSatuanKapasitasResponseDto>>(data.Results);
            IEnumerable<RFSatuanKapasitasResponseDto> dataVm;
            var listResponse = new List<RFSatuanKapasitasResponseDto>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<RFSatuanKapasitasResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFSatuanKapasitasResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}