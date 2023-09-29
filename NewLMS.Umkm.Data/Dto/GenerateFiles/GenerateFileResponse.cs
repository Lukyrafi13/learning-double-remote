using System;
using NewLMS.Umkm.Data.Dto.GeneratedFIleGroup;

namespace NewLMS.Umkm.Data.Dto.GenerateFiles
{
    public class GeneratedFileResponse
    {
        public Guid GeneratedFileGuid { get; set; }
        public Guid LoanApplicationGuid { get; set; }
        public GeneratedFileGroupResponse GeneratedFileGroups { get; set; }
        public string FileName { get; set; }
        public string FileSize { get; set; }
        public string FilePath { get; set; }
    }
}