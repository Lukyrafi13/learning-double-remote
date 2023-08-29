using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.DomainDHN.Entities
{
    [Table("tbl_dhnlist")]
    public class DHNList
    {
        public int SerialNo { get; set; }
        public string? BlackListNo { get; set; }
        public string? SequentialNo { get; set; }
        public string? ReferenceNo { get; set; }
        public string? BankCode { get; set; }
        [Column("bankname")]
        public string? BankName { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerOccupation { get; set; }
        public string? CustomerType { get; set; }
        public string? IdNumber { get; set; }
        public string? NPWP { get; set; }
        public string? Address { get; set; }
        public string? Rt { get; set; }
        public string? Rw { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public string? PostCode { get; set; }
        public string? Remarks { get; set; }
        public string? BirthDate { get; set; }
        public string? Expired { get; set; }
        public int? JumlahSukuKata { get; set; }
        public int? Score { get; set; }
        public Guid? DataId { get; set; }
        public string? NIK { get; set; }
        public DateTime? UpdatingDate { get; set; }
        public int? Status { get; set; }
        public string? UseToClear { get; set; }
    }
}
