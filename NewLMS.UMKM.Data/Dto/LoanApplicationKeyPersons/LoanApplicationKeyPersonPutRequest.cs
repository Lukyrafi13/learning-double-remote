using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.LoanApplicationKeyPersons
{
    public class LoanApplicationKeyPersonPutRequest : LoanApplicationKeyPersonPostRequest
    {
        public Guid Id { get; set; }
    }
}
