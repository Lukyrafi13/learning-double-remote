using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class RFBentukLahan : BaseEntity
    {
        public Guid Id { get; set; }
        public string BentukLahan_Id { get; set; }
        public string BentukLahan_Desc { get; set; }
    }
}
