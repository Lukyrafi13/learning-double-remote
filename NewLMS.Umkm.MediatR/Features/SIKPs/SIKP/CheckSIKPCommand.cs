using AutoMapper;
using MediatR;
using NewLMS.Umkm.SIKP.Interfaces;
using NewLMS.Umkm.SIKP.Models;
using NewLMS.Umkm.Data.Dto.SIKPs;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Domain.Context;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace NewLMS.Umkm.MediatR.Features.SIKPs.SIKP
{
    public class SIKPGetValidasiPostCalonQuery : SIKPRequestRequest, IRequest<ServiceResponse<ValidasiPostCalonResponseModel>>
    {

    }

    //public class ValidasiPostCalonResponseModel
    //{
    //    public CalonDebiturResponseModel DebtorData { get; set; }
    //    public bool Valid { get; set; } = true;
    //    public string Errors { get; set; }
    //    public string Message { get; set; } = "Calon Debitur Valid";
    //}

    public class ValidasiPostCalonResponseModel
    {
        public string Message { get; set; } = "Calon Debitur Valid";
        public bool Valid { get; set; } = true;
        public PlafonResponseModel PlafonResponse { get; set; }
        public LimitAkadResponseModel LimitAkadResponse { get; set; }
        public CalonDebiturResponseModel CalonDebiturResponse { get; set; }
        public PostCalonDebiturResponseModel PostCalonDebiturResponse { get; set; }
    }

    public class CheckSIKPCommand : SIKPRequestRequest, IRequest<ServiceResponse<ValidasiPostCalonResponseModel>>
    {
    }

    public class CheckSIKPCommandHandler : IRequestHandler<CheckSIKPCommand, ServiceResponse<ValidasiPostCalonResponseModel>>
    {
        private IGenericRepositoryAsync<NewLMS.Umkm.Data.Entities.SIKP> _sikp;
        private IGenericRepositoryAsync<SIKPRequest> _sikpRequest;
        private IGenericRepositoryAsync<SIKPResponse> _sikpResponse;
        private IGenericRepositoryAsync<RfSectorLBU3> _rfSectorLBU3;
        private IGenericRepositoryAsync<RfGender> _rfGender;
        private IGenericRepositoryAsync<RfJob> _rfJob;
        private IGenericRepositoryAsync<RfMarital> _rfMarital;
        private IGenericRepositoryAsync<RfEducation> _rfEducation;
        private IGenericRepositoryAsync<RfZipCode> _rfZipCode;
        private IGenericRepositoryAsync<RfLinkAge> _rfLinkage;
        private readonly UserContext _userContext;
        private readonly ISIKPService _sikpService;
        private readonly IMapper _mapper;

        public CheckSIKPCommandHandler(IMapper mapper, IGenericRepositoryAsync<NewLMS.Umkm.Data.Entities.SIKP> sikp, IGenericRepositoryAsync<SIKPRequest> sikpRequest, ISIKPService sikpService, IGenericRepositoryAsync<RfSectorLBU3> rfSectorLBU3, IGenericRepositoryAsync<SIKPResponse> sikpResponse, IGenericRepositoryAsync<RfGender> rfGender, IGenericRepositoryAsync<RfJob> rfJob, IGenericRepositoryAsync<RfMarital> rfMarital, IGenericRepositoryAsync<RfEducation> rfEducation, IGenericRepositoryAsync<RfZipCode> rfZipCode, IGenericRepositoryAsync<RfLinkAge> rfLinkage, UserContext userContext)
        {
            _mapper = mapper;
            _sikp = sikp;
            _sikpRequest = sikpRequest;
            _sikpService = sikpService;
            _rfSectorLBU3 = rfSectorLBU3;
            _sikpResponse = sikpResponse;
            _rfGender = rfGender;
            _rfJob = rfJob;
            _rfMarital = rfMarital;
            _rfEducation = rfEducation;
            _rfZipCode = rfZipCode;
            _rfLinkage = rfLinkage;
            _userContext = userContext;
        }

        public async Task<ServiceResponse<ValidasiPostCalonResponseModel>> Handle(CheckSIKPCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _userContext.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var response = new ValidasiPostCalonResponseModel
                {
                    Valid = true,
                    Message = "Calon Debitur Valid"
                };

                var sikpIncludes = new string[]
                    {
                        //"SIKPRequest",
                        "LoanApplication",
                        "SIKPRequest.RfSectorLBU3",
                        "SIKPRequest.RfGender",
                        "SIKPRequest.RfMarital",
                        "SIKPRequest.RfEducation",
                        "SIKPRequest.RfJob",
                        "SIKPRequest.DebtorRfZipCode",
                        "SIKPRequest.DebtorCompanyRfZipCode",
                        "SIKPRequest.DebtorCompanyRfLinkage",
                        "SIKPResponse",
                        //"SIKPResponse.RfSectorLBU3",
                        //"SIKPResponse.RfGender",
                        //"SIKPResponse.RfMarital",
                        //"SIKPResponse.RfEducation",
                        //"SIKPResponse.RfJob",
                        //"SIKPResponse.DebtorRfZipCode",
                        //"SIKPResponse.DebtorCompanyRfZipCode",
                        //"SIKPResponse.DebtorCompanyRfLinkage",
                    };
                var sikp = await _sikp.GetByIdAsync(request.Id, "Id", sikpIncludes);
                var collaterals = sikp.LoanApplication.LoanApplicationCollaterals;
                var sikpRequest = sikp.SIKPRequest;
                var sikpResponse = sikp.SIKPResponse;
                if (sikpResponse == null)
                {
                    sikpResponse = new SIKPResponse() { Id = sikp.Id };
                    await _sikpResponse.AddAsync(sikpResponse);
                }
                sikpRequest = _mapper.Map<SIKPRequestRequest, SIKPRequest>(request);
                sikpRequest.Id = sikp.Id;

                await _sikpRequest.UpdateAsync(sikpRequest);

                var debtorDataResponse = (await _sikpService.GetCalonDebitur(sikp.SIKPRequest.DebtorNoIdentity))?.data;
                if (debtorDataResponse == null)
                {
                    return ServiceResponse<ValidasiPostCalonResponseModel>.Return404("Data SIKP Tidak Ditemukan");
                }
                else
                {
                    response.CalonDebiturResponse = debtorDataResponse;
                    if (debtorDataResponse.code == "12")
                    {
                        // Get Rf(s)
                        // var rfSectorLBU3 = _rfSectorLBU3.GetByPredicate(x => x.Code => debtorDataResponse)
                        var rfGender = await _rfGender.GetByPredicate(x => x.GenderCodeSIKP == debtorDataResponse.data.jns_kelamin);
                        var rfMarital = await _rfMarital.GetByPredicate(x => x.MaritalCodeSKIP == debtorDataResponse.data.maritas_sts);
                        var rfJob = await _rfJob.GetByPredicate(x => x.JobCodeSIKP == debtorDataResponse.data.pekerjaan);
                        var rfEducation = await _userContext.RfEducations.FirstOrDefaultAsync(x => x.EducationCodeSIKP == debtorDataResponse.data.pendidikan, cancellationToken: cancellationToken);
                        var rfZipCode = await _rfZipCode.GetByPredicate(x => x.ZipCode == debtorDataResponse.data.kode_pos);
                        var rfLinkage = await _rfLinkage.GetByPredicate(x => x.LinkAgeCode == debtorDataResponse.data.is_linkage);

                        // Map from SIKP service response
                        sikpResponse = _mapper.Map<CalonDebiturResponseModel, SIKPResponse>(debtorDataResponse, sikpResponse);
                        if (sikpResponse.Id == Guid.Empty)
                        {
                            sikpResponse.Id = sikp.Id;
                            await _sikpResponse.AddAsync(sikpResponse);
                        }


                        sikpResponse.DebtorGenderId = rfGender.GenderCode;
                        sikpResponse.DebtorMaritalStatusId = rfMarital.MaritalCode;
                        sikpResponse.DebtorJobId = rfJob.JobCode;
                        sikpResponse.DebtorEducationId = rfEducation.EducationCode;
                        sikpResponse.DebtorCompanyLinkageId = rfLinkage.LinkAgeCode;
                        sikpResponse.DebtorZipCode = rfZipCode.ZipCode;
                        sikpResponse.DebtorZipCodeId = rfZipCode.Id;
                        sikpResponse.DebtorProvince = rfZipCode.Provinsi;
                        sikpResponse.DebtorCity = rfZipCode.Kota;
                        sikpResponse.DebtorDistrict = rfZipCode.Kecamatan;
                        sikpResponse.DebtorNeighborhoods = rfZipCode.Kelurahan;

                        sikpResponse.RfEducation = null;
                        sikpResponse.RfGender = null;
                        sikpResponse.RfJob = null;
                        sikpResponse.RfMarital = null;
                        sikpResponse.RfSectorLBU3 = null;
                        sikpResponse.DebtorCompanyRfLinkage = null;
                        sikpResponse.DebtorCompanyRfLinkageType = null;
                        sikpResponse.DebtorCompanyRfZipCode = null;
                        sikpResponse.DebtorRfZipCode = null;
                        sikpResponse.Valid = !debtorDataResponse.error;
                        sikpResponse.ValidationMessage = debtorDataResponse.message;

                        await _sikpResponse.UpdateAsync(sikpResponse);

                        if (debtorDataResponse.data?.nmr_registry != null)
                        {
                            sikp.RegistrationNumber = debtorDataResponse.data.nmr_registry;
                            await _sikp.UpdateAsync(sikp);
                        }
                    }
                    else if (debtorDataResponse.code == "15")
                    {
                        response.Valid = false;
                        response.Message = debtorDataResponse.message;

                        sikpResponse = new SIKPResponse
                        {
                            Id = sikp.Id,
                            CreatedBy = sikp.CreatedBy,
                            CreatedDate = DateTime.Now,
                            Valid = false,
                            ValidationMessage = debtorDataResponse.message
                        };
                    }
                }

                if (sikp.RegistrationNumber == null)
                {
                    var sikpCount = await _sikp.GetCountByPredicate(x => x.CreatedDate.Year == DateTime.Now.Year && x.CreatedDate.Month == DateTime.Now.Month);
                    var sikpRegist = $"{sikp.LoanApplication.BranchId}/{sikpCount + 1:D4}/{sikp.LoanApplication.CreatedDate:MM/yy}";

                    sikp.RegistrationNumber = sikpRegist;
                    await _sikp.UpdateAsync(sikp);
                }

                var debtorPlafondResponse = (await _sikpService.GetPlafon(sikp.SIKPRequest.DebtorNoIdentity))?.data;
                if (debtorPlafondResponse == null)
                {
                    return ServiceResponse<ValidasiPostCalonResponseModel>.Return404("Data SIKP Tidak Ditemukan");
                }
                else
                {
                    response.PlafonResponse = debtorPlafondResponse;
                }

                // Check if Skipable
                if (response.CalonDebiturResponse?.code != "07")
                {
                    response = ValidasiCalonDebitur(response);
                    sikpResponse.Valid = response.Valid;
                    sikpResponse.ValidationMessage = response.Message;
                }

                if (response.PlafonResponse.data != null)
                {
                    response = await ValidasiLimit(request, response);
                    sikpResponse.Valid = response.Valid;
                    sikpResponse.ValidationMessage = response.Message;
                }

                PostCalonDebiturRequestModel req = new()
                {
                    nik = sikpRequest.DebtorNoIdentity,
                    nmr_registry = sikp.RegistrationNumber,
                    nama = sikpRequest.Fullname,
                    tgl_lahir = sikpRequest.DateOfBirth.ToString("ddMMyyyy"),
                    jns_kelamin = await _userContext.RfGenders.Where(x => x.GenderCode == sikpRequest.DebtorGenderId).Select(x => x.GenderCodeSIKP).FirstOrDefaultAsync(),
                    maritas_sts = await _userContext.RfMaritals.Where(x => x.MaritalCode == sikpRequest.DebtorMaritalStatusId).Select(x => x.MaritalCodeSKIP).FirstOrDefaultAsync(),
                    pendidikan = await _userContext.RfEducations.Where(x => x.EducationCode == sikpRequest.DebtorEducationId).Select(x => x.EducationCodeSIKP).FirstOrDefaultAsync(),
                    pekerjaan = await _userContext.RfJobs.Where(x => x.JobCode == sikpRequest.DebtorJobId).Select(x => x.JobCodeSIKP).FirstOrDefaultAsync(),
                    alamat = sikpRequest.DebtorAddress ?? "",
                    kode_kabkota = await _userContext.RfZipCodes.Where(x => x.Id == sikpRequest.DebtorZipCodeId).Select(x => x.KodeKabupaten).FirstOrDefaultAsync(),
                    kode_pos = sikpRequest.DebtorZipCode ?? "",
                    npwp = sikpRequest.DebtorNPWP?.Substring(0, 15) ?? "",
                    mulai_usaha = sikpRequest.DebtorCompanyEstablishmentDate?.ToString("ddMMyyyy") ?? "",
                    alamat_usaha = sikpRequest.DebtorCompanyAddress ?? "",
                    ijin_usaha = sikpRequest.DebtorCompanyPermit ?? "",
                    modal_usaha = sikpRequest.DebtorCompanyVentureCapital.ToString(),
                    jml_pekerja = sikpRequest.DebtorCompanyEmployee.ToString(),
                    jml_kredit = sikpRequest.DebtorCompanyCreditValue.ToString(),
                    is_linkage = sikpRequest.DebtorCompanyLinkageId ?? "",
                    linkage = sikpRequest.DebtorCompanyLinkageTypeId ?? "",
                    no_hp = sikpRequest.DebtorCompanyPhone ?? "",
                    uraian_agunan = sikpRequest.DebtorCompanyCollaterals ?? "",
                    is_subsidized = sikpRequest.DebtorCompanySubisdyStatus ? "1" : "0",
                    subsidi_sebelumnya = sikpRequest.DebtorCompanyPreviousSubsidy ?? "",
                };
                sikp.RegistrationNumber = req.nmr_registry;

                if (request.Post)
                {
                    var sikpCheck = (await _sikpService.PostCalonDebitur(req))?.data;
                    response.PostCalonDebiturResponse = sikpCheck;
                    if (sikpCheck.error)
                    {
                        response.Valid = false;
                        response.Message = sikpCheck.message;
                    }

                    sikpResponse.Valid = response.Valid;
                    sikpResponse.ValidationMessage = response.Message;
                }



                await _sikp.UpdateAsync(sikp);
                await _sikpResponse.UpdateAsync(sikpResponse);
                await _sikpRequest.UpdateAsync(sikpRequest);

                await transaction.CommitAsync(cancellationToken);
                return new ServiceResponse<ValidasiPostCalonResponseModel>
                {
                    Data = response
                };
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);
                return ServiceResponse<ValidasiPostCalonResponseModel>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }

        }

        public ValidasiPostCalonResponseModel ValidasiCalonDebitur(ValidasiPostCalonResponseModel validasiResponse)
        {
            var response = validasiResponse;
            var dataCalonDebitur = response.CalonDebiturResponse.data;
            bool valid;
            if (dataCalonDebitur.kode_bank == "110")
            {
                valid = true;
            }
            else
            {
                var sisaWaktu = int.Parse(dataCalonDebitur.sisa_waktu_book ?? "0");

                valid = sisaWaktu < 0;

                if (!valid)
                {
                    response.Message = "Debitur masih terdaftar di penyalur lain";
                }
            }

            response.Valid = valid;

            return response;
        }

        public async Task<ValidasiPostCalonResponseModel> ValidasiLimit(CheckSIKPCommand request, ValidasiPostCalonResponseModel validasiResponse)
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

        public async Task<ValidasiPostCalonResponseModel> ValidasiSkema(CheckSIKPCommand request, DetailLimitAkadResponseModel dataPlafon, ValidasiPostCalonResponseModel validasiResponse)
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
                var lbuIncludes = new string[] { "RfSectorLBU2.RfSectorLBU1" };
                var subsubsektor = await _rfSectorLBU3.GetByIdAsync(request.DebtorSectorLBU3Code, "Code", lbuIncludes) ?? throw new NullReferenceException("Data Sektor LBU3 tidak ditemukan.");
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
    }
}

