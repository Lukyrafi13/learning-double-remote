using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using static System.Net.Mime.MediaTypeNames;

namespace NewLMS.Umkm.Helper
{
    public static class FileStorage
    {

        public static string[] DEFAULT_DOCUMENT_MIMETYPES => new string[] { "application/pdf", "application/x-pdf" };

        public static string[] DEFAULT_IMAGE_MIMETYPES => new string[] { "image/jpeg", "image/bmp", "image/png", "image/jpg", };

        public static string[] DEFAULT_VALID_MIMETYPES => new string[] { "application/pdf", "application/x-pdf", "image/jpeg", "image/bmp", "image/png", "image/jpg", };

        /// <summary>
        /// Save IFormFile to local directory
        /// </summary>
        /// <param name="sourceFile">IFormFile type</param>
        /// <param name="saveDir">string directory path</param>
        /// <returns></returns>
        public static async Task<string> SaveToLocal(this IFormFile sourceFile, (string root, string sub, string loanapplicationId, string documentName, string timestamp) saveDir)
        {
            if (sourceFile.Length < 1)
                return null;

            var documentName = Regex.Replace(saveDir.documentName, "[^A-Za-z0-9]+", "_");

            var sourceFileName = saveDir.loanapplicationId + "_" + documentName + "_" + saveDir.timestamp + Path.GetExtension(sourceFile.GetFileName());

            var saveFilePath = Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), saveDir.root, saveDir.sub), sourceFileName).Replace(@"\", @"/").Replace(@"\\", @"/"); ;

            using (var stream = new FileStream(saveFilePath, FileMode.Create))
            {
                await sourceFile.CopyToAsync(stream);
            }

            return Path.Combine(saveDir.sub, sourceFileName).Replace(@"\", @"/").Replace(@"\\", @"/");
        }

        public static async Task<string> getType(this IFormFile sourceFile, (string root, string sub, string loanapplicationId, string documentName, string timestamp) saveDir)
        {
            if (sourceFile.Length < 1)
                return null;
            var sourceFileName = Path.GetExtension(sourceFile.GetFileName());
            var extension = Path.GetExtension(sourceFileName);

            var typeFile = extension.Replace(".", "");

            //if (sourceFile.IsImages())
            //{
            //     typeFile = "image/" + extension.Replace(".", "");
            //}
            //else
            //{
            //     typeFile = "document/" + extension.Replace(".", "");
            //}
            return typeFile;
        }

        public static string GetFileName(this IFormFile file) => ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

        public static bool IsDocument(
            this IFormFile file,
            string[] mimeTypes = null) => (mimeTypes != null ? mimeTypes : DEFAULT_DOCUMENT_MIMETYPES).Contains(file.ContentType);

        public static bool IsImages(
            this IFormFile file,
            string[] mimeTypes = null) => (mimeTypes != null ? mimeTypes : DEFAULT_IMAGE_MIMETYPES).Contains(file.ContentType);

        public static bool IsValidTypeFile(
             this IFormFile file,
             string[] mimeTypes = null) => (mimeTypes != null ? mimeTypes : DEFAULT_VALID_MIMETYPES).Contains(file.ContentType);
    }
}