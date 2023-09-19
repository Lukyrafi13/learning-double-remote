using Microsoft.AspNetCore.Identity;
using System;

namespace NewLMS.Umkm.Data
{
    public class UserLogin : IdentityUserLogin<Guid>
    {
        public virtual User User { get; set; }
    }
}
