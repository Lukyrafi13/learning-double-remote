using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.BiayaVariabels;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.BiayaVariabels.Commands
{
    public class BiayaVariabelPutCommand : BiayaVariabelPutRequestDto, IRequest<ServiceResponse<BiayaVariabelResponseDto>>
    {
    }

    public class PutBiayaVariabelCommandHandler : IRequestHandler<BiayaVariabelPutCommand, ServiceResponse<BiayaVariabelResponseDto>>
    {
        private readonly IGenericRepositoryAsync<BiayaVariabel> _BiayaVariabel;
        private readonly IMapper _mapper;

        public PutBiayaVariabelCommandHandler(IGenericRepositoryAsync<BiayaVariabel> BiayaVariabel, IMapper mapper)
        {
            _BiayaVariabel = BiayaVariabel;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<BiayaVariabelResponseDto>> Handle(BiayaVariabelPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingBiayaVariabel = await _BiayaVariabel.GetByIdAsync(request.Id, "Id");
                existingBiayaVariabel.Keterangan = request.Keterangan;
                existingBiayaVariabel.Jumlah = request.Jumlah;
                existingBiayaVariabel.Satuan = request.Satuan;
                existingBiayaVariabel.Harga = request.Harga;
                existingBiayaVariabel.Total = request.Total;
                existingBiayaVariabel.SurveyId = request.SurveyId;

                await _BiayaVariabel.UpdateAsync(existingBiayaVariabel);

                var response = _mapper.Map<BiayaVariabelResponseDto>(existingBiayaVariabel);

                return ServiceResponse<BiayaVariabelResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<BiayaVariabelResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}