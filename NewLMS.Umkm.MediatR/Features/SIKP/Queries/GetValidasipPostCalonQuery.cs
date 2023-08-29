using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.SIKP2.Models;
using NewLMS.Umkm.SIKP.Models;
using NewLMS.Umkm.SIKP2.Interfaces;
using NewLMS.Umkm.SIKP.Interfaces;
using System.Collections.Generic;
using NewLMS.Umkm.Data.Dto.SIKPCalonDebiturs;

namespace NewLMS.Umkm.MediatR.Features.SIKP.Queries
{
    public class SIKPGetValidasiPostCalonRequest
    {
        public string NIK { get; set; }
        public string Skema { get; set; }
        public string Sektor { get; set; }
        public string NmrRegistry { get; set; }
        public string Nama { get; set; }
        public string TglLahir { get; set; }
        public string JenisKelamin { get; set; }
        public string MaritasStatus { get; set; }
        public string Pendidikan { get; set; }
        public string Pekerjaan { get; set; }
        public string Alamat { get; set; }
        public string KodeKabKota { get; set; }
        public string KodePos { get; set; }
        public string NPWP { get; set; }
        public string MulaiUsaha { get; set; }
        public string AlamatUsaha { get; set; }
        public string IjinUsaha { get; set; }
        public string ModalUsaha { get; set; }
        public string JmlPekerja { get; set; }
        public string JmlKredit { get; set; }
        public string IsLinkage { get; set; }
        public string Linkage { get; set; }
        public string NoHP { get; set; }
        public string UraianAgunan { get; set; }
        public string IsSubsidized { get; set; }
        public string SubsidiSebelumnya { get; set; }
        public Guid SIKPCalonDebiturId { get; set; }
        public SIKPCalonDebiturValidasiPutRequestDto SIKPPutCalonDebitur { get; set; }
    }
    public class ValidasiPostCalonResponseModel
    {
        public string Message { get; set; }
        public bool Valid { get; set; }
        public PlafonResponseModel PlafonResponse { get; set; }
        public LimitAkadResponseModel LimitAkadResponse { get; set; }
        public CalonDebiturResponseModel CalonDebiturResponse { get; set; }
    }
    public class SIKPGetValidasiPostCalonQuery : SIKPGetValidasiPostCalonRequest, IRequest<ServiceResponse<ValidasiPostCalonResponseModel>>
    {

    }

    public class SIKPGetValidasiPostCalonQueryHandler : IRequestHandler<SIKPGetValidasiPostCalonQuery, ServiceResponse<ValidasiPostCalonResponseModel>>
    {
        private IGenericRepositoryAsync<RFSectorLBU1> _Sektor;
        private IGenericRepositoryAsync<RFSectorLBU2> _SubSektor;
        private IGenericRepositoryAsync<RFSectorLBU3> _SubSubSektor;
        private IGenericRepositoryAsync<SIKPCalonDebitur> _SIKPCalonDebitur;
        private IGenericRepositoryAsync<RFGender> _RFGender;
        private IGenericRepositoryAsync<RFMARITAL> _RFMARITAL;
        private IGenericRepositoryAsync<RFEDUCATION> _RFEDUCATION;
        private IGenericRepositoryAsync<RFZipCode> _RFZipCode;
        private IGenericRepositoryAsync<RFJOB> _RFJOB;
        private IGenericRepositoryAsync<RFLinkage> _RFLinkage;
        private ISIKPService _SIKPService;
        private readonly IMapper _mapper;

        public SIKPGetValidasiPostCalonQueryHandler(
            IGenericRepositoryAsync<RFSectorLBU1> Sektor,
            IGenericRepositoryAsync<RFSectorLBU2> SubSektor,
            IGenericRepositoryAsync<RFSectorLBU3> SubSubSektor,
            IGenericRepositoryAsync<SIKPCalonDebitur> SIKPCalonDebitur,
            IGenericRepositoryAsync<RFGender> RFGender,
            IGenericRepositoryAsync<RFMARITAL> RFMARITAL,
            IGenericRepositoryAsync<RFEDUCATION> RFEDUCATION,
            IGenericRepositoryAsync<RFZipCode> RFZipCode,
            IGenericRepositoryAsync<RFJOB> RFJOB,
            IGenericRepositoryAsync<RFLinkage> RFLinkage,
            ISIKPService SIKPService,
            IMapper mapper)
        {
            _Sektor = Sektor;
            _SubSektor = SubSektor;
            _SubSubSektor = SubSubSektor;
            _SIKPCalonDebitur = SIKPCalonDebitur;
            _RFGender = RFGender;
            _RFMARITAL = RFMARITAL;
            _RFEDUCATION = RFEDUCATION;
            _RFZipCode = RFZipCode;
            _RFJOB = RFJOB;
            _RFLinkage = RFLinkage;
            _SIKPService = SIKPService;
            _mapper = mapper;
        }

        public ValidasiPostCalonResponseModel ValidasiCalonDebitur(ValidasiPostCalonResponseModel validasiResponse)
        {
            var dataCalonDebitur = validasiResponse.CalonDebiturResponse.data;
            var valid = false;
            if (dataCalonDebitur.kode_bank != "110")
            {
                valid = true;
            }
            else
            {
                var sisaWaktu = int.Parse(dataCalonDebitur.sisa_waktu_book);

                valid = sisaWaktu < 0;

                if (!valid)
                {
                    validasiResponse.Message = "Debitur masih terdaftar di penyalur lain";
                }
            }

            validasiResponse.Valid = valid;

            return validasiResponse;
        }

        public async Task<ValidasiPostCalonResponseModel> ValidasiLimit(SIKPGetValidasiPostCalonQuery request, ValidasiPostCalonResponseModel validasiResponse)
        {
            var dataCalonDebitur = validasiResponse.CalonDebiturResponse.data;

            var valid = false;

            foreach (var dataPlafon in validasiResponse.PlafonResponse.data)
            {
                if (dataPlafon.skema != request.Skema)
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


        public async Task<ValidasiPostCalonResponseModel> ValidasiSkema(SIKPGetValidasiPostCalonQuery request, DetailLimitAkadResponseModel dataPlafon, ValidasiPostCalonResponseModel validasiResponse)
        {
            var dataCalonDebitur = validasiResponse.CalonDebiturResponse.data;


            var reqLimitAkad = new LimitAkadRequestModel
            {
                nik = request.NIK,
                sektor = request.Sektor,
                skema = dataPlafon.skema
            };

            var responseLimitAkad = await _SIKPService.GetLimitAkadSkemaSektor(reqLimitAkad);
            validasiResponse.LimitAkadResponse = responseLimitAkad;

            var dataLimitAkad = responseLimitAkad.data;

            var valid = false;
            if (request.Skema == "3" || request.Skema == "1")
            {
                var subsubsektor = await _SubSubSektor.GetByIdAsync(request.Sektor, "Code");
                var subsektor = await _SubSektor.GetByIdAsync(subsubsektor.RFSectorLBU2Code, "Code");
                var sektor = await _Sektor.GetByIdAsync(subsektor.RFSectorLBU1Code, "Code");

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

        public async Task<ServiceResponse<ValidasiPostCalonResponseModel>> Handle(SIKPGetValidasiPostCalonQuery request, CancellationToken cancellationToken)
        {

            try
            {

                var includes = new string[]{
                };

                var response = new ValidasiPostCalonResponseModel();
                response.Valid = true;
                response.Message = "Calon Debitur Valid";

                // Simpan data debitur
                var SIKPCalonDebitur = await _SIKPCalonDebitur.GetByIdAsync(request.SIKPCalonDebiturId);

                // Kalo put calondebitur ada
                if (request.SIKPPutCalonDebitur != null)
                {
                    SIKPCalonDebitur = _mapper.Map(request.SIKPPutCalonDebitur, SIKPCalonDebitur);

                    await _SIKPCalonDebitur.UpdateAsync(SIKPCalonDebitur);
                }

                var dataPlafon = await _SIKPService.GetPlafon(request.NIK);
                if (dataPlafon == null)
                    return ServiceResponse<ValidasiPostCalonResponseModel>.Return404("Data SIKPService not found");

                response.PlafonResponse = dataPlafon;

                var dataCalonDebitur = await _SIKPService.GetCalonDebitur(request.NIK);
                if (dataCalonDebitur == null)
                    return ServiceResponse<ValidasiPostCalonResponseModel>.Return404("Data SIKPService not found");

                response.CalonDebiturResponse = dataCalonDebitur;

                // Check if calon validation is skippable

                if (response.CalonDebiturResponse.code != "07")
                {
                    // Validasi calon debitur
                    response = ValidasiCalonDebitur(response);
                    SIKPCalonDebitur.Valid = response.Valid;
                    SIKPCalonDebitur.MessageValidasi = response.Message;
                }

                // Update data SIKP
                if (dataCalonDebitur.data != null)
                {
                    // Get SIKP RFs
                    var RFZipCode = await _RFZipCode.GetByPredicate(x => x.ZipCode == dataCalonDebitur.data.kode_pos && x.KodeKabupaten == dataCalonDebitur.data.kode_kabkota);
                    var RFGender = await _RFGender.GetByIdAsync(dataCalonDebitur.data.jns_kelamin, "GenderCodeSIKP");
                    var RFMarital = await _RFMARITAL.GetByIdAsync(dataCalonDebitur.data.maritas_sts, "MR_CODESIKP");
                    var RFEducation = await _RFEDUCATION.GetByIdAsync(dataCalonDebitur.data.pendidikan, "ED_CODESIKP");
                    var RFJob = await _RFJOB.GetByIdAsync(dataCalonDebitur.data.pekerjaan, "JOB_CODESIKP");
                    var RFLinkage = await _RFLinkage.GetByIdAsync(dataCalonDebitur.data.is_linkage, "SIKPCode");

                    // IDE
                    SIKPCalonDebitur.NoRegistrasiSIKP = dataCalonDebitur.data.nmr_registry;
                    SIKPCalonDebitur.NoKTPSIKP = dataCalonDebitur.data.nik;
                    SIKPCalonDebitur.NPWPSIKP = dataCalonDebitur.data.npwp;
                    SIKPCalonDebitur.NamaDebiturSIKP = dataCalonDebitur.data.nama;
                    SIKPCalonDebitur.TanggalLahirSIKP = DateTime.Parse(dataCalonDebitur.data.tgl_lahir);
                    SIKPCalonDebitur.AlamatSIKP = dataCalonDebitur.data.alamat;
                    SIKPCalonDebitur.KelurahanSIKP = RFZipCode.Kelurahan;
                    SIKPCalonDebitur.KecamatanSIKP = RFZipCode.Kecamatan;
                    SIKPCalonDebitur.KabupatenKotaSIKP = RFZipCode.KodeKabKota;
                    SIKPCalonDebitur.PropinsiSIKP = RFZipCode.Provinsi;

                    SIKPCalonDebitur.RFGenderSIKPId = RFGender.Id;
                    SIKPCalonDebitur.RFMaritalSIKPId = RFMarital.Id;
                    SIKPCalonDebitur.RFEducationSIKPId = RFEducation.Id;
                    SIKPCalonDebitur.RFJobSIKPId = RFJob.Id;
                    SIKPCalonDebitur.RFZipCodeSIKPId = RFZipCode.Id;

                    // Usaha
                    SIKPCalonDebitur.TanggalMulaiUsahaSIKP = DateTime.Parse(dataCalonDebitur.data.mulai_usaha);
                    SIKPCalonDebitur.AlamatUsahaSIKP = dataCalonDebitur.data.alamat_usaha;
                    SIKPCalonDebitur.KelurahanUsahaSIKP = RFZipCode.Kelurahan;
                    SIKPCalonDebitur.KecamatanUsahaSIKP = RFZipCode.Kecamatan;
                    SIKPCalonDebitur.KabupatenKotaUsahaSIKP = RFZipCode.KodeKabKota;
                    SIKPCalonDebitur.PropinsiUsahaSIKP = RFZipCode.Provinsi;
                    SIKPCalonDebitur.IzinUsahaSIKP = dataCalonDebitur.data.ijin_usaha;
                    SIKPCalonDebitur.ModalUsahaSIKP = double.Parse(dataCalonDebitur.data.modal_usaha);
                    SIKPCalonDebitur.JumlahKreditSIKP = double.Parse(dataCalonDebitur.data.jml_kredit);
                    SIKPCalonDebitur.NoHPSIKP = dataCalonDebitur.data.no_hp;
                    SIKPCalonDebitur.AgunanSIKP = dataCalonDebitur.data.uraian_agunan;
                    SIKPCalonDebitur.JumlahPekerjaSIKP = int.Parse(dataCalonDebitur.data.jml_pekerja);
                    SIKPCalonDebitur.StatusSubsidiSIKP = dataCalonDebitur.data.is_subsidized == "1";
                    SIKPCalonDebitur.SubsidiSebelumnyaSIKP = double.Parse(dataCalonDebitur.data.subsidi_sebelumnya ?? "0");

                    SIKPCalonDebitur.RFZipCodeUsahaSIKPId = RFZipCode.Id;
                    SIKPCalonDebitur.RFLinkageUsahaSIKPId = RFLinkage.Id;

                    await _SIKPCalonDebitur.UpdateAsync(SIKPCalonDebitur);
                }

                if (response.Valid == false)
                {
                    await _SIKPCalonDebitur.UpdateAsync(SIKPCalonDebitur);
                    return ServiceResponse<ValidasiPostCalonResponseModel>.ReturnResultWith200(response);
                }

                // Validasi Limit
                if (response.PlafonResponse.data != null)
                {
                    response = await ValidasiLimit(request, response);
                    SIKPCalonDebitur.Valid = response.Valid;
                    SIKPCalonDebitur.MessageValidasi = response.Message;
                }

                if (response.Valid == false)
                {
                    await _SIKPCalonDebitur.UpdateAsync(SIKPCalonDebitur);
                    return ServiceResponse<ValidasiPostCalonResponseModel>.ReturnResultWith200(response);
                }

                // Post Calon Debitur

                var postResponse = await _SIKPService.PostCalonDebitur(new PostCalonDebiturRequestModel
                {
                    nik = request.NIK,
                    nmr_registry = request.NmrRegistry,
                    nama = request.Nama,
                    tgl_lahir = request.TglLahir,
                    jns_kelamin = request.JenisKelamin,
                    maritas_sts = request.MaritasStatus,
                    pendidikan = request.Pendidikan,
                    pekerjaan = request.Pekerjaan,
                    alamat = request.Alamat,
                    kode_kabkota = request.KodeKabKota,
                    kode_pos = request.KodePos,
                    npwp = request.NPWP,
                    mulai_usaha = request.MulaiUsaha,
                    alamat_usaha = request.AlamatUsaha,
                    ijin_usaha = request.IjinUsaha,
                    modal_usaha = request.ModalUsaha,
                    jml_pekerja = request.JmlPekerja,
                    jml_kredit = request.JmlKredit,
                    is_linkage = request.IsLinkage,
                    linkage = request.Linkage,
                    no_hp = request.NoHP,
                    uraian_agunan = request.UraianAgunan,
                    is_subsidized = request.IsSubsidized,
                    subsidi_sebelumnya = request.SubsidiSebelumnya,
                });

                if (postResponse.error == true)
                {
                    response.Valid = false;
                    response.Message = postResponse.message;
                }

                if (response.CalonDebiturResponse.data == null)
                {
                    response.Valid = false;
                    response.Message = "Calon debitur belum terdaftar di SIKP";
                }

                SIKPCalonDebitur.Valid = response.Valid;
                SIKPCalonDebitur.MessageValidasi = response.Message;
                await _SIKPCalonDebitur.UpdateAsync(SIKPCalonDebitur);

                return ServiceResponse<ValidasiPostCalonResponseModel>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<ValidasiPostCalonResponseModel>.ReturnException(ex);
            }
        }
    }
}