using System;

namespace NewLMS.UMKM.Data.Dto.RfStages
{
    public class RfStagePutRequestDto : RfStagePostRequestDto
    {
        public Guid StageId { get; set; }
    }
}
