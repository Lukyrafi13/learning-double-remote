using System.Collections.Generic;
using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Configuration;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using System.Text.RegularExpressions;
using System.Globalization;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Data;
using DocumentFormat.OpenXml.Office.CoverPageProps;
using Bjb.DigitalBisnis.CurrentUser.Interfaces;
using Bjb.DigitalBisnis.FileUpload.Interfaces;
using Bjb.DigitalBisnis.FileUpload.Models;

namespace NewLMS.Umkm.MediatR.Features.Appraisals.Commands.GenerateSuratTugas
{
    public class GenerateSuratTugas : IRequest<ServiceResponse<string>>
    {
        public Guid LoanApplicationCollateralId { get; set; }
    }
    public class GenerateSuratTugasHandler : IRequestHandler<GenerateSuratTugas, ServiceResponse<string>>
    {
        public string filePath = "";
        private readonly IGenericRepositoryAsync<GeneratedFiles> _generatedFile;
        private readonly IGenericRepositoryAsync<LoanApplicationCollateralOwner> _loanApplicationcollateralowner;
        private readonly IGenericRepositoryAsync<LoanApplicationAppraisal> _loanApplicationappraisal;
        private readonly IGenericRepositoryAsync<User> _user;
        private readonly IConfiguration _appConfig;
        private readonly IUploadService _uploadService;
        private readonly ICurrentUserService _userService;


        public GenerateSuratTugasHandler
        (
            IGenericRepositoryAsync<LoanApplicationCollateralOwner> loanApplicationcollateralowner,
            IGenericRepositoryAsync<LoanApplicationAppraisal> loanApplicationappraisal,
            IGenericRepositoryAsync<GeneratedFiles> generatedFile,
            IGenericRepositoryAsync<User> user,
            IConfiguration appConfig,
            IUploadService uploadService,
            ICurrentUserService userService
        )
        {
            _loanApplicationcollateralowner = loanApplicationcollateralowner;
            _loanApplicationappraisal = loanApplicationappraisal;
            _generatedFile = generatedFile;
            _user = user;
            _appConfig = appConfig;
            _uploadService = uploadService;
            _userService = userService;
        }

        string rootDir => "Directory" switch
        {
            "Directory" => _appConfig.GetValue<string>("ConsumerStorage:Directory"),
            _ => throw new NotSupportedException()
        };
        public async Task<ServiceResponse<string>> Handle(GenerateSuratTugas request, CancellationToken cancellationToken)
        {
            var includes = new string[]
            {
                "LoanApplicationCollateral",
                "LoanApplicationCollateral.LoanApplication",
                "LoanApplicationCollateral.LoanApplication.Debtor",
                "LoanApplicationCollateral.RfCollateralBC",
                "LoanApplicationCollateral.RfDocument",
            };
            User usr = new();
            var generatedFileEntity = new GeneratedFiles();
            var dateNow = DateTime.Now.ToString("dd MMMM yyyy");
            //var day = DateTime.Now.ToString("dddd");
            var coll = await _loanApplicationcollateralowner.GetByIdAsync(request.LoanApplicationCollateralId, "Id", includes);
            var appr = await _loanApplicationappraisal.GetByIdAsync(request.LoanApplicationCollateralId, "LoanApplicationCollateralId");
            usr = await _user.GetByPredicate(x => x.UserId == appr.Estimator); 


            Dictionary<string, string> keyValues = new Dictionary<string, string>()
            {
                {"{tanggal}",dateNow ?? "[no data]"},
                {"{namaAgunan}",coll?.OwnerName ?? "[no data]"},
                {"{namaBl}",usr.Nama ?? "[no data]"},
                {"{jabatan}",usr.Jabatan ?? "[no data]"},
                {"{nip}",_userService?.NIP ?? "[no data]"},
                {"{jenisAgunan}", coll?.LoanApplicationCollateral.RfCollateralBC.CollateralDesc ??"[no data]"},
                {"{noDokumen}", coll?.LoanApplicationCollateral.DocumentNumber ??"[no data]"},
                {"{dokumen}", coll?.LoanApplicationCollateral.RfDocument.DocumentDesc ??"[no data]"},
                {"{alamatAgunan}", coll?.Address ??"[no data]"},
                {"{noNPWP}",coll?.OwnerNPWP ?? "[no data]"},
                {"{cabang}",_userService?.BranchName ?? "[no data]"},
                {"{namaOOK}",_userService?.Fullname?? "[no data]"}
            };
            var tempalateFolder = "/templates";
            var templateDir = rootDir + tempalateFolder + "/TemplatePeninjauan.docx";
            var fileName = "Surat_Tugas_Peninjauan_Agunan_Appraisal_Surveyor";

            filePath = GenerateWordFromTemplate(
                templateDir,
                keyValues,
                fileName
            );
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(filePath);
            long bsize = fileInfo.Length;
            long kbsize = bsize / 1000;
            string finalSize = kbsize + "kb";
            var fileByte = File.ReadAllBytes(filePath);
            var FolderName = "UMKM/generatefiles/" + $"{coll.LoanApplicationCollateral?.LoanApplication?.LoanApplicationId}{"_"}{coll.LoanApplicationCollateral?.LoanApplication?.Debtor?.Fullname.Replace(" ", "-")}";
            var FileTemplate = $"{"Surat_Tugas"}_{coll.LoanApplicationCollateral?.LoanApplication?.LoanApplicationId}.docx";
            var upload = await _uploadService.GenerateFileWord(new GenerateFileRequestModel
            {
                Segment = "umkm",
                DebtorName = coll.LoanApplicationCollateral.LoanApplication.Debtor.Fullname.Replace(" ", "-"),
                FileTemplate = $"{"berita_acara"}",
                File = fileByte,
                LoanApplicationId = coll.LoanApplicationCollateral.LoanApplication.LoanApplicationId,
            });
            var result = Path.Combine(FolderName, FileTemplate).Replace(@"\", @"/").Replace(@"\\", @"/");
            var link = result;
            //File.Delete(filePath);

            var generatedFile = await _generatedFile.GetByPredicate(x => x.FileName == fileInfo.Name);
            if(generatedFile != null)
            {
                generatedFile.FileName = fileInfo.Name;
                generatedFile.FilePath = link;
                generatedFile.FileSize = finalSize;

                await _generatedFile.UpdateAsync(generatedFile);
            }
            generatedFileEntity = new GeneratedFiles
            {
                GeneratedFileGuid = Guid.NewGuid(),
                LoanApplicationGuid = coll.LoanApplicationCollateral.LoanApplication.Id,
                FileName = fileInfo.Name,
                FilePath = link,
                FileSize = finalSize,
                GeneratedFileGroupGuid = Guid.Parse("308828f2-3954-41ab-a516-4baa2a298af7")
            };
            await _generatedFile.AddAsync(generatedFileEntity);
            return ServiceResponse<string>.ReturnResultWith200(link);
        }

        public string GenerateWordFromTemplate(
            string document,
            Dictionary<string, string> dict,
            string newFileName)
        {
            var resultFolder = $@"{rootDir}/Result/SuratTugas";
            if (!Directory.Exists(resultFolder))
            {
                Directory.CreateDirectory(resultFolder.ToString());
            }
            var resultDir = $@"{resultFolder}/{newFileName}.docx";

            File.Copy(document, resultDir, true);

            using WordprocessingDocument wordDoc = WordprocessingDocument.Open(resultDir, true);
            {
                string docText = null;
                using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                {
                    docText = sr.ReadToEnd();
                }
                foreach (KeyValuePair<string, string> item in dict)
                {
                    Regex regexText = new Regex(item.Key);
                    docText = regexText.Replace(docText, item.Value);
                }

                using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                {
                    sw.Write(docText);
                }
            }
            return resultDir;
        }
    }
}