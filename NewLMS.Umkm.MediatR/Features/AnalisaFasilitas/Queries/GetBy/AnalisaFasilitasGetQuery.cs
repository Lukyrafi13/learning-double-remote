using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.AnalisaFasilitass;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.AnalisaFasilitass.Queries
{
    public class AnalisaFasilitasGetQuery : AnalisaFasilitasFindRequestDto, IRequest<ServiceResponse<AnalisaFasilitasResponseDto>>
    {
    }

    public class AnalisaFasilitasGetQueryHandler : IRequestHandler<AnalisaFasilitasGetQuery, ServiceResponse<AnalisaFasilitasResponseDto>>
    {
        private IGenericRepositoryAsync<AnalisaFasilitas> _AnalisaFasilitas;
        private readonly IMapper _mapper;

        public AnalisaFasilitasGetQueryHandler(IGenericRepositoryAsync<AnalisaFasilitas> AnalisaFasilitas, IMapper mapper)
        {
            _AnalisaFasilitas = AnalisaFasilitas;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<AnalisaFasilitasResponseDto>> Handle(AnalisaFasilitasGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                    "Analisa",
                    "Analisa.Survey",
                    "JangkaWaktu",
                    "SkimKredit",
                };

                var data = await _AnalisaFasilitas.GetByIdAsync(request.Id, "Id", includes);
                if (data == null)
                    return ServiceResponse<AnalisaFasilitasResponseDto>.Return404("Data AnalisaFasilitas not found");
                var response = _mapper.Map<AnalisaFasilitasResponseDto>(data);
                
                return ServiceResponse<AnalisaFasilitasResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<AnalisaFasilitasResponseDto>.ReturnException(ex);
            }
        }
    }
}