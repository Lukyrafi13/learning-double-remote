using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class RFJenisUsahaYangDihindari
 : BaseEntity
    {
        public Guid Id { get; set; }
        public string StatusJenisUsaha_Code { get; set; }
        public string StatusJenisUsaha_Desc { get; set; }

    }
}
