using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Domain.Dwh.Entities
{
    [Keyless]
    public class DWH_EXTERNALACC
    {
        public string BRANCHID { get; set; }
        public string CIF { get; set; }
        public string SUFFIX { get; set; }
        public string EXTERNAL_ACCOUNT { get; set; }
        public string FULLNAME { get; set; }
        public string INSERTDATE { get; set; }
        public string INSERTBY { get; set; }
        public string UPDATEDATE { get; set; }
        public string UPDATEBY { get; set; }
        public string PENYESUAIAN { get; set; }
    }
}
