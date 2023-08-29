using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.BiayaInvestasis;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.BiayaInvestasis.Commands
{
    public class BiayaInvestasiPutCommand : BiayaInvestasiPutRequestDto, IRequest<ServiceResponse<BiayaInvestasiResponseDto>>
    {
    }

    public class PutBiayaInvestasiCommandHandler : IRequestHandler<BiayaInvestasiPutCommand, ServiceResponse<BiayaInvestasiResponseDto>>
    {
        private readonly IGenericRepositoryAsync<BiayaInvestasi> _BiayaInvestasi;
        private readonly IMapper _mapper;

        public PutBiayaInvestasiCommandHandler(IGenericRepositoryAsync<BiayaInvestasi> BiayaInvestasi, IMapper mapper)
        {
            _BiayaInvestasi = BiayaInvestasi;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<BiayaInvestasiResponseDto>> Handle(BiayaInvestasiPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingBiayaInvestasi = await _BiayaInvestasi.GetByIdAsync(request.Id, "Id");
                existingBiayaInvestasi.Keterangan = request.Keterangan;
                existingBiayaInvestasi.Jumlah = request.Jumlah;
                existingBiayaInvestasi.Satuan = request.Satuan;
                existingBiayaInvestasi.Harga = request.Harga;
                existingBiayaInvestasi.Total = request.Total;
                existingBiayaInvestasi.SurveyId = request.SurveyId;


                await _BiayaInvestasi.UpdateAsync(existingBiayaInvestasi);

                var response = _mapper.Map<BiayaInvestasiResponseDto>(existingBiayaInvestasi);

                return ServiceResponse<BiayaInvestasiResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<BiayaInvestasiResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}