using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class DebiturMemilikiUsahaLain
 : BaseEntity
    {
        public Guid Id { get; set; }
        public string StatusDebitur_Code { get; set; }
        public string StatusDebitur_Desc { get; set; }

    }
}
