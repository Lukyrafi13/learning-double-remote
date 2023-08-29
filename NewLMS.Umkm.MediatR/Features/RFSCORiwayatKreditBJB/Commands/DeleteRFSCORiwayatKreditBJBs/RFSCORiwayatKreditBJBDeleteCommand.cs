using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFSCORiwayatKreditBJBs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFSCORiwayatKreditBJBs.Commands
{
    public class RFSCORiwayatKreditBJBDeleteCommand : RFSCORiwayatKreditBJBFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFSCORiwayatKreditBJBCommandHandler : IRequestHandler<RFSCORiwayatKreditBJBDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFSCORiwayatKreditBJB> _RFSCORiwayatKreditBJB;
        private readonly IMapper _mapper;

        public DeleteRFSCORiwayatKreditBJBCommandHandler(IGenericRepositoryAsync<RFSCORiwayatKreditBJB> RFSCORiwayatKreditBJB, IMapper mapper){
            _RFSCORiwayatKreditBJB = RFSCORiwayatKreditBJB;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFSCORiwayatKreditBJBDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFSCORiwayatKreditBJB.GetByIdAsync(request.SCO_CODE, "SCO_CODE");
            rFProduct.IsDeleted = true;
            await _RFSCORiwayatKreditBJB.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}