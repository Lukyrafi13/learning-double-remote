using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFBanks;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFBanks.Commands
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