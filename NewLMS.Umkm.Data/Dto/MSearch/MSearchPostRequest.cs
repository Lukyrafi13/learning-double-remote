using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace NewLMS.Umkm.Data.Dto.MSearchs
{
    public class MSearchPostRequestDto
    {
        public string TypeId { get; set; }
        public string SearchType { get; set; }
        public string SearchId { get; set; }
        public string SearchDesc { get; set; }
        public string ResultType { get; set; }
        public string VariableSystem { get; set; }
        public string VariableFields { get; set; }
        public string VariableCondition { get; set; }
        public string ResultSystem { get; set; }
        public string ResultKey { get; set; }
        public string ResultCondition { get; set; }
        public bool Active { get; set; }
    }
}
