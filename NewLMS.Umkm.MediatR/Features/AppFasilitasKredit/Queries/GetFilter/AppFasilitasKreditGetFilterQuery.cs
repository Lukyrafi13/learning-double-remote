using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.AppFasilitasKredits;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.AppFasilitasKredits.Queries
{
    public class AppFasilitasKreditsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<AppFasilitasKreditResponseDto>>>
    {
    }

    public class GetFilterAppFasilitasKreditQueryHandler : IRequestHandler<AppFasilitasKreditsGetFilterQuery, PagedResponse<IEnumerable<AppFasilitasKreditResponseDto>>>
    {
        private IGenericRepositoryAsync<AppFasilitasKredit> _AppFasilitasKredit;
        private IGenericRepositoryAsync<AnalisaSandiOJK> _AnalisaSandiOJK;
        private IGenericRepositoryAsync<AnalisaFasilitas> _AnalisaFasilitas;
        private readonly IMapper _mapper;

        public GetFilterAppFasilitasKreditQueryHandler(
            IGenericRepositoryAsync<AppFasilitasKredit> AppFasilitasKredit,
            IGenericRepositoryAsync<AnalisaSandiOJK> AnalisaSandiOJK,
            IGenericRepositoryAsync<AnalisaFasilitas> AnalisaFasilitas,
            IMapper mapper)
        {
            _AppFasilitasKredit = AppFasilitasKredit;
            _AnalisaSandiOJK = AnalisaSandiOJK;
            _AnalisaFasilitas = AnalisaFasilitas;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<AppFasilitasKreditResponseDto>>> Handle(AppFasilitasKreditsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
                "App",
                "JenisPermohonanKredit",
                "TujuanKredit",
                "LoanType",
                "NegaraPenempatan",
                "TenorKredit",
                "SifatKredit",
                "SektorEkonomiLBU",
                "SubSektorEkonomiLBU",
                "SubSubSektorEkonomiLBU",
            };

            var data = await _AppFasilitasKredit.GetPagedReponseAsync(request, includes);
            // var dataVm = _mapper.Map<IEnumerable<AppFasilitasKreditResponseDto>>(data.Results);
            IEnumerable<AppFasilitasKreditResponseDto> dataVm;
            var listResponse = new List<AppFasilitasKreditResponseDto>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<AppFasilitasKreditResponseDto>(res);

                listResponse.Add(response);

                // Check if there's an analisa fasilitas
                var analisaFasilitas = await _AnalisaFasilitas.GetByIdAsync(response.Id, "AppFasilitasKreditId",  new string[] {"JangkaWaktu", "SkimKredit"});

                if (analisaFasilitas != null)
                {
                    response.AnalisaFasilitas = analisaFasilitas;
                }

                // Check if there's an analisa sandi ojk
                var AnalisaSandiOJK = await _AnalisaSandiOJK.GetByIdAsync(response.Id, "AppFasilitasKreditId");

                if (AnalisaSandiOJK != null)
                {
                    response.AnalisaSandiOJK = AnalisaSandiOJK;
                }

            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<AppFasilitasKreditResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}