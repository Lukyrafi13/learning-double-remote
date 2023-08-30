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
    public class RfStagePostCommand : RfStagePostRequestDto, IRequest<ServiceResponse<RfStageResponseDto>>
    {

    }
    public class PostRfStageCommandHandler : IRequestHandler<RfStagePostCommand, ServiceResponse<RfStageResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RfStage> _RfStage;
        private readonly IMapper _mapper;

        public PostRfStageCommandHandler(IGenericRepositoryAsync<RfStage> RfStage, IMapper mapper)
        {
            _RfStage = RfStage;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfStageResponseDto>> Handle(RfStagePostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RfStage = _mapper.Map<RfStage>(request);

                var returnedRfStage = await _RfStage.AddAsync(RfStage, callSave: false);

                // var response = _mapper.Map<RfStageResponseDto>(returnedRfStage);
                var response = _mapper.Map<RfStageResponseDto>(returnedRfStage);

                await _RfStage.SaveChangeAsync();
                return ServiceResponse<RfStageResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RfStageResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}