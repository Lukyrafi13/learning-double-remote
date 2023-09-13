using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace NewLMS.UMKM.API.Filters
{
    public class HangfireAuthorizeFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            return true;
        }
    }
}
