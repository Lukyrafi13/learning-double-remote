using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NewLMS.Umkm.Data.Dto;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.API.Helpers.Mapping
{
    public class ParameterProfile : Profile
    {
        public ParameterProfile()
        {
            CreateMap<Parameters, SimpleResponse<Guid>>()
               .ForMember(d => d.Id, s => s.MapFrom(s => s.ParameterGuid))
               .ForMember(d => d.Description, s => s.MapFrom(s => s.ParameterName));
        }
    }
}