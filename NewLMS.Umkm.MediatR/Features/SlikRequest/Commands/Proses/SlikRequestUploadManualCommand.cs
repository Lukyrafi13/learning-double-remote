// using System;
// using System.Collections.Generic;
// using System.Globalization;
// using System.IO;
// using System.Linq;
// using System.Text;
// using System.Threading;
// using System.Threading.Tasks;
// using Bjb.DigitalBisnis.SLIK.Interfaces;
// using MediatR;
// using Microsoft.AspNetCore.Http;
// using Microsoft.EntityFrameworkCore;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Data.Dto.SlikRequests;
// using NewLMS.UMKM.Domain.Context;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.MediatR.Exceptions;
// using NewLMS.UMKM.Repository.GenericRepository;
// using Newtonsoft.Json;

// namespace NewLMS.UMKM.MediatR.Features.SlikRequests.Commands
// {
//     public class UploadSlikManualCommand : IRequest<ServiceResponse<Unit>>
// 	{
// 		public Guid Id { get; set; }
// 		public IFormFile file { get; set; }
// 	}

//     public class UploadSlikManualCommandHanlder : IRequestHandler<UploadSlikManualCommand, ServiceResponse<Unit>>
//     {
//         private readonly ISlikService _slikService;
//         private readonly IGenericRepositoryAsync<SlikRequestObject> _slikRequestObjects;
//         private readonly IGenericRepositoryAsync<RFSANDIBI> _rfSandiBI;
//         private readonly IGenericRepositoryAsync<RFBank> _rfBank;
//         private readonly IGenericRepositoryAsync<SlikCreditHistory> _loanApplicationCreditHistory;
//         private readonly IGenericRepositoryAsync<RFTipeKredit> _rfCreditType;
//         private readonly IGenericRepositoryAsync<RFCondition> _rfCondition;
//         private readonly UserContext _userContext;

//         public UploadSlikManualCommandHanlder(ISlikService slikService
//             , IGenericRepositoryAsync<SlikRequestObject> slikRequestObjects
//             , IGenericRepositoryAsync<RFSANDIBI> rfSandiBI
//             , IGenericRepositoryAsync<RFBank> rfBank
//             , IGenericRepositoryAsync<SlikCreditHistory> loanApplicationCreditHistory
//             , UserContext userContext
//             , IGenericRepositoryAsync<RFTipeKredit> rfCreditType
//             , IGenericRepositoryAsync<RFCondition> rfCondition
//             )
//         {
//             _slikService = slikService;
//             _slikRequestObjects = slikRequestObjects;
//             _rfSandiBI = rfSandiBI;
//             _rfBank = rfBank;
//             _loanApplicationCreditHistory = loanApplicationCreditHistory;
//             _userContext = userContext;
//             _rfCreditType = rfCreditType;
//             _rfCondition = rfCondition;
//         }

//         public async Task<ServiceResponse<Unit>> Handle(UploadSlikManualCommand request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var SlikResult = new List<SlikRequestManualResponse>();
//                 var banks = new RFBank();
//                 var slikDebtors = await _slikRequestObjects.GetListByPredicate(x => request.Id == x.Id,
//                 new string[]
//                 {
//                     "SlikRequest",
//                     "SlikRequest.App"
//                 });
//                 if (slikDebtors == null)
//                     throw new ApiException("data not found");
//                 using var sr = new StreamReader(request.file.OpenReadStream(), Encoding.UTF8);
//                 string content = await sr.ReadToEndAsync();
//                 var data = JsonConvert.DeserializeObject<SlikRequestManualResponse>(content);
//                 foreach (var i in data.Individual.Fasilitas.KreditPembiayan)
//                 {
//                     RFSANDIBI SandiBIEconomySector = new RFSANDIBI();
//                     RFSANDIBI SandiBIBehaviour = new RFSANDIBI();
//                     RFSANDIBI SandiBIApplicationType = new RFSANDIBI(); ;
//                     RFSANDIBI SandiBICollectibility = new RFSANDIBI(); ;
//                     // if (i.Ljk == "110") //for bjb only
//                     // {
//                         var dataCreditType = await _rfCreditType.GetByIdAsync(i.JenisKreditPembiayaan, "Code");
//                         if (dataCreditType == null)
//                         {

//                             RFTipeKredit credittype = new RFTipeKredit
//                             {
//                                 Code = i.JenisKreditPembiayaan,
//                                 Description = i.JenisKreditPembiayaanKet,
//                                 CreditAgreement = true
//                             };
//                             await _rfCreditType.AddAsync(credittype);
//                         }
//                         i.SektorEkonomi = i.SektorEkonomi.TrimStart(new Char[] { '0' } ); // Remove Prefix
//                         var DataEconomySector = await _rfSandiBI.GetByPredicate(x => x.BI_GROUP == "3" && x.CORE_CODE == i.SektorEkonomi);
//                         if (DataEconomySector == null)
//                         {
//                             SandiBIEconomySector = new RFSANDIBI
//                             {
//                                 BI_GROUP = "3",
//                                 BI_TYPE = "LBU",
//                                 BI_CODE = i.SektorEkonomi,
//                                 BI_DESC = i.SektorEkonomiKet,
//                                 CORE_CODE = i.SektorEkonomi,
//                                 ACTIVE = true,
//                                 KATEGORI_CODE = null,
//                                 LBU2_CODE = null
//                             };
//                             DataEconomySector = await _rfSandiBI.AddAsync(SandiBIEconomySector);
//                         }

//                         // Cek Behaviour
//                         var DataBehaviour = await _rfSandiBI.GetByPredicate(x => x.BI_GROUP == "12" && x.CORE_CODE == i.SifatKreditPembiayaan.ToString());
//                         if (DataBehaviour == null)
//                         {
//                             SandiBIBehaviour = new RFSANDIBI
//                             {
//                                 BI_GROUP = "12",
//                                 BI_TYPE = "LBU",
//                                 BI_CODE = i.SifatKreditPembiayaan.ToString(),
//                                 BI_DESC = i.SifatKreditPembiayaanKet,
//                                 CORE_CODE = i.SifatKreditPembiayaan.ToString(),
//                                 ACTIVE = true,
//                                 KATEGORI_CODE = null,
//                                 LBU2_CODE = null
//                             };
//                             DataBehaviour = await _rfSandiBI.AddAsync(SandiBIBehaviour);
//                         }

//                         var DataApplicationType = await _rfSandiBI.GetByPredicate(x => x.BI_GROUP == "9" && x.CORE_CODE == i.JenisPenggunaan.ToString());
//                         if (DataApplicationType == null)
//                         {
//                             SandiBIApplicationType = new RFSANDIBI
//                             {
//                                 BI_GROUP = "9",
//                                 BI_TYPE = "LBU",
//                                 BI_CODE = i.JenisPenggunaan.ToString(),
//                                 BI_DESC = i.JenisPenggunaanKet.ToString(),
//                                 CORE_CODE = i.JenisPenggunaan.ToString(),
//                                 ACTIVE = true,
//                                 KATEGORI_CODE = null,
//                                 LBU2_CODE = null
//                             };
//                             DataApplicationType = await _rfSandiBI.AddAsync(SandiBIApplicationType);
//                         }

//                         var DataCollectibility = await _rfSandiBI.GetByPredicate(x => x.BI_GROUP == "8" && x.CORE_CODE == i.Kualitas.ToString());
//                         if (DataCollectibility == null)
//                         {   
//                             SandiBICollectibility = new RFSANDIBI
//                             {
//                                 BI_GROUP = "8",
//                                 BI_TYPE = "LBU",
//                                 BI_CODE = i.Kualitas.ToString(),
//                                 BI_DESC = i.KualitasKet,
//                                 CORE_CODE = i.Kualitas.ToString(),
//                                 ACTIVE = true,
//                                 KATEGORI_CODE = null,
//                                 LBU2_CODE = null
//                             };
//                             DataCollectibility = await _rfSandiBI.AddAsync(SandiBICollectibility);
//                         }

//                         var TipeKredit = await _rfCreditType.GetByPredicate(x => x.Code == i.JenisKreditPembiayaan);

//                         if (TipeKredit == null){
//                             var newTipeKredit = new RFTipeKredit{
//                                 Code = i.JenisKreditPembiayaan,
//                                 Description = i.JenisKreditPembiayaanKet,
//                                 CreditAgreement = null
//                             };

//                             TipeKredit = await _rfCreditType.AddAsync(newTipeKredit);
//                         }

//                         var Condition = await _rfCondition.GetByPredicate(x => x.ConditionCode == i.Kondisi);

//                         if (Condition == null){
//                             var newCondition = new RFCondition{
//                                 ConditionCode = i.Kondisi,
//                                 ConditionDesc = i.KondisiKet,
//                                 ConditionCategory = "",
//                                 Active = true,
//                             };

//                             Condition = await _rfCondition.AddAsync(newCondition);
//                         }

//                         var dataPokorDebitur = data.Individual.DataPokokDebitur.FirstOrDefault();
//                         var StartDate = i.TanggalAkadAwal == "" ? null : DateTime.ParseExact(i.TanggalAkadAwal, "yyyyMMdd", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
//                         var EndDate = i.TanggalAkadAkhir == "" ? null : DateTime.ParseExact(i.TanggalAkadAkhir, "yyyyMMdd", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
//                         var StuckDate = i.TanggalMacet == "" ? null : DateTime.ParseExact(i.TanggalMacet, "yyyyMMdd", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
//                         var DateOfBirth = dataPokorDebitur.TanggalLahir.ToString() == "" ? null : DateTime.ParseExact(dataPokorDebitur.TanggalLahir.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");

//                         var slikDebtorscek = await _slikRequestObjects.GetByPredicate(x => x.SlikRequestId == request.Id && x.NoIdentity == dataPokorDebitur.NoIdentitas);
//                         if(slikDebtorscek == null)
//                         {
//                             SlikRequestObject SlikRequestObject = new SlikRequestObject
//                             {
//                                 SlikRequestId = request.Id,
//                                 NoIdentity = dataPokorDebitur.NoIdentitas,
//                                 Fullname = dataPokorDebitur.NamaDebitur,
//                                 SlikObjectTypeId = 1,
//                                 PlaceOfBirth = dataPokorDebitur.TempatLahir,
//                                 DateOfBirth = DateOfBirth == null ? DateTime.Now : DateTime.ParseExact(DateOfBirth, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
//                                 NPWP = dataPokorDebitur.Npwp,
//                                 RequestDate = DateTime.Now,
//                                 ApplicationStatus = null,
//                                 Automatic = false,
//                                 // SIDStatus = null,
//                                 // ByKesamaan = true,
//                                 // ByNoIdentitas = true,
//                                 TujuanPermintaan = "01",
//                             };
//                             await _slikRequestObjects.AddAsync(SlikRequestObject);
//                         }


//                         SlikCreditHistory creditHistory = new SlikCreditHistory
//                         {
//                             SLIKNoIdentity = dataPokorDebitur.NoIdentitas,
//                             DebtorName = dataPokorDebitur.NamaDebitur,
//                             Bank = i.LjkKet,
//                             StartDate = StartDate == null ? null : DateTime.ParseExact(StartDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
//                             EndDate = EndDate == null ? null : DateTime.ParseExact(EndDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
//                             RFSandiBIEconomySectorId = DataEconomySector != null ? DataEconomySector.Id : SandiBIEconomySector.Id,// _userContext.RfSandiBIs.Where(x => x.BIGroup == "03" && x.BICode == i.SektorEkonomi).Select(x => x.RfSandiBIId).FirstOrDefault(),
//                             RFSandiBIBehaviourId = DataBehaviour != null ? DataBehaviour.Id : SandiBIBehaviour.Id,
//                             RFSandiBIApplicationTypeId = DataApplicationType != null ? DataApplicationType.Id : SandiBIApplicationType.Id,
//                             RFConditionId = _userContext.RFConditions.Where(x => x.ConditionCode == i.Kondisi).Select(x => x.Id).FirstOrDefault(),
//                             PlafondLimit = Convert.ToInt32(i.PlafonAwal),
//                             Interest = i.SukuBungaImbalan,
//                             Outstanding = i.Plafon,
//                             StuckDate = StuckDate == null ? null : DateTime.ParseExact(StuckDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
//                             RFSandiBICollectibilityId = DataCollectibility != null ? DataCollectibility.Id : SandiBICollectibility.Id,
//                             SLIKStatus = false,
//                             SlikRequestId = request.Id,
//                             RFTipeKreditId = _userContext.RFTipeKredits.Where(x => x.Code == i.JenisKreditPembiayaan).Select(x => x.Id).FirstOrDefault(),
//                             IsRobo = false,
//                             SlikObjectTypeId = 1,
//                             BelumMemilikiSLIK = false
//                         };

//                         await _loanApplicationCreditHistory.AddAsync(creditHistory);
//                     // }
//                 }
//                 return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.InnerException != null ? ex.InnerException.Message.ToString() : ex.Message.ToString());
//             }
//         }
//     }
// }