using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.Repository.LoanApplicationRepository
{
    public interface ILoanApplicationRepository
    {
        Task GetPagedResponse(int id, string idFieldName = "Id", string[] includes = null);
        Task<IReadOnlyList<LoanApplication>> GetPagedReponseAsync(int pageNumber, int pageSize, string[] includes = null);
    }
}

