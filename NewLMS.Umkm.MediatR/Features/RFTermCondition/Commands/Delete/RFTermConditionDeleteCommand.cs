using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFTermConditions;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFTermConditions.Commands
{
    public class RFTermConditionDeleteCommand : RFTermConditionFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFTermConditionCommandHandler : IRequestHandler<RFTermConditionDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFTermCondition> _RFTermCondition;
        private readonly IMapper _mapper;

        public DeleteRFTermConditionCommandHandler(IGenericRepositoryAsync<RFTermCondition> RFTermCondition, IMapper mapper){
            _RFTermCondition = RFTermCondition;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFTermConditionDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFTermCondition.GetByIdAsync(request.TermCode, "TermCode");
            rFProduct.IsDeleted = true;
            await _RFTermCondition.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}