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
    public class RFVehModelPutCommand : RFVehModelPutRequestDto, IRequest<ServiceResponse<RFVehModelResponseDto>>
    {
    }

    public class PutRFVehModelCommandHandler : IRequestHandler<RFVehModelPutCommand, ServiceResponse<RFVehModelResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFVehModel> _RFVehModel;
        private readonly IMapper _mapper;

        public PutRFVehModelCommandHandler(IGenericRepositoryAsync<RFVehModel> RFVehModel, IMapper mapper){
            _RFVehModel = RFVehModel;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFVehModelResponseDto>> Handle(RFVehModelPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFVehModel = await _RFVehModel.GetByIdAsync(request.VMDL_CODE, "VMDL_CODE");
                existingRFVehModel.VMDL_CODE = request.VMDL_CODE;
                existingRFVehModel.VMDL_DESC = request.VMDL_DESC;
                existingRFVehModel.CORE_CODE = request.CORE_CODE;
                existingRFVehModel.Active = request.Active;
                
                await _RFVehModel.UpdateAsync(existingRFVehModel);

                var response = _mapper.Map<RFVehModelResponseDto>(existingRFVehModel);

                return ServiceResponse<RFVehModelResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFVehModelResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}