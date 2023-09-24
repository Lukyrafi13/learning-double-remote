using NewLMS.Umkm.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.ChekingSIKPs
{
    public class ChekingSIKPHistoryResponse : BaseResponse
    {
        public Guid? Id { get; set; }
        public string NoIdentiry { get; set; }
        public string BanckCode { get; set; }
        public double? PlanPlafond { get; set; }
        public double? RateAkad { get; set; }
        public double? LimitActive { get; set; }
        public double? AllowedAkad { get; set; }
        public double? RemainingBookDays { get; set; }

        public virtual ICollection<ChekingSIKPHistoryDetailResponse> SIKPHistoryDetails { get; set; }
    }

    public class ChekingSIKPHistoryDetailResponse : BaseResponse
    {
        public Guid? Id { get; set; }
        public Guid? SIKPHistoryId { get; set; }
        public string BanckCode { get; set; }
        public int? RemainingDay { get; set; }
        public string Schema { get; set; }
        public string TotalAkad { get; set; }
        public int? MaxTotalAkad { get; set; }
        public double? AllowedAkad { get; set; }
        public double? RateAkad { get; set; }
        public string LimitActiveDefault { get; set; }
        public string LimitActive { get; set; }
        public double? TotalLimit { get; set; }
        public double? AllowedRemainingPlafond { get; set; }
    }
}
