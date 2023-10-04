using System;
using AutoMapper;
using NewLMS.Umkm.Data.Dto.FileUrls;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
{
    public class FileUrlProfile : Profile
    {
        public FileUrlProfile()
        {
            CreateMap<FileUrl, FileUrlResponse>();
            CreateMap<FileUrl, FileUrlSimpleResponse>();
        }
    }
}

