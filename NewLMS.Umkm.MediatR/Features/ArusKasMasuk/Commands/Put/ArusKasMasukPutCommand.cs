using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.ArusKasMasuks;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.ArusKasMasuks.Commands
{
    public class ArusKasMasukPutCommand : ArusKasMasukPutRequestDto, IRequest<ServiceResponse<ArusKasMasukResponseDto>>
    {
    }

    public class PutArusKasMasukCommandHandler : IRequestHandler<ArusKasMasukPutCommand, ServiceResponse<ArusKasMasukResponseDto>>
    {
        private readonly IGenericRepositoryAsync<ArusKasMasuk> _ArusKasMasuk;
        private readonly IMapper _mapper;

        public PutArusKasMasukCommandHandler(IGenericRepositoryAsync<ArusKasMasuk> ArusKasMasuk, IMapper mapper)
        {
            _ArusKasMasuk = ArusKasMasuk;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ArusKasMasukResponseDto>> Handle(ArusKasMasukPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingArusKasMasuk = await _ArusKasMasuk.GetByIdAsync(request.Id, "Id");
                existingArusKasMasuk.Keterangan = request.Keterangan;
                existingArusKasMasuk.Jumlah = request.Jumlah;
                existingArusKasMasuk.Satuan = request.Satuan;
                existingArusKasMasuk.Harga = request.Harga;
                existingArusKasMasuk.Total = request.Total;
                existingArusKasMasuk.SurveyId = request.SurveyId;

                await _ArusKasMasuk.UpdateAsync(existingArusKasMasuk);

                var response = _mapper.Map<ArusKasMasukResponseDto>(existingArusKasMasuk);

                return ServiceResponse<ArusKasMasukResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<ArusKasMasukResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}