﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.AppraisalVehicle
{
    public class ApprVehicleNotePostRequest
    {
        public Guid ApprVehicleTemplateGuid { get; set; }
        public string VehiclePart { get; set; }
        public string Note { get; set; }
    }
}
