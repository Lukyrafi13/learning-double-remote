// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.AnalisaSandiOJKs;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;

// namespace NewLMS.UMKM.MediatR.Features.AnalisaSandiOJKs.Queries
// {
//     public class AnalisaSandiOJKGetQuery : AnalisaSandiOJKFindRequestDto, IRequest<ServiceResponse<AnalisaSandiOJKResponseDto>>
//     {
//     }

//     public class AnalisaSandiOJKGetQueryHandler : IRequestHandler<AnalisaSandiOJKGetQuery, ServiceResponse<AnalisaSandiOJKResponseDto>>
//     {
//         private IGenericRepositoryAsync<AnalisaSandiOJK> _AnalisaSandiOJK;
//         private readonly IMapper _mapper;

//         public AnalisaSandiOJKGetQueryHandler(IGenericRepositoryAsync<AnalisaSandiOJK> AnalisaSandiOJK, IMapper mapper)
//         {
//             _AnalisaSandiOJK = AnalisaSandiOJK;
//             _mapper = mapper;
//         }
//         public async Task<ServiceResponse<AnalisaSandiOJKResponseDto>> Handle(AnalisaSandiOJKGetQuery request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var includes = new string[]{
//                     "Analisa",
//                     "Analisa.Survey",
//                     "AppFasilitasKredit",
//                     "GolonganDebitur",
//                     "HubunganDenganBank",
//                     "StatusDebitur",
//                     "KategoriDebitur",
//                     "KategoriPortofolio",
//                     "LembagaPemerikatan",
//                     "JenisKredit",
//                     "SifatKredit",
//                     "JenisPenggunaan",
//                     "TakeOver",
//                     "OrientasiPenggunaan",
//                     "KategoriKredit",
//                     "JenisSukuBunga",
//                     "LokasiProyek",
//                     "JenisAgunan",
//                     "SifatAgunan",
//                     "JenisValuta",
//                     "PenerbitAgunan",
//                     "PeringkatPenerbitAgunan",
//                     "StatusAgunan",
//                     "SkimPembiayaan",
//                     "KreditProgramPemerintah",
//                     "SumberDana",
//                 };

//                 var data = await _AnalisaSandiOJK.GetByIdAsync(request.Id, "Id", includes);
//                 if (data == null)
//                     return ServiceResponse<AnalisaSandiOJKResponseDto>.Return404("Data AnalisaSandiOJK not found");
//                 var response = _mapper.Map<AnalisaSandiOJKResponseDto>(data);
//                 return ServiceResponse<AnalisaSandiOJKResponseDto>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<AnalisaSandiOJKResponseDto>.ReturnException(ex);
//             }
//         }
//     }
// }