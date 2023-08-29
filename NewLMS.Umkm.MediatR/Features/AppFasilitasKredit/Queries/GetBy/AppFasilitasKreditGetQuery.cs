
// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.AppFasilitasKredits;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;

// namespace NewLMS.UMKM.MediatR.Features.AppFasilitasKredits.Queries
// {
//     public class AppFasilitasKreditGetQuery : AppFasilitasKreditFindRequestDto, IRequest<ServiceResponse<AppFasilitasKreditResponseDto>>
//     {
//     }

//     public class AppFasilitasKreditGetQueryHandler : IRequestHandler<AppFasilitasKreditGetQuery, ServiceResponse<AppFasilitasKreditResponseDto>>
//     {
//         private IGenericRepositoryAsync<AppFasilitasKredit> _AppFasilitasKredit;
//         private IGenericRepositoryAsync<AnalisaFasilitas> _AnalisaFasilitas;
//         private IGenericRepositoryAsync<AnalisaSandiOJK> _AnalisaSandiOJK;
//         private readonly IMapper _mapper;

//         public AppFasilitasKreditGetQueryHandler(
//             IGenericRepositoryAsync<AppFasilitasKredit> AppFasilitasKredit,
//             IGenericRepositoryAsync<AnalisaFasilitas> AnalisaFasilitas,
//             IGenericRepositoryAsync<AnalisaSandiOJK> AnalisaSandiOJK,
//             IMapper mapper)
//         {
//             _AppFasilitasKredit = AppFasilitasKredit;
//             _AnalisaFasilitas = AnalisaFasilitas;
//             _AnalisaSandiOJK = AnalisaSandiOJK;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<AppFasilitasKreditResponseDto>> Handle(AppFasilitasKreditGetQuery request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var includes = new string[]{
//                     "App",
//                     "JenisPermohonanKredit",
//                     "TujuanKredit",
//                     "LoanType",
//                     "NegaraPenempatan",
//                     "TenorKredit",
//                     "SifatKredit",
//                     "SektorEkonomiLBU",
//                     "SubSektorEkonomiLBU",
//                     "SubSubSektorEkonomiLBU",
//                 };

//                 var data = await _AppFasilitasKredit.GetByIdAsync(request.Id, "Id", includes);
//                 if (data == null)
//                     return ServiceResponse<AppFasilitasKreditResponseDto>.Return404("Data AppFasilitasKredit not found");
//                 var response = _mapper.Map<AppFasilitasKreditResponseDto>(data);

//                 // Check if there's an analisa fasilitas
//                 var analisaFasilitas = await _AnalisaFasilitas.GetByIdAsync(response.Id, "AppFasilitasKreditId", new string[] {"JangkaWaktu", "SkimKredit"});

//                 if (analisaFasilitas != null){
//                     response.AnalisaFasilitas = analisaFasilitas;
//                 }

//                 // Check if there's an analisa sandi ojk
//                 var AnalisaSandiOJK = await _AnalisaSandiOJK.GetByIdAsync(response.Id, "AppFasilitasKreditId");

//                 if (AnalisaSandiOJK != null){
//                     response.AnalisaSandiOJK = AnalisaSandiOJK;
//                 }

//                 return ServiceResponse<AppFasilitasKreditResponseDto>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<AppFasilitasKreditResponseDto>.ReturnException(ex);
//             }
//         }
//     }
// }