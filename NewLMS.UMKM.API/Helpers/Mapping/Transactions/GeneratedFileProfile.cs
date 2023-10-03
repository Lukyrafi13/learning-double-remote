using AutoMapper;
using NewLMS.Umkm.Data.Dto.GeneratedFIleGroup;
using NewLMS.Umkm.Data.Dto.GenerateFiles;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
{
    public class GeneratedFileProfile : Profile
    {
        public GeneratedFileProfile()
        {
            CreateMap<GeneratedFiles, GeneratedFileResponse>();
            CreateMap<GeneratedFileGroups, GeneratedFileGroupResponse>();

        }
    }
}
