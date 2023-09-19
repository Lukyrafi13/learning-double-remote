using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Common.GenericRespository
{
    public class RequestFilterParameter
    {
        public string Field { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public string ComparisonOperator { get; set; }
        public bool SwitchPosition { get; set; } = false;
    }
}
