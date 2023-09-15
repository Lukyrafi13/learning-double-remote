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
}
