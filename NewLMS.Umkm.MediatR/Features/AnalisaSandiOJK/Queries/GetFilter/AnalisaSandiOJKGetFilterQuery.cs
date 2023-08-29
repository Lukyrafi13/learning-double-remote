// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.AnalisaSandiOJKs;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System.Threading;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Common.GenericRespository;
// using System.Collections.Generic;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.AnalisaSandiOJKs.Queries
// {
//     public class AnalisaSandiOJKsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<AnalisaSandiOJKResponseDto>>>
//     {
//     }

//     public class GetFilterAnalisaSandiOJKQueryHandler : IRequestHandler<AnalisaSandiOJKsGetFilterQuery, PagedResponse<IEnumerable<AnalisaSandiOJKResponseDto>>>
//     {
//         private IGenericRepositoryAsync<AnalisaSandiOJK> _AnalisaSandiOJK;
//         private readonly IMapper _mapper;

//         public GetFilterAnalisaSandiOJKQueryHandler(IGenericRepositoryAsync<AnalisaSandiOJK> AnalisaSandiOJK, IMapper mapper)
//         {
//             _AnalisaSandiOJK = AnalisaSandiOJK;
//             _mapper = mapper;
//         }

//         public async Task<PagedResponse<IEnumerable<AnalisaSandiOJKResponseDto>>> Handle(AnalisaSandiOJKsGetFilterQuery request, CancellationToken cancellationToken)
//         {
//             var includes = new string[]{
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

//             var data = await _AnalisaSandiOJK.GetPagedReponseAsync(request, includes);
//             // var dataVm = _mapper.Map<IEnumerable<AnalisaSandiOJKResponseDto>>(data.Results);
//             IEnumerable<AnalisaSandiOJKResponseDto> dataVm;
//             var listResponse = new List<AnalisaSandiOJKResponseDto>();

//             foreach (var res in data.Results){
//                 var response = _mapper.Map<AnalisaSandiOJKResponseDto>(res);

//                 listResponse.Add(response);
//             }

//             dataVm = listResponse.ToArray();
//             return new PagedResponse<IEnumerable<AnalisaSandiOJKResponseDto>>(dataVm, data.Info, request.Page, request.Length)
//             {
//                 StatusCode = (int)HttpStatusCode.OK
//             };
//         }
//     }
// }