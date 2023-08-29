using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.Prospects;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.Prospects.Commands
{
    public class ProspectPutCommand : ProspectPutRequestDto, IRequest<ServiceResponse<ProspectResponseDto>>
    {

    }
    public class PutProspectCommandHandler : IRequestHandler<ProspectPutCommand, ServiceResponse<ProspectResponseDto>>
    {
        private readonly IGenericRepositoryAsync<Prospect> _prospect;
        // private readonly IGenericRepositoryAsync<Debitur> _debitur;
        private readonly IGenericRepositoryAsync<RfOwnerCategory> _tipeDebitur;
        private readonly IGenericRepositoryAsync<RfProduct> _product;
        private readonly IGenericRepositoryAsync<RfZipCode> _zipCode;
        private readonly IGenericRepositoryAsync<RfGender> _gender;
        private readonly IGenericRepositoryAsync<RfAppType> _jenisPermohonan;
        private readonly IGenericRepositoryAsync<RfTargetStatus> _statusTarget;
        private readonly IGenericRepositoryAsync<RfSectorLBU1> _sector;
        private readonly IGenericRepositoryAsync<RfSectorLBU2> _subSector;
        private readonly IGenericRepositoryAsync<RfSectorLBU3> _subSubSector;
        private readonly IGenericRepositoryAsync<RfCompanyGroup> _kelUsaha;
        private readonly IGenericRepositoryAsync<RfCompanyType> _jenisUsaha;
        private readonly IMapper _mapper;


        public PutProspectCommandHandler(
                IGenericRepositoryAsync<Prospect> prospect,
                IGenericRepositoryAsync<RfOwnerCategory> tipeDebitur,
                IGenericRepositoryAsync<RfProduct> product,
                IGenericRepositoryAsync<RfZipCode> zipCode,
                // IGenericRepositoryAsync<Debitur> debitur,
                IGenericRepositoryAsync<RfGender> gender,
                IGenericRepositoryAsync<RfAppType> jenisPermohonan,
                IGenericRepositoryAsync<RfTargetStatus> statusTarget,
                IGenericRepositoryAsync<RfSectorLBU1> sector,
                IGenericRepositoryAsync<RfSectorLBU2> subSector,
                IGenericRepositoryAsync<RfSectorLBU3> subSubSector,
                IGenericRepositoryAsync<RfCompanyGroup> kelUsaha,
                IGenericRepositoryAsync<RfCompanyType> jenisUsaha,
                IMapper mapper
            )
        {
            _prospect = prospect;
            _tipeDebitur = tipeDebitur;
            _product = product;
            _zipCode = zipCode;
            // _debitur = debitur;
            _gender = gender;
            _jenisPermohonan = jenisPermohonan;
            _statusTarget = statusTarget;
            _sector = sector;
            _subSector = subSector;
            _subSubSector = subSubSector;
            _kelUsaha = kelUsaha;
            _jenisUsaha = jenisUsaha;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ProspectResponseDto>> Handle(ProspectPutCommand request, CancellationToken cancellationToken)
        {
            var productCount = await _product.GetCountByPredicate(x => x.Active && x.Id == request.RfProductId);
            if(productCount == 0){
                var response = ServiceResponse<ProspectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "RfProduct tidak ditemukan, pastikan Id sudah sesuai");
                response.Success = false;
                return response;
            }
            if((await _tipeDebitur.GetCountByPredicate(x => x.Active && x.Id == request.RfOwnerCategoryId)) == 0){
                var response = ServiceResponse<ProspectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "RfOwnerCategory tidak ditemukan, pastikan Id sudah sesuai");
                response.Success = false;
                return response;
            }
            if((await _jenisPermohonan.GetCountByPredicate(x => x.Id == request.RfAppTypeId)) == 0){
                var response = ServiceResponse<ProspectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "RfAppType tidak ditemukan, pastikan Id sudah sesuai");
                response.Success = false;
                return response;
            }
            if((await _statusTarget.GetCountByPredicate(x => x.Active && x.Id == request.RFStatusId)) == 0){
                var response = ServiceResponse<ProspectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "RfTargetStatus tidak ditemukan, pastikan Id sudah sesuai");
                response.Success = false;
                return response;
            }
            if((await _zipCode.GetCountByPredicate(x => x.Active && x.Id == request.KodePosId)) == 0){
                var response = ServiceResponse<ProspectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "RfZipcode tidak ditemukan, pastikan kode pos sudah sesuai");
                response.Success = false;
                return response;
            }
            if((await _zipCode.GetCountByPredicate(x => x.Active && x.Id == request.KodePosTempatId)) == 0){
                var response = ServiceResponse<ProspectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "RfZipcode tidak ditemukan, pastikan kode pos sudah sesuai");
                response.Success = false;
                return response;
            }
            if((await _jenisPermohonan.GetCountByPredicate(x => x.Id == request.RfAppTypeId)) == 0){
                var response = ServiceResponse<ProspectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "RfAppType tidak ditemukan, pastikan Id sudah sesuai");
                response.Success = false;
                return response;
            }
            if((await _sector.GetCountByPredicate(x => x.Code == request.RfSectorLBU1Code)) == 0){
                var response = ServiceResponse<ProspectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "RfSectorLBU1 tidak ditemukan, pastikan code sudah sesuai");
                response.Success = false;
                return response;
            }
            if((await _subSector.GetCountByPredicate(x => x.Code == request.RfSectorLBU2Code)) == 0){
                var response = ServiceResponse<ProspectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "RfSectorLBU2 tidak ditemukan, pastikan code sudah sesuai");
                response.Success = false;
                return response;
            }
            if((await _subSubSector.GetCountByPredicate(x => x.Code == request.RfSectorLBU3Code)) == 0){
                var response = ServiceResponse<ProspectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "RfSectorLBU3 tidak ditemukan, pastikan code sudah sesuai");
                response.Success = false;
                return response;
            }

            try
            {
                // Get Tipe Debitur

                var tipeDebitur = await _tipeDebitur.GetByIdAsync(request.RfOwnerCategoryId, "Id");
                var product = await _product.GetByIdAsync(request.RfProductId, "Id");
                var zipCode = await _zipCode.GetByIdAsync(request.KodePosId, "Id");
                var zipCodeTempat = await _zipCode.GetByIdAsync(request.KodePosTempatId, "Id");

                var prospect = await _prospect.GetByIdAsync(Guid.Parse(request.Id), "Id");

                prospect.NamaCustomer = request.NamaCustomer;
                prospect.RfProductId = request.RfProductId;
                prospect.RfOwnerCategoryId = request.RfOwnerCategoryId;
                prospect.RfCategoryId = request.RfCategoryId;
                prospect.RfZipCodeId = zipCode.Id;
                prospect.RfZipCodeTempatId = zipCodeTempat.Id;
                prospect.NomorTelpon = request.NomorTelpon;

                if (tipeDebitur.OwnDesc.ToLower() == "Badan Usaha".ToLower())
                {
                    prospect.StatusPerusahaan = request.StatusPerusahaan;
                    if (product.ProductType.ToUpper() != "KRG"){

                        if((await _kelUsaha.GetCountByPredicate(x => x.ACTIVE && x.Id == request.RfCompanyGroupId)) == 0){
                            var responseVal = ServiceResponse<ProspectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "RfCompanyGroupId tidak ditemukan, pastikan Id sudah sesuai");
                            responseVal.Success = false;
                            return responseVal;
                        }

                        if((await _jenisUsaha.GetCountByPredicate(x => x.ACTIVE??false && x.Id == request.RfCompanyTypeId)) == 0){
                            var responseVal = ServiceResponse<ProspectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "RfCompanyTypeId tidak ditemukan, pastikan Id sudah sesuai");
                            responseVal.Success = false;
                            return responseVal;
                        }

                        prospect.RfCompanyGroupId = request.RfCompanyGroupId;
                        prospect.RfCompanyTypeId = request.RfCompanyTypeId;
                        prospect.JenisUsahaLain = request.JenisUsahaLain;
                    }
                }

                if (tipeDebitur.OwnDesc.ToLower() == "Perorangan".ToLower())
                {
                    if((await _gender.GetCountByPredicate(x => x.Active && x.Id == request.RfGenderId)) == 0){
                        var responseValidator = ServiceResponse<ProspectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "RfGender tidak ditemukan, pastikan Id sudah sesuai");
                        responseValidator.Success = false;
                        return responseValidator;
                    }
                    
                    prospect.RfGenderId = request.RfGenderId;
                    
                    if((await _zipCode.GetCountByPredicate(x => x.Active && x.Id == request.RfZipCodeUsahaId)) == 0){
                        var responseVal = ServiceResponse<ProspectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "RfZipcode tidak ditemukan, pastikan kode pos sudah sesuai");
                        responseVal.Success = false;
                        return responseVal;
                    }
                    prospect.TempatLahir = request.TempatLahir;
                    prospect.TanggalLahir = request.TanggalLahir;
                    prospect.NamaUsaha = request.NamaUsaha;
                    prospect.AlamatUsaha = request.AlamatUsaha;
                    prospect.AlamatLengkapUsaha = request.AlamatLengkapUsaha;
                    prospect.RfZipCodeUsahaId = request.RfZipCodeUsahaId;
                    prospect.KelurahanUsaha = request.KelurahanUsaha;
                    prospect.KecamatanUsaha = request.KecamatanUsaha;
                    prospect.KabupatenKotaUsaha = request.KabupatenKotaUsaha;
                    prospect.PropinsiUsaha = request.PropinsiUsaha;

                    if (product.ProductType.ToUpper() != "KRG"){
                        
                        prospect.NomorKTP = request.NomorKTP;
                    }
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
                prospect.RfAppTypeId = request.RfAppTypeId;
                prospect.RFStatusId = request.RFStatusId;
                prospect.RfSectorLBU1Code = request.RfSectorLBU1Code;
                prospect.RfSectorLBU2Code = request.RfSectorLBU2Code;
                prospect.RfSectorLBU3Code = request.RfSectorLBU3Code;
                prospect.Alasan = request.Alasan;
                prospect.PerkiraanPengajuan = request.PerkiraanPengajuan;
                prospect.TanggalProspect = request.TanggalProspect;

                // Update debitur
                // var existingDebitur = await _debitur.GetByIdAsync(prospect.DebiturId, "Id");
               
                // existingDebitur.AlamatTempatTinggal = request.Alamat;
                // existingDebitur.RfGenderId = request.RfGenderId;
                // existingDebitur.KelurahanTempatTinggal = (request.Kelurahan == null || request.Kelurahan.Length < 1) ? zipCode.Kelurahan : request.Kelurahan ;
                // existingDebitur.KecamatanTempatTinggal = zipCode.Kecamatan;
                // existingDebitur.KabupatenKotaTempatTinggal = zipCode.Kota;
                // existingDebitur.PropinsiTempatTinggal = zipCode.Provinsi;
                // existingDebitur.RfZipCodeTempatTinggalId = zipCode.Id;
                // existingDebitur.NamaLengkap = request.NamaCustomer;
                // existingDebitur.NomorTelpon = request.NomorTelpon;
                
                // await _debitur.UpdateAsync(existingDebitur);

                await _prospect.UpdateAsync(prospect);

                var response = _mapper.Map<ProspectResponseDto>(prospect);

                await _prospect.SaveChangeAsync();
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