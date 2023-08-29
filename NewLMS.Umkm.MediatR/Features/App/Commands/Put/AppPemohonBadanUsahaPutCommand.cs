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
    public class AppPemohonBadanUsahaPutCommand : AppPemohonBadanUsaha, IRequest<ServiceResponse<Unit>>
    {

    }
    public class AppPemohonBadanUsahaPutCommandHandler : IRequestHandler<AppPemohonBadanUsahaPutCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<App> _app;
        private readonly IGenericRepositoryAsync<RFZipCode> _zipCode;
        private readonly IMapper _mapper;

        public AppPemohonBadanUsahaPutCommandHandler(
            IGenericRepositoryAsync<App> app,
            IGenericRepositoryAsync<RFZipCode> zipCode,
            IMapper mapper)
        {
            _app = app;
            _zipCode = zipCode;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(AppPemohonBadanUsahaPutCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var existingApp = await _app.GetByIdAsync(request.Id, "Id");

                existingApp.NamaCustomer = request.NamaCustomer;
                existingApp.NomorTelpon = request.NomorTelpon;
                existingApp.NPWP = request.NPWP;
                existingApp.Alamat = request.Alamat;
                existingApp.RFZipCodeId = request.RFZipCodeId;
                existingApp.Kelurahan = request.Kelurahan;
                existingApp.Kecamatan = request.Kecamatan;
                existingApp.KabupatenKota = request.KabupatenKota;
                existingApp.Propinsi = request.Propinsi;
                existingApp.NamaKontakDarurat = request.NamaKontakDarurat;
                existingApp.NoTelpKontakDarurat = request.NoTelpKontakDarurat;
                existingApp.AlamatKontakDarurat = request.AlamatKontakDarurat;
                existingApp.RFZipCodeKontakDaruratId = request.RFZipCodeKontakDaruratId;
                existingApp.KelurahanKontakDarurat = request.KelurahanKontakDarurat;
                existingApp.KecamatanKontakDarurat = request.KecamatanKontakDarurat;
                existingApp.KabupatenKotaKontakDarurat = request.KabupatenKotaKontakDarurat;
                existingApp.PropinsiKontakDarurat = request.PropinsiKontakDarurat;

                existingApp.NomorAktaPendirian = request.NomorAktaPendirian;
                existingApp.TanggalAktaPendirian = request.TanggalAktaPendirian;
                existingApp.NomorPendaftaran = request.NomorPendaftaran;
                existingApp.TanggalSK = request.TanggalSK;
                existingApp.PerubahanAktaTerakhir = request.PerubahanAktaTerakhir;
                existingApp.TanggalAkta = request.TanggalAkta;
                existingApp.NomorSIUP = request.NomorSIUP;
                existingApp.TanggalSIUP = request.TanggalSIUP;
                existingApp.NomorTDP = request.NomorTDP;
                existingApp.TanggalTDP = request.TanggalTDP;
                existingApp.TanggalJatuhTempoTDP = request.TanggalJatuhTempoTDP;
                existingApp.NomorSKDP = request.NomorSKDP;
                existingApp.TanggalSKDP = request.TanggalSKDP;
                existingApp.TanggalJatuhTempoSK = request.TanggalJatuhTempoSK;

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