using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class LogSendCallbackThirdParty : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey(nameof(ThridParty))]
        public string ThridPartyName { get; set; }
        [Required]
        public string Request { get; set; }
        [Required]
        public string Response { get; set; }
        public virtual ThridParty ThridParty { get; set; }
    }
}
