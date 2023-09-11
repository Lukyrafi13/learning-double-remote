using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.Users;

namespace NewLMS.UMKM.API.Helpers.Mapping.Transactions
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
