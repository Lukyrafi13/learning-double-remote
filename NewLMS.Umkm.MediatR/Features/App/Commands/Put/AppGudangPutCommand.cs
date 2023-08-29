// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.Apps;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.Apps.Commands
// {
//     public class AppGudangPutCommand : AppGudang, IRequest<ServiceResponse<Unit>>
//     {

//     }
//     public class AppGudangPutCommandHandler : IRequestHandler<AppGudangPutCommand, ServiceResponse<Unit>>
//     {
//         private readonly IGenericRepositoryAsync<App> _app;
//         private readonly IGenericRepositoryAsync<RfZipCode> _zipCode;
//         private readonly IMapper _mapper;

//         public AppGudangPutCommandHandler(
//             IGenericRepositoryAsync<App> app,
//             IGenericRepositoryAsync<RfZipCode> zipCode,
//             IMapper mapper)
//         {
//             _app = app;
//             _zipCode = zipCode;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<Unit>> Handle(AppGudangPutCommand request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var existingApp = await _app.GetByIdAsync(request.Id, "Id");

//                 existingApp.NoResi = request.NoResi;
//                 existingApp.NoSeriResiGudang = request.NoSeriResiGudang;
//                 existingApp.NamaPemilikResi = request.NamaPemilikResi;
//                 existingApp.TglTerbitResi = request.TglTerbitResi;
//                 existingApp.TglJatuhTempoResiGudang = request.TglJatuhTempoResiGudang;
//                 existingApp.JenisBarang = request.JenisBarang;
//                 existingApp.JumlahBarangKg = request.JumlahBarangKg;
//                 existingApp.NilaiBarang = request.NilaiBarang;
//                 existingApp.LokasiGudangPenyimpanan = request.LokasiGudangPenyimpanan;
//                 existingApp.NamaLengkapPengelola = request.NamaLengkapPengelola;
//                 existingApp.NoKTPPengelola = request.NoKTPPengelola;
//                 existingApp.TglLahirPengelola = request.TglLahirPengelola;

//                 await _app.UpdateAsync(existingApp);
//                 return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//             }
//         }
//     }
// }