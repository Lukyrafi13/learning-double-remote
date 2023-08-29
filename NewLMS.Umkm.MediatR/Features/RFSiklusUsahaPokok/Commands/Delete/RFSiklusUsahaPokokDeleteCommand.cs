using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFSiklusUsahaPokoks;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFSiklusUsahaPokoks.Commands
{
    public class RFSiklusUsahaPokokDeleteCommand : RFSiklusUsahaPokokFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFSiklusUsahaPokokCommandHandler : IRequestHandler<RFSiklusUsahaPokokDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFSiklusUsahaPokok> _RFSiklusUsahaPokok;
        private readonly IMapper _mapper;

        public DeleteRFSiklusUsahaPokokCommandHandler(IGenericRepositoryAsync<RFSiklusUsahaPokok> RFSiklusUsahaPokok, IMapper mapper){
            _RFSiklusUsahaPokok = RFSiklusUsahaPokok;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFSiklusUsahaPokokDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFSiklusUsahaPokok.GetByIdAsync(request.SiklusCode, "SiklusCode");
            rFProduct.IsDeleted = true;
            await _RFSiklusUsahaPokok.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}