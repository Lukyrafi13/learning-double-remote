using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace NewLMS.Umkm.API.Filters
{
    public class HangfireAuthorizeFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            return true;
        }
    }
}
