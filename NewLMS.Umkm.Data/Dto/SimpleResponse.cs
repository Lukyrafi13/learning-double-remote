using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto
{
    public class SimpleResponse
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }

    public class SimpleResponse<T>
    {
        public T Id { get; set; }
        public string Description { get; set; }
    }

    public class SimpleResponseWithPostCode<T>
    {
        public T Id { get; set; }
        public string Description { get; set; }
        public string PostCode { get; set; }
    }

    public class SimpleResponseWithScore<T>
    {
        public T Id { get; set; }
        public string Description { get; set; }
        public double Score { get; set; }
    }

    public class SimpleResponseWithCurrency<T>
    {
        public T Id { get; set; }
        public string Description { get; set; }
        public decimal? Currency { get; set; }
    }

    public class SimpleResponseWithRate<T>
    {
        public T Id { get; set; }
        public double Rate { get; set; }
    }
}
