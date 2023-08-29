using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFLinkages;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFLinkages.Commands
{
    public class RFLinkageDeleteCommand : RFLinkageFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFLinkageCommandHandler : IRequestHandler<RFLinkageDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFLinkage> _RFLinkage;
        private readonly IMapper _mapper;

        public DeleteRFLinkageCommandHandler(IGenericRepositoryAsync<RFLinkage> RFLinkage, IMapper mapper){
            _RFLinkage = RFLinkage;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFLinkageDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFLinkage.GetByIdAsync(request.LinkCode, "LinkCode");
            rFProduct.IsDeleted = true;
            await _RFLinkage.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}