using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.Users;

namespace NewLMS.Umkm.API.Helpers.Mapping.Transactions
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserResponse>();
            CreateMap<User, UserSimpleResponse>();
        }
    }
}
