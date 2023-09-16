// using System.Collections.Generic;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using MediatR;
// using Microsoft.Extensions.Configuration;
// using NewLMS.UMKM.Data.Entities;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System.IO;
// using DocumentFormat.OpenXml.Packaging;
// using System.Text.RegularExpressions;
// using System.Globalization;
// using Bjb.DigitalBisnis.FileUpload;

// namespace NewLMS.UMKM.MediatR.Features.Appraisals.Commands.GenerateBeritaAcara
// {
//     public class GenerateBeritaAcara : IRequest<ServiceResponse<string>>
//     {
//         public Guid LoanApplicationGuid { get; set; }
//     }
//     public class GenerateBeritaAcaraHandler : IRequestHandler<GenerateBeritaAcara, ServiceResponse<string>>
//     {
//         public string filePath = "";
//         private readonly IGenericRepositoryAsync<GeneratedFiles> _generatedFile;
//         private readonly IGenericRepositoryAsync<LoanApplications> _loanApplication;
//         private readonly IGenericRepositoryAsync<Collaterals> _collateral;
//         private readonly IGenericRepositoryAsync<DebtorCollateral> _debtorCollateral;
//         private readonly IGenericRepositoryAsync<CompanyAddress> _companyAddress;
//         private readonly IGenericRepositoryAsync<Appraisal> _appraisal;
//         private readonly IGenericRepositoryAsync<User> _user;
//         private readonly IGenericRepositoryAsync<UserRole> _userRole;
//         private readonly IConfiguration _appConfig;
//         private readonly IUploadService _uploadService;

//         public GenerateBeritaAcaraHandler
//         (
//             IGenericRepositoryAsync<Collaterals> collateral,
//             IGenericRepositoryAsync<GeneratedFiles> generatedFile,
//             IGenericRepositoryAsync<LoanApplications> loanApplication,
//             IGenericRepositoryAsync<DebtorCollateral> debtorCollateral,
//             IGenericRepositoryAsync<CompanyAddress> companyAddress,
//             IGenericRepositoryAsync<Appraisal> appraisal,
//             IGenericRepositoryAsync<User> user,
//             IGenericRepositoryAsync<UserRole> userRole,
//             IConfiguration appConfig,
//             IUploadService uploadService
//         )
//         {
//             _collateral = collateral;
//             _generatedFile = generatedFile;
//             _loanApplication = loanApplication;
//             _debtorCollateral = debtorCollateral;
//             _companyAddress = companyAddress;
//             _appraisal = appraisal;
//             _user = user;
//             _userRole = userRole;
//             _appConfig = appConfig;
//             _uploadService = uploadService;
//         }

//         string rootDir => "Directory" switch
//         {
//             "Directory" => _appConfig.GetValue<string>("CommercialStorage:Directory"),
//             _ => throw new NotSupportedException()
//         };
//         public async Task<ServiceResponse<string>> Handle(GenerateBeritaAcara request, CancellationToken cancellationToken)
//         {
//             var generatedFileEntity = new GeneratedFiles();
//             var include = new string[]
//             {
//                 "LoanApplications",
//                 "LoanApplications.Debtors",
//             };
//             var includeDebtColl = new string[]
//             {
//                 "RfCollateral",
//                 "RfPledge",
//                 "Appraisals",
//                 "Debtors"
//             };
//             var includeLoan = new string[]
//             {
//                 "Debtors"
//             };
//             CultureInfo idID = new CultureInfo("id-ID");
//             Appraisal appr = new();
//             User usr = new();
//             var dateNow = DateTime.Now.ToString("dd MMMM yyyy");
//             var day = DateTime.Now.ToString("dddd");
//             // var dateNow = DateTime.Now.ToString("dd MMMM yyyy", idID);
//             // var day = DateTime.Now.ToString("dddd",idID);
//             var coll = await _collateral.GetByIdAsync(request.LoanApplicationGuid, "LoanApplicationGuid", include);
//             var loanApp = await _loanApplication.GetByIdAsync(request.LoanApplicationGuid, "LoanApplicationGuid", includeLoan);
//             var debtColl = await _debtorCollateral.GetByIdAsync(loanApp.DebtorGuid, "DebtorGuid", includeDebtColl);
//             if (debtColl != null)
//             {
//                 appr = await _appraisal.GetByIdAsync(debtColl.DebtorCollateralGuid, "DebtorCollateralGuid");
//                 if (appr != null)
//                 {
//                     usr = await _user.GetByPredicate(x => x.UserId == appr.Estimator);
//                 }
//             }
//             var compAddress = await _companyAddress.GetByIdAsync(loanApp.DebtorGuid, "DebtorGuid");
//             Dictionary<string, string> keyValues = new Dictionary<string, string>()
//             {
//                 {"{hari}",day ?? "[no data]"},
//                 {"{tanggal}",dateNow ?? "[no data]"},
//                 {"{namaBl}",usr?.Nama ?? "[no data]"},
//                 {"{nip}",usr?.Nip ?? "[no data]"},
//                 {"{jabatan}",usr?.Jabatan ?? "[no data]"},
//                 // {"{bertindakSelaku1}",},
//                 {"{namaDebitur}",debtColl?.Debtors?.CompanyName ?? "[no data]"},
//                 {"{alamatDebitur}",compAddress?.Address ?? "[no data]"},
//                 {"{noNPWP}",coll?.LoanApplications?.Debtors?.NPWP ?? "[no data]"},
//                 // {"{bertindakSelaku2}",},
//                 {"{jenisAgunan}",debtColl?.RfCollateral.Description ?? "[no data]"},
//                 {"{rincianAgunan}",debtColl?.RfPledge.PledgeTypeDesc ?? "[no data]"}
//             };
//             var tempalteFolder = "/Template";
//             var templateDir = rootDir + tempalteFolder + "/TemplateBAPAppraisal.docx";
//             var fileName = "Berita_Acara_Pemeriksaan_Setempat_Appraisal_Assignment";

//             filePath = GenerateWordFromTemplate(
//                 templateDir,
//                 keyValues,
//                 fileName
//             );
//             System.IO.FileInfo fileInfo = new System.IO.FileInfo(filePath);
//             long bsize = fileInfo.Length;
//             long kbsize = bsize / 1000;
//             string finalSize = kbsize + "kb";
//             var fileByte = File.ReadAllBytes(filePath);
//             var FolderName = "UMKM/generatefiles/" + $"{loanApp.LoanApplicationId}{"_"}{loanApp.Debtors.CompanyName.Replace(" ", "-")}";
//             var FileTemplate = $"{"Berita_Acara"}_{loanApp.LoanApplicationId}.docx";
//             var upload = await _uploadService.GenerateFileWord(new GenerateFileRequestModel
//             {
//                 Segment = "UMKM",
//                 DebtorName = loanApp.Debtors.CompanyName.Replace(" ", "-"),
//                 FileTemplate = $"{"Berita_Acara"}",
//                 File = fileByte,
//                 LoanApplicationId = loanApp.LoanApplicationId
//             });
//             var result = Path.Combine(FolderName, FileTemplate).Replace(@"\", @"/").Replace(@"\\", @"/");
//             var link = result;
//             File.Delete(filePath);
//             generatedFileEntity = new GeneratedFiles
//             {
//                 GeneratedFileGuid = Guid.NewGuid(),
//                 LoanApplicationGuid = request.LoanApplicationGuid,
//                 FileName = fileInfo.Name,
//                 FilePath = link,
//                 FileSize = finalSize,
//                 GeneratedFileGroupGuid = Guid.Parse("308828f2-3954-41ab-a516-4baa2a298af7")
//             };
//             await _generatedFile.AddAsync(generatedFileEntity);
//             return ServiceResponse<string>.ReturnResultWith200(link);
//         }

//         public string GenerateWordFromTemplate(
//             string document,
//             Dictionary<string, string> dict,
//             string newFileName)
//         {
//             var resultFolder = $@"{rootDir}/Result/BeritaAcara";
//             if (!Directory.Exists(resultFolder))
//             {
//                 Directory.CreateDirectory(resultFolder.ToString());
//             }
//             var resultDir = $@"{resultFolder}/{newFileName}.docx";

//             File.Copy(document, resultDir, true);

//             using WordprocessingDocument wordDoc = WordprocessingDocument.Open(resultDir, true);
//             {
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
//             }
//             return resultDir;
//         }
//     }
// }