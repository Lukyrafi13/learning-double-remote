using Microsoft.AspNetCore.Identity;
using System;

namespace NewLMS.UMKM.Data
{
    public class UserLogin : IdentityUserLogin<Guid>
    {
        public virtual User User { get; set; }
    }
}
