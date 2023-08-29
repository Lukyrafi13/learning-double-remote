using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Konsumer.Domain.Dwh.Dtos
{
    public class GetDebtorReference
    {
        public string IdNumber { get; set; }
        public string AccountNumber { get; set; }
        public string Fullname { get; set; }
    }
}
