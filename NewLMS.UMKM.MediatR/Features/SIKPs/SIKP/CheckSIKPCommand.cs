using AutoMapper;
using MediatR;
using NewLMS.Umkm.SIKP.Interfaces;
using NewLMS.Umkm.SIKP.Models;
using NewLMS.UMKM.Data.Dto.SIKPs;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Helper;
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
        public string Message { get; set; }
        public bool Valid { get; set; }
        public PlafonResponseModel PlafonResponse { get; set; }
        public LimitAkadResponseModel LimitAkadResponse { get; set; }
        public CalonDebiturResponseModel CalonDebiturResponse { get; set; }
        public PostCalonDebiturResponseModel PostCalonDebiturResponse { get; set; }
    }

    public class CheckSIKPCommand : IRequest<ServiceResponse<ValidasiPostCalonResponseModel>>
    {
        public Guid Id { get; set; }
    }

    public class CheckSIKPCommandHandler : IRequestHandler<CheckSIKPCommand, ServiceResponse<ValidasiPostCalonResponseModel>>
    {
        private IGenericRepositoryAsync<Data.Entities.SIKP> _sikp;
        private IGenericRepositoryAsync<SIKPRequest> _sikpRequest;
        private IGenericRepositoryAsync<RfSectorLBU1> _rfSectorLBU1;
        private IGenericRepositoryAsync<RfSectorLBU2> _rfSectorLBU2;
        private IGenericRepositoryAsync<RfSectorLBU3> _rfSectorLBU3;
        private ISIKPService _sikpService;
        private readonly IMapper _mapper;

        public CheckSIKPCommandHandler(IMapper mapper, IGenericRepositoryAsync<Data.Entities.SIKP> sikp, IGenericRepositoryAsync<SIKPRequest> sikpRequest, ISIKPService sikpService, IGenericRepositoryAsync<RfSectorLBU1> rfSectorLBU1, IGenericRepositoryAsync<RfSectorLBU2> rfSectorLBU2, IGenericRepositoryAsync<RfSectorLBU3> rfSectorLBU3)
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
                    "SIKPRequest.DebtorRfZipCode",
                    "SIKPRequest.DebtorCompanyRfZipCode",
                    "SIKPRequest.DebtorCompanyRfLinkage",
                    };
                var sikp = await _sikp.GetByIdAsync(request.Id, "Id", sikpIncludes);
                var sikpRequest = sikp.SIKPRequest;

                var debtorDataResponse = (await _sikpService.GetCalonDebitur(sikp.SIKPRequest.DebtorNoIdentity))?.data;
                if (debtorDataResponse == null)
                    return ServiceResponse<ValidasiPostCalonResponseModel>.Return404("Data SIKP Tidak Ditemukan");

                var debtorPlafondResponse = (await _sikpService.GetPlafon(sikp.SIKPRequest.DebtorNoIdentity))?.data;
                if (debtorPlafondResponse == null)
                    return ServiceResponse<ValidasiPostCalonResponseModel>.Return404("Data SIKP Tidak Ditemukan");

                PostCalonDebiturRequestModel req = new()
                {
                    nik = sikpRequest.DebtorNoIdentity,
                    nmr_registry = sikpRequest.Id.ToString() ?? sikp.RegistrationNumber,
                    nama = sikpRequest.Fullname,
                    tgl_lahir = sikpRequest.DateOfBirth.ToString("ddMMyyyy"),
                    jns_kelamin = sikpRequest.RfGender.GenderCodeSIKP,
                    maritas_sts = sikpRequest.RfMarital.MaritalCodeSKIP,
                    pendidikan = sikpRequest.RfEducation.EducationCodeSIKP,
                    pekerjaan = sikpRequest.RfJob.JobCodeSIKP,
                    alamat = sikpRequest.DebtorAddress,
                    kode_kabkota = sikpRequest.DebtorRfZipCode.KodeKabupaten,
                    kode_pos = sikpRequest.DebtorRfZipCode.ZipCode,
                    npwp = sikpRequest.DebtorNPWP,
                    mulai_usaha = sikpRequest.DebtorCompanyEstablishmentDate.ToString("ddMMyyyy"),
                    alamat_usaha = sikpRequest.DebtorCompanyAddress,
                    ijin_usaha = sikpRequest.DebtorCompanyPermit,
                    modal_usaha = sikpRequest.DebtorCompanyVentureCapital.ToString(),
                    jml_pekerja = sikpRequest.DebtorCompanyEmployee.ToString(),
                    jml_kredit = sikpRequest.DebtorCompanyCreditValue.ToString(),
                    is_linkage = (sikpRequest.DebtorCompanyRfLinkage != null).ToString(),
                    linkage = sikpRequest.DebtorCompanyRfLinkage.LinkAgeDesc,
                    no_hp = sikpRequest.DebtorCompanyPhone,
                    uraian_agunan = sikpRequest.DebtorCompanyCollaterals,
                    is_subsidized = sikpRequest.DebtorCompanySubisdyStatus.ToString(),
                    subsidi_sebelumnya = sikpRequest.DebtorCompanyPreviousSubsidy,
                };

                var includes = new string[]
                    {
                        "SIKPRequest"
                    };

                // Validasi Limit
                if (response.PlafonResponse.data != null)
                {
                    response = await ValidasiLimit(_mapper.Map<SIKPRequestRequest>(sikpRequest), response);
                    debtorDataResponse.Valid = response.Valid;
                    debtorDataResponse.MessageValidasi = response.Message;
                }

                if (response.Valid == false)
                {
                    await _SIKPCalonDebitur.UpdateAsync(SIKPCalonDebitur);
                    return ServiceResponse<ValidasiPostCalonResponseModel>.ReturnResultWith200(response);
                }
                var sikpCheck = (await _sikpService.PostCalonDebitur(req))?.data;

                return new ServiceResponse<ValidasiPostCalonResponseModel>();
            }
            catch (Exception ex)
            {
                return ServiceResponse<ValidasiPostCalonResponseModel>.ReturnException(ex);
            }

        }

        public async Task<ValidasiPostCalonResponseModel> ValidasiSkema(SIKPRequestRequest request, DetailLimitAkadResponseModel dataPlafon, ValidasiPostCalonResponseModel validasiResponse)
        {
            var dataCalonDebitur = validasiResponse.CalonDebiturResponse.data;


            var reqLimitAkad = new LimitAkadRequestModel
            {
                nik = request.DebtorNoIdentity,
                sektor = request.DebtorSectorLBU3Code,
                skema = dataPlafon.skema
            };

            var responseLimitAkad = (await _sikpService.GetLimitAkadSkemaSektor(reqLimitAkad))?.data;
            validasiResponse.LimitAkadResponse = responseLimitAkad;

            var dataLimitAkad = responseLimitAkad.data;

            var valid = false;
            if (request.Scheme == "3" || request.Scheme == "1")
            {
                var subsubsektor = await _rfSectorLBU3.GetByIdAsync(request.DebtorSectorLBU3Code, "Code");
                var subsektor = subsubsektor.RfSectorLBU2;
                var sektor = subsubsektor.RfSectorLBU2.RfSectorLBU1;

                var subSubSectorList = new List<string> { "A1", "B1", "B2", "B3", "B4", "B5" };

                var countAkad = dataLimitAkad.count_akad == null ? 0 : int.Parse(dataLimitAkad.count_akad);

                if (subSubSectorList.Contains(subsektor.Code))
                {
                    valid = countAkad <= 4;

                    if (!valid)
                    {
                        validasiResponse.Message = "Jumlah akad melebihi maksimal";
                    }
                }
                else
                {
                    valid = countAkad <= 2;

                    if (!valid)
                    {
                        validasiResponse.Message = "Jumlah akad melebihi maksimal";
                    }
                }
            }
            else
            {
                valid = true;
            }

            validasiResponse.Valid = valid;

            return validasiResponse;
        }

        public async Task<ValidasiPostCalonResponseModel> ValidasiLimit(SIKPRequestRequest request, ValidasiPostCalonResponseModel validasiResponse)
        {
            var dataCalonDebitur = validasiResponse.CalonDebiturResponse.data;

            var valid = false;

            foreach (var dataPlafon in validasiResponse.PlafonResponse.data)
            {
                if (dataPlafon.skema != request.Scheme)
                {
                    continue;
                }

                if (dataPlafon.limit_aktif == "0")
                {
                    valid = double.Parse(dataPlafon.total_limit) != double.Parse(dataPlafon.total_limit_default ?? "0");

                    if (!valid)
                    {
                        validasiResponse.Message = "Alokasi calon debitur untuk skema ini sudah habis";
                    }
                }
                else
                {
                    valid = dataPlafon.kode_bank == "110";

                    if (!valid)
                    {
                        validasiResponse.Message = "Calon debitur memiliki kewajiban di penyalur lain";
                    }
                }

                if (valid)
                {
                    validasiResponse = await ValidasiSkema(request, dataPlafon, validasiResponse);
                    valid = validasiResponse.Valid;
                }

                if (!valid)
                {
                    break;
                }
            }

            validasiResponse.Valid = valid;

            return validasiResponse;
        }
    }
}
