using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFStagess;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFStagess.Commands
{
    public class RFStagesPutCommand : RFStagesPutRequestDto, IRequest<ServiceResponse<RFStagesResponseDto>>
    {
    }

    public class PutRFStagesCommandHandler : IRequestHandler<RFStagesPutCommand, ServiceResponse<RFStagesResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFStages> _RFStages;
        private readonly IMapper _mapper;

        public PutRFStagesCommandHandler(IGenericRepositoryAsync<RFStages> RFStages, IMapper mapper){
            _RFStages = RFStages;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFStagesResponseDto>> Handle(RFStagesPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFStages = await _RFStages.GetByIdAsync(request.StageId, "StageId");
                existingRFStages.StageId = request.StageId;
                existingRFStages.Code = request.Code;
                existingRFStages.Description = request.Description;
                existingRFStages.GroupStage = request.GroupStage;
                existingRFStages.GroupName = request.GroupName;
                
                await _RFStages.UpdateAsync(existingRFStages);

                var response = _mapper.Map<RFStagesResponseDto>(existingRFStages);

                return ServiceResponse<RFStagesResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFStagesResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}