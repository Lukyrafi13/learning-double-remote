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
    public class RFVehicleTypeListDeleteCommand : RFVehicleTypeListFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFVehicleTypeListCommandHandler : IRequestHandler<RFVehicleTypeListDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFVehicleTypeList> _RFVehicleTypeList;
        private readonly IMapper _mapper;

        public DeleteRFVehicleTypeListCommandHandler(IGenericRepositoryAsync<RFVehicleTypeList> RFVehicleTypeList, IMapper mapper){
            _RFVehicleTypeList = RFVehicleTypeList;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFVehicleTypeListDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFVehicleTypeList.GetByIdAsync(request.Id, "Id");
            rFProduct.IsDeleted = true;
            await _RFVehicleTypeList.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}