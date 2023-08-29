using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFJumlahPegawais;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFJumlahPegawais.Commands
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