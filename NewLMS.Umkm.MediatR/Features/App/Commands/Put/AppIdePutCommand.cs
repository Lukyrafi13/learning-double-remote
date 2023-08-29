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
// using System.Collections.Generic;

// namespace NewLMS.UMKM.MediatR.Features.Apps.Commands
// {
//     public class AppIDEPutCommand : AppIDEPutRequestDto, IRequest<ServiceResponse<Unit>>
//     {

//     }
//     public class AppIDEPutCommandHandler : IRequestHandler<AppIDEPutCommand, ServiceResponse<Unit>>
//     {
//         private readonly IGenericRepositoryAsync<App> _app;
//         private readonly IGenericRepositoryAsync<AppFasilitasKredit> _AppFasilitasKredit;
//         private readonly IGenericRepositoryAsync<RFSiklusUsahaPokok> _RFSiklusUsahaPokok;
//         private readonly IMapper _mapper;

//         public AppIDEPutCommandHandler(
//             IGenericRepositoryAsync<App> app,
//             IGenericRepositoryAsync<AppFasilitasKredit> AppFasilitasKredit,
//             IGenericRepositoryAsync<RFSiklusUsahaPokok> RFSiklusUsahaPokok,
//             IMapper mapper)
//         {
//             _app = app;
//             _AppFasilitasKredit = AppFasilitasKredit;
//             _RFSiklusUsahaPokok = RFSiklusUsahaPokok;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<Unit>> Handle(AppIDEPutCommand request, CancellationToken cancellationToken)
//         {

//             try
//             {
//                 var existingApp = await _app.GetByIdAsync(request.Id, "Id");

//                 var siklusChanged = existingApp.RFSiklusUsahaPokokId != request.RFSiklusUsahaPokokId;

//                 existingApp.RfProductId = request.RfProductId;
//                 existingApp.RfOwnerCategoryId = request.RfOwnerCategoryId;
//                 existingApp.SiklusUsaha = request.SiklusUsaha;
//                 existingApp.RFSCOReputasiTempatTinggalId = request.RFSCOReputasiTempatTinggalId;
//                 existingApp.RFSCOTingkatKebutuhanId = request.RFSCOTingkatKebutuhanId;
//                 existingApp.RFSCOCaraTransaksiId = request.RFSCOCaraTransaksiId;
//                 existingApp.RFSCOPengelolaKeuanganId = request.RFSCOPengelolaKeuanganId;
//                 existingApp.RFSCOHutangPihakLainId = request.RFSCOHutangPihakLainId;
//                 existingApp.RFSCOLokTempatUsahaId = request.RFSCOLokTempatUsahaId;
//                 existingApp.RFSCOHubunganPerbankanId = request.RFSCOHubunganPerbankanId;
//                 existingApp.RFSCOMutasiPerBulanId = request.RFSCOMutasiPerBulanId;
//                 existingApp.RFSCORiwayatKreditBJBId = request.RFSCORiwayatKreditBJBId;
//                 existingApp.RFSCOScoringAgunanId = request.RFSCOScoringAgunanId;
//                 existingApp.RFSCOSaldoRekRataId = request.RFSCOSaldoRekRataId;
//                 existingApp.RfBranchesId = request.RFBranchesId;
//                 existingApp.SiklusUsahaMonth = request.SiklusUsahaMonth;
//                 existingApp.RFSiklusUsahaPokokId = request.RFSiklusUsahaPokokId;
                
//                 if (request.RFSiklusUsahaPokokId == null && (request.SiklusUsaha??false)){
//                     return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, "RF Siklus Usaha dengan Id "+ request.RFSiklusUsahaPokokId+" tidak ditemukan");
//                 }
                
//                 RFSiklusUsahaPokok siklusUsahaPokok = request.RFSiklusUsahaPokokId==null ? null : await _RFSiklusUsahaPokok.GetByIdAsync((Guid)request.RFSiklusUsahaPokokId, "Id");

//                 if (siklusChanged){

//                     var updateListFasilitas = new List<AppFasilitasKredit>();

//                     var sameDateNextMonth = new DateTime(existingApp.CreatedDate.Year, existingApp.CreatedDate.Month+1, existingApp.CreatedDate.Day ); 
//                     var diffDays = Math.Abs((existingApp.CreatedDate - sameDateNextMonth).Days);
//                     var siklusUsahaAkhir = siklusUsahaPokok?.SiklusCode == "02";
//                     var AppFasilitasKredits = await _AppFasilitasKredit.GetListByPredicate(x=>x.AppId == existingApp.Id, new string[]{"TenorKredit"}); 

//                     foreach (var fasilitasKredit in AppFasilitasKredits)
//                     {
//                         if (fasilitasKredit.TenorKredit.Tenor == null){
//                             continue;
//                         }

//                         fasilitasKredit.AngsuranBunga = siklusUsahaAkhir ? 0 : 
//                         fasilitasKredit.PlafondYangDiajukan * fasilitasKredit.TingkatSukuBunga / 100 /360 * diffDays;

//                         fasilitasKredit.AngsuranPokok = (float)(siklusUsahaAkhir ? fasilitasKredit.PlafondYangDiajukan :
//                         fasilitasKredit.PlafondYangDiajukan / fasilitasKredit.TenorKredit.Tenor);

//                         updateListFasilitas.Add(fasilitasKredit);
//                     }

//                     await _AppFasilitasKredit.UpdateRangeAsync(updateListFasilitas);
//                 }

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