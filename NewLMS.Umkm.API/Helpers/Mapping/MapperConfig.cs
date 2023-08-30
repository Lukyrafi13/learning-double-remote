﻿using AutoMapper;
using NewLMS.Umkm.API.Helpers.Mapping;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.API.Helpers.Mapping
{
    public static class MapperConfig
    {
        public static IMapper GetMapperConfigs()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new RfGenderProfile());
                mc.AddProfile(new RFSCOREPUTASITEMPATTINGGALProfile());
                mc.AddProfile(new RFSCOHUBUNGANPERBANKANProfile());
                mc.AddProfile(new RFSCOMUTASIPERBULANProfile());
                mc.AddProfile(new RFSCOSCORINGAGUNANProfile());
                mc.AddProfile(new RFSCOTINGKATKEBUTUHANProfile());
                mc.AddProfile(new RFSCOSALDOREKRATAProfile());
                mc.AddProfile(new RFSCORiwayatKreditBJBProfile());
                mc.AddProfile(new RFSCOPENGELOLAKEUANGANProfile());
                mc.AddProfile(new RFSCOLOKTEMPATUSAHAProfile());
                mc.AddProfile(new RFSCOHUTANGPIHAKLAINProfile());
                mc.AddProfile(new RFSCOCARATRANSAKSIProfile());
                mc.AddProfile(new RFJOBProfile());
                // mc.AddProfile(new DebiturProfile());
                mc.AddProfile(new ProspectProfile());
                mc.AddProfile(new RfSectorLBU1Profile());
                mc.AddProfile(new RfSectorLBU2Profile());
                mc.AddProfile(new RfSectorLBU3Profile());
                mc.AddProfile(new RfZipCodeProfile());
                mc.AddProfile(new RfAppTypeProfile());
                mc.AddProfile(new RfCategoryProfile());
                mc.AddProfile(new RfServiceCodeProfile());
                mc.AddProfile(new RFColLateralBCProfile());
                mc.AddProfile(new RFDocumentProfile());
                mc.AddProfile(new RFDocumentAgunanProfile());
                mc.AddProfile(new RFMappingAgunan2Profile());
                mc.AddProfile(new RFRelationColProfile());
                mc.AddProfile(new RFMARITALProfile());
                mc.AddProfile(new RFSubProductProfile());
                mc.AddProfile(new RFTenorProfile());
                mc.AddProfile(new RFTenorMappingProfile());
                mc.AddProfile(new RFSifatKreditProfile());
                mc.AddProfile(new RFVEHCLASSProfile());
                mc.AddProfile(new RFVEHMAKERProfile());
                mc.AddProfile(new RFEDUCATIONProfile());
                mc.AddProfile(new RFVEHICLETYPEProfile());
                mc.AddProfile(new RFLoanPurposeProfile());
                mc.AddProfile(new RFHOMESTAProfile());
                mc.AddProfile(new RFVehModelProfile());
                mc.AddProfile(new RFJenisKendaraanAgunanProfile());
                mc.AddProfile(new RFBuktiKepemilikanProfile());
                mc.AddProfile(new RFKepemilikanTUProfile());
                mc.AddProfile(new RFJenisTempatUsahaProfile());
                mc.AddProfile(new RFAspekPemasaranProfile());
                mc.AddProfile(new RFCaraPengikatanProfile());
                mc.AddProfile(new RFDecisionSKProfile());
                mc.AddProfile(new RfCompanyGroupProfile());
                mc.AddProfile(new RFLokasiTempatUsahaProfile());
                mc.AddProfile(new RfBranchProfile());
                mc.AddProfile(new RFSubProductTenorProfile());
                mc.AddProfile(new RFVehicleTypeListProfile());
                // mc.AddProfile(new RFStageProfile());
                // mc.AddProfile(new ProspectStageLogsProfile());
                mc.AddProfile(new RFRelationSurveyProfile());
                // mc.AddProfile(new AppProfile());
                // mc.AddProfile(new AppKeyPersonProfile());
                mc.AddProfile(new RfCompanyTypeProfile());
                // mc.AddProfile(new AppAgunanProfile());
                mc.AddProfile(new RfCompanyTypeMapProfile());
                mc.AddProfile(new RFRejectProfile());
                mc.AddProfile(new AppContactPersonProfile());
                mc.AddProfile(new RFNegaraPenempatanProfile());
                mc.AddProfile(new PrescreeningProfile());
                mc.AddProfile(new FileUrlProfile());
                mc.AddProfile(new RFTipeDokumenProfile());
                mc.AddProfile(new RFStatusDokumenProfile());
                mc.AddProfile(new FileDokumenProfile());
                mc.AddProfile(new PrescreeningDokumenProfile());
                // mc.AddProfile(new AppFasilitasKreditProfile());
                mc.AddProfile(new SurveyProfile());
                mc.AddProfile(new SurveySupplierProfile());
                mc.AddProfile(new SurveyBuyerProfile());
                mc.AddProfile(new SurveyFileUploadProfile());
                mc.AddProfile(new SIKPHistoryProfile());
                mc.AddProfile(new SIKPHistoryDetailProfile());
                mc.AddProfile(new SIKPCalonDebiturProfile());
                mc.AddProfile(new SlikRequestProfile());
                mc.AddProfile(new SlikRequestObjectProfile());
                mc.AddProfile(new RFPilihanPemutusProfile());
                mc.AddProfile(new RFBusinessTypeProfile());
                mc.AddProfile(new RFBidangUsahaKURProfile());
                mc.AddProfile(new RFPaymentMethodProfile());
                mc.AddProfile(new RFLamaUsahaLainProfile());
                mc.AddProfile(new RFKepemilikanUsahaProfile());
                mc.AddProfile(new RFMappingLBU3Profile());
                mc.AddProfile(new RFSiklusUsahaProfile());
                mc.AddProfile(new RFOwnerOTSProfile());
                mc.AddProfile(new RFSiklusUsahaPokokProfile());
                mc.AddProfile(new SCJabatanProfile());
                mc.AddProfile(new RFPengikatanKreditProfile());
                mc.AddProfile(new RFMappingPrescreeningDocumentProfile());
                mc.AddProfile(new RFLokasiUsahaProfile());
                mc.AddProfile(new AnalisaProfile());
                mc.AddProfile(new AnalisaSyaratKreditProfile());
                mc.AddProfile(new RFJenisAktaProfile());
                mc.AddProfile(new RFJenisSyaratKreditProfile());
                mc.AddProfile(new RFLinkageProfile());
                mc.AddProfile(new RFTermConditionProfile());
                mc.AddProfile(new RFJumlahPegawaiProfile());
                mc.AddProfile(new SPPKProfile());
                mc.AddProfile(new RFAlamatUsahaSamaDenganAplikasiProfile());
                mc.AddProfile(new RFDebiturMemilikiUsahaLainProfile());
                mc.AddProfile(new RfCompanyTypeYangDihindariProfile());
                mc.AddProfile(new RFJenisLinkAgeProfile());
                mc.AddProfile(new AnalisaPinjamanDariBankProfile());
                mc.AddProfile(new AnalisaFasilitasProfile());
                mc.AddProfile(new RFSANDIBIProfile());
                mc.AddProfile(new EnumSandiBIGroupProfile());
                mc.AddProfile(new EnumSandiBITypeProfile());
                mc.AddProfile(new AnalisaSandiOJKProfile());
                mc.AddProfile(new RFJenisAsuransiProfile());
                mc.AddProfile(new AnalisaAsuransiProfile());
                mc.AddProfile(new RFApprTanahLokasiProfile());
                mc.AddProfile(new RFApprKomoditiProfile());
                mc.AddProfile(new RFApprTanahLnkPertumbuhanProfile());
                mc.AddProfile(new RFApprTingkatKesuburanProfile());
                mc.AddProfile(new RFInsRateTemplateProfile());
                mc.AddProfile(new RFInsCompanyProfile());
                mc.AddProfile(new RFBranchInsCompProfile());
                mc.AddProfile(new RFPolaPengembalianProfile());
                mc.AddProfile(new SlikHistoryKreditProfile());
                mc.AddProfile(new PersiapanAkadProfile());
                mc.AddProfile(new PersiapanAkadAsuransiProfile());
                mc.AddProfile(new RFTipeKreditProfile());
                mc.AddProfile(new RFConditionProfile());
                mc.AddProfile(new RFBankProfile());
                mc.AddProfile(new RFCSBPDetailProfile());
                mc.AddProfile(new RFCSBPHeaderProfile());
                mc.AddProfile(new RFTempalateAkadKreditProfile());
                mc.AddProfile(new ApprovalProfile());
                mc.AddProfile(new RFInsRateMappingProfile());
                mc.AddProfile(new RFSubProductIntProfile());
                mc.AddProfile(new SlikRequestDuplikasiProfile());
                mc.AddProfile(new RFJenisDuplikasiProfile());
                mc.AddProfile(new RFBentukLahanProfile());
                mc.AddProfile(new RFSatuanLuasProfile());
                mc.AddProfile(new RFSatuanKapasitasProfile());
                mc.AddProfile(new ArusKasMasukProfile());
                mc.AddProfile(new BiayaTetapProfile());
                mc.AddProfile(new BiayaInvestasiProfile());
                mc.AddProfile(new BiayaVariabelProfile());
                mc.AddProfile(new BiayaVariabelTenagaKerjaProfile());
                mc.AddProfile(new InformasiOmsetProfile());
                mc.AddProfile(new ApprovalHistoryProfile());
                mc.AddProfile(new SPPKFileUploadProfile());
                
                #region RfParameter
                mc.AddProfile(new RfParameterProfile());
                mc.AddProfile(new RfParameterDetailProfile());
                #endregion

            });
            return mappingConfig.CreateMapper();
        }
    }
}
