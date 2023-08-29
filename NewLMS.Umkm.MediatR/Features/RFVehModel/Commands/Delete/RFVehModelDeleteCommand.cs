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
    public class RFVehModelDeleteCommand : RFVehModelFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFVehModelCommandHandler : IRequestHandler<RFVehModelDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFVehModel> _RFVehModel;
        private readonly IMapper _mapper;

        public DeleteRFVehModelCommandHandler(IGenericRepositoryAsync<RFVehModel> RFVehModel, IMapper mapper){
            _RFVehModel = RFVehModel;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFVehModelDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFVehModel.GetByIdAsync(request.VMDL_CODE, "VMDL_CODE");
            rFProduct.IsDeleted = true;
            await _RFVehModel.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}