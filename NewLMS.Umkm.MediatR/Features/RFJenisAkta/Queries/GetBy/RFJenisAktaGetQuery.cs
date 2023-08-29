using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFJenisAktas;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFJenisAktas.Queries
{
    public class RFJenisAktaGetQuery : RFJenisAktaFindRequestDto, IRequest<ServiceResponse<RFJenisAktaResponseDto>>
    {
    }

    public class RFJenisAktaGetQueryHandler : IRequestHandler<RFJenisAktaGetQuery, ServiceResponse<RFJenisAktaResponseDto>>
    {
        private IGenericRepositoryAsync<RFJenisAkta> _RFJenisAkta;
        private readonly IMapper _mapper;

        public RFJenisAktaGetQueryHandler(IGenericRepositoryAsync<RFJenisAkta> RFJenisAkta, IMapper mapper)
        {
            _RFJenisAkta = RFJenisAkta;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFJenisAktaResponseDto>> Handle(RFJenisAktaGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                };

                var data = await _RFJenisAkta.GetByIdAsync(request.AktaCode, "AktaCode");
                if (data == null)
                    return ServiceResponse<RFJenisAktaResponseDto>.Return404("Data RFJenisAkta not found");
                var response = _mapper.Map<RFJenisAktaResponseDto>(data);
                return ServiceResponse<RFJenisAktaResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFJenisAktaResponseDto>.ReturnException(ex);
            }
        }
    }
}