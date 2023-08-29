using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.Prospects;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.Prospects.Commands

{
    public class ProspectPostCommand : ProspectPostRequestDto, IRequest<ServiceResponse<ProspectResponseDto>>
    {

    }
    public class PostProspectCommandHandler : IRequestHandler<ProspectPostCommand, ServiceResponse<ProspectResponseDto>>
    {
        private readonly IGenericRepositoryAsync<Prospect> _prospect;
        private readonly IGenericRepositoryAsync<Debitur> _debitur;
        private readonly IGenericRepositoryAsync<RFOwnerCategory> _tipeDebitur;
        private readonly IGenericRepositoryAsync<RFProduct> _product;
        private readonly IGenericRepositoryAsync<RFZipCode> _zipCode;
        private readonly IGenericRepositoryAsync<RFGender> _gender;
        private readonly IGenericRepositoryAsync<RFJenisPermohonan> _jenisPermohonan;
        private readonly IGenericRepositoryAsync<RFStatusTarget> _statusTarget;
        private readonly IGenericRepositoryAsync<RFSectorLBU1> _sector;
        private readonly IGenericRepositoryAsync<RFSectorLBU2> _subSector;
        private readonly IGenericRepositoryAsync<RFSectorLBU3> _subSubSector;
        private readonly IGenericRepositoryAsync<RFKategori> _kategori;
        private readonly IGenericRepositoryAsync<RFKodeDinas> _kodeDinas;
        private readonly IGenericRepositoryAsync<ProspectStageLogs> _stageLog;
        private readonly IGenericRepositoryAsync<RFStages> _stage;
        private readonly IGenericRepositoryAsync<RFKelompokUsaha> _kelUsaha;
        private readonly IGenericRepositoryAsync<RFJenisUsaha> _jenisUsaha;
        private readonly IMapper _mapper;

        public PostProspectCommandHandler(
                IGenericRepositoryAsync<Prospect> prospect,
                IGenericRepositoryAsync<RFOwnerCategory> tipeDebitur,
                IGenericRepositoryAsync<RFProduct> product,
                IGenericRepositoryAsync<RFZipCode> zipCode,
                IGenericRepositoryAsync<Debitur> debitur,
                IGenericRepositoryAsync<RFGender> gender,
                IGenericRepositoryAsync<RFJenisPermohonan> jenisPermohonan,
                IGenericRepositoryAsync<RFStatusTarget> statusTarget,
                IGenericRepositoryAsync<RFSectorLBU1> sector,
                IGenericRepositoryAsync<RFSectorLBU2> subSector,
                IGenericRepositoryAsync<RFSectorLBU3> subSubSector,
                IGenericRepositoryAsync<RFKategori> kategori,
                IGenericRepositoryAsync<RFKodeDinas> kodeDinas,
                IGenericRepositoryAsync<ProspectStageLogs> stageLog,
                IGenericRepositoryAsync<RFKelompokUsaha> kelUsaha,
                IGenericRepositoryAsync<RFJenisUsaha> jenisUsaha,
                IGenericRepositoryAsync<RFStages> stage,
                IMapper mapper
            )
        {
            _prospect = prospect;
            _tipeDebitur = tipeDebitur;
            _product = product;
            _zipCode = zipCode;
            _debitur = debitur;
            _gender = gender;
            _jenisPermohonan = jenisPermohonan;
            _statusTarget = statusTarget;
            _sector = sector;
            _subSector = subSector;
            _subSubSector = subSubSector;
            _kategori = kategori;
            _kodeDinas = kodeDinas;
            _stage = stage;
            _stageLog = stageLog;
            _kelUsaha = kelUsaha;
            _jenisUsaha = jenisUsaha;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ProspectResponseDto>> Handle(ProspectPostCommand request, CancellationToken cancellationToken)
        {

            var debiturId = Guid.NewGuid();
            // Validate data dependencies
            
            var productCount = await _product.GetCountByPredicate(x => x.Active && x.Id == request.RFProductId);
            if(productCount == 0){
                var response = ServiceResponse<ProspectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "RFProduct tidak ditemukan, pastikan Id sudah sesuai");
                response.Success = false;
                return response;
            }
            if((await _tipeDebitur.GetCountByPredicate(x => x.Active && x.Id == request.RFOwnerCategoryId)) == 0){
                var response = ServiceResponse<ProspectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "RFOwnerCategory tidak ditemukan, pastikan Id sudah sesuai");
                response.Success = false;
                return response;
            }
            if((await _jenisPermohonan.GetCountByPredicate(x => x.Id == request.RFJenisPermohonanId)) == 0){
                var response = ServiceResponse<ProspectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "RFJenisPermohonan tidak ditemukan, pastikan Id sudah sesuai");
                response.Success = false;
                return response;
            }
            if((await _statusTarget.GetCountByPredicate(x => x.Active && x.Id == request.RFStatusId)) == 0){
                var response = ServiceResponse<ProspectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "RFStatusTarget tidak ditemukan, pastikan Id sudah sesuai");
                response.Success = false;
                return response;
            }
            if((await _zipCode.GetCountByPredicate(x => x.Active && x.Id == request.KodePosId)) == 0){
                var response = ServiceResponse<ProspectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "RFZipcode tidak ditemukan, pastikan kode pos sudah sesuai");
                response.Success = false;
                return response;
            }
            if((await _zipCode.GetCountByPredicate(x => x.Active && x.Id == request.KodePosTempatId)) == 0){
                var response = ServiceResponse<ProspectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "RFZipcode tidak ditemukan, pastikan kode pos sudah sesuai");
                response.Success = false;
                return response;
            }
            if((await _jenisPermohonan.GetCountByPredicate(x => x.Id == request.RFJenisPermohonanId)) == 0){
                var response = ServiceResponse<ProspectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "RFJenisPermohonan tidak ditemukan, pastikan Id sudah sesuai");
                response.Success = false;
                return response;
            }
            if((await _sector.GetCountByPredicate(x => x.Code == request.RFSectorLBU1Code)) == 0){
                var response = ServiceResponse<ProspectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "RFSectorLBU1 tidak ditemukan, pastikan code sudah sesuai");
                response.Success = false;
                return response;
            }
            if((await _subSector.GetCountByPredicate(x => x.Code == request.RFSectorLBU2Code)) == 0){
                var response = ServiceResponse<ProspectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "RFSectorLBU2 tidak ditemukan, pastikan code sudah sesuai");
                response.Success = false;
                return response;
            }
            if((await _subSubSector.GetCountByPredicate(x => x.Code == request.RFSectorLBU3Code)) == 0){
                var response = ServiceResponse<ProspectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "RFSectorLBU3 tidak ditemukan, pastikan code sudah sesuai");
                response.Success = false;
                return response;
            }
            
            if((await _kategori.GetCountByPredicate(x => x.Active && x.Id == request.RFKategoriId)) == 0){
                var response = ServiceResponse<ProspectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "RFKategoriId tidak ditemukan, pastikan Id sudah sesuai");
                response.Success = false;
                return response;
            }
            
            try
            {
                // Get Tipe Debitur

                var tipeDebitur = await _tipeDebitur.GetByIdAsync(request.RFOwnerCategoryId, "Id");
                var product = await _product.GetByIdAsync(request.RFProductId, "Id");
                var zipCode = await _zipCode.GetByIdAsync(request.KodePosId, "Id");
                var zipCodeTempat = await _zipCode.GetByIdAsync(request.KodePosTempatId, "Id");

                var prospect = new Prospect();

                var countDataProspect = await _prospect.GetCountByPredicate(x =>
                            x.CreatedDate.Year == DateTime.Now.Year
                            && x.CreatedDate.Month == DateTime.Now.Month
                            );

                // Autogenerate Id
                var prospectId = request.KodeCabang+"-"+product.ProductType+"-"+DateTime.Now.ToString("yy")+DateTime.Now.ToString("MM")+"-"+(countDataProspect+1).ToString("D4");

                prospect.ProspectId = prospectId;
                prospect.NamaCustomer = request.NamaCustomer;
                prospect.RFProductId = request.RFProductId;
                prospect.RFOwnerCategoryId = request.RFOwnerCategoryId;
                prospect.RFKategoriId = request.RFKategoriId;
                prospect.RFZipCodeId = zipCode.Id;
                prospect.RFZipCodeTempatId = zipCodeTempat.Id;
                prospect.NomorTelpon = request.NomorTelpon;

                if (tipeDebitur.OwnDesc.ToLower() == "Badan Usaha".ToLower())
                {
                    prospect.StatusPerusahaan = request.StatusPerusahaan;
                    if (product.ProductType.ToUpper() != "KRG"){

                        if((await _kelUsaha.GetCountByPredicate(x => x.ACTIVE && x.Id == request.RFKelompokUsahaId)) == 0){
                            var responseVal = ServiceResponse<ProspectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "RFKelompokUsahaId tidak ditemukan, pastikan Id sudah sesuai");
                            responseVal.Success = false;
                            return responseVal;
                        }

                        if((await _jenisUsaha.GetCountByPredicate(x => x.ACTIVE??false && x.Id == request.RFJenisUsahaId)) == 0){
                            var responseVal = ServiceResponse<ProspectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "RFJenisUsahaId tidak ditemukan, pastikan Id sudah sesuai");
                            responseVal.Success = false;
                            return responseVal;
                        }

                        prospect.RFKelompokUsahaId = request.RFKelompokUsahaId;
                        prospect.RFJenisUsahaId = request.RFJenisUsahaId;
                        prospect.JenisUsahaLain = request.JenisUsahaLain;
                    }
                    
                }

                if (tipeDebitur.OwnDesc.ToLower() == "Perorangan".ToLower())
                {
                    if((await _gender.GetCountByPredicate(x => x.Active && x.Id == request.RFGenderId)) == 0){
                        var responseValidator = ServiceResponse<ProspectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "RFGender tidak ditemukan, pastikan Id sudah sesuai");
                        responseValidator.Success = false;
                        return responseValidator;
                    }
                    
                    prospect.RFGenderId = request.RFGenderId;
                    
                    if((await _zipCode.GetCountByPredicate(x => x.Active && x.Id == request.RFZipCodeUsahaId)) == 0){
                        var responseVal = ServiceResponse<ProspectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "RFZipcode tidak ditemukan, pastikan kode pos sudah sesuai");
                        responseVal.Success = false;
                        return responseVal;
                    }
                    prospect.TempatLahir = request.TempatLahir;
                    prospect.TanggalLahir = request.TanggalLahir;
                    prospect.NamaUsaha = request.NamaUsaha;
                    prospect.AlamatUsaha = request.AlamatUsaha;
                    prospect.AlamatLengkapUsaha = request.AlamatLengkapUsaha;
                    prospect.RFZipCodeUsahaId = request.RFZipCodeUsahaId;
                    prospect.KelurahanUsaha = request.KelurahanUsaha;
                    prospect.KecamatanUsaha = request.KecamatanUsaha;
                    prospect.KabupatenKotaUsaha = request.KabupatenKotaUsaha;
                    prospect.PropinsiUsaha = request.PropinsiUsaha;

                    if (product.ProductType.ToUpper() != "KRG"){
                        
                        prospect.NomorKTP = request.NomorKTP;
                    }
                }

                if (request.RFKodeDinasId != null)
                {
                    if((await _kodeDinas.GetCountByPredicate(x => x.Active && x.Id == request.RFKodeDinasId)) == 0){
                        var responseValidator = ServiceResponse<ProspectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "RFKodeDinas tidak ditemukan, pastikan Id sudah sesuai");
                        responseValidator.Success = false;
                        return responseValidator;
                    }
                    prospect.RFKodeDinasId = request.RFKodeDinasId;
                }

                // Alamat
                prospect.Alamat = request.Alamat;
                prospect.Kelurahan = (request.Kelurahan == null || request.Kelurahan.Length < 1) ? zipCode.Kelurahan : request.Kelurahan;
                prospect.Kecamatan = zipCode.Kecamatan;
                prospect.KabupatenKota = zipCode.Kota;
                prospect.Propinsi = zipCode.Provinsi;

                // Alamat Tempat
                prospect.AlamatSesuaiKTP = request.AlamatSesuaiKTP;
                prospect.AlamatTempat = request.AlamatTempat;
                prospect.KelurahanTempat = (request.KelurahanTempat == null || request.KelurahanTempat.Length < 1) ? zipCodeTempat.Kelurahan : request.KelurahanTempat;
                prospect.KecamatanTempat = zipCodeTempat.Kecamatan;
                prospect.KabupatenKotaTempat = zipCodeTempat.Kota;
                prospect.PropinsiTempat = zipCodeTempat.Provinsi;

                // Target
                prospect.RFJenisPermohonanId = request.RFJenisPermohonanId;
                prospect.RFStatusId = request.RFStatusId;
                prospect.RFSectorLBU1Code = request.RFSectorLBU1Code;
                prospect.RFSectorLBU2Code = request.RFSectorLBU2Code;
                prospect.RFSectorLBU3Code = request.RFSectorLBU3Code;
                prospect.Alasan = request.Alasan;
                prospect.PerkiraanPengajuan = request.PerkiraanPengajuan;
                prospect.TanggalProspect = request.TanggalProspect;

                // Etc
                prospect.NamaAO = request.NamaAO;
                prospect.NamaCabang = request.NamaCabang;
                prospect.KodeCabang = request.KodeCabang;
                prospect.SumberData = "NewLMS";
                prospect.RFStagesId = 1;

                // Generate Debitur
                int existingDebitur = 999;
                while (existingDebitur > 0){
                    debiturId = Guid.NewGuid();
                    existingDebitur = await _debitur.GetCountByPredicate(x=> x.Id == debiturId);
                }


                var debitur = new Debitur();

                // Mandatory empty string
                debitur.NomorKTP = "";
                debitur.AlamatKTP = "";
                debitur.Kelurahan = "";
                debitur.Kecamatan = "";
                debitur.KabupatenKota = "";
                debitur.Propinsi = "";
                debitur.AlamatSesuaiKTP = false;
                debitur.AlamatKTP = "";
                debitur.NoTelpDapatDihubungi = "";
                debitur.NomorHP = "";
                debitur.TempatLahir = "";
                
                // Actual value
                debitur.Id = debiturId;
                debitur.AlamatTempatTinggal = request.Alamat;
                debitur.RFGenderId = request.RFGenderId;
                debitur.KelurahanTempatTinggal = (request.Kelurahan == null || request.Kelurahan.Length < 1) ? zipCode.Kelurahan : request.Kelurahan;
                debitur.KecamatanTempatTinggal = zipCode.Kecamatan;
                debitur.KabupatenKotaTempatTinggal = zipCode.Kota;
                debitur.PropinsiTempatTinggal = zipCode.Provinsi;
                debitur.RFZipCodeTempatTinggalId = zipCode.Id;
                debitur.NamaLengkap = request.NamaCustomer;
                debitur.NomorTelpon = request.NomorTelpon;
                
                await _debitur.AddAsync(debitur, callSave: false);

                prospect.DebiturId = debiturId;
                
                var returnedProspect = await _prospect.AddAsync(prospect, callSave: false);

                var response = _mapper.Map<ProspectResponseDto>(returnedProspect);
                
                await _debitur.SaveChangeAsync();
                await _prospect.SaveChangeAsync();

                // Post History

                var history = new ProspectStageLogs();

                var prospectFound = await _prospect.GetByPredicate(x=> x.ProspectId == prospectId);
                var stageFound = await _stage.GetByPredicate(x=> x.Code == "1.0");

                history.ProspectId = prospectFound.Id;
                history.StageId = stageFound.StageId;
                history.ExecutedBy = prospectFound.NamaAO;

                await _stageLog.AddAsync(history);

                return ServiceResponse<ProspectResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                var response = ServiceResponse<ProspectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                response.Success = false;
                return response;
            }
        }
    }
}