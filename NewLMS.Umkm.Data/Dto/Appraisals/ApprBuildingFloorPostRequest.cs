﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.Appraisals
{
    public class ApprBuildingFloorPostRequest
    {
        public Guid ApprBuildingTemplateGuid { get; set; }
        public string Description { get; set; }
        public int? RoomNumber { get; set; }
        public int? Area { get; set; }
    }
}
