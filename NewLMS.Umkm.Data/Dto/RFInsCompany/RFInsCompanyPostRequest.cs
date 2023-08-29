using System;
namespace NewLMS.Umkm.Data.Dto.RFInsCompanys
{
    public class RFInsCompanyPostRequestDto
    {
        public string CompId { get; set; }
        public string CompName { get; set; }
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string Addr3 { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string PhoneArea { get; set; }
        public string PhoneNum { get; set; }
        public string PhoneExt { get; set; }
        public string Email { get; set; }
        public string FaxArea { get; set; }
        public string FaxNum { get; set; }
        public string NoRekening { get; set; }
        public string RekFire { get; set; }
        public string RekLife { get; set; }
        public string FormulaID { get; set; }
        public string CoreID { get; set; }
        public bool? Active { get; set; }
        public string CompType { get; set; }
    }
}
