using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFRejects;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFRejects.Commands
{
    public class RFRejectDeleteCommand : RFRejectFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFRejectCommandHandler : IRequestHandler<RFRejectDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFReject> _RFReject;
        private readonly IMapper _mapper;

        public DeleteRFRejectCommandHandler(IGenericRepositoryAsync<RFReject> RFReject, IMapper mapper){
            _RFReject = RFReject;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFRejectDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFReject.GetByIdAsync(request.RjCode, "RjCode");
            rFProduct.IsDeleted = true;
            await _RFReject.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}