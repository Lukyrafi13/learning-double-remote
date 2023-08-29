using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFJumlahPegawais;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFJumlahPegawais.Commands
{
    public class RFJumlahPegawaiDeleteCommand : RFJumlahPegawaiFindRequestDto, IRequest<ServiceResponse<Unit>>
    {

    }

    public class DeleteRFJumlahPegawaiCommandHandler : IRequestHandler<RFJumlahPegawaiDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFJumlahPegawai> _RFJumlahPegawai;
        private readonly IMapper _mapper;

        public DeleteRFJumlahPegawaiCommandHandler(IGenericRepositoryAsync<RFJumlahPegawai> RFJumlahPegawai, IMapper mapper)
        {
            _RFJumlahPegawai = RFJumlahPegawai;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFJumlahPegawaiDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFJumlahPegawai.GetByIdAsync(request.ANL_CODE, "ANL_CODE");
            rFProduct.IsDeleted = true;
            await _RFJumlahPegawai.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}