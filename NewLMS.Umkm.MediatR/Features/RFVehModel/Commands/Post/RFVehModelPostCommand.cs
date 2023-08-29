using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFVehModels;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFVehModels.Commands
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