using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFVehModels;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFVehModels.Commands
{
    public class RFVehModelPostCommand : RFVehModelPostRequestDto, IRequest<ServiceResponse<RFVehModelResponseDto>>
    {

    }
    public class PostRFVehModelCommandHandler : IRequestHandler<RFVehModelPostCommand, ServiceResponse<RFVehModelResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFVehModel> _RFVehModel;
        private readonly IMapper _mapper;

        public PostRFVehModelCommandHandler(IGenericRepositoryAsync<RFVehModel> RFVehModel, IMapper mapper)
        {
            _RFVehModel = RFVehModel;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFVehModelResponseDto>> Handle(RFVehModelPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFVehModel = _mapper.Map<RFVehModel>(request);

                var returnedRFVehModel = await _RFVehModel.AddAsync(RFVehModel, callSave: false);

                // var response = _mapper.Map<RFVehModelResponseDto>(returnedRFVehModel);
                var response = _mapper.Map<RFVehModelResponseDto>(returnedRFVehModel);

                await _RFVehModel.SaveChangeAsync();
                return ServiceResponse<RFVehModelResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFVehModelResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}