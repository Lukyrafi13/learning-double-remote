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