// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.Apps;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;

// namespace NewLMS.UMKM.MediatR.Features.Apps.Queries
// {
//     public class AppIdeGet : AppFind, IRequest<ServiceResponse<AppIDEPutRequestDtoResponse>>
//     {
//     }

//     public class AppIdeGetQueryHandler : IRequestHandler<AppIdeGet, ServiceResponse<AppIDEPutRequestDtoResponse>>
//     {
//         private IGenericRepositoryAsync<App> _App;
//         private readonly IMapper _mapper;

//         public AppIdeGetQueryHandler(IGenericRepositoryAsync<App> App, IMapper mapper)
//         {
//             _App = App;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<AppIDEPutRequestDtoResponse>> Handle(AppIdeGet request, CancellationToken cancellationToken)
//         {
//             var includes = new string[]{
//                 "JenisProduk",
//                 "TipeDebitur",
//                 "ReputasiTempatTinggal",
//                 "TingkatKebutuhan",
//                 "CaraTransaksi",
//                 "PengelolaKeuangan",
//                 "HutangPihakLain",
//                 "LokTempatUsaha",
//                 "HubunganPerbankan",
//                 "MutasiPerBulan",
//                 "RiwayatKreditBJB",
//                 "ScoringAgunan",
//                 "SaldoRekRata",
//                 "BookingOffice",
//             };

//             var data = await _App.GetByIdAsync(request.Id, "Id", includes);

//             var response = _mapper.Map<AppIDEPutRequestDtoResponse>(data);

//             return ServiceResponse<AppIDEPutRequestDtoResponse>.ReturnResultWith200(response);
//         }
//     }
// }