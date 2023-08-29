using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFVehicleTypeLists;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFVehicleTypeLists.Commands
{
    public class RFVehicleTypeListPutCommand : RFVehicleTypeListPutRequestDto, IRequest<ServiceResponse<RFVehicleTypeListResponseDto>>
    {
    }

    public class PutRFVehicleTypeListCommandHandler : IRequestHandler<RFVehicleTypeListPutCommand, ServiceResponse<RFVehicleTypeListResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFVehicleTypeList> _RFVehicleTypeList;
        private readonly IMapper _mapper;

        public PutRFVehicleTypeListCommandHandler(IGenericRepositoryAsync<RFVehicleTypeList> RFVehicleTypeList, IMapper mapper){
            _RFVehicleTypeList = RFVehicleTypeList;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFVehicleTypeListResponseDto>> Handle(RFVehicleTypeListPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFVehicleTypeList = await _RFVehicleTypeList.GetByIdAsync(request.Id, "Id");
                existingRFVehicleTypeList.COL_CODE = request.COL_CODE;
                existingRFVehicleTypeList.VEH_CODE = request.VEH_CODE;
                
                await _RFVehicleTypeList.UpdateAsync(existingRFVehicleTypeList);

                var response = _mapper.Map<RFVehicleTypeListResponseDto>(existingRFVehicleTypeList);

                return ServiceResponse<RFVehicleTypeListResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFVehicleTypeListResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}