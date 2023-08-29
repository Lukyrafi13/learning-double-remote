using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.SIKPHistorys;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.SIKPHistorys.Commands
{
    public class SIKPHistoryDeleteCommand : SIKPHistoryFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteSIKPHistoryCommandHandler : IRequestHandler<SIKPHistoryDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<SIKPHistory> _SIKPHistory;
        private readonly IMapper _mapper;

        public DeleteSIKPHistoryCommandHandler(IGenericRepositoryAsync<SIKPHistory> SIKPHistory, IMapper mapper){
            _SIKPHistory = SIKPHistory;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(SIKPHistoryDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _SIKPHistory.GetByIdAsync(request.Id, "Id");
            rFProduct.IsDeleted = true;
            await _SIKPHistory.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}