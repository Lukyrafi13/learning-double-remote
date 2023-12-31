﻿using NewLMS.Umkm.Data.Dto.RfVehMaker;
using NewLMS.Umkm.Data.Dto.RfVehModel;
using NewLMS.Umkm.Data.Dto.RfVehType;
using NewLMS.Umkm.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.RfVehClass
{
    public class RfVehClassResponse : BaseResponse
    {
        public string VehClassCode { get; set; }
        public string VehClassDesc { get; set; }
        public RfVehTypeSimpleResponse RfVehType { get; set; }
        public RfVehModelSimplelResponse RfVehModel { get; set; }
        public RfVehMakerSimpleResponse RfVehMaker { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
    }

    public class RfVehClassSimpleResponse
    {
        public string VehClassCode { get; set; }
        public string VehClassDesc { get; set; }
    }
}
