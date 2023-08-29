using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFVehicleTypeLists;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFVehicleTypeLists.Queries
{
    public class RFVehicleTypeListGetQuery : RFVehicleTypeListFindRequestDto, IRequest<ServiceResponse<RFVehicleTypeListResponseDto>>
    {
    }

    public class RFVehicleTypeListGetQueryHandler : IRequestHandler<RFVehicleTypeListGetQuery, ServiceResponse<RFVehicleTypeListResponseDto>>
    {
        private IGenericRepositoryAsync<RFVehicleTypeList> _RFVehicleTypeList;
        private readonly IMapper _mapper;

        public RFVehicleTypeListGetQueryHandler(IGenericRepositoryAsync<RFVehicleTypeList> RFVehicleTypeList, IMapper mapper)
        {
            _RFVehicleTypeList = RFVehicleTypeList;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFVehicleTypeListResponseDto>> Handle(RFVehicleTypeListGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFVehicleTypeList.GetByIdAsync(request.Id, "Id");
                if (data == null)
                    return ServiceResponse<RFVehicleTypeListResponseDto>.Return404("Data RFVehicleTypeList not found");
                var response = _mapper.Map<RFVehicleTypeListResponseDto>(data);
                return ServiceResponse<RFVehicleTypeListResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFVehicleTypeListResponseDto>.ReturnException(ex);
            }
        }
    }
}