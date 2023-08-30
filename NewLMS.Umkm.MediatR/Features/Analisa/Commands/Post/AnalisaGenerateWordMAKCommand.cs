// using System.Text.RegularExpressions;
// using System.Collections.Generic;
// using System.Threading;
// using System.Threading.Tasks;
// using MediatR;
// using NewLMS.UMKM.Helper;
// using System.IO;
// using DocumentFormat.OpenXml.Packaging;
// using NewLMS.UMKM.Repository.GenericRepository;
// using NewLMS.UMKM.Data.Entities;
// using System;
// using Microsoft.Extensions.Configuration;
// using DocumentFormat.OpenXml.Wordprocessing;
// using System.Linq;
// using System.Reflection.Emit;
// using NewLMS.UMKM.Data.Dto.Analisas;

// namespace NewLMS.UMKM.MediatR.Features.Analisas.Commands
// {
//     public class AnalisaGenerateWordMAKCommand : IRequest<ServiceResponse<string>>
//     {
//         public Guid LoanApplicationGuid { get; set; }
//     }
//     public class AnalisaGenerateWordMAKCommandHandler : IRequestHandler<AnalisaGenerateWordMAKCommand, ServiceResponse<string>>
//     {
//         string link = null;
//         private readonly IGenericRepositoryAsync<Debtors> _debtor;
//         private readonly IGenericRepositoryAsync<LoanApplications> _loanApplications;
//         private readonly IGenericRepositoryAsync<CreditFacilities> _creditFacility;
//         private readonly IGenericRepositoryAsync<FinancialAnalysis> _financialAnalysis;
//         private readonly IGenericRepositoryAsync<FinancingProposals> _financingProposal;
//         private readonly IGenericRepositoryAsync<CompanyShareHolders> _companyShareholder;
//         private readonly IGenericRepositoryAsync<CompanyAddress> _companyAddress;
//         private readonly IGenericRepositoryAsync<CompanyProjects> _companyProject;
//         private readonly IGenericRepositoryAsync<CompanyManagements> _companyManagement;
//         private readonly IGenericRepositoryAsync<Accounts> _account;
//         private readonly IGenericRepositoryAsync<AccountMutationDetails> _accountMutationDetail;
//         private readonly IGenericRepositoryAsync<OTS> _ots;
//         private readonly IGenericRepositoryAsync<LoanFacilities> _loanFacility;
//         private readonly IGenericRepositoryAsync<VisitedSides> _vistedSide;
//         private readonly IGenericRepositoryAsync<Facilities> _facility;
//         private readonly IGenericRepositoryAsync<CreditApplicationHeaders> _caHeader;
//         private readonly IGenericRepositoryAsync<CreditApplications> _creditApplication;
//         private readonly IGenericRepositoryAsync<Collaterals> _collateral;
//         private readonly IGenericRepositoryAsync<AppraisalResults> _appraisalResult;
//         private readonly IGenericRepositoryAsync<CollateralBindings> _collateralBinding;
//         private readonly IGenericRepositoryAsync<DebtorCollateral> _debtorCollateral;
//         private readonly IGenericRepositoryAsync<ApprLiquidation> _apprLiquidation;
//         private readonly IGenericRepositoryAsync<GeneratedFileMAK> _generateFile;
//         private readonly IGenericRepositoryAsync<TermAndConditions> _termAndCondition;
//         private readonly IGenericRepositoryAsync<RiskAndMitigations> _riksAndMitigation;
//         private readonly IConfiguration _appConfig;
//         private readonly IGenericRepositoryAsync<User> _user;
//         private readonly ICurrentUserService _ICurrentUserService;

//         public AnalisaGenerateWordMAKCommandHandler
//         (
//             IGenericRepositoryAsync<Debtors> debtor,
//             IGenericRepositoryAsync<LoanApplications> loanApplication,
//             IGenericRepositoryAsync<CreditFacilities> creditFacility,
//             IGenericRepositoryAsync<FinancialAnalysis> financialAnalysis,
//             IGenericRepositoryAsync<FinancingProposals> financingProposal,
//             IGenericRepositoryAsync<CompanyShareHolders> companyShareholder,
//             IGenericRepositoryAsync<CompanyAddress> companyAddress,
//             IGenericRepositoryAsync<CompanyProjects> companyProject,
//             IGenericRepositoryAsync<CompanyManagements> companyManagement,
//             IGenericRepositoryAsync<Accounts> account,
//             IGenericRepositoryAsync<AccountMutationDetails> accountMutationDetail,
//             IGenericRepositoryAsync<OTS> ots,
//             IGenericRepositoryAsync<LoanFacilities> loanFacility,
//             IGenericRepositoryAsync<VisitedSides> visitedSide,
//             IGenericRepositoryAsync<Facilities> facility,
//             IGenericRepositoryAsync<CreditApplicationHeaders> caHeader,
//             IGenericRepositoryAsync<CreditApplications> creditApplication,
//             IGenericRepositoryAsync<Collaterals> collateral,
//             IGenericRepositoryAsync<AppraisalResults> appraisalResult,
//             IGenericRepositoryAsync<CollateralBindings> collateralBinding,
//             IGenericRepositoryAsync<DebtorCollateral> debtorCollateral,
//             IGenericRepositoryAsync<ApprLiquidation> apprLiquidation,
//             // IGenericRepositoryAsync<
//             IGenericRepositoryAsync<GeneratedFileMAK> generateFile,
//             IGenericRepositoryAsync<TermAndConditions> termAndCondition,
//             IGenericRepositoryAsync<RiskAndMitigations> riskAndMitigation,
//             ICurrentUserService ICurrentUserService,
//             IGenericRepositoryAsync<User> user,
//             IConfiguration appConfig
//         )
//         {
//             _debtor = debtor;
//             _loanApplications = loanApplication;
//             _creditFacility = creditFacility;
//             _financialAnalysis = financialAnalysis;
//             _financingProposal = financingProposal;
//             _companyShareholder = companyShareholder;
//             _companyAddress = companyAddress;
//             _companyProject = companyProject;
//             _companyManagement = companyManagement;
//             _account = account;
//             _accountMutationDetail = accountMutationDetail;
//             _ots = ots;
//             _loanFacility = loanFacility;
//             _vistedSide = visitedSide;
//             _facility = facility;
//             _caHeader = caHeader;
//             _creditApplication = creditApplication;
//             _collateral = collateral;
//             _appraisalResult = appraisalResult;
//             _collateralBinding = collateralBinding;
//             _debtorCollateral = debtorCollateral;
//             _apprLiquidation = apprLiquidation;
//             _generateFile = generateFile;
//             _termAndCondition = termAndCondition;
//             _riksAndMitigation = riskAndMitigation;
//             _ICurrentUserService = ICurrentUserService;
//             _user = user;
//             _appConfig = appConfig;
//         }
//         string rootDir => "Directory" switch
//         {
//             "Directory" => _appConfig.GetValue<string>("UMKMStorage:Directory"),
//             _ => throw new NotSupportedException()
//         };
//         public async Task<ServiceResponse<string>> Handle(AnalisaGenerateWordMAKCommand request, CancellationToken cancellationToken)
//         {
//             var includeDebtor = new string[]
//             {
//                 "RfSectorLBU1",
//                 "RfSectorLBU2",
//                 "RfSectorLBU3",
//                 "RFCompanyTypes"
//             };

//             var includeCreditApp = new string[]
//             {
//                 "LoanFacilities",
//                 "LoanFacilities.RFCreditApplicationTypes",
//                 "LoanFacilities.RFFacilityTypes",
//                 "LoanFacilities.RFCreditSubProducts",
//                 "LoanFacilities.RFCreditSubProducts.RFCreditProducts",
//                 // "RFCreditApplicationTypes",
//                 // "RFCreditSubProduct",
//                 "RFAuthorities",
//                 // "RFFacilityTypes",
//                 "RFCreditNatures",
//                 // "RFPurposes",
//                 "RFWithdrawalMethods",
//                 "RFBindingCredits",
//                 "RFPaymentPatterns",
//                 "RFPaymentPatternInterest"
//             };

//             var includeCompProj = new string[]
//             {
//                 "RFBouwheerCategories",
//                 "RFBouwheerGroups",
//                 "RFProjectTypes"
//             };
//             var includeDebtCol = new string[]
//             {
//                 "RfCollateral"
//             };
//             var includeBankRel = new string[]
//             {
//                 "Accounts"
//             };
//             LoanApplications loanApp = null;
//             Debtors debt = null;
//             FinancialAnalysis financeAn = null;
//             FinancingProposals financePr = null;
//             Facilities faciliti = null;
//             CreditFacilities credFacility = null;
//             CreditApplicationHeaders creditHeader = null;
//             CreditApplications creditApp = null;
//             CompanyShareHolders compShare = null;
//             CompanyAddress officeAddress = null;
//             CompanyAddress wareAddress = null;
//             List<CompanyManagements> compManagement = null;
//             List<AccountMutationDetails> accDetail = new List<AccountMutationDetails>();
//             List<Accounts> acc = new List<Accounts>();
//             OTS otsNew = null;
//             VisitedSides visitSide = null;
//             List<LoanFacilities> loanFacilities = null;
//             CompanyProjects compProj = null;
//             List<TermAndConditions> syaratPenandatanganan = null;
//             List<TermAndConditions> syaratEfektifPenarikan = null;
//             List<TermAndConditions> syaratLainnya = null;
//             List<DebtorCollateral> debtCollFixedAsset = null;
//             List<DebtorCollateral> debtCollPiutang = null;
//             List<ApprLiquidation> apprLiq = null;
//             RiskAndMitigations riskMitigation = null;
//             List<AccountMutationDetails> accDetail2D = new List<AccountMutationDetails>();

//             var userId = Guid.Parse(_ICurrentUserService.Id);
//             var userInfo = await _user.GetByIdAsync(userId, "Id");
//             var DateNow = DateTime.Now.ToString("dd MMMM yyyy");
//             loanApp = await _loanApplications.GetByIdAsync(request.LoanApplicationGuid, "LoanApplicationGuid");
//             debt = await _debtor.GetByIdAsync(loanApp.DebtorGuid, "DebtorGuid", includeDebtor);
//             compProj = await _companyProject.GetByIdAsync(loanApp.DebtorGuid, "DebtorGuid", includeCompProj);
//             compShare = await _companyShareholder.GetByIdAsync(loanApp.DebtorGuid, "DebtorGuid");
//             officeAddress = await _companyAddress.GetByPredicate(x => x.DebtorGuid == loanApp.DebtorGuid && x.AddressTypeId == 1 && x.IsDeleted == false);
//             wareAddress = await _companyAddress.GetByPredicate(x => x.DebtorGuid == loanApp.DebtorGuid && x.AddressTypeId == 2 && x.IsDeleted == false);
//             debtCollFixedAsset = await _debtorCollateral.GetListByPredicate(x => x.DebtorGuid == loanApp.DebtorGuid && !x.IsDeleted && x.RfCollateral.CollateralTypeId == 3 ,includeDebtCol);
//             debtCollPiutang = await _debtorCollateral.GetListByPredicate(x => x.DebtorGuid == loanApp.DebtorGuid && !x.IsDeleted && x.RfCollateralCode == "33",includeDebtCol);
//             compManagement = await _companyManagement.GetListByPredicate(x => x.LoanApplicationGuid == loanApp.LoanApplicationGuid && !x.IsDeleted);
//             for (int i = 0; i < compManagement.Count; i++)
//             {
//                 var accc = await _account.GetListByPredicate(x => x.CompanyManagementGuid == compManagement[i].CompanyManagementGuid && !x.IsDeleted);
//                 acc.AddRange(accc);
//             }
//             for (int i = 0; i < acc.Count; i++)
//             {
//                 var accDetailList = await _accountMutationDetail.GetListByPredicate(x => x.AccountGuid == acc[i].AccountGuid && !x.IsDeleted,includeBankRel);
//                 accDetail2D.AddRange(accDetailList);
//             }
//             financeAn = await _financialAnalysis.GetByIdAsync(request.LoanApplicationGuid,"LoanApplicationGuid");
//             financePr = await _financingProposal.GetByIdAsync(request.LoanApplicationGuid,"LoanApplicationGuid");
//             faciliti = await _facility.GetByIdAsync(request.LoanApplicationGuid,"LoanApplicationGuid");
//             if (faciliti != null)
//             {
//                 creditHeader = await _caHeader.GetByIdAsync(faciliti.FacilityGuid, "FacilityGuid");
//                 if (creditHeader != null)
//                 {
//                     creditApp = await _creditApplication.GetByIdAsync(creditHeader.CreditApplicationHeaderGuid, "CreditApplicationHeaderGuid", includeCreditApp);
//                 }
//             }
//             credFacility = await _creditFacility.GetByIdAsync(request.LoanApplicationGuid, "LoanApplicationGuid");
//             otsNew = await _ots.GetByIdAsync(request.LoanApplicationGuid, "LoanApplicationGuid");
//             if (otsNew != null)
//             {
//                 visitSide = await _vistedSide.GetByIdAsync(otsNew.OTSGuid, "OtsGuid");
//             }
//             loanFacilities = await _loanFacility.GetListByPredicate(x => x.LoanApplicationGuid == request.LoanApplicationGuid && !x.IsDeleted);
//             syaratPenandatanganan = await _termAndCondition.GetListByPredicate(x => x.LoanApplicationGuid == request.LoanApplicationGuid && x.TermAndConditionId == 1 && !x.IsDeleted);
//             syaratEfektifPenarikan = await _termAndCondition.GetListByPredicate(x => x.LoanApplicationGuid == request.LoanApplicationGuid && x.TermAndConditionId == 2 && !x.IsDeleted);
//             syaratLainnya = await _termAndCondition.GetListByPredicate(x => x.LoanApplicationGuid == request.LoanApplicationGuid && x.TermAndConditionId == 3 && !x.IsDeleted);
//             // coll = await _collateral.GetByIdAsync(request.LoanApplicationGuid,"LoanApplicationGuid");
//             // appraisalR = await _appraisalResult.GetByIdAsync(request.LoanApplicationGuid,"LoanApplicationGuid");
//             // collBind = await _collateralBinding.GetByIdAsync(appraisalR.AppraisalResultGuid,"AppraisalResultGuid");
//             apprLiq = await _apprLiquidation.GetListByPredicate(x => x.ApprTemplateGuid == request.LoanApplicationGuid && !x.IsDeleted);
//             riskMitigation = await _riksAndMitigation.GetByIdAsync(request.LoanApplicationGuid, "LoanApplicationGuid");
//             Dictionary<string, string> keyValues = new Dictionary<string, string>()
//             {
//                 {"{noMAK}",financePr?.MAK == null ? "[no data]" : financePr?.MAK},
//                 {"{tanggal}", DateNow},
//                 {"{namaNasabah}",debt?.CompanyName == null ? "[no data]" : debt?.CompanyName},
//                 {"{bidangUsaha}",debt?.RFCompanyTypes?.CompanyTypeName == null ? "[no data]" : debt?.RFCompanyTypes.CompanyTypeName},
//                 {"{sektorEkonomi}",debt?.RfSectorLBU1?.Description == null ? "[no data]" : debt?.RfSectorLBU1?.Description},
//                 {"{subsektorEkonomi}", debt?.RfSectorLBU2?.Description == null ? "[no data]" : debt?.RfSectorLBU2.Description},
//                 {"{subsubsektorEkonomi}",debt?.RfSectorLBU3?.Description == null ? "[no data]" : debt?.RfSectorLBU3.Description},
//                 {"{grupUsaha}",debt?.RFCompanyTypes?.CompanyTypeName == null ? "[no data]" : debt?.RFCompanyTypes.CompanyTypeName},
//                 {"{jenisPengajuan}",creditApp?.LoanFacilities?.RFCreditApplicationTypes?.CreditApplicationTypeName == null ? "[no data]" : creditApp?.LoanFacilities?.RFCreditApplicationTypes?.CreditApplicationTypeName},
//                 {"{fasilitas}", creditApp?.LoanFacilities?.RFCreditSubProducts?.RFCreditProducts?.CreditProductName == null ? "[no data]" : creditApp?.LoanFacilities?.RFCreditSubProducts?.RFCreditProducts?.CreditProductName},

//                 {"{totalFasilitas}",creditHeader?.TotalCommercialFacility.ToString() == null ? "[no data]" : creditHeader?.TotalCommercialFacility.ToString()},
//                 // //Tabel Kondisi Keuangan
//                 // //------------------------
//                 {"{kemampuanFinansial}", ""},
//                 {"{sumberPelunasanKredit}",""},
//                 {"{jaminan}",""},
//                 {"{facilityRating}",""},
//                 {"{industriDanBisnis}", ""},
//                 {"{accountStrategyGroup}", ""},
//                 {"{bankPolicy}", ""},
//                 {"{dasarPermohonan}", ""},
//                 {"{accountOfficer}", userInfo?.Nama == null ? "[no data]" : userInfo?.Nama},
//                 // {"jabatanPengusul", jabatanPengusul},
//                 {"{pejabatPengusul}", ""},
//                 // {"jabatanPejabatPengusul", ""},
//                 {"{kantorCabang}", ""},
//                 {"{limitExisting}", ""},
//                 {"{limitGrup}", ""},
//                 {"{limitPermohonan}", ""},
//                 {"{tujuanPengajuanKredit}", ""},
//                 {"{tanggalRating}", ""},
//                 {"{ratingDebitur}", ""},
//                 {"{ratingFasilitas}",""},
//                 {"{ratingProyek}", ""},
//                 {"{skDireksi}",""},
//                 {"{tanggalSk}",""},
//                 {"{totalLoan}",""},
//                 // {"{namaPemilikRekening}",""},
//                 {"{totalEksposur}",""},
//                 {"{wewenangMemutus}", creditApp?.RFAuthorities?.AuthorName == null ? "[no data]" : creditApp?.RFAuthorities.AuthorName},
//                 {"{tanggalPendirian}",compShare?.InitialDate.ToString("dd MMMM yyyy") == null ? "[no data]" : compShare?.InitialDate.ToString("dd MMMM yyyy")},
//                 // {"{bidangUsaha}", debt.RFCompanyTypes.CompanyTypeName},
//                 {"{sektorIndustri}", debt?.IndustrialType == null ? "[no data]" : debt?.IndustrialType},
//                 {"{alamatGudang}", wareAddress?.Address == null ? "[no data]" : wareAddress?.Address},
//                 {"{alamatKantor}", officeAddress?.Address == null ? "[no data]" : officeAddress?.Address},
//                 {"{keyPerson}", debt?.KeyPerson == null ? "[no data]" : debt?.KeyPerson},
//                 {"{keyPersonPhone}",debt?.KeyPersonPhone == null ? "[no data]" : debt?.KeyPersonPhone},
//                 {"{tahunHubunganDenganBank}",""},
//                 {"{informasiKhusus}",""},
//                 {"{permodalan}",""},
//                 {"{aktaNotaris}",""},
//                 {"{namaNotaris}",""},
//                 // {"namaperngurus",namaPengurus},
//                 // {"jabatan",jabatan},
//                 //Hubungan Dengan Bank
//                 // ---------------------------
//                 {"{customerProfit}",""},
//                 {"{kontribusiBersih}",""},
//                 //OTS 
//                 {"{namaPengunjung}",visitSide?.Name == null ? "[no data]" : visitSide?.Name},
//                 {"{jabatanPengunjung}", visitSide?.Position == null ? "[no data]" : visitSide?.Position},
//                 {"{lokasiKunjungan}",visitSide?.Location == null ?  "[no data]" : visitSide?.Location},
//                 {"{tanggalKunjungan}",visitSide?.VisitDate.ToString("dd MMMM yyyy") == null ? "[no data]" : visitSide?.VisitDate.ToString("dd MMMM yyyy")},
//                 {"{hasilKunjungan}",visitSide?.VisitResult == null ? "[no data]" : visitSide?.VisitResult},
//                 //BMPK
//                 {"{modalInti}",""},
//                 {"{modalPelengkap}",""},
//                 {"{totalModal}",""},
//                 {"{NPWPPerusahaan}",compShare?.NPWP == null ? "[no data]" : compShare?.NPWP},
//                 {"{aktaPendirian}",compShare?.CertificateNo == null ? "[no data]" : compShare?.CertificateNo},
//                 {"{SIUJK}",debt?.SIUJK == null ? "[no data]" : debt?.SIUJK},
//                 {"{SIUP}",debt?.SIUP == null ? "[no data]" : debt?.SIUP},
//                 {"{SITU}",debt?.SITU == null ? "[no data]" : debt?.SITU},
//                 {"{TDP}",""},
//                 {"{legalitasLain}",""},
//                 {"{karakterdanManajemen}",""},
//                 {"{lokasiUsaha}",""},
//                 {"{catatanTeknikProduksi}",""},
//                 {"{pemasaran}",""},
//                 {"{catatanKeuangan}",""},

//                 {"{kesimpulanLaporanKeuangan}",financeAn?.FinancialReportResume == null ? "[no data]" : financeAn?.FinancialReportResume},
//                 {"{kategoriBouwheer}",compProj?.RFBouwheerCategories.BouwheerCategoryName == null ? "[no data]" : compProj?.RFBouwheerCategories.BouwheerCategoryName},
//                 {"{golonganBouwheer}",compProj?.RFBouwheerGroups.BouwheerGroupName == null ? "[no data]" : compProj?.RFBouwheerGroups.BouwheerGroupName},
//                 {"{namaBouwheer}",compProj?.BouwheerName == null ? "[no data]" : compProj?.BouwheerName},
//                 {"{jenisProyek}",compProj?.RFProjectTypes.ProjectTypeName == null ? "[no data]" : compProj?.RFProjectTypes.ProjectTypeName},
//                 {"{namaProyek}",compProj?.ProjectName == null ? "[no data]" : compProj?.ProjectName},
//                 {"{jenisSumberDana}",compProj?.ResourceType == null ? "[no data]" : compProj?.ResourceType},
//                 {"{lokasiProyek}",compProj?.ProjectLocation == null ? "[no data]" : compProj?.ProjectLocation},
//                 {"{nilaiProyek}",compProj?.ProjectValue.ToString() == null ? "[no data]" : compProj?.ProjectValue.ToString()},
//                 {"{kebutuhanKredit}",credFacility?.CreditNeed == null ? "[no data]" : credFacility?.CreditNeed},
//                 {"{nilaiPlafond}",credFacility?.AppliedPlafond == null ? "[no data]" : credFacility?.AppliedPlafond},
//                 {"{keteranganPerhitunganKredit}",""},
//                 //Agunan
//                 // {"{namaAgunan}",coll.CollateralName},
//                 // {"{nilaiPasar}",debtColl.CollateralValue.ToString()},
//                 // {"{nilaiPengikat}",collBind.BindingValue},
//                 {"{jenisStrategi}",""},
//                 {"{catatanStrategi}",""},
//                 {"{potensiRisiko}",""},
//                 {"{mitigasiRisiko}",""},
//                 {"{reviewKolektabilitas}",""},

//                 {"{jenisKredit}",creditApp?.LoanFacilities?.RFFacilityTypes.FacilityTypeName == null ? "[no data]" : creditApp?.LoanFacilities?.RFFacilityTypes.FacilityTypeName},
//                 {"{sublimit}",""},
//                 {"{sifatKredit}",creditApp?.LoanFacilities?.RFCreditSubProducts?.RFCreditNatures.CreditNatureName == null ? "[no data]" : creditApp?.LoanFacilities?.RFCreditSubProducts?.RFCreditNatures.CreditNatureName},
//                 {"{tujuanPenggunaan}",creditApp?.LoanFacilities?.Purpose == null ? "[no data]" : creditApp?.LoanFacilities?.Purpose},
//                 {"{jangkaWaktu}",""},
//                 {"{jangkaWaktuFasilitas}",""},
//                 {"{masaPenarikan}",creditApp?.WithdrawalPeriod.ToString() == null ? "[no data]" : creditApp?.WithdrawalPeriod.ToString()},
//                 {"{gracePeriod}",creditApp?.GracePeriod.ToString() == null ? "[no data]" : creditApp?.GracePeriod.ToString()},
//                 {"{sukuBungaKredit}",creditApp?.InterestMargin.ToString() == null ? "[no data]" : creditApp?.InterestMargin.ToString()},
//                 {"{caraPenarikan}",creditApp?.RFWithdrawalMethods.WithdrawalMethodName == null ? "[no data]" : creditApp?.RFWithdrawalMethods.WithdrawalMethodName},
//                 {"{caraPembayaran}",creditApp?.RFPaymentPatterns.PaymentPatternName == null ? "[no data]" : creditApp?.RFPaymentPatterns.PaymentPatternName},
//                 {"{caraPembayaranBunga}",creditApp?.RFPaymentPatternInterest.PaymentPatternInterestName == null ? "[no data]" : creditApp?.RFPaymentPatternInterest.PaymentPatternInterestName},
//                 {"{caraPengikatan}",creditApp?.RFBindingCredits.BindingCreditName == null ? "[no data]" : creditApp?.RFBindingCredits.BindingCreditName},
//                 {"{provisi}",creditApp?.NominalProvision.ToString() == null ? "[no data]" : creditApp?.NominalProvision.ToString()},
//                 {"{biayaAdministrasi}",creditApp?.AdminFee.ToString() == null ? "[no data]" : creditApp?.AdminFee.ToString()},
//                 {"{biayaNotaris}",""},
//                 {"{dendaDenda}",creditApp?.Fine.ToString() == null ? "[no data]" : creditApp?.Fine.ToString()},
//                 {"{dendaDendaBunga}",creditApp?.FineInterest.ToString() == null ? "[no data]" : creditApp?.FineInterest.ToString()},
//                 {"{commitmentFee}",creditApp?.CommitmentFee.ToString() == null ? "[no data]" : creditApp?.CommitmentFee.ToString()},
//                 {"{asuransiAgunan}",""},
//                 {"{asuransiKredit}",creditApp?.CreditInsurance.ToString() == null ? "[no data]" : creditApp?.CreditInsurance.ToString()},
//                 {"{fixedAsset}",""},
//                 {"{nonFixedAsset}",""},
//                 {"{syaratPenandatangananKredit}",""},
//                 {"{syaratPenarikan}",""},
//                 {"{syaratLainnya}",""},
//                 {"{namaCabang}",userInfo?.NamaCabang == null ? "[no data]" : userInfo?.NamaCabang},
//                 {"{pendapatRekomendasiKetua}",""},
//                 {"{ketuaKomiteKredit}",""},
//                 {"{pendapatRekomendasiPejabat}",""},
//                 {"{pendapatRekomendasiAO}",""}
//             };

//             var TemplateFolder = "/Template";
//             var dirTemp = rootDir + TemplateFolder + "/TemplateMAK.docx";
//             var fileName = "no data";
//             var mak = financePr?.MAK;
//             if (mak != null)
//             {
//                 fileName = mak.Replace("/", "_");
//             }
//             var fileSize = EditDocumentFromTemplate
//                             (
//                                 dirTemp,
//                                 keyValues,
//                                 fileName,
//                                 loanFacilities,
//                                 compManagement,
//                                 syaratPenandatanganan,
//                                 syaratEfektifPenarikan,
//                                 syaratLainnya,
//                                 debtCollFixedAsset,
//                                 debtCollPiutang,
//                                 accDetail2D,
//                                 acc
//                             );
//             var files = await _generateFile.GetByPredicate(x => x.FileName == fileName);
//             if (files != null)
//             {
//                 files.FileName = fileName;
//                 files.FileSize = fileSize;
//                 files.FinancingProposalGuid = financePr.FinancingProposalGuid;
//                 await _generateFile.UpdateAsync(files);
//             }
//             else if (financePr?.FinancingProposalGuid != null)
//             {
//                 var generateFileEntity = new GeneratedFileMAK
//                 {
//                     FileName = fileName,
//                     FileSize = fileSize,
//                     FinancingProposalGuid = financePr.FinancingProposalGuid,
//                     FilePath = link
//                 };
//                 await _generateFile.AddAsync(generateFileEntity);
//             }
//             return ServiceResponse<string>.ReturnResultWith200(link); 
//         }

//         public string EditDocumentFromTemplate
//         (
//             string document,
//             Dictionary<string, string> dict,
//             string newFileName,
//             List<LoanFacilities> loanFacilities,
//             List<CompanyManagements> companyManagement,
//             List<TermAndConditions> syaratPenandatangan,
//             List<TermAndConditions> syaratPenarikan,
//             List<TermAndConditions> syaratLain,
//             List<DebtorCollateral> debtcolFixedAsset,
//             List<DebtorCollateral> debtcolPutang,
//             List<AccountMutationDetails> accDetail2D,
//             List<Accounts> acc
//         )
//         {

//             var resultFolder = $@"{rootDir}/Result/MAK/";
//             if (!Directory.Exists(resultFolder))
//             {
//                 Directory.CreateDirectory(resultFolder.ToString());
//             }
//             var dirRes = $@"{resultFolder}/{newFileName}.docx";

//             link = dirRes;

//             File.Copy(document, dirRes, true);

//             //table fasilitas eksisting
//             using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(dirRes, true))
//             {
//                 // Table tableFasilitasEksisting = new Table();
//                 // var bookmarkStartFasilitasEksisting = wordDoc.MainDocumentPart.Document.Body.Descendants<BookmarkStart>().Where(r => r.Name == "fasilitasEksisting");
//                 // if (bookmarkStartFasilitasEksisting != null)
//                 // {
//                 //     var test  = bookmarkStartFasilitasEksisting.First().Parent.Parent.Parent.Parent;
//                 //     if (test.GetType() == typeof (DocumentFormat.OpenXml.Wordprocessing.Table))

//                 //         tableFasilitasEksisting = (Table)test;
//                 //         var laList = new List<LA>();
//                 //         foreach (var item in loanFacilities)
//                 //         {
//                 //             laList.Add(new LA{
//                 //                 Plafond = item.Plafond,
//                 //                 Tenor = item.Tenor
//                 //             });
//                 //         }
//                 //         for(var i=0; i<laList.Count;i++)
//                 //         {
//                 //                 TableRow tr = new TableRow();
//                 //                 for(var j =0;j<2;j++)
//                 //                 {
//                 //                     if (j == 0)
//                 //                     {
//                 //                         TableCell tc1 = new TableCell(new Paragraph(new Run(new Text(laList[i].Plafond.ToString()))));
//                 //                         tr.Append(tc1);
//                 //                     }else if(j == 1)
//                 //                     {
//                 //                         TableCell tc1 = new TableCell(new Paragraph(new Run(new Text(laList[i].Tenor.ToString()))));
//                 //                         tr.Append(tc1);
//                 //                     }
//                 //                 }
//                 //                 tableFasilitasEksisting.Append(tr);
//                 //         }
//                 // }

//                 //table pengalaman usaha
//                 // Table tablePengalamanUsaha = new Table();
//                 // var bookmarkStartPengalaman = wordDoc.MainDocumentPart.Document.Body.Descendants<BookmarkStart>().Where(r => r.Name == "pengalamanUsaha");
//                 // if (bookmarkStartPengalaman != null)
//                 // {
//                 //     var test = bookmarkStartPengalaman.First().Parent.Parent.Parent.Parent;
//                 //     if (test.GetType() == typeof(Table))
//                 //     {
//                 //         tablePengalamanUsaha = (Table)test;
//                 //         var listPengalaman = new List<PengalamanUsaha>();
//                 //         // foreach (var item in collection)
//                 //         // {

//                 //         // }
//                 //     }
//                 // }

//                 string docText = null;
//                 using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
//                 {
//                     docText = sr.ReadToEnd();
//                 }

//                 foreach (KeyValuePair<string, string> item in dict)
//                 {
//                     Regex regexText = new Regex(item.Key);
//                     docText = regexText.Replace(docText, item.Value);
//                 }


//                 using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
//                 {
//                     sw.Write(docText);
//                 }

//                 int penandatanganan = wordDoc.MainDocumentPart.Document.Body.ToList().IndexOf(wordDoc.MainDocumentPart.Document.Body.Where(p => p.InnerText.Contains("Syarat Penandatanganan Kredit")).First());
//                 if (syaratPenandatangan != null)
//                 {
//                     InsertBulletList(wordDoc.MainDocumentPart.Document.Body, penandatanganan, 1, syaratPenandatangan);
//                 }
//                 int penarikan = wordDoc.MainDocumentPart.Document.Body.ToList().IndexOf(wordDoc.MainDocumentPart.Document.Body.Where(p => p.InnerText.Contains("Syarat Penarikan")).First());
//                 if (syaratPenarikan != null)
//                 {
//                     InsertBulletList(wordDoc.MainDocumentPart.Document.Body, penarikan, 1, syaratPenarikan);
//                 }
//                 int lainnya = wordDoc.MainDocumentPart.Document.Body.ToList().IndexOf(wordDoc.MainDocumentPart.Document.Body.Where(p => p.InnerText.Contains("Syarat Lainnya")).First());
//                 if (syaratLain != null)
//                 {
//                     InsertBulletList(wordDoc.MainDocumentPart.Document.Body, lainnya, 1, syaratLain);
//                 }

//                 //tabel susunan pengurus
//                 Table tableSusunanPengurus = new Table();
//                 var bookmarkStartPengurus = wordDoc.MainDocumentPart.Document.Body.Descendants<BookmarkStart>().Where(r => r.Name == "susunanPengurus");
//                 if (bookmarkStartPengurus != null)
//                 {
//                     var test = bookmarkStartPengurus.First().Parent.Parent.Parent.Parent;
//                     if (test.GetType() == typeof(DocumentFormat.OpenXml.Wordprocessing.Table))

//                         tableSusunanPengurus = (Table)test;
//                     var newList = new List<SusunanPengurus>();
//                     foreach (var item in companyManagement)
//                     {
//                         newList.Add(new SusunanPengurus
//                         {
//                             NamaPengurus = item.Name,
//                             Jabatan = item.Position
//                         });
//                     }
//                     for (int i = 0; i < newList.Count; i++)
//                     {
//                         TableRow tr = new TableRow();
//                         for (int j = 0; j < 2; j++)
//                         {
//                             if (j == 0)
//                             {
//                                 TableCell tc1 = textCell(newList[i].NamaPengurus);
//                                 tr.Append(tc1);
//                             }
//                             else if (j == 1)
//                             {
//                                 TableCell tc2 = textCell(newList[i].Jabatan);
//                                 tr.Append(tc2);
//                             }
//                         }
//                         tableSusunanPengurus.Append(tr);
//                     }
//                 }

//                 //table KTP pengurus
//                 Table tableKTPPengurus = new Table();
//                 var bookmarkStartKtp = wordDoc.MainDocumentPart.Document.Body.Descendants<BookmarkStart>().Where(r => r.Name == "ktpPengurus");
//                 if (bookmarkStartKtp != null)
//                 {
//                     var test = bookmarkStartKtp.First().Parent.Parent.Parent.Parent;
//                     if (test.GetType() == typeof(Table))
//                     {
//                         tableKTPPengurus = (Table)test;
//                         var listKtp = new List<KTPPengurus>();
//                         foreach (var item in companyManagement)
//                         {
//                             listKtp.Add(new KTPPengurus
//                             {
//                                 Nama = item.Name,
//                                 Jabatan = item.Position,
//                                 NoKTP = item.IDCard,
//                                 NoNPWP = item.NPWP
//                             });
//                         }
//                         for (int i = 0; i < listKtp.Count; i++)
//                         {
//                             TableRow tr = new TableRow();
//                             for (int j = 0; j < 4; j++)
//                             {

//                                 switch (j)
//                                 {
//                                     case 0:
//                                         TableCell tc1 = textCell(listKtp[i].Nama);
//                                         tr.Append(tc1);
//                                         break;
//                                     case 1:
//                                         TableCell tc2 = textCell(listKtp[i].Jabatan);
//                                         tr.Append(tc2);
//                                         break;
//                                     case 2:
//                                         TableCell tc3 = textCell(listKtp[i].NoKTP);
//                                         tr.Append(tc3);
//                                         break;
//                                     case 3:
//                                         TableCell tc4 = textCell(listKtp[i].NoNPWP);
//                                         tr.Append(tc4);
//                                         break;
//                                     default:
//                                         break;
//                                 }
//                             }
//                             tableKTPPengurus.Append(tr);
//                         }
//                     }
//                 }

//                 //table agunan dan coverage
//                 Table tableAgunan = new Table();
//                 var bookmarkStartCol = wordDoc.MainDocumentPart.Document.Body.Descendants<BookmarkStart>().Where(r => r.Name == "agunandanCoverage");
//                 if (bookmarkStartCol != null)
//                 {
//                     var tab = bookmarkStartCol.First().Parent.Parent.Parent.Parent;
//                     if (tab.GetType() == typeof(Table))
//                     {
//                         tableAgunan = (Table)tab;
//                         var listCol = new List<AgunanCoverage>();
//                         TableRow header1 = new TableRow();
//                         for (int j = 0; j < 7; j++)
//                         {
//                             switch (j)
//                             {
//                                 case 0:
//                                     TableCell tc1 = textCell("A.");
//                                     header1.Append(tc1);
//                                     break;
//                                 case 1:
//                                     TableCell tc2 = textCell("Fixed Asset & Deposito");
//                                     header1.Append(tc2);
//                                     break;
//                                 case 2:
//                                     TableCell tc3 = textCell("");
//                                     header1.Append(tc3);
//                                     break;
//                                 case 3:
//                                     TableCell tc4 = textCell("");
//                                     header1.Append(tc4);
//                                     break;
//                                 case 4:
//                                     TableCell tc5 = textCell("");
//                                     header1.Append(tc5);
//                                     break;
//                                 case 5:
//                                     TableCell tc6 = textCell("");
//                                     header1.Append(tc6);
//                                     break;
//                                 case 6:
//                                     TableCell tc7 = textCell("");
//                                     header1.Append(tc7);
//                                     break;
//                                 default:
//                                     break;
//                             }
//                         }
//                         tableAgunan.Append(header1);

//                         foreach (var item in debtcolFixedAsset)
//                         {
//                             listCol.Add(new AgunanCoverage
//                             {
//                                 agunan = item.RfCollateral.Description,
//                                 uraian = item.NoOwnershipProof,
//                                 nilaiPasar = "",
//                                 nilaiLikuidasi = "",
//                                 nilaiPengikat = "",
//                                 komposisiCoverage = ""
//                             });
//                             for (int i = 0; i < listCol.Count; i++)
//                             {
//                                 TableRow tr = new TableRow();
//                                 for (int j = 0; j < 7; j++)
//                                 {
//                                     switch (j)
//                                     {
//                                         case 0:
//                                             TableCell tc1 = textCell((i + 1).ToString());
//                                             tr.Append(tc1);
//                                             break;
//                                         case 1:
//                                             TableCell tc2 = textCell(listCol[i].agunan);
//                                             tr.Append(tc2);
//                                             break;
//                                         case 2:
//                                             TableCell tc3 = textCell(listCol[i].uraian);
//                                             tr.Append(tc3);
//                                             break;
//                                         case 3:
//                                             TableCell tc4 = textCell(listCol[i].nilaiPasar);
//                                             tr.Append(tc4);
//                                             break;
//                                         case 4:
//                                             TableCell tc5 = textCell(listCol[i].nilaiLikuidasi);
//                                             tr.Append(tc5);
//                                             break;
//                                         case 5:
//                                             TableCell tc6 = textCell(listCol[i].nilaiPengikat);
//                                             tr.Append(tc6);
//                                             break;
//                                         case 6:
//                                             TableCell tc7 = textCell(listCol[i].komposisiCoverage);
//                                             tr.Append(tc7);
//                                             break;
//                                         default:
//                                             break;
//                                     }
//                                 }
//                                 tableAgunan.Append(tr);
//                             }
//                         }
//                         TableRow total = new TableRow();
//                         for (int j = 0; j < 7; j++)
//                         {
//                             switch (j)
//                             {
//                                 case 0:
//                                     TableCell tc1 = textCell("");
//                                     total.Append(tc1);
//                                     break;
//                                 case 1:
//                                     TableCell tc2 = textCell("Total Nilai Jaminan fixed asset + deposito");
//                                     total.Append(tc2);
//                                     break;
//                                 case 2:
//                                     TableCell tc3 = textCell("");
//                                     total.Append(tc3);
//                                     break;
//                                 case 3:
//                                     TableCell tc4 = textCell("");
//                                     total.Append(tc4);
//                                     break;
//                                 case 4:
//                                     TableCell tc5 = textCell("");
//                                     total.Append(tc5);
//                                     break;
//                                 case 5:
//                                     TableCell tc6 = textCell("");
//                                     total.Append(tc6);
//                                     break;
//                                 case 6:
//                                     TableCell tc7 = textCell("");
//                                     total.Append(tc7);
//                                     break;
//                                 default:
//                                     break;
//                             }
//                         }
//                         tableAgunan.Append(total);

//                         TableRow header = new TableRow();
//                         for (int j = 0; j < 7; j++)
//                         {
//                             switch (j)
//                             {
//                                 case 0:
//                                     TableCell tc1 = textCell("B.");
//                                     header.Append(tc1);
//                                     break;
//                                 case 1:
//                                     TableCell tc2 = textCell("Persediaan dan Piutang");
//                                     header.Append(tc2);
//                                     break;
//                                 case 2:
//                                     TableCell tc3 = textCell("");
//                                     header.Append(tc3);
//                                     break;
//                                 case 3:
//                                     TableCell tc4 = textCell("");
//                                     header.Append(tc4);
//                                     break;
//                                 case 4:
//                                     TableCell tc5 = textCell("");
//                                     header.Append(tc5);
//                                     break;
//                                 case 5:
//                                     TableCell tc6 = textCell("");
//                                     header.Append(tc6);
//                                     break;
//                                 case 6:
//                                     TableCell tc7 = textCell("");
//                                     header.Append(tc7);
//                                     break;
//                                 default:
//                                     break;
//                             }
//                         }
//                         tableAgunan.Append(header);

//                         foreach (var item2 in debtcolPutang)
//                         {
//                             listCol.Add(new AgunanCoverage
//                             {
//                                 agunan = item2.RfCollateral.Description,
//                                 uraian = item2.NoOwnershipProof,
//                                 nilaiPasar = "",
//                                 nilaiLikuidasi = "",
//                                 nilaiPengikat = "",
//                                 komposisiCoverage = ""
//                             });
//                             for (int a = 0; a < listCol.Count; a++)
//                             {
//                                 TableRow tr2 = new TableRow();
//                                 for (int j = 0; j < 7; j++)
//                                 {
//                                     switch (j)
//                                     {
//                                         case 0:
//                                             TableCell tc1 = textCell((a + 1).ToString());
//                                             tr2.Append(tc1);
//                                             break;
//                                         case 1:
//                                             TableCell tc2 = textCell(listCol[a].agunan);
//                                             tr2.Append(tc2);
//                                             break;
//                                         case 2:
//                                             TableCell tc3 = textCell(listCol[a].uraian);
//                                             tr2.Append(tc3);
//                                             break;
//                                         case 3:
//                                             TableCell tc4 = textCell(listCol[a].nilaiPasar);
//                                             tr2.Append(tc4);
//                                             break;
//                                         case 4:
//                                             TableCell tc5 = textCell(listCol[a].nilaiLikuidasi);
//                                             tr2.Append(tc5);
//                                             break;
//                                         case 5:
//                                             TableCell tc6 = textCell(listCol[a].nilaiPengikat);
//                                             tr2.Append(tc6);
//                                             break;
//                                         case 6:
//                                             TableCell tc7 = textCell(listCol[a].komposisiCoverage);
//                                             tr2.Append(tc7);
//                                             break;
//                                         default:
//                                             break;
//                                     }
//                                 }
//                                 tableAgunan.Append(tr2);

//                                 TableRow total1 = new TableRow();
//                                 for (int j = 0; j < 7; j++)
//                                 {
//                                     switch (j)
//                                     {
//                                         case 0:
//                                             TableCell tc1 = textCell("");
//                                             total1.Append(tc1);
//                                             break;
//                                         case 1:
//                                             TableCell tc2 = textCell("Total Nilai Jaminan Persediaan + Piutang");
//                                             total1.Append(tc2);
//                                             break;
//                                         case 2:
//                                             TableCell tc3 = textCell("");
//                                             total1.Append(tc3);
//                                             break;
//                                         case 3:
//                                             TableCell tc4 = textCell("");
//                                             total1.Append(tc4);
//                                             break;
//                                         case 4:
//                                             TableCell tc5 = textCell("");
//                                             total1.Append(tc5);
//                                             break;
//                                         case 5:
//                                             TableCell tc6 = textCell("");
//                                             total1.Append(tc6);
//                                             break;
//                                         case 6:
//                                             TableCell tc7 = textCell("");
//                                             total.Append(tc7);
//                                             break;
//                                         default:
//                                             break;
//                                     }
//                                 }
//                                 tableAgunan.Append(total1);

//                                 TableRow total2 = new TableRow();
//                                 for (int j = 0; j < 7; j++)
//                                 {
//                                     switch (j)
//                                     {
//                                         case 0:
//                                             TableCell tc1 = textCell("");
//                                             total2.Append(tc1);
//                                             break;
//                                         case 1:
//                                             TableCell tc2 = textCell("Total Nilai Jaminan");
//                                             total2.Append(tc2);
//                                             break;
//                                         case 2:
//                                             TableCell tc3 = textCell("");
//                                             total2.Append(tc3);
//                                             break;
//                                         case 3:
//                                             TableCell tc4 = textCell("");
//                                             total2.Append(tc4);
//                                             break;
//                                         case 4:
//                                             TableCell tc5 = textCell("");
//                                             total2.Append(tc5);
//                                             break;
//                                         case 5:
//                                             TableCell tc6 = textCell("");
//                                             total2.Append(tc6);
//                                             break;
//                                         case 6:
//                                             TableCell tc7 = textCell("");
//                                             total2.Append(tc7);
//                                             break;
//                                         default:
//                                             break;
//                                     }
//                                 }
//                                 tableAgunan.Append(total2);

//                             }

//                         }
//                     }
//                 }

//                     var tableBankRelationPlaceholder = wordDoc.MainDocumentPart.Document.Body.Descendants<Paragraph>().Where(x => x.InnerText.Equals("{placeholderBankRelation}")).FirstOrDefault();
//                     // var placeholder = tableBankRelationPlaceholder.FirstOrDefault();
//                     if (tableBankRelationPlaceholder != null)
//                     {
//                         tableBankRelationPlaceholder.RemoveAllChildren<Run>();
//                         tableBankRelationPlaceholder.InsertAfterSelf(new Paragraph(new Run(new Text(acc[0].AccountGuid.ToString()))));
//                         for (int i = 0; i < acc.Count; i++)
//                         {
//                             var tableKeyPlaceholder = wordDoc.MainDocumentPart.Document.Body.Descendants<Paragraph>().Where(x => x.InnerText.Equals(acc[i].AccountGuid.ToString())).FirstOrDefault();
//                             Table table = Globals.createTableBankRelation(accDetail2D, acc[i]);
//                             tableKeyPlaceholder.InsertAfterSelf(table);
//                             // tableKeyPlaceholder.AppendChild<Run>(new Run(new Text("")));
//                             tableKeyPlaceholder.RemoveAllChildren<Run>();
//                             if (i != 0 )
//                             {
//                                 tableKeyPlaceholder.AppendChild<Run>(new Run(new Break()));
//                             }
//                             tableKeyPlaceholder.AppendChild<Run>(new Run(new Text("     ")));
//                             tableKeyPlaceholder.AppendChild<Run>(new Run(new Text(acc[i].AccountName)));

//                             var tablePlaceholder = table.InnerXml;
//                             var findTable = wordDoc.MainDocumentPart.Document.Body.Descendants<Table>().Where(x => x.InnerXml == tablePlaceholder).LastOrDefault();
//                             if (findTable != null && i < acc.Count - 1 )
//                             {
//                                 var pPr = new ParagraphProperties() {
//                                     SpacingBetweenLines = new SpacingBetweenLines() { After="0" }
//                                 };
//                                 findTable.InsertAfterSelf(new Paragraph(pPr, new Run(new Text(acc[i+1].AccountGuid.ToString()))));
//                             }
//                             // tableBankRelationPlaceholder.InsertAfterSelf(new Paragraph(new Run(new Text(acc[1].AccountGuid.ToString()))));
//                     }
//                 }
                
//                 System.IO.FileInfo fileInfo = new System.IO.FileInfo(dirRes);
//                 long bsize = fileInfo.Length;
//                 long kbsize = bsize / 1000;
//                 string finalSize = kbsize + "kb";

//                 return finalSize;
//             }
//         }

//         public static void InsertBulletList(Body wordDocumentBody, int insertindex, int style, List<TermAndConditions> data)
//         {
//             foreach (var item in data)
//             {
//                 Paragraph pr = wordDocumentBody.InsertAt(new Paragraph(), insertindex + 1);
//                 ParagraphProperties paragraphProperties = new ParagraphProperties();
//                 paragraphProperties.Append(new ParagraphStyleId() { Val = "ListParagraph" });
//                 paragraphProperties.Append(new NumberingProperties(
//                     new NumberingLevelReference() { Val = 0 },
//                     new NumberingId() { Val = style }
//                 ));
//                 var temp = item.Criteria.Replace("<p>", "");
//                 var crit = temp.Replace("</p>", "");
//                 pr.Append(paragraphProperties);
//                 pr.Append(new Run(
//                     new RunProperties(
//                         new RunStyle() { Val = "ListParagraph" },
//                         new NoProof(),
//                         new FontSize() { Val = "20" }
//                     ),
//                     new Text($"{crit}")
//                 ));
//                 insertindex++;
//             }
//         }
//         public TableCell textCell(string value)
//         {
//             TableCell tc2 = new TableCell();
//             Paragraph pr = new Paragraph();
//             Run run = new Run();
//             Text text = new Text(value);
//             RunProperties runProperties1 = new RunProperties();
//             FontSize fontSize1 = new FontSize() { Val = "20" };
//             runProperties1.Append(fontSize1);
//             run.Append(runProperties1);
//             run.Append(text);
//             pr.Append(run);
//             tc2.Append(pr);

//             return tc2;
//         }
//     }
//     public class LA
//     {
//         public double Plafond { get; set; }
//         public int Tenor { get; set; }
//     }

//     public class SusunanPengurus
//     {
//         public string NamaPengurus { get; set; }
//         public string Jabatan { get; set; }
//     }
//     public class RatingDebitur
//     {
//         public DateTime TanggalRating { get; set; }
//         public string RatingDebtor { get; set; }
//         public string FasilitasRating { get; set; }
//         public string RatingProyek { get; set; }
//     }

//     public class DataObligor
//     {
//         public string Nama { get; set; }
//         public string Fasilitas { get; set; }
//         public double Plafond { get; set; }
//         public double Bunga { get; set; }
//         public double Tenor { get; set; }
//         public string Agunan { get; set; }
//     }

//     public class KTPPengurus
//     {
//         public string Nama { get; set; }
//         public string Jabatan { get; set; }
//         public string NoKTP { get; set; }
//         public string NoNPWP { get; set; }
//     }

//     public class PengalamanUsaha
//     {
//         public string Tahun { get; set; }
//         public string PelaksanaPekerjaan { get; set; }
//         public string JenisPekerjaan { get; set; }
//         public string SumberData { get; set; }
//         public string Bouwheer { get; set; }
//         public string NilaiProyek { get; set; }
//     }

//     public class InformasiSuplier
//     {
//         public string NamaSupPlier { get; set; }
//         public string Barang { get; set; }
//         public string Alamat { get; set; }
//     }

//     public class SaranaPrasarana
//     {
//         public string JenisPeralatan { get; set; }
//         public int jumlah { get; set; }
//         public string Kapasitas { get; set; }
//         public string Kondisi { get; set; }
//         public string Lokasi { get; set; }
//         public string BuktiKepemilikan { get; set; }
//     }

//     public class AgunanCoverage
//     {
//         public string agunan { get; set; }
//         public string uraian { get; set; }
//         public string nilaiPasar { get; set; }
//         public string nilaiLikuidasi { get; set; }
//         public string nilaiPengikat { get; set; }
//         public string komposisiCoverage { get; set; }
//     }
//     public class PemilikRekening
//     {
//         public string NamaBank {get;set;}
//         public string Debit {get;set;}
//         public string FrekuensiDebit {get;set;}
//         public string Kredit {get;set;}
//         public string FrekuensiKredit {get;set;}
//         public string SaldoAkhir {get;set;}
//         public string owner {get;set;}

//     }
// }