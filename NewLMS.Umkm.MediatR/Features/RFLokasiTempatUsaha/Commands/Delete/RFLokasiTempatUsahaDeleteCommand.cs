using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFLokasiTempatUsahas;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFLokasiTempatUsahas.Commands
{
    public class RFLokasiTempatUsahaDeleteCommand : RFLokasiTempatUsahaFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFLokasiTempatUsahaCommandHandler : IRequestHandler<RFLokasiTempatUsahaDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFLokasiTempatUsaha> _RFLokasiTempatUsaha;
        private readonly IMapper _mapper;

        public DeleteRFLokasiTempatUsahaCommandHandler(IGenericRepositoryAsync<RFLokasiTempatUsaha> RFLokasiTempatUsaha, IMapper mapper){
            _RFLokasiTempatUsaha = RFLokasiTempatUsaha;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFLokasiTempatUsahaDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFLokasiTempatUsaha.GetByIdAsync(request.ANL_CODE, "ANL_CODE");
            rFProduct.IsDeleted = true;
            await _RFLokasiTempatUsaha.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}