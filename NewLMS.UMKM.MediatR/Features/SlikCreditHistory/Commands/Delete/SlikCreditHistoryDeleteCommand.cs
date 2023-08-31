using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.SlikCreditHistorys;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.SlikCreditHistorys.Commands
{
    public class SlikCreditHistoryDeleteCommand : SlikCreditHistoryFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteSlikCreditHistoryCommandHandler : IRequestHandler<SlikCreditHistoryDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<SlikCreditHistory> _SlikCreditHistory;
        private readonly IMapper _mapper;

        public DeleteSlikCreditHistoryCommandHandler(IGenericRepositoryAsync<SlikCreditHistory> SlikCreditHistory, IMapper mapper){
            _SlikCreditHistory = SlikCreditHistory;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(SlikCreditHistoryDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _SlikCreditHistory.GetByIdAsync(request.Id, "Id");
            rFProduct.IsDeleted = true;
            await _SlikCreditHistory.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}