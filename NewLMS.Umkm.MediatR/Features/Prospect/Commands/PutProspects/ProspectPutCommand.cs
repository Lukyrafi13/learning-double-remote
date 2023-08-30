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
        private readonly IGenericRepositoryAsync<RfOwnerCategory> _tipeDebitur;
        private readonly IGenericRepositoryAsync<RfProduct> _product;
        private readonly IGenericRepositoryAsync<RfZipCode> _zipCode;
        private readonly IGenericRepositoryAsync<RfGender> _gender;
        private readonly IGenericRepositoryAsync<RfAppType> _AppType;
        private readonly IGenericRepositoryAsync<RfTargetStatus> _statusTarget;
        private readonly IGenericRepositoryAsync<RfSectorLBU3> _subSubSector;
        private readonly IGenericRepositoryAsync<RfCompanyGroup> _kelUsaha;
        private readonly IGenericRepositoryAsync<RfCompanyType> _CompanyType;
        private readonly IMapper _mapper;


        public PutProspectCommandHandler(
                IGenericRepositoryAsync<Prospect> prospect,
                IGenericRepositoryAsync<RfOwnerCategory> tipeDebitur,
                IGenericRepositoryAsync<RfProduct> product,
                IGenericRepositoryAsync<RfZipCode> zipCode,
                IGenericRepositoryAsync<RfGender> gender,
                IGenericRepositoryAsync<RfAppType> AppType,
                IGenericRepositoryAsync<RfTargetStatus> statusTarget,
                IGenericRepositoryAsync<RfSectorLBU3> subSubSector,
                IGenericRepositoryAsync<RfCompanyGroup> kelUsaha,
                IGenericRepositoryAsync<RfCompanyType> CompanyType,
                IMapper mapper
            )
        {
            _prospect = prospect;
            _tipeDebitur = tipeDebitur;
            _product = product;
            _zipCode = zipCode;
            _gender = gender;
            _AppType = AppType;
            _statusTarget = statusTarget;
            _subSubSector = subSubSector;
            _kelUsaha = kelUsaha;
            _CompanyType = CompanyType;
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
            if((await _AppType.GetCountByPredicate(x => x.Id == request.RfAppTypeId)) == 0){
                var response = ServiceResponse<ProspectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "RfAppType tidak ditemukan, pastikan Id sudah sesuai");
                response.Success = false;
                return response;
            }
            if((await _statusTarget.GetCountByPredicate(x => x.Active && x.Id == request.RfTargetStatusId)) == 0){
                var response = ServiceResponse<ProspectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "RfTargetStatusTarget tidak ditemukan, pastikan Id sudah sesuai");
                response.Success = false;
                return response;
            }
            if((await _zipCode.GetCountByPredicate(x => x.Active && x.Id == request.ZipCodeId)) == 0){
                var response = ServiceResponse<ProspectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "RfZipcode tidak ditemukan, pastikan kode pos sudah sesuai");
                response.Success = false;
                return response;
            }
            if((await _zipCode.GetCountByPredicate(x => x.Active && x.Id == request.PlaceZipCodeId)) == 0){
                var response = ServiceResponse<ProspectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "RfZipcode tempat tidak ditemukan, pastikan kode pos sudah sesuai");
                response.Success = false;
                return response;
            }
            if((await _AppType.GetCountByPredicate(x => x.Id == request.RfAppTypeId)) == 0){
                var response = ServiceResponse<ProspectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "RfAppType tidak ditemukan, pastikan Id sudah sesuai");
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

                var tipeDebitur = await _tipeDebitur.GetByIdAsync((Guid)request.RfOwnerCategoryId, "Id");
                var product = await _product.GetByIdAsync((Guid)request.RfProductId, "Id");
                var zipCode = await _zipCode.GetByIdAsync(request.ZipCodeId, "Id");
                var PlaceZipCode = await _zipCode.GetByIdAsync(request.PlaceZipCodeId, "Id");

                var prospect = await _prospect.GetByIdAsync(request.Id, "Id");

                prospect.Fullname = request.Fullname;
                prospect.RfProductId = request.RfProductId;
                prospect.RfOwnerCategoryId = request.RfOwnerCategoryId;
                prospect.RfCategoryId = request.RfCategoryId;
                prospect.ZipCodeId = zipCode.Id;
                prospect.PlaceZipCodeId = PlaceZipCode.Id;
                prospect.PhoneNumber = request.PhoneNumber;

                if (tipeDebitur.OwnDesc.ToLower() == "Badan Usaha".ToLower())
                {
                    prospect.RfCompanyStatusId = request.RfCompanyStatusId;
                    if (product.ProductType.ToUpper() != "KRG"){

                        if((await _kelUsaha.GetCountByPredicate(x => x.Active && x.Id == request.RfCompanyGroupId)) == 0){
                            var responseVal = ServiceResponse<ProspectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "RfKelompokUsahaId tidak ditemukan, pastikan Id sudah sesuai");
                            responseVal.Success = false;
                            return responseVal;
                        }

                        if((await _CompanyType.GetCountByPredicate(x => x.Active && x.Id == (Guid)request.RfCompanyTypeId)) == 0){
                            var responseVal = ServiceResponse<ProspectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "RfCompanyTypeId tidak ditemukan, pastikan Id sudah sesuai");
                            responseVal.Success = false;
                            return responseVal;
                        }

                        prospect.RfCompanyGroupId = request.RfCompanyGroupId;
                        prospect.RfCompanyTypeId = request.RfCompanyTypeId;
                        prospect.OtherCompanyType = request.OtherCompanyType;
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
                    
                    if((await _zipCode.GetCountByPredicate(x => x.Active && x.Id == request.CompanyZipCodeId)) == 0){
                        var responseVal = ServiceResponse<ProspectResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, "RfZipcode tidak ditemukan, pastikan kode pos sudah sesuai");
                        responseVal.Success = false;
                        return responseVal;
                    }
                    prospect.PlaceOfBirth = request.PlaceOfBirth;
                    prospect.DateOfBirth = request.DateOfBirth;
                    prospect.CompanyName = request.CompanyName;
                    prospect.CompanyAddress = request.CompanyAddress;
                    prospect.CompanyFullAddress = request.CompanyFullAddress;
                    prospect.CompanyZipCodeId = request.CompanyZipCodeId;
                    prospect.CompanyNeighborhoods = request.CompanyNeighborhoods;
                    prospect.CompanyDistrict = request.CompanyDistrict;
                    prospect.CompanyCity = request.CompanyCity;
                    prospect.CompanyProvince = request.CompanyProvince;

                    if (product.ProductType.ToUpper() != "KRG"){
                        
                        prospect.NoIdentity = request.NoIdentity;
                    }
                }

                // Alamat
                prospect.Address = request.Address;
                prospect.Neighborhoods = (request.Neighborhoods == null || request.Neighborhoods.Length < 1) ? zipCode.Kelurahan : request.Neighborhoods;
                prospect.District = zipCode.Kecamatan;
                prospect.City = zipCode.Kota;
                prospect.Province = zipCode.Provinsi;

                // Alamat Tempat
                prospect.SameAsIdentity = request.SameAsIdentity;
                prospect.PlaceAddress = request.PlaceAddress;
                prospect.PlaceNeighborhoods = (request.PlaceNeighborhoods == null || request.PlaceNeighborhoods.Length < 1) ? PlaceZipCode.Kelurahan : request.PlaceNeighborhoods;
                prospect.PlaceDistrict = PlaceZipCode.Kecamatan;
                prospect.PlaceCity = PlaceZipCode.Kota;
                prospect.PlaceProvince = PlaceZipCode.Provinsi;

                // Target
                prospect.RfAppTypeId = request.RfAppTypeId;
                prospect.RfTargetStatusId = request.RfTargetStatusId;
                prospect.RfSectorLBU3Code = request.RfSectorLBU3Code;
                prospect.Reason = request.Reason;
                prospect.TargetPladfond = request.TargetPladfond;
                prospect.EstimateProcessDate = request.EstimateProcessDate;


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