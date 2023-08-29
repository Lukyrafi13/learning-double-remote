using Microsoft.AspNetCore.Identity;
using System;

namespace NewLMS.Umkm.Data
{
    public class UserToken : IdentityUserToken<Guid>
    {
        public virtual User User { get; set; } = null;
    }
}
