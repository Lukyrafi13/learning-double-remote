using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using NewLMS.UMKM.Data.Dto.RfBusinessPrimaryCycles;

namespace NewLMS.UMKM.MediatR.Features.RfBusinessPrimaryCycles.Commands
{
    public class RfBusinessPrimaryCycleDeleteCommand : RfBusinesPrimaryCycleFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class RfBusinessPrimaryCiclusDeleteCommandHandler : IRequestHandler<RfBusinessPrimaryCycleDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RfBusinessPrimaryCycle> _RFSiklusUsahaPokok;
        private readonly IMapper _mapper;

        public RfBusinessPrimaryCiclusDeleteCommandHandler(IGenericRepositoryAsync<RfBusinessPrimaryCycle> RFSiklusUsahaPokok, IMapper mapper){
            _RFSiklusUsahaPokok = RFSiklusUsahaPokok;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RfBusinessPrimaryCycleDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFSiklusUsahaPokok.GetByIdAsync(request.CycleCode, "CyclusCode");
            rFProduct.IsDeleted = true;
            await _RFSiklusUsahaPokok.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}