using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFLokasiUsahas;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFLokasiUsahas.Commands
{
    public class RFLokasiUsahaDeleteCommand : RFLokasiUsahaFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFLokasiUsahaCommandHandler : IRequestHandler<RFLokasiUsahaDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFLokasiUsaha> _RFLokasiUsaha;
        private readonly IMapper _mapper;

        public DeleteRFLokasiUsahaCommandHandler(IGenericRepositoryAsync<RFLokasiUsaha> RFLokasiUsaha, IMapper mapper){
            _RFLokasiUsaha = RFLokasiUsaha;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFLokasiUsahaDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFLokasiUsaha.GetByIdAsync(request.ANL_CODE, "ANL_CODE");
            rFProduct.IsDeleted = true;
            await _RFLokasiUsaha.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}