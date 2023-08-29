using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfServiceCodes;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfServiceCodes.Commands
{
    public class RfServiceCodeDeleteCommand : RfServiceCodeFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRfServiceCodeCommandHandler : IRequestHandler<RfServiceCodeDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RfServiceCode> _RfServiceCode;
        private readonly IMapper _mapper;

        public DeleteRfServiceCodeCommandHandler(IGenericRepositoryAsync<RfServiceCode> RfServiceCode, IMapper mapper){
            _RfServiceCode = RfServiceCode;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RfServiceCodeDeleteCommand request, CancellationToken cancellationToken)
        {
            var RfServiceCode = await _RfServiceCode.GetByIdAsync(request.ServiceCode, "ServiceCode");
            RfServiceCode.IsDeleted = true;
            await _RfServiceCode.UpdateAsync(RfServiceCode);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}