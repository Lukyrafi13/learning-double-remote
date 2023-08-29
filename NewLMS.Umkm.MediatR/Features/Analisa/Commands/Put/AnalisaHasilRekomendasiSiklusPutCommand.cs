// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.Analisas;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.Analisas.Commands
// {
//     public class AnalisaHasilRekomendasiPutCommand : AnalisaHasilRekomendasiPut, IRequest<ServiceResponse<AnalisaHasilRekomendasiResponse>>
//     {
//     }

//     public class AnalisaHasilRekomendasiPutCommandHandler : IRequestHandler<AnalisaHasilRekomendasiPutCommand, ServiceResponse<AnalisaHasilRekomendasiResponse>>
//     {
//         private readonly IGenericRepositoryAsync<Analisa> _Analisa;
//         private readonly IGenericRepositoryAsync<AnalisaFasilitas> _AnalisaFasilitas;
//         private readonly IMapper _mapper;

//         public AnalisaHasilRekomendasiPutCommandHandler(
//             IGenericRepositoryAsync<Analisa> Analisa,
//             IGenericRepositoryAsync<AnalisaFasilitas> AnalisaFasilitas,
//             IMapper mapper)
//         {
//             _Analisa = Analisa;
//             _AnalisaFasilitas = AnalisaFasilitas;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<AnalisaHasilRekomendasiResponse>> Handle(AnalisaHasilRekomendasiPutCommand request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var existingAnalisa = await _Analisa.GetByIdAsync(request.Id, "Id");
                
//                 existingAnalisa = _mapper.Map<AnalisaHasilRekomendasiPut, Analisa>(request, existingAnalisa);

//                 var listFasilitas = await _AnalisaFasilitas.GetListByPredicate(x=> x.AnalisaId == existingAnalisa.Id,
//                 new string[]{
//                     "AppFasilitasKredit",
//                     "AppFasilitasKredit.TujuanKredit",
//                     "AppFasilitasKredit.TenorKredit",
//                     "JangkaWaktu"
//                 });

//                 foreach (var fasilitas in listFasilitas)
//                 {
//                     var modalKerja = fasilitas.AppFasilitasKredit.TujuanKredit.LP_CODE == "MD";
//                     var investasi = fasilitas.AppFasilitasKredit.TujuanKredit.LP_CODE == "IN";

//                     var plafon = fasilitas.Fasilitas??fasilitas.AppFasilitasKredit.PlafondYangDiajukan;
//                     var tenor = fasilitas.JangkaWaktu.Tenor?? fasilitas.AppFasilitasKredit.TenorKredit.Tenor;
//                     var tingkatSukuBunga = fasilitas.SukuBunga?? fasilitas.AppFasilitasKredit.TingkatSukuBunga;
//                     var year = existingAnalisa.TanggalRencanaPencairan?.Year??0;
//                     var month = existingAnalisa.TanggalRencanaPencairan?.Month??0;
//                     var daysInMonth = year == 0 || month == 0 ? 30 : DateTime.DaysInMonth(year, month);

//                     if (modalKerja){
//                         var angsuranPokok = plafon / tenor;
//                         fasilitas.Angsuran = angsuranPokok + (plafon * (tingkatSukuBunga/100) * daysInMonth/360 );
//                     }
//                     if (investasi){
//                         var selfFinancing = fasilitas.SelfFinancing??0.00;
//                         plafon -= selfFinancing;
//                         var angsuranPokok = plafon / tenor;
//                         fasilitas.Angsuran = angsuranPokok + (plafon * (tingkatSukuBunga/100) * daysInMonth/360 );
//                     }
                    
//                 }
                
//                 await _Analisa.UpdateAsync(existingAnalisa);
//                 await _AnalisaFasilitas.UpdateRangeAsync(listFasilitas);

//                 var response = _mapper.Map<AnalisaHasilRekomendasiResponse>(existingAnalisa);

//                 return ServiceResponse<AnalisaHasilRekomendasiResponse>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<AnalisaHasilRekomendasiResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//             }
//         }
//     }
// }