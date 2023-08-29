using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFLinkages;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFLinkages.Commands
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