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
    public class AppGudangPutCommand : AppGudang, IRequest<ServiceResponse<Unit>>
    {

    }
    public class AppGudangPutCommandHandler : IRequestHandler<AppGudangPutCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<App> _app;
        private readonly IGenericRepositoryAsync<RFZipCode> _zipCode;
        private readonly IMapper _mapper;

        public AppGudangPutCommandHandler(
            IGenericRepositoryAsync<App> app,
            IGenericRepositoryAsync<RFZipCode> zipCode,
            IMapper mapper)
        {
            _app = app;
            _zipCode = zipCode;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(AppGudangPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingApp = await _app.GetByIdAsync(request.Id, "Id");

                existingApp.NoResi = request.NoResi;
                existingApp.NoSeriResiGudang = request.NoSeriResiGudang;
                existingApp.NamaPemilikResi = request.NamaPemilikResi;
                existingApp.TglTerbitResi = request.TglTerbitResi;
                existingApp.TglJatuhTempoResiGudang = request.TglJatuhTempoResiGudang;
                existingApp.JenisBarang = request.JenisBarang;
                existingApp.JumlahBarangKg = request.JumlahBarangKg;
                existingApp.NilaiBarang = request.NilaiBarang;
                existingApp.LokasiGudangPenyimpanan = request.LokasiGudangPenyimpanan;
                existingApp.NamaLengkapPengelola = request.NamaLengkapPengelola;
                existingApp.NoKTPPengelola = request.NoKTPPengelola;
                existingApp.TglLahirPengelola = request.TglLahirPengelola;

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