using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Domain.Dwh.Entities
{
    public class DownloadData
    {
        [Key]
        public Guid Id { get; set; }
        public string? ProspectId { get; set; }
        public string? AccountOfficer { get; set; }
        public string? BranchId { get; set; }
        public string? BookingBranch { get; set; }
        public string? CompanyId { get; set; }
        public string? NoIdentity { get; set; }
        public string? Fullname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Age { get; set; }
        public string? PlaceOfBirth { get; set; }
        public int? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? MotherName { get; set; }
        public string? SourceApplication { get; set; }
        public string? Address { get; set; }
        public string? Rt { get; set; }
        public string? Rw { get; set; }
        public string? Province { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? Neighborhoods { get; set; }
        public byte? ProcessStatus { get; set; }
        public string? ZipCode { get; set; }
        public string? RfSectorLBU3Code { get; set; }
        public double? TargetPlafond { get; set; }
        public DateTime? EstimateProcessDate { get; set; }
        public DateTime? MaturityDate { get; set; }
        public double? Plafond { get; set; }
        public double? Outstanding { get; set; }
        public double? Sisa { get; set; }
        public string? DealType { get; set; }
        public string? SubmissionType { get; set; }
        public DateTime? BusinessDate { get; set; }
        public string? CIF { get; set; }
        public bool IsHasBeenDownload { get; set; }
    }
}
