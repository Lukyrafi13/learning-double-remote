using NewLMS.Umkm.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.LoanApplicationKeyPersons
{
    public class LoanApplicationKeyPersonPostRequest
    {
        public Guid LoanApplicationId { get; set; }
        public string Name { get; set; }
        public string PlaceOfBirth { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Position { get; set; }
        public string NoIdentity { get; set; }
        public DateTime? IdentityDueDate { get; set; }
        public bool LifetimeIdentity { get; set; } = false;
        public string? NPWP { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Neighborhoods { get; set; }
        public int ZipCodeId { get; set; }
        public string? PhoneNumber { get; set; }
        public string MaritalStatusId { get; set; }
        public string EducationId { get; set; }
    }
}
