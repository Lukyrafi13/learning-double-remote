using AutoMapper;
using NewLMS.Umkm.Data.Dto.RfParameterDetails;
using NewLMS.Umkm.Data.Dto.RfParameters;
using NewLMS.UMKM.Data.Dto;
using NewLMS.UMKM.Data.Dto.RfBusinessFieldKUR;
using NewLMS.UMKM.Data.Dto.RfBusinessLocation;
using NewLMS.UMKM.Data.Dto.RfBusinessOwnership;
using NewLMS.UMKM.Data.Dto.RfBusinessPlaceOwnership;
using NewLMS.UMKM.Data.Dto.RfBusinessPlaceType;
using NewLMS.UMKM.Data.Dto.RfBusinessType;
using NewLMS.UMKM.Data.Dto.RfCollateralBC;
using NewLMS.UMKM.Data.Dto.RfCreditNature;
using NewLMS.UMKM.Data.Dto.RfDocument;
using NewLMS.UMKM.Data.Dto.RfDocumentCollateral;
using NewLMS.UMKM.Data.Dto.RfEducation;
using NewLMS.UMKM.Data.Dto.RfGenders;
using NewLMS.UMKM.Data.Dto.RfJob;
using NewLMS.UMKM.Data.Dto.RfLinkAge;
using NewLMS.UMKM.Data.Dto.RfBranches;
using NewLMS.UMKM.Data.Dto.RfLinkAgeType;
using NewLMS.UMKM.Data.Dto.RfLoanPurpose;
using NewLMS.UMKM.Data.Dto.RfSectorLBU1s;
using NewLMS.UMKM.Data.Dto.RfSectorLBU2s;
using NewLMS.UMKM.Data.Dto.RfSectorLBU3s;
using NewLMS.UMKM.Data.Dto.RfMappingCollateral;
using NewLMS.UMKM.Data.Dto.RfMappingTenor;
using NewLMS.UMKM.Data.Dto.RfMarital;
using NewLMS.UMKM.Data.Dto.RfPlacementCountry;
using NewLMS.UMKM.Data.Dto.RfProducts;
using NewLMS.UMKM.Data.Dto.RfScPosition;
using NewLMS.UMKM.Data.Dto.RfSubProducts;
using NewLMS.UMKM.Data.Dto.RfTenor;
using NewLMS.UMKM.Data.Dto.RfTransportationType;
using NewLMS.UMKM.Data.Dto.RfVehClass;
using NewLMS.UMKM.Data.Dto.RfVehMaker;
using NewLMS.UMKM.Data.Dto.RfVehModel;
using NewLMS.UMKM.Data.Dto.RfVehType;
using NewLMS.UMKM.Data.Dto.RfZipCodes;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RfInstituteCodes;
using NewLMS.UMKM.Data.Dto.RfVehCountry;
using NewLMS.UMKM.Data.Dto.RfCompanyTypes;
using NewLMS.UMKM.Data.Dto.RfInstallmentTypes;
using NewLMS.UMKM.Data.Dto.RfCondition;
using NewLMS.UMKM.Data.Dto.RfCreditType;
using NewLMS.UMKM.Data.Dto.RfSandiBI;
using NewLMS.UMKM.Data.Dto.RfSandiBIGroup;
using NewLMS.UMKM.Data.Dto.RfDecisionMakers;
using NewLMS.UMKM.Data.Dto.RfAppraisalKJPPMasters;

namespace NewLMS.UMKM.API.Helpers.Mapping
{
    public class ReferenceProfile : Profile
    {
        public ReferenceProfile()
        {
            //RfProduct
            CreateMap<RfProduct, RfProductResponse>();
            CreateMap<RfProduct, RfProductSimpleResponse>();

            //RfGender
            CreateMap<RfGender, RfGenderResponse>();
            CreateMap<RfGender, RfGenderSimpleResponse>();

            //RfEducation
            CreateMap<RfEducation, RfEducationResponse>();
            CreateMap<RfEducation, RfEducationSimpleResponse>();

            //RfBranch
            CreateMap<RfBranch, RfBranchResponse>();

            //RfMarital
            CreateMap<RfMarital, RfMaritalResponse>();
            CreateMap<RfMarital, RfMaritalSimpleResponse>();

            //RfSectorLBU
            CreateMap<RfSectorLBU1, RfSectorLBU1Response>();
            CreateMap<RfSectorLBU2, RfSectorLBU2Response>()
                .ForMember(d => d.RfSectorLBU1, s => s.MapFrom(d => d.RfSectorLBU1));
            CreateMap<RfSectorLBU3, RfSectorLBU3Response>()
                .ForMember(d => d.RfSectorLBU2, s => s.MapFrom(d => d.RfSectorLBU2));

            //RfJob
            CreateMap<RfJob, RfJobResponse>()
                .ForMember(d => d.RfProduct, s => s.MapFrom(d => d.RfProduct));
            CreateMap<RfJob, RfJobSimpleResponse>();

            //RfCollateralBC
            CreateMap<RfCollateralBC, RfCollateralBCResponse>();
            CreateMap<RfCollateralBC, RfCollateralBCSimpleResponse>();

            //RfDocumentCollateral
            CreateMap<RfDocumentCollateral, RfDocumentCollateralResponse>()
                .ForMember(d => d.RfDocument, s => s.MapFrom(d => d.RfDocument))
                .ForMember(d => d.RfCollateralBC, s => s.MapFrom(d => d.RfCollateralBC));
            CreateMap<RfDocumentCollateral, RfDocumentCollateralSimpleResponse>()
                .ForMember(d => d.RfDocument, s => s.MapFrom(d => d.RfDocument))
                .ForMember(d => d.RfCollateralBC, s => s.MapFrom(d => d.RfCollateralBC));

            //RfDocument
            CreateMap<RfDocument, RfDocumentResponse>();
            CreateMap<RfDocument, RfDocumentSimpleResponse>();
            //RfMappingCollateral
            CreateMap<RfMappingCollateral, RfMappingCollateralResponse>()
                .ForMember(d => d.RfProduct, s => s.MapFrom(d => d.RfProduct))
                .ForMember(d => d.RfCollateralBC, s => s.MapFrom(d => d.RfCollateralBC));
            CreateMap<RfMappingCollateral, RfMappingCollateralSimpleResponse>()
                .ForMember(d => d.RfProduct, s => s.MapFrom(d => d.RfProduct))
                .ForMember(d => d.RfCollateralBC, s => s.MapFrom(d => d.RfCollateralBC));

            //RfLoanPurpose
            CreateMap<RfLoanPurpose, RfLoanPurposeResponse>();
            CreateMap<RfLoanPurpose, RfLoanPurposeSimpleResponse>();

            //RfSubProduct
            CreateMap<RfSubProduct, RfSubProductResponse>()
                .ForMember(d => d.RfProduct, s => s.MapFrom(d => d.RfProduct))
                .ForMember(d => d.RfLoanPurpose, s => s.MapFrom(d => d.RfLoanPurpose));
            CreateMap<RfSubProduct, RfSubProductSimpleResponse>();

            //RfTenor,
            CreateMap<RfTenor, RfTenorResponse>()
                .ForMember(d => d.RfProduct, s => s.MapFrom(d => d.RfProduct));
            CreateMap<RfTenor, RfTenorSimpleResponse>();

            //RfMappingTenor
            CreateMap<RfMappingTenor, RfMappingTenorResponse>()
                .ForMember(d => d.RfTenor, s => s.MapFrom(d => d.RfTenor))
                .ForMember(d => d.RfProduct, s => s.MapFrom(d => d.RfProduct))
                .ForMember(d => d.RfLoanPurpose, s => s.MapFrom(d => d.RfLoanPurpose))
                .ForMember(d => d.ParamApplicationType, s => s.MapFrom(d => d.ParamApplicationType))
                .ForMember(d => d.RfSubProduct, s => s.MapFrom(d => d.RfSubProduct));
            CreateMap<RfMappingTenor, RfMappingTenorSimpleResponse>()
                .ForMember(d => d.RfTenor, s => s.MapFrom(d => d.RfTenor))
                .ForMember(d => d.RfProduct, s => s.MapFrom(d => d.RfProduct));

            //RfCreditNature
            CreateMap<RfCreditNature, RfCreditNatureResponse>();
            CreateMap<RfCreditNature, RfCreditNatureSimpleResponse>();

            //RfVehCountry
            CreateMap<RfVehCountry, RfVehCountryResponse>();
            CreateMap<RfVehCountry, RfVehCountrySimpleResponse>();

            //RfVehMaker
            CreateMap<RfVehMaker, RfVehMakerResponse>()
                .ForMember(d => d.RfVehType, s => s.MapFrom(d => d.RfVehType))
                .ForMember(d => d.RfVehCountry, s => s.MapFrom(d => d.RfVehCountry))
                .ForMember(d => d.RfCollateralBC, s => s.MapFrom(d => d.RfCollateralBC));
            CreateMap<RfVehMaker, RfVehMakerSimpleResponse>();

            //RfVehClass
            CreateMap<RfVehClass, RfVehClassResponse>()
                .ForMember(d => d.RfVehType, s => s.MapFrom(d => d.RfVehType))
                .ForMember(d => d.RfVehModel, s => s.MapFrom(d => d.RfVehModel))
                .ForMember(d => d.RfVehMaker, s => s.MapFrom(d => d.RfVehMaker));
            CreateMap<RfVehClass, RfVehClassSimpleResponse>();

            //RfVehType
            CreateMap<RfVehType, RfVehTypeResponse>();
            CreateMap<RfVehType, RfVehTypeSimpleResponse>();

            //RfTransportatioType
            CreateMap<RfTransportationType, RfTransportationTypeResponse>();
            CreateMap<RfTransportationType, RfTransportationTypeSimpleResponse>();

            //RfVehModel
            CreateMap<RfVehModel, RfVehModelResponse>();
            CreateMap<RfVehModel, RfVehModelSimplelResponse>();

            //RfPlacementCountry
            CreateMap<RfPlacementCountry, RfPlacementCountryResponse>();
            CreateMap<RfPlacementCountry, RfPlacementCountrySimpleResponse>();

            //RfBusinesOwnership
            CreateMap<RfBusinessOwnership, RfBusinessOwnershipResponse>();
            CreateMap<RfBusinessOwnership, RfBusinessOwnershipSimpleResponse>();

            //RfBusinesFieldKUR
            CreateMap<RfBusinessFieldKUR, RfBusinessFieldKURResponse>();
            CreateMap<RfBusinessFieldKUR, RfBusinessFieldKURSimpleResponse>();

            //RfBusinessPlaceType
            CreateMap<RfBusinessPlaceType, RfBusinessPlaceTypeResponse>();
            CreateMap<RfBusinessPlaceType, RfBusinessPlaceTypeSimpleResponse>();

            //RfBusinessType
            CreateMap<RfBusinessType, RfBusinessTypeResponse>();
            CreateMap<RfBusinessType, RfBusinessTypeSimpleResponse>();

            //RfBusinessPlaceLocation
            CreateMap<RfBusinessPlaceLocation, RfBusinessPlaceLocationResponse>();
            CreateMap<RfBusinessPlaceLocation, RfBusinessPlaceLocationSimpleResponse>();

            //RfLoanPurpose
            CreateMap<RfLoanPurpose, RfLoanPurposeResponse>();
            CreateMap<RfLoanPurpose, RfLoanPurposeSimpleResponse>();

            //RfBusinessPlaceOwnership
            CreateMap<RfBusinessPlaceOwnership, RfBusinessPlaceOwnershipResponse>()
                .ForMember(d => d.RfBusinessPlaceLocation, s => s.MapFrom(d => d.RfBusinessPlaceLocation));
            CreateMap<RfBusinessPlaceOwnership, RfBusinessPlaceOwnershipSimpleResponse>();

            //RfBusinessLocation
            CreateMap<RfBusinessLocation, RfBusinessLocationResponse>();
            CreateMap<RfBusinessLocation, RfBusinessLocationSimpleResponse>();

            //RfScPosition
            CreateMap<RfScPosition, RfScPositionResponse>()
                .ForMember(d => d.RfDecisionLetter, s => s.MapFrom(d => d.RfDecisionLetter));
            CreateMap<RfScPosition, RfScPositionSimpleResponse>();

            //RfLinkAge
            CreateMap<RfLinkAge, RfLinkAgeResponse>();
            CreateMap<RfLinkAge, RfLinkAgeResponse>();

            //RfLinkAgeType
            CreateMap<RfLinkAgeType, RfLinkAgeTypeResponse>();
            CreateMap<RfLinkAgeType, RfLinkAgeTypeSimpleResponse>();

            //RfParameter
            CreateMap<RfParameter, RfParameterResponse>()
                .ForMember(d => d.RfParameterDetails, s => s.MapFrom(d => d.RfParameterDetails));

            //RfParameterDetail
            CreateMap<RfParameterDetail, RfParameterDetailResponse>()
                .ForMember(d => d.RfParameter, s => s.MapFrom(d => d.RfParameter));
            CreateMap<RfParameterDetail, RfParameterDetailSimpleResponse>();

            //RfZipCode
            CreateMap<RfZipCode, RfZipCodeResponse>().ReverseMap();
            CreateMap<RfZipCodePostRequest, RfZipCode>();
            CreateMap<RfZipCodePutRequest, RfZipCode>();

            //RfCompanyType
            CreateMap<RfCompanyType, RfCompanyTypeResponse>()
                .ForMember(d => d.ParamCompanyGroup, s => s.MapFrom(d => d.ParamCompanyGroup));

            //RfInstituteCode
            CreateMap<RfInstituteCode, RfInstituteCodeResponse>();

            //RfInstalmentType
            CreateMap<RfInstallmentType, RfInstallmentTypeResponse>();
            CreateMap<RfInstallmentType, RfInstallmentTypeSimpleResponse>();

            //RfCondition
            CreateMap<RfCondition, RfConditionResponse>();
            CreateMap<RfCondition, RfConditionSimpleResponse>();

            //RfCreditType
            CreateMap<RfCreditType, RfCreditTypeResponse>();
            CreateMap<RfCreditType, RfCreditTypeSimpleResponse>();

            //RfSandiBI
            CreateMap<RfSandiBI, RfSandiBIResponse>()
                .ForMember(d => d.RfSandiBIGroup, s => s.MapFrom(d => d.RfSandiBIGroup));
            CreateMap<RfSandiBI, RfSandiBIMinResponse>();
            CreateMap<RfSandiBI, RfSandiBISimpleResponse>()
                .ForMember(d => d.RfSandiBIGroup, s => s.MapFrom(d => d.RfSandiBIGroup));

            //RfSandiBIGroup
            CreateMap<RfSandiBIGroup, RfSandiBIGroupResponse>();

            //RfDecisionMaker
            CreateMap<RfDecisionMaker, RfDecisionMakerResponse>();
            CreateMap<RfDecisionMaker, RfDecisionMakerSimpleResponse>();

            //RfAPpraisalKJPPMaster
            CreateMap<RfAppraisalKJPPMaster, RfAppraisalKJPPMastersResponse>();
        }
    }
}
