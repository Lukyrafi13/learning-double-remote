using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.Debiturs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.Debiturs.Commands
{
    public class DebiturPutCommand : DebiturPutRequestDto, IRequest<ServiceResponse<DebiturResponseDto>>
    {

    }
    public class PutDebiturCommandHandler : IRequestHandler<DebiturPutCommand, ServiceResponse<DebiturResponseDto>>
    {
        private readonly IGenericRepositoryAsync<Debitur> _debitur;
        private readonly IGenericRepositoryAsync<RFZipCode> _zipCode;
        private readonly IMapper _mapper;

        public PutDebiturCommandHandler(
            IGenericRepositoryAsync<Debitur> debitur,
            IGenericRepositoryAsync<RFZipCode> zipCode,
            IMapper mapper)
        {
            _debitur = debitur;
            _zipCode = zipCode;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<DebiturResponseDto>> Handle(DebiturPutCommand request, CancellationToken cancellationToken)
        {

            try
            {
                // Get Tipe Debitur

                var debitur = await _debitur.GetByIdAsync(request.Id, "Id");

                debitur.NamaLengkap = request.NamaLengkap;
                debitur.RFGenderId = request.RFGenderId;
                debitur.NomorKTP = request.NomorKTP;
                debitur.NomorTelpon = request.NomorTelpon;
                debitur.NomorHP = request.NomorHP;

                // Get Kode Post
                var zipCode = await _zipCode.GetByIdAsync(request.KodePos, "ZipCode");
                var zipCodeTempatTinggal = await _zipCode.GetByIdAsync(request.KodePosTempatTinggal, "ZipCode");

                debitur.AlamatKTP = request.AlamatKTP;
                debitur.RFZipCodeId = zipCode.Id;
                debitur.Kelurahan = request.Kelurahan;
                debitur.Kecamatan = request.Kecamatan;
                debitur.KabupatenKota = request.KabupatenKota;
                debitur.Propinsi = request.Propinsi;
                debitur.AlamatSesuaiKTP = request.AlamatSesuaiKTP;
                debitur.AlamatTempatTinggal = request.AlamatTempatTinggal;
                debitur.RFZipCodeTempatTinggalId = zipCodeTempatTinggal.Id;
                debitur.KelurahanTempatTinggal = request.KelurahanTempatTinggal;
                debitur.KecamatanTempatTinggal = request.KecamatanTempatTinggal;
                debitur.KabupatenKotaTempatTinggal = request.KabupatenKotaTempatTinggal;
                debitur.PropinsiTempatTinggal = request.PropinsiTempatTinggal;
                debitur.NoTelpDapatDihubungi = request.NoTelpDapatDihubungi;
                debitur.TempatLahir = request.TempatLahir;
                debitur.TanggalLahir = request.TanggalLahir;

                await _debitur.UpdateAsync(debitur);

                // var response = _mapper.Map<DebiturResponseDto>(returnedDebitur);
                var response = _mapper.Map<DebiturResponseDto>(debitur);

                await _debitur.SaveChangeAsync();
                return ServiceResponse<DebiturResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<DebiturResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}