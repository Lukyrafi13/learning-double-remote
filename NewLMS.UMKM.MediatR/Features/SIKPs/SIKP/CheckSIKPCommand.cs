using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.SIKPs;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using NewLMS.UMKM.SIKP.Interfaces;
using NewLMS.UMKM.SIKP.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfVehTypes.Queries.GetFilterRfVehTypes
{
    public class ValidasiPostCalonResponseModel
    {
        public string Message { get; set; }
        public bool Valid { get; set; }
        public PlafonResponseModel PlafonResponse { get; set; }
        public LimitAkadResponseModel LimitAkadResponse { get; set; }
        public CalonDebiturResponseModel CalonDebiturResponse { get; set; }
    }

    public class CheckSIKPCommand : IRequest<ServiceResponse<DetailCalonDebiturResponseModel>>
    {
        public Guid Id { get; set; }
    }

    public class CheckSIKPCommandHandler : IRequestHandler<CheckSIKPCommand, ServiceResponse<DetailCalonDebiturResponseModel>>
    {
        private IGenericRepositoryAsync<Data.Entities.SIKP> _sikp;
        private IGenericRepositoryAsync<SIKPRequest> _sikpRequest;
        private ISIKPService _sikpService;
        private readonly IMapper _mapper;

        public CheckSIKPCommandHandler(IMapper mapper, IGenericRepositoryAsync<Data.Entities.SIKP> sikp, IGenericRepositoryAsync<SIKPRequest> sikpRequest, ISIKPService sikpService)
        {
            _mapper = mapper;
            _sikp = sikp;
            _sikpRequest = sikpRequest;
            _sikpService = sikpService;
        }

        public async Task<ServiceResponse<DetailCalonDebiturResponseModel>> Handle(CheckSIKPCommand request, CancellationToken cancellationToken)
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

            var sikpDebtor = await _sikpService.GetCalonDebitur(sikp.SIKPRequest.DebtorNoIdentity);

            PostCalonDebiturRequestModel req = new()
            {
                nik = sikpRequest.DebtorNoIdentity,
                nmr_registry = sikp.RegistrationNumber,
                nama = sikpRequest.Fullname,
                tgl_lahir = $"{sikpRequest.DateOfBirth.Date.ToString()}{sikpRequest.DateOfBirth.Month.ToString()}{sikpRequest.DateOfBirth.Year.ToString()}",
                jns_kelamin = sikpRequest.RfGender.GenderCodeSIKP,
                maritas_sts = sikpRequest.RfMarital.MaritalCodeSKIP,
                pendidikan = sikpRequest.RfEducation.EducationCodeSIKP,
                pekerjaan = string.Empty,
                alamat = sikpRequest.DebtorAddress,
                kode_kabkota = sikpRequest.DebtorRfZipCode.KodeKabupaten,
                kode_pos = sikpRequest.DebtorRfZipCode.ZipCode,
                npwp = sikpRequest.DebtorNPWP,
                mulai_usaha = $"{sikpRequest.DebtorCompanyEstablishmentDate.Date.ToString()}{sikpRequest.DebtorCompanyEstablishmentDate.Month.ToString()}{sikpRequest.DebtorCompanyEstablishmentDate.Year.ToString()}",
                alamat_usaha = sikpRequest.DebtorCompanyAddress,
                ijin_usaha = sikpRequest.DebtorCompanyPermit,
                modal_usaha = sikpRequest.DebtorCompanyVentureCapital.ToString(),
                jml_pekerja = sikpRequest.DebtorCompanyEmployee.ToString(),
                jml_kredit = sikpRequest.DebtorCompanyCreditValue.ToString(),
                is_linkage = (sikpRequest.DebtorCompanyRfLinkage != null).ToString(),
                linkage = sikpRequest.DebtorCompanyRfLinkage.LinkAgeCode,
                no_hp = sikpRequest.DebtorCompanyPhone,
                uraian_agunan = sikpRequest.DebtorCompanyCollaterals,
                is_subsidized = sikpRequest.DebtorCompanySubisdyStatus.ToString(),
                subsidi_sebelumnya = sikpRequest.DebtorCompanyPreviousSubsidy,
            };
            var includes = new string[]
                {
                    "SIKPRequest"
                };
            var postResponse = await _sikpService.PostCalonDebitur(req);

            return new ServiceResponse<DetailCalonDebiturResponseModel>();
        }
    }
}
