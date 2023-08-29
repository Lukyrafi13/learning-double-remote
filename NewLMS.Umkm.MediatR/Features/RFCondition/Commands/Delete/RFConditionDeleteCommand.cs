using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFConditions;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFConditions.Commands
{
    public class RFConditionDeleteCommand : RFConditionFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFConditionCommandHandler : IRequestHandler<RFConditionDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFCondition> _RFCondition;
        private readonly IMapper _mapper;

        public DeleteRFConditionCommandHandler(IGenericRepositoryAsync<RFCondition> RFCondition, IMapper mapper){
            _RFCondition = RFCondition;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFConditionDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFCondition.GetByIdAsync(request.ConditionCode, "ConditionCode");
            rFProduct.IsDeleted = true;
            await _RFCondition.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}