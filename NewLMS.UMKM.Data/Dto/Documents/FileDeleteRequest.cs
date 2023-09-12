using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.Documents
{
    public class FileDeleteRequest
    {
        public Guid DocumentId { get; set; }
        public Guid FileUrlId { get; set; }
    }
}
