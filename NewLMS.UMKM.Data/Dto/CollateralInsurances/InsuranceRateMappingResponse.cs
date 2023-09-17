using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.CollateralInsurances
{
    public class InsuranceRateMappingResponse
    {
        public string TemplateMappingCode { get; set; }
        public string TemplateId { get; set; }
        public string JobCode { get; set; }
        public string LoanType { get; set; }
        public int? MinTenor { get; set; }
        public int? MaxTenor { get; set; }
        public int? DebiturAge { get; set; }
        public double? InsuranceRate { get; set; }
        public string KetreCode { get; set; }
        public string KetvehCode { get; set; }
        public double? MinTtg { get; set; }
        public double? MaxTtg { get; set; }
        public string TujuanCode { get; set; }
        public string ZonaCode { get; set; }
        public string WilayahCode { get; set; }
        public string ColusiaCode { get; set; }
        public string RisikoCode { get; set; }
        public string BtsRisikoCode { get; set; }
        public bool IsActive { get; set; }
    }
}
