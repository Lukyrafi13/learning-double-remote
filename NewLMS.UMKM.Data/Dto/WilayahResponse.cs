using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto
{
    public class WilayahResponse
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string PostCode { get; set; }
    }

    public class WilayahResponse<T>
    {
        public T Id { get; set; }
        public string Description { get; set; }
        public string PostCode { get; set; }
    }
}
