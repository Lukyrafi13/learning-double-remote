using System;
namespace NewLMS.UMKM.Data.Dto.RFStagess
{
    public class RFStagesResponseDto
    {
        public int StageId { get; set; }
        public string Code { get; set; }

        public string Description { get; set; }
        public int GroupStage { get; set; }

        public string GroupName { get; set; }
    }
}
