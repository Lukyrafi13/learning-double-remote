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
//     public class AnalisaInformasiPencairanGetQuery : AnalisaFind, IRequest<ServiceResponse<AnalisaInformasiPencairanResponse>>
//     {
//     }

//     public class AnalisaInformasiPencairanGetQueryHandler : IRequestHandler<AnalisaInformasiPencairanGetQuery, ServiceResponse<AnalisaInformasiPencairanResponse>>
//     {
//         private IGenericRepositoryAsync<Analisa> _Analisa;
//         private readonly IMapper _mapper;

//         public AnalisaInformasiPencairanGetQueryHandler(IGenericRepositoryAsync<Analisa> Analisa, IMapper mapper)
//         {
//             _Analisa = Analisa;
//             _mapper = mapper;
//         }
//         public async Task<ServiceResponse<AnalisaInformasiPencairanResponse>> Handle(AnalisaInformasiPencairanGetQuery request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var includes = new string[]{
//                     "CaraPenarikan",
//                     "PengikatanKredit",
//                     "PolaPengembalianKredit",
//                     "BookingOffice",
//                     "AnalisaFasilitass",
//                     "AnalisaFasilitass.AppFasilitasKredit",
//                 };

//                 var data = await _Analisa.GetByIdAsync(request.Id, "Id", includes);
//                 if (data == null)
//                     return ServiceResponse<AnalisaInformasiPencairanResponse>.Return404("Data Analisa not found");
//                 var response = _mapper.Map<AnalisaInformasiPencairanResponse>(data);
//                 return ServiceResponse<AnalisaInformasiPencairanResponse>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<AnalisaInformasiPencairanResponse>.ReturnException(ex);
//             }
//         }
//     }
// }