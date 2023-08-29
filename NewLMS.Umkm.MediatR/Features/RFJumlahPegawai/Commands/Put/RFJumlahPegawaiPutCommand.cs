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
    public class RFJumlahPegawaiPutCommand : RFJumlahPegawaiPutRequestDto, IRequest<ServiceResponse<RFJumlahPegawaiResponseDto>>
    {
    }

    public class PutRFJumlahPegawaiCommandHandler : IRequestHandler<RFJumlahPegawaiPutCommand, ServiceResponse<RFJumlahPegawaiResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFJumlahPegawai> _RFJumlahPegawai;
        private readonly IMapper _mapper;

        public PutRFJumlahPegawaiCommandHandler(IGenericRepositoryAsync<RFJumlahPegawai> RFJumlahPegawai, IMapper mapper)
        {
            _RFJumlahPegawai = RFJumlahPegawai;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFJumlahPegawaiResponseDto>> Handle(RFJumlahPegawaiPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFJumlahPegawai = await _RFJumlahPegawai.GetByIdAsync(request.ANL_CODE, "ANL_CODE");
                existingRFJumlahPegawai.ANL_CODE = request.ANL_CODE;
                existingRFJumlahPegawai.ANL_DESC = request.ANL_DESC;
                existingRFJumlahPegawai.CORE_CODE = request.CORE_CODE;
                existingRFJumlahPegawai.ACTIVE = request.ACTIVE;

                await _RFJumlahPegawai.UpdateAsync(existingRFJumlahPegawai);

                var response = _mapper.Map<RFJumlahPegawaiResponseDto>(existingRFJumlahPegawai);

                return ServiceResponse<RFJumlahPegawaiResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFJumlahPegawaiResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}