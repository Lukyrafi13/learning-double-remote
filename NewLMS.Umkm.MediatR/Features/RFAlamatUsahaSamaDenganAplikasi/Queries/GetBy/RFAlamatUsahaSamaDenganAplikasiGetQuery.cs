using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFAlamatUsahaSamaDenganAplikasis;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFAlamatUsahaSamaDenganAplikasis.Queries
{
    public class RFAlamatUsahaSamaDenganAplikasiGetQuery : RFAlamatUsahaSamaDenganAplikasiFindRequestDto, IRequest<ServiceResponse<RFAlamatUsahaSamaDenganAplikasiResponseDto>>
    {
    }

    public class RFAlamatUsahaSamaDenganAplikasiGetQueryHandler : IRequestHandler<RFAlamatUsahaSamaDenganAplikasiGetQuery, ServiceResponse<RFAlamatUsahaSamaDenganAplikasiResponseDto>>
    {
        private IGenericRepositoryAsync<AlamatUsahaSamaDenganAplikasi> _RFAlamatUsahaSamaDenganAplikasi;
        private readonly IMapper _mapper;

        public RFAlamatUsahaSamaDenganAplikasiGetQueryHandler(IGenericRepositoryAsync<AlamatUsahaSamaDenganAplikasi> RFAlamatUsahaSamaDenganAplikasi, IMapper mapper)
        {
            _RFAlamatUsahaSamaDenganAplikasi = RFAlamatUsahaSamaDenganAplikasi;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFAlamatUsahaSamaDenganAplikasiResponseDto>> Handle(RFAlamatUsahaSamaDenganAplikasiGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFAlamatUsahaSamaDenganAplikasi.GetByIdAsync(request.StatusAlamat_Code, "StatusAlamat_Code");
                if (data == null)
                    return ServiceResponse<RFAlamatUsahaSamaDenganAplikasiResponseDto>.Return404("Data RFAlamatUsahaSamaDenganAplikasi not found");
                var response = _mapper.Map<RFAlamatUsahaSamaDenganAplikasiResponseDto>(data);
                return ServiceResponse<RFAlamatUsahaSamaDenganAplikasiResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFAlamatUsahaSamaDenganAplikasiResponseDto>.ReturnException(ex);
            }
        }
    }
}