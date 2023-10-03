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
using NewLMS.Umkm.Data;
using Bjb.DigitalBisnis.FileUpload.Interfaces;
using Bjb.DigitalBisnis.FileUpload.Models;
using NewLMS.Umkm.Common.GenericRespository;

namespace NewLMS.Umkm.MediatR.Features.Appraisals.Commands.GenerateBeritaAcara
{
    public class GenerateBeritaAcara : IRequest<ServiceResponse<string>>
    {
        public Guid LoanApplicationCollateralId { get; set; }
    }
    public class GenerateBeritaAcaraHandler : IRequestHandler<GenerateBeritaAcara, ServiceResponse<string>>
    {
        public string filePath = "";
        private readonly IGenericRepositoryAsync<GeneratedFiles> _generatedFile;
        private readonly IGenericRepositoryAsync<LoanApplicationCollateralOwner> _loanApplicationcollateralowner;
        private readonly IGenericRepositoryAsync<LoanApplicationAppraisal> _loanApplicationappraisal;
        private readonly IGenericRepositoryAsync<User> _user;
        private readonly IConfiguration _appConfig;
        private readonly IUploadService _uploadService;
        private readonly ICurrentUserService _userService;


        public GenerateBeritaAcaraHandler
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
        public async Task<ServiceResponse<string>> Handle(GenerateBeritaAcara request, CancellationToken cancellationToken)
        {
            var includes = new string[]
            {
                "LoanApplicationCollateral",
                "LoanApplicationCollateral.LoanApplication",
                "LoanApplicationCollateral.LoanApplication.Debtor"
            };
            User usr = new();
            var generatedFileEntity = new GeneratedFiles();
            var dateNow = DateTime.Now.ToString("dd MMMM yyyy");
            //var day = DateTime.Now.ToString("dddd");
            var coll = await _loanApplicationcollateralowner.GetByIdAsync(request.LoanApplicationCollateralId, "Id",includes);

            Dictionary<string, string> keyValues = new Dictionary<string, string>()
            {
                {"{tanggal}",dateNow ?? "[no data]"},
                {"{namaBl}",_userService?.Fullname ?? "[no data]"},
                {"{nip}",_userService?.NIP ?? "[no data]"},
                {"{jabatan}",_userService?.PositionName ?? "[no data]"},
                // {"{bertindakSelaku1}",},
                {"{namaAgunan}",coll?.OwnerName ?? "[no data]"},
                {"{alamatAgunan}", coll?.Address ??"[no data]"},
                {"{noNPWP}",coll?.OwnerNPWP ?? "[no data]"},
                // {"{bertindakSelaku2}",},
            };
            var tempalateFolder = "/templates";
            var templateDir = rootDir + tempalateFolder + "/TemplateBAPAppraisal.docx";
            var fileName = "Berita_Acara_Pemeriksaan_Setempat_Appraisal_Assignment";

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
            var FileTemplate = $"{"Berita_Acara"}_{coll.LoanApplicationCollateral?.LoanApplication?.LoanApplicationId}.docx";
            var upload = await _uploadService.GenerateFileWord(new GenerateFileRequestModel
            {
                Segment = "umkm",
                DebtorName = coll.LoanApplicationCollateral.LoanApplication.Debtor.Fullname.Replace(" ", "-"),
                FileTemplate = $"{"berita_acara"}",
                File = fileByte,
                LoanApplicationId = coll.LoanApplicationCollateral.LoanApplication.LoanApplicationId
            });
            var result = Path.Combine(FolderName, FileTemplate).Replace(@"\", @"/").Replace(@"\\", @"/");
            var link = result;
            //File.Delete(filePath);

            var generatedFile = await _generatedFile.GetByPredicate(
                x => x.FileName == fileInfo.Name
                && x.LoanApplicationGuid == coll.LoanApplicationCollateral.LoanApplicationId
                && x.GeneratedFileGroupGuid == GeneratedFileGroup.BeritaAcaraAppr
                );
            if (generatedFile != null)
            {
                generatedFile.FileName = fileInfo.Name;
                generatedFile.FilePath = link;
                generatedFile.FileSize = finalSize;
                generatedFile.LoanApplicationCollateralGuid = request.LoanApplicationCollateralId;

                await _generatedFile.UpdateAsync(generatedFile);
            }
            else
            {
                generatedFileEntity = new GeneratedFiles
                {
                    GeneratedFileGuid = Guid.NewGuid(),
                    LoanApplicationGuid = coll.LoanApplicationCollateral.LoanApplication.Id,
                    FileName = fileInfo.Name,
                    FilePath = link,
                    FileSize = finalSize,
                    GeneratedFileGroupGuid = GeneratedFileGroup.BeritaAcaraAppr,
                    LoanApplicationCollateralGuid = request.LoanApplicationCollateralId
                };
                await _generatedFile.AddAsync(generatedFileEntity);
            }

            return ServiceResponse<string>.ReturnResultWith200(link);
        }

        public string GenerateWordFromTemplate(
            string document,
            Dictionary<string, string> dict,
            string newFileName)
        {
            var resultFolder = $@"{rootDir}/Result/BeritaAcara";
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