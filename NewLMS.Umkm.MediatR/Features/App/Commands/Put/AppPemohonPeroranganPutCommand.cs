using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.Apps;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.Apps.Commands
{
    public class AppPemohonPeroranganPutCommand : AppPemohonPerorangan, IRequest<ServiceResponse<Unit>>
    {

    }
    public class AppPemohonPeroranganPutCommandHandler : IRequestHandler<AppPemohonPeroranganPutCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<App> _app;
        private readonly IGenericRepositoryAsync<RFZipCode> _zipCode;
        private readonly IMapper _mapper;

        public AppPemohonPeroranganPutCommandHandler(
            IGenericRepositoryAsync<App> app,
            IGenericRepositoryAsync<RFZipCode> zipCode,
            IMapper mapper)
        {
            _app = app;
            _zipCode = zipCode;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(AppPemohonPeroranganPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingApp = await _app.GetByIdAsync(request.Id, "Id");

                existingApp.NamaCustomer = request.NamaCustomer;
                existingApp.TempatLahir = request.TempatLahir;
                existingApp.TanggalLahir = request.TanggalLahir;
                existingApp.NomorKTP = request.NomorKTP;
                existingApp.BerlakuSampaiDengan = request.BerlakuSampaiDengan;
                existingApp.SeumurHidup = request.SeumurHidup;
                existingApp.NomorTelpon = request.NomorTelpon;
                // existingApp.KewarganegaraanId = request.KewarganegaraanId;
                existingApp.RFEducationId = request.RFEducationId;
                existingApp.NamaIbuKandung = request.NamaIbuKandung;
                existingApp.JumlahTanggungan = request.JumlahTanggungan;
                existingApp.NPWP = request.NPWP;
                existingApp.RFMaritalId = request.RFMaritalId;
                existingApp.RFJobId = request.RFJobId;
                existingApp.NomorAktaNikah = request.NomorAktaNikah;
                existingApp.TanggalAktaNikah = request.TanggalAktaNikah;
                existingApp.PembuatAktaNikah = request.PembuatAktaNikah;
                existingApp.Alamat = request.Alamat;
                existingApp.RFZipCodeId = request.RFZipCodeId;
                existingApp.Kelurahan = request.Kelurahan;
                existingApp.Kecamatan = request.Kecamatan;
                existingApp.KabupatenKota = request.KabupatenKota;
                existingApp.Propinsi = request.Propinsi;
                existingApp.LamaTinggal = request.LamaTinggal;
                existingApp.RFHomestaId = request.RFHomestaId;
                existingApp.NamaLengkapPasangan = request.NamaLengkapPasangan;
                existingApp.NoKTPPasangan = request.NoKTPPasangan;
                existingApp.NPWPPasangan = request.NPWPPasangan;
                existingApp.RFJobPasanganId = request.RFJobPasanganId;
                existingApp.TempatLahirPasangan = request.TempatLahirPasangan;
                existingApp.TanggalLahirPasangan = request.TanggalLahirPasangan;
                existingApp.AlamatSamaDenganDebitur = request.AlamatSamaDenganDebitur;
                existingApp.AlamatPasangan = request.AlamatPasangan;
                existingApp.RFZipCodePasanganId = request.RFZipCodePasanganId;
                existingApp.KelurahanPasangan = request.KelurahanPasangan;
                existingApp.KecamatanPasangan = request.KecamatanPasangan;
                existingApp.KabupatenKotaPasangan = request.KabupatenKotaPasangan;
                existingApp.PropinsiPasangan = request.PropinsiPasangan;
                existingApp.NamaKontakDarurat = request.NamaKontakDarurat;
                existingApp.NoTelpKontakDarurat = request.NoTelpKontakDarurat;
                existingApp.NoKTPKontakDarurat = request.NoKTPKontakDarurat;
                existingApp.AlamatKontakDarurat = request.AlamatKontakDarurat;
                existingApp.RFZipCodeKontakDaruratId = request.RFZipCodeKontakDaruratId;
                existingApp.KelurahanKontakDarurat = request.KelurahanKontakDarurat;
                existingApp.KecamatanKontakDarurat = request.KecamatanKontakDarurat;
                existingApp.KabupatenKotaKontakDarurat = request.KabupatenKotaKontakDarurat;
                existingApp.PropinsiKontakDarurat = request.PropinsiKontakDarurat;

                await _app.UpdateAsync(existingApp);
                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}