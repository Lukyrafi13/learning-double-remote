using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFColLateralBCs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFColLateralBCs.Commands
{
    public class RFColLateralBCDeleteCommand : RFColLateralBCFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFColLateralBCCommandHandler : IRequestHandler<RFColLateralBCDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFColLateralBC> _RFColLateralBC;
        private readonly IMapper _mapper;

        public DeleteRFColLateralBCCommandHandler(IGenericRepositoryAsync<RFColLateralBC> RFColLateralBC, IMapper mapper){
            _RFColLateralBC = RFColLateralBC;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFColLateralBCDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFColLateralBC.GetByIdAsync(request.ColCode, "ColCode");
            rFProduct.IsDeleted = true;
            await _RFColLateralBC.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}