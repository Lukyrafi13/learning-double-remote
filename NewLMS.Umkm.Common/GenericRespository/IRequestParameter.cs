using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Common.GenericRespository
{
    public interface IRequestParameter
    {
        int Page { get; set; }
        int Length { get; set; }
        List<string> Orders { get; set; }
        string SortType { get; set; }
        List<RequestFilterParameter> Filters { get; set; }
    }
}
