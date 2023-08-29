using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFKategoris;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFKategoris.Queries
{
    public class RFKategorisGetByKategoriCodeQuery : RFKategoriFindRequestDto, IRequest<ServiceResponse<RFKategoriResponseDto>>
    {
    }

    public class GetByIdRFKategoriQueryHandler : IRequestHandler<RFKategorisGetByKategoriCodeQuery, ServiceResponse<RFKategoriResponseDto>>
    {
        private IGenericRepositoryAsync<RFKategori> _RFKategori;
        private readonly IMapper _mapper;

        public GetByIdRFKategoriQueryHandler(IGenericRepositoryAsync<RFKategori> RFKategori, IMapper mapper)
        {
            _RFKategori = RFKategori;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFKategoriResponseDto>> Handle(RFKategorisGetByKategoriCodeQuery request, CancellationToken cancellationToken)
        {

            var data = await _RFKategori.GetByIdAsync(request.KategoriCode, "KategoriCode");

            var response = _mapper.Map<RFKategoriResponseDto>(data);
            
            return ServiceResponse<RFKategoriResponseDto>.ReturnResultWith200(response);
        }
    }
}