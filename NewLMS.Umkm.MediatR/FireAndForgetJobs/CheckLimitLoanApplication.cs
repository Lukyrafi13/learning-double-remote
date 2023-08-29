using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.FireAndForgetJobs
{
    public interface ICheckLimitLoanApplication
    {
        Task<bool> CheckLimitLoanApplication(Guid Id);
    }
}
