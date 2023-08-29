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
    public class RFStagesPostCommand : RFStagesPostRequestDto, IRequest<ServiceResponse<RFStagesResponseDto>>
    {

    }
    public class PostRFStagesCommandHandler : IRequestHandler<RFStagesPostCommand, ServiceResponse<RFStagesResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFStages> _RFStages;
        private readonly IMapper _mapper;

        public PostRFStagesCommandHandler(IGenericRepositoryAsync<RFStages> RFStages, IMapper mapper)
        {
            _RFStages = RFStages;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFStagesResponseDto>> Handle(RFStagesPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFStages = _mapper.Map<RFStages>(request);

                var returnedRFStages = await _RFStages.AddAsync(RFStages, callSave: false);

                // var response = _mapper.Map<RFStagesResponseDto>(returnedRFStages);
                var response = _mapper.Map<RFStagesResponseDto>(returnedRFStages);

                await _RFStages.SaveChangeAsync();
                return ServiceResponse<RFStagesResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFStagesResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}