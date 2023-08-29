// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.Analisas;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;

// namespace NewLMS.UMKM.MediatR.Features.Analisas.Queries
// {
//     public class AnalisaInformasiUsahaGetQuery : AnalisaFind, IRequest<ServiceResponse<AnalisaInformasiUsahaResponse>>
//     {
//     }

//     public class AnalisaInformasiUsahaGetQueryHandler : IRequestHandler<AnalisaInformasiUsahaGetQuery, ServiceResponse<AnalisaInformasiUsahaResponse>>
//     {
//         private IGenericRepositoryAsync<Analisa> _Analisa;
//         private readonly IMapper _mapper;

//         public AnalisaInformasiUsahaGetQueryHandler(IGenericRepositoryAsync<Analisa> Analisa, IMapper mapper)
//         {
//             _Analisa = Analisa;
//             _mapper = mapper;
//         }
//         public async Task<ServiceResponse<AnalisaInformasiUsahaResponse>> Handle(AnalisaInformasiUsahaGetQuery request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var includes = new string[]{
//                     "App",
//                     "Prescreening",
//                     "Survey",
//                     "LokasiUsaha",
//                     "JenisTempatUsaha",
//                     "KelompokBidangUsaha",
//                     "JenisUsaha",
//                     "LokasiTempatUsaha",
//                     "KepemilikanTU",
//                     "BuktiKepemilikan",
//                     "AspekPemasaran",
//                     "JumlahPegawaiTetap",
//                     "JumlahPegawaiHarian",
//                 };

//                 var data = await _Analisa.GetByIdAsync(request.Id, "Id", includes);
//                 if (data == null)
//                     return ServiceResponse<AnalisaInformasiUsahaResponse>.Return404("Data Analisa not found");
//                 var response = _mapper.Map<AnalisaInformasiUsahaResponse>(data);
//                 return ServiceResponse<AnalisaInformasiUsahaResponse>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<AnalisaInformasiUsahaResponse>.ReturnException(ex);
//             }
//         }
//     }
// }