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
    public class RFJumlahPegawaiPostCommand : RFJumlahPegawaiPostRequestDto, IRequest<ServiceResponse<RFJumlahPegawaiResponseDto>>
    {

    }
    public class PostRFJumlahPegawaiCommandHandler : IRequestHandler<RFJumlahPegawaiPostCommand, ServiceResponse<RFJumlahPegawaiResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFJumlahPegawai> _RFJumlahPegawai;
        private readonly IMapper _mapper;

        public PostRFJumlahPegawaiCommandHandler(IGenericRepositoryAsync<RFJumlahPegawai> RFJumlahPegawai, IMapper mapper)
        {
            _RFJumlahPegawai = RFJumlahPegawai;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFJumlahPegawaiResponseDto>> Handle(RFJumlahPegawaiPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFJumlahPegawai = _mapper.Map<RFJumlahPegawai>(request);

                var returnedRFJumlahPegawai = await _RFJumlahPegawai.AddAsync(RFJumlahPegawai, callSave: false);

                // var response = _mapper.Map<RFJumlahPegawaiResponseDto>(returnedRFJumlahPegawai);
                var response = _mapper.Map<RFJumlahPegawaiResponseDto>(returnedRFJumlahPegawai);

                await _RFJumlahPegawai.SaveChangeAsync();
                return ServiceResponse<RFJumlahPegawaiResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFJumlahPegawaiResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}