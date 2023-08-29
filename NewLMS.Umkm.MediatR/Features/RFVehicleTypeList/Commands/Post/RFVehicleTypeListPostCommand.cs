using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFVehicleTypeLists;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFVehicleTypeLists.Commands
{
    public class RFVehicleTypeListPostCommand : RFVehicleTypeListPostRequestDto, IRequest<ServiceResponse<RFVehicleTypeListResponseDto>>
    {

    }
    public class PostRFVehicleTypeListCommandHandler : IRequestHandler<RFVehicleTypeListPostCommand, ServiceResponse<RFVehicleTypeListResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFVehicleTypeList> _RFVehicleTypeList;
        private readonly IMapper _mapper;

        public PostRFVehicleTypeListCommandHandler(IGenericRepositoryAsync<RFVehicleTypeList> RFVehicleTypeList, IMapper mapper)
        {
            _RFVehicleTypeList = RFVehicleTypeList;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFVehicleTypeListResponseDto>> Handle(RFVehicleTypeListPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFVehicleTypeList = _mapper.Map<RFVehicleTypeList>(request);

                var returnedRFVehicleTypeList = await _RFVehicleTypeList.AddAsync(RFVehicleTypeList, callSave: false);

                // var response = _mapper.Map<RFVehicleTypeListResponseDto>(returnedRFVehicleTypeList);
                var response = _mapper.Map<RFVehicleTypeListResponseDto>(returnedRFVehicleTypeList);

                await _RFVehicleTypeList.SaveChangeAsync();
                return ServiceResponse<RFVehicleTypeListResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFVehicleTypeListResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}