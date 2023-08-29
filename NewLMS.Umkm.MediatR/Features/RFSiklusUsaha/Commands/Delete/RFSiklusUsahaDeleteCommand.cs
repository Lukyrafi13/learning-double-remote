using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFSiklusUsahas;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFSiklusUsahas.Commands
{
    public class RFSiklusUsahaDeleteCommand : RFSiklusUsahaFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFSiklusUsahaCommandHandler : IRequestHandler<RFSiklusUsahaDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFSiklusUsaha> _RFSiklusUsaha;
        private readonly IMapper _mapper;

        public DeleteRFSiklusUsahaCommandHandler(IGenericRepositoryAsync<RFSiklusUsaha> RFSiklusUsaha, IMapper mapper){
            _RFSiklusUsaha = RFSiklusUsaha;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFSiklusUsahaDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFSiklusUsaha.GetByIdAsync(request.SiklusCode, "SiklusCode");
            rFProduct.IsDeleted = true;
            await _RFSiklusUsaha.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}