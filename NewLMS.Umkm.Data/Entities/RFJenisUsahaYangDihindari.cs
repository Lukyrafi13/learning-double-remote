using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class RfCompanyTypeYangDihindari
 : BaseEntity
    {
        public Guid Id { get; set; }
        public string StatusJenisUsaha_Code { get; set; }
        public string StatusJenisUsaha_Desc { get; set; }

    }
}
