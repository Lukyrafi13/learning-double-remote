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
    public class AnalisaHasilRekomendasiSiklusGetQuery : AnalisaFind, IRequest<ServiceResponse<AnalisaHasilRekomendasiSiklusResponse>>
    {
    }

    public class AnalisaHasilRekomendasiSiklusGetQueryHandler : IRequestHandler<AnalisaHasilRekomendasiSiklusGetQuery, ServiceResponse<AnalisaHasilRekomendasiSiklusResponse>>
    {
        private IGenericRepositoryAsync<Analisa> _Analisa;
        private IGenericRepositoryAsync<AnalisaPinjamanDariBank> _AnalisaPinjamanDariBank;
        private IGenericRepositoryAsync<AppFasilitasKredit> _AppFasilitasKredit;
        private readonly IMapper _mapper;

        public AnalisaHasilRekomendasiSiklusGetQueryHandler(
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
        public async Task<ServiceResponse<AnalisaHasilRekomendasiSiklusResponse>> Handle(AnalisaHasilRekomendasiSiklusGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                    "Survey",
                    "Survey.ArusKasMasuks",
                    "Survey.BiayaInvestasis",
                    "Survey.BiayaTetaps",
                    "Survey.BiayaVariabels",
                    "Survey.BiayaVariabelTenagaKerjas",
                };

                var data = await _Analisa.GetByIdAsync(request.Id, "Id", includes);
                if (data == null)
                    return ServiceResponse<AnalisaHasilRekomendasiSiklusResponse>.Return404("Data Analisa not found");
                var response = _mapper.Map<AnalisaHasilRekomendasiSiklusResponse>(data);

                return ServiceResponse<AnalisaHasilRekomendasiSiklusResponse>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                var response = ServiceResponse<AnalisaHasilRekomendasiSiklusResponse>.ReturnException(ex);
                response.Success = false;
                return response;
            }
        }
    }
}