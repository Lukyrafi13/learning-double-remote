using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFBusinessTypes;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFBusinessTypes.Commands
{
    public class RFBusinessTypeDeleteCommand : RFBusinessTypeFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFBusinessTypeCommandHandler : IRequestHandler<RFBusinessTypeDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFBusinessType> _RFBusinessType;
        private readonly IMapper _mapper;

        public DeleteRFBusinessTypeCommandHandler(IGenericRepositoryAsync<RFBusinessType> RFBusinessType, IMapper mapper){
            _RFBusinessType = RFBusinessType;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFBusinessTypeDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFBusinessType.GetByIdAsync(request.BTCode, "BTCode");
            rFProduct.IsDeleted = true;
            await _RFBusinessType.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}