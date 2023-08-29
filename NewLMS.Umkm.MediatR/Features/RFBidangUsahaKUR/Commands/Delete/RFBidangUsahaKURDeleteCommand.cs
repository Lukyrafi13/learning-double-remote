using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFBidangUsahaKURs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFBidangUsahaKURs.Commands
{
    public class RFBidangUsahaKURDeleteCommand : RFBidangUsahaKURFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFBidangUsahaKURCommandHandler : IRequestHandler<RFBidangUsahaKURDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFBidangUsahaKUR> _RFBidangUsahaKUR;
        private readonly IMapper _mapper;

        public DeleteRFBidangUsahaKURCommandHandler(IGenericRepositoryAsync<RFBidangUsahaKUR> RFBidangUsahaKUR, IMapper mapper){
            _RFBidangUsahaKUR = RFBidangUsahaKUR;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFBidangUsahaKURDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFBidangUsahaKUR.GetByIdAsync(request.BTCode, "BTCode");
            rFProduct.IsDeleted = true;
            await _RFBidangUsahaKUR.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}