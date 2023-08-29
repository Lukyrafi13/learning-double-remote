using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFJenisUsahaYangDihindaris;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFJenisUsahaYangDihindaris.Queries
{
    public class RFJenisUsahaYangDihindariGetQuery : RFJenisUsahaYangDihindariFindRequestDto, IRequest<ServiceResponse<RFJenisUsahaYangDihindariResponseDto>>
    {
    }

    public class RFJenisUsahaYangDihindariGetQueryHandler : IRequestHandler<RFJenisUsahaYangDihindariGetQuery, ServiceResponse<RFJenisUsahaYangDihindariResponseDto>>
    {
        private IGenericRepositoryAsync<RFJenisUsahaYangDihindari> _RFJenisUsahaYangDihindari;
        private readonly IMapper _mapper;

        public RFJenisUsahaYangDihindariGetQueryHandler(IGenericRepositoryAsync<RFJenisUsahaYangDihindari> RFJenisUsahaYangDihindari, IMapper mapper)
        {
            _RFJenisUsahaYangDihindari = RFJenisUsahaYangDihindari;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFJenisUsahaYangDihindariResponseDto>> Handle(RFJenisUsahaYangDihindariGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFJenisUsahaYangDihindari.GetByIdAsync(request.StatusJenisUsaha_Code, "StatusJenisUsaha_Code");
                if (data == null)
                    return ServiceResponse<RFJenisUsahaYangDihindariResponseDto>.Return404("Data RFJenisUsahaYangDihindari not found");
                var response = _mapper.Map<RFJenisUsahaYangDihindariResponseDto>(data);
                return ServiceResponse<RFJenisUsahaYangDihindariResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFJenisUsahaYangDihindariResponseDto>.ReturnException(ex);
            }
        }
    }
}