using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.Analisas;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.Analisas.Queries
{
    public class AnalisaHasilRekomendasiGetQuery : AnalisaFind, IRequest<ServiceResponse<AnalisaHasilRekomendasiResponse>>
    {
    }

    public class AnalisaHasilRekomendasiGetQueryHandler : IRequestHandler<AnalisaHasilRekomendasiGetQuery, ServiceResponse<AnalisaHasilRekomendasiResponse>>
    {
        private IGenericRepositoryAsync<Analisa> _Analisa;
        private IGenericRepositoryAsync<AnalisaPinjamanDariBank> _AnalisaPinjamanDariBank;
        private IGenericRepositoryAsync<AppFasilitasKredit> _AppFasilitasKredit;
        private readonly IMapper _mapper;

        public AnalisaHasilRekomendasiGetQueryHandler(
            IGenericRepositoryAsync<Analisa> Analisa,
            IGenericRepositoryAsync<AnalisaPinjamanDariBank> AnalisaPinjamanDariBank,
            IGenericRepositoryAsync<AppFasilitasKredit> AppFasilitasKredit,
            IMapper mapper)
        {
            _Analisa = Analisa;
            _AnalisaPinjamanDariBank = AnalisaPinjamanDariBank;
            _AppFasilitasKredit = AppFasilitasKredit;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<AnalisaHasilRekomendasiResponse>> Handle(AnalisaHasilRekomendasiGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                    "Survey"
                };

                var data = await _Analisa.GetByIdAsync(request.Id, "Id", includes);
                if (data == null)
                    return ServiceResponse<AnalisaHasilRekomendasiResponse>.Return404("Data Analisa not found");
                var response = _mapper.Map<AnalisaHasilRekomendasiResponse>(data);

                return ServiceResponse<AnalisaHasilRekomendasiResponse>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<AnalisaHasilRekomendasiResponse>.ReturnException(ex);
            }
        }
    }
}