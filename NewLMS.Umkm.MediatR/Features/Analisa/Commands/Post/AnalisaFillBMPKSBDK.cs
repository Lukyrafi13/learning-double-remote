// using System.Text.RegularExpressions;
// using System.Collections.Generic;
// using System.Threading;
// using System.Threading.Tasks;
// using MediatR;
// using NewLMS.UMKM.Helper;
// using System;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Repository.GenericRepository;
// using NewLMS.UMKM.Domain.FUSE.Services;
// using System.Net;
// using NewLMS.UMKM.Common.GenericRespository;

// namespace NewLMS.UMKM.MediatR.Features.Analisas.Commands
// {
//     public class AnalisaFillBMPKSBDKCommand : IRequest<ServiceResponse<Unit>>
//     {
//         public Guid Id { get; set; }
//     }
//     public class AnalisaFillBMPKSBDKCommandHandler : IRequestHandler<AnalisaFillBMPKSBDKCommand, ServiceResponse<Unit>>
//     {
//         public IGenericRepositoryAsync<Analisa> _Analisa;
//         public ISBDKService _SBDK;
//         public IBMPKService _BMPK;
        
//         public AnalisaFillBMPKSBDKCommandHandler
//         (
//             IGenericRepositoryAsync<Analisa> Analisa,
//             ISBDKService SBDK,
//             IBMPKService BMPK
//         )
//         {
//             _Analisa = Analisa;
//             _SBDK = SBDK;
//             _BMPK = BMPK;
//         }

//         public async Task<ServiceResponse<Unit>> Handle(AnalisaFillBMPKSBDKCommand request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var existingAnalisa = await _Analisa.GetByIdAsync(request.Id, "Id");
                
//                 if (existingAnalisa == null)
//                     return ServiceResponse<Unit>.Return404("Data Analisa not found");

//                 // get bmpk
//                 if (existingAnalisa.PeriodeBMPK == null){
//                     var bmpks = await _BMPK.GetBMPKByFilter(new RequestParameter{
//                         Length = 1,
//                         SortType = "DESC",
//                         Orders = new List<string>{ "Periode" },
//                         Page = 1,
//                         Filters = new List<RequestFilterParameter> {
//                             new RequestFilterParameter{
//                                 SwitchPosition = false,
//                                 ComparisonOperator = "<=",
//                                 Type = "string",
//                                 Field = "Periode",
//                                 Value = DateTime.Now.ToString("s"),
//                             },
//                         }
//                     });
                    
//                     if (bmpks.Count == 0)
//                         return ServiceResponse<Unit>.Return404("Data BMPK not found");
//                     var bmpk = bmpks.ToArray()[0];

//                     existingAnalisa.PeriodeBMPK = bmpk.Periode;
//                     existingAnalisa.ModalBank = bmpk.ModalPelengkap;
//                     existingAnalisa.ModalInti = bmpk.ModalInti;
//                     existingAnalisa.BMPK = bmpk.ModalInti * decimal.ToDouble(bmpk.PctInfrastruktur??0.0m);
//                     existingAnalisa.BMPKBUMN = bmpk.ModalPelengkap * 0.3;
//                     existingAnalisa.Inhouse = bmpk.ModalInti * decimal.ToDouble(bmpk.PctTidakTerkait??0.0m) * 0.8;
//                     existingAnalisa.PenyediaanDanaBesar = bmpk.ModalInti * 0.1;

//                     await _Analisa.UpdateAsync(existingAnalisa);
//                 }
                
//                 // get sbdk
//                 if (existingAnalisa.PeriodeSBDK == null){
//                     var sbdks = await _SBDK.GetSBDKByFilter(new RequestParameter{
//                         Length = 1,
//                         SortType = "DESC",
//                         Orders = new List<string>{ "Period" },
//                         Page = 1,
//                         Filters = new List<RequestFilterParameter> {
//                             new RequestFilterParameter{
//                                 SwitchPosition = false,
//                                 ComparisonOperator = "<=",
//                                 Type = "string",
//                                 Field = "Period",
//                                 Value = DateTime.Now.ToString("s"),
//                             }
//                         }
//                     });
                    
//                     if (sbdks.Count == 0)
//                         return ServiceResponse<Unit>.Return404("Data BMPK not found");
//                     var bmpk = sbdks.ToArray()[0];

//                     existingAnalisa.PeriodeSBDK = bmpk.Period;
//                     existingAnalisa.HPDKKorporasi = bmpk.HPDKKorporasi;
//                     existingAnalisa.HPDKRitel = bmpk.HPDKRitel;
//                     existingAnalisa.HPDKMikro = bmpk.HPDKMikro;
//                     existingAnalisa.HPDKKPR = bmpk.HPDKKPR;
//                     existingAnalisa.HPDKNonKPR = bmpk.HPDKNonKPR;
//                     existingAnalisa.BOKorporasi = bmpk.OverHeadKorporasi;
//                     existingAnalisa.BORitel = bmpk.OverHeadRitel;
//                     existingAnalisa.BOMikro = bmpk.OverHeadMikro;
//                     existingAnalisa.BOKPR = bmpk.OverHeadKPR;
//                     existingAnalisa.BONonKPR = bmpk.OverHeadNonKPR;
//                     existingAnalisa.MKKorporasi = bmpk.MarjinKorporasi;
//                     existingAnalisa.MKRitel = bmpk.MarjinRitel;
//                     existingAnalisa.MKMikro = bmpk.MarjinMikro;
//                     existingAnalisa.MKKPR = bmpk.MarjinKPR;
//                     existingAnalisa.MKNonKPR = bmpk.MarjinNonKPR;
//                     // existingAnalisa.SBDKKorporasi = bmpk.SBDKKorporasi;
//                     // existingAnalisa.SBDKRitel = bmpk.SBDKRitel;
//                     // existingAnalisa.SBDKMikro = bmpk.SBDKMikro;
//                     // existingAnalisa.SBDKKPR = bmpk.SBDKKPR;
//                     // existingAnalisa.SBDKNonKPR = bmpk.SBDKNonKPR;

//                     await _Analisa.UpdateAsync(existingAnalisa);
//                 }

//                 return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
//             }
//             catch (Exception ex)
//             {
//                 var response = ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//                 response.Success = false;
//                 return response;
//             }
//         }
//     }
// }