﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace NewLMS.Umkm.Data.Dto.AppraisalImages
{
    public class AppraisalImagesUploadRequest
    {
        public IFormFile Files { get; set; }
        public Guid AppraisalGuid { get; set; }
        public string DocumentType { get; set; }
        public string Title { get; set; }
    }
}
