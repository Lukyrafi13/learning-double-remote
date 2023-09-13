using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.FileUpload.Models
{
    public class BaseResponseModel<T>
    {
        public bool Success { set; get; }

        public T Data { get; set; }

        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }
        public string Message { get; set; }
    }
}
