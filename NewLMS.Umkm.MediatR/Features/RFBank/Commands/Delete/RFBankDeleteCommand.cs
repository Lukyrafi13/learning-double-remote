using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFBanks;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFBanks.Commands
{
    public class RFBankDeleteCommand : RFBankFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFBankCommandHandler : IRequestHandler<RFBankDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFBank> _RFBank;
        private readonly IMapper _mapper;

        public DeleteRFBankCommandHandler(IGenericRepositoryAsync<RFBank> RFBank, IMapper mapper){
            _RFBank = RFBank;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFBankDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFBank.GetByIdAsync(request.BankId, "BankId");
            rFProduct.IsDeleted = true;
            await _RFBank.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}