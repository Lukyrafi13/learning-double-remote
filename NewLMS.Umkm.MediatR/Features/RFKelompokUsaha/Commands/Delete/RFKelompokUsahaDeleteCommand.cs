using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFKelompokUsahas;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFKelompokUsahas.Commands
{
    public class RFKelompokUsahaDeleteCommand : RFKelompokUsahaFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFKelompokUsahaCommandHandler : IRequestHandler<RFKelompokUsahaDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFKelompokUsaha> _RFKelompokUsaha;
        private readonly IMapper _mapper;

        public DeleteRFKelompokUsahaCommandHandler(IGenericRepositoryAsync<RFKelompokUsaha> RFKelompokUsaha, IMapper mapper){
            _RFKelompokUsaha = RFKelompokUsaha;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFKelompokUsahaDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFKelompokUsaha.GetByIdAsync(request.ANL_CODE, "ANL_CODE");
            rFProduct.IsDeleted = true;
            await _RFKelompokUsaha.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}