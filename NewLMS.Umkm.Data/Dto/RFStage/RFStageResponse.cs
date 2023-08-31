using System;
namespace NewLMS.UMKM.Data.Dto.RfStages
{
    public class RfStageResponseDto
    {
        public Guid StageId { get; set; }
        public string Code { get; set; }

        public string Description { get; set; }
        public int GroupStage { get; set; }

        public string GroupName { get; set; }
    }
}
