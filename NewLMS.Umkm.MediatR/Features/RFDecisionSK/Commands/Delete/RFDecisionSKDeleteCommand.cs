using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFDecisionSKs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFDecisionSKs.Commands
{
    public class RFDecisionSKDeleteCommand : RFDecisionSKFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFDecisionSKCommandHandler : IRequestHandler<RFDecisionSKDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFDecisionSK> _RFDecisionSK;
        private readonly IMapper _mapper;

        public DeleteRFDecisionSKCommandHandler(IGenericRepositoryAsync<RFDecisionSK> RFDecisionSK, IMapper mapper){
            _RFDecisionSK = RFDecisionSK;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFDecisionSKDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFDecisionSK.GetByIdAsync(request.DEC_CODE, "DEC_CODE");
            rFProduct.IsDeleted = true;
            await _RFDecisionSK.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}