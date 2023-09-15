using AutoMapper;
using MediatR;
using NewLMS.Umkm.SIKP.Interfaces;
using NewLMS.Umkm.SIKP.Models;
using NewLMS.UMKM.Data.Dto.SIKPs;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.MediatR.Features.RfVehTypes.Queries.GetFilterRfVehTypes;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfVehTypes.Queries.GetFilterRfVehTypes
{
    public class SIKPGetValidasiPostCalonQuery : SIKPRequestRequest, IRequest<ServiceResponse<ValidasiPostCalonResponseModel>>
    {

    }

    public class ValidasiPostCalonResponseModel
    {
        public CalonDebiturResponseModel DebtorData { get; set; }
        public bool Valid { get; set; } = true;
        public string Errors { get; set; }
        public string Message { get; set; } = "Calon Debitur Valid";
    }
}

public class CheckSIKPCommand : SIKPRequestRequest, IRequest<ServiceResponse<ValidasiPostCalonResponseModel>>
{
}

public class CheckSIKPCommandHandler : IRequestHandler<CheckSIKPCommand, ServiceResponse<ValidasiPostCalonResponseModel>>
{
    private IGenericRepositoryAsync<NewLMS.UMKM.Data.Entities.SIKP> _sikp;
    private IGenericRepositoryAsync<SIKPRequest> _sikpRequest;
    private IGenericRepositoryAsync<RfSectorLBU1> _rfSectorLBU1;
    private IGenericRepositoryAsync<RfSectorLBU2> _rfSectorLBU2;
    private IGenericRepositoryAsync<RfSectorLBU3> _rfSectorLBU3;
    private ISIKPService _sikpService;
    private readonly IMapper _mapper;

    public CheckSIKPCommandHandler(IMapper mapper, IGenericRepositoryAsync<NewLMS.UMKM.Data.Entities.SIKP> sikp, IGenericRepositoryAsync<SIKPRequest> sikpRequest, ISIKPService sikpService, IGenericRepositoryAsync<RfSectorLBU1> rfSectorLBU1, IGenericRepositoryAsync<RfSectorLBU2> rfSectorLBU2, IGenericRepositoryAsync<RfSectorLBU3> rfSectorLBU3)
    {
        _mapper = mapper;
        _sikp = sikp;
        _sikpRequest = sikpRequest;
        _sikpService = sikpService;
        _rfSectorLBU1 = rfSectorLBU1;
        _rfSectorLBU2 = rfSectorLBU2;
        _rfSectorLBU3 = rfSectorLBU3;
    }

    public async Task<ServiceResponse<ValidasiPostCalonResponseModel>> Handle(CheckSIKPCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var response = new ValidasiPostCalonResponseModel
            {
                Valid = true,
                Message = "Calon Debitur Valid"
            };

            var sikpIncludes = new string[]
                {
                        "SIKPRequest.RfSectorLBU3",
                        "SIKPRequest.RfGender",
                        "SIKPRequest.RfMarital",
                        "SIKPRequest.RfEducation",
                        "SIKPRequest.RfJob",
                        "SIKPRequest.DebtorRfZipCode",
                        "SIKPRequest.DebtorCompanyRfZipCode",
                        "SIKPRequest.DebtorCompanyRfLinkage",
                };
            var sikp = await _sikp.GetByIdAsync(request.Id, "Id", sikpIncludes);
            var sikpRequest = sikp.SIKPRequest;
            sikpRequest = _mapper.Map<SIKPRequestRequest, SIKPRequest>(request, sikpRequest);

            var debtorDataResponse = (await _sikpService.GetCalonDebitur(sikp.SIKPRequest.DebtorNoIdentity))?.data;
            if (debtorDataResponse == null)
                return ServiceResponse<ValidasiPostCalonResponseModel>.Return404("Data SIKP Tidak Ditemukan");

            var debtorPlafondResponse = (await _sikpService.GetPlafon(sikp.SIKPRequest.DebtorNoIdentity))?.data;
            if (debtorPlafondResponse == null)
                return ServiceResponse<ValidasiPostCalonResponseModel>.Return404("Data SIKP Tidak Ditemukan");

            PostCalonDebiturRequestModel req = new()
            {
                nik = sikpRequest.DebtorNoIdentity,
                nmr_registry = debtorDataResponse?.data?.nmr_registry ?? sikp.RegistrationNumber ?? sikpRequest.Id.ToString().Substring(0, 5),
                nama = sikpRequest.Fullname,
                tgl_lahir = sikpRequest.DateOfBirth.ToString("ddMMyyyy"),
                jns_kelamin = sikpRequest.RfGender?.GenderCodeSIKP ?? "",
                maritas_sts = "1" ?? sikpRequest.RfMarital?.MaritalCodeSKIP ?? "",
                pendidikan = sikpRequest.RfEducation?.EducationCodeSIKP ?? "",
                pekerjaan = sikpRequest.RfJob?.JobCodeSIKP ?? "",
                alamat = sikpRequest.DebtorAddress ?? "",
                kode_kabkota = sikpRequest.DebtorRfZipCode?.KodeKabupaten ?? "",
                kode_pos = sikpRequest.DebtorRfZipCode?.ZipCode ?? "",
                npwp = sikpRequest.DebtorNPWP?.Substring(0, 15) ?? "",
                mulai_usaha = sikpRequest.DebtorCompanyEstablishmentDate.ToString("ddMMyyyy") ?? "",
                alamat_usaha = sikpRequest.DebtorCompanyAddress ?? "",
                ijin_usaha = sikpRequest.DebtorCompanyPermit ?? "",
                modal_usaha = sikpRequest.DebtorCompanyVentureCapital.ToString(),
                jml_pekerja = sikpRequest.DebtorCompanyEmployee.ToString(),
                jml_kredit = sikpRequest.DebtorCompanyCreditValue.ToString(),
                is_linkage = sikpRequest.DebtorCompanyRfLinkage?.LinkAgeCode ?? "",
                linkage = sikpRequest.DebtorCompanyRfLinkage?.LinkAgeCode ?? "",
                no_hp = sikpRequest.DebtorCompanyPhone ?? "",
                uraian_agunan = sikpRequest.DebtorCompanyCollaterals ?? "",
                is_subsidized = sikpRequest.DebtorCompanySubisdyStatus ? "1" : "0",
                subsidi_sebelumnya = sikpRequest.DebtorCompanyPreviousSubsidy ?? "",
            };

            var sikpCheck = (await _sikpService.PostCalonDebitur(req))?.data;
            var lmsResponse = new ValidasiPostCalonResponseModel
            {
                DebtorData = debtorDataResponse,
                Errors = sikpCheck.error ? sikpCheck.message : null,
                Message = sikpCheck.error ? "Gagal" : "Berhasil",
                Valid = !sikpCheck.error

            };

            return new ServiceResponse<ValidasiPostCalonResponseModel>
            {
                Data = lmsResponse
            };
        }
        catch (Exception ex)
        {
            return ServiceResponse<ValidasiPostCalonResponseModel>.ReturnException(ex);
        }

    }
}
