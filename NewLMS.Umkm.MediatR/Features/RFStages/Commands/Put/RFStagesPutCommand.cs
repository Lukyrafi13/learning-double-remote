using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfStages;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfStages.Commands
{
    public class RfStagePutCommand : RfStagePutRequestDto, IRequest<ServiceResponse<RfStageResponseDto>>
    {
    }

    public class PutRfStageCommandHandler : IRequestHandler<RfStagePutCommand, ServiceResponse<RfStageResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RfStage> _RfStage;
        private readonly IMapper _mapper;

        public PutRfStageCommandHandler(IGenericRepositoryAsync<RfStage> RfStage, IMapper mapper){
            _RfStage = RfStage;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfStageResponseDto>> Handle(RfStagePutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRfStage = await _RfStage.GetByIdAsync(request.StageId, "StageId");
                existingRfStage.StageId = request.StageId;
                existingRfStage.Code = request.Code;
                existingRfStage.Description = request.Description;
                existingRfStage.GroupStage = request.GroupStage;
                existingRfStage.GroupName = request.GroupName;
                
                await _RfStage.UpdateAsync(existingRfStage);

                var response = _mapper.Map<RfStageResponseDto>(existingRfStage);

                return ServiceResponse<RfStageResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RfStageResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}