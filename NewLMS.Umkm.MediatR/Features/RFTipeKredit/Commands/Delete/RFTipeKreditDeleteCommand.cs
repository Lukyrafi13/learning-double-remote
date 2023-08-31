using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfCreditTypes;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfCreditTypes.Commands
{
    public class RfCreditTypeDeleteCommand : RfCreditTypeFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRfCreditTypeCommandHandler : IRequestHandler<RfCreditTypeDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RfCreditType> _RfCreditType;
        private readonly IMapper _mapper;

        public DeleteRfCreditTypeCommandHandler(IGenericRepositoryAsync<RfCreditType> RfCreditType, IMapper mapper){
            _RfCreditType = RfCreditType;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RfCreditTypeDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RfCreditType.GetByIdAsync(request.Code, "Code");
            rFProduct.IsDeleted = true;
            await _RfCreditType.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}