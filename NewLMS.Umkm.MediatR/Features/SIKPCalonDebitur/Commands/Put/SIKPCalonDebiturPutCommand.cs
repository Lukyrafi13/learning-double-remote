using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.SIKPCalonDebiturs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.SIKPCalonDebiturs.Commands
{
    public class SIKPCalonDebiturPutCommand : SIKPCalonDebiturPutRequestDto, IRequest<ServiceResponse<SIKPCalonDebiturResponseDto>>
    {
    }

    public class PutSIKPCalonDebiturCommandHandler : IRequestHandler<SIKPCalonDebiturPutCommand, ServiceResponse<SIKPCalonDebiturResponseDto>>
    {
        private readonly IGenericRepositoryAsync<SIKPCalonDebitur> _SIKPCalonDebitur;
        private readonly IMapper _mapper;

        public PutSIKPCalonDebiturCommandHandler(IGenericRepositoryAsync<SIKPCalonDebitur> SIKPCalonDebitur, IMapper mapper)
        {
            _SIKPCalonDebitur = SIKPCalonDebitur;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<SIKPCalonDebiturResponseDto>> Handle(SIKPCalonDebiturPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingSIKPCalonDebitur = await _SIKPCalonDebitur.GetByIdAsync(request.Id, "Id");

                existingSIKPCalonDebitur.NoCIF = request.NoCIF;
                existingSIKPCalonDebitur.NoKTP = request.NoKTP;
                existingSIKPCalonDebitur.NPWP = request.NPWP;
                existingSIKPCalonDebitur.NamaDebitur = request.NamaDebitur;
                existingSIKPCalonDebitur.TanggalLahir = request.TanggalLahir;
                existingSIKPCalonDebitur.Alamat = request.Alamat;
                existingSIKPCalonDebitur.Kelurahan = request.Kelurahan;
                existingSIKPCalonDebitur.Kecamatan = request.Kecamatan;
                existingSIKPCalonDebitur.KabupatenKota = request.KabupatenKota;
                existingSIKPCalonDebitur.Propinsi = request.Propinsi;

                // Data Usaha
                existingSIKPCalonDebitur.TanggalMulaiUsaha = request.TanggalMulaiUsaha;
                existingSIKPCalonDebitur.AlamatUsaha = request.AlamatUsaha;
                existingSIKPCalonDebitur.KelurahanUsaha = request.KelurahanUsaha;
                existingSIKPCalonDebitur.KecamatanUsaha = request.KecamatanUsaha;
                existingSIKPCalonDebitur.KabupatenKotaUsaha = request.KabupatenKotaUsaha;
                existingSIKPCalonDebitur.PropinsiUsaha = request.PropinsiUsaha;
                existingSIKPCalonDebitur.IzinUsaha = request.IzinUsaha;
                existingSIKPCalonDebitur.ModalUsaha = request.ModalUsaha;
                existingSIKPCalonDebitur.JumlahKredit = request.JumlahKredit;
                existingSIKPCalonDebitur.NoHP = request.NoHP;
                existingSIKPCalonDebitur.Agunan = request.Agunan;
                existingSIKPCalonDebitur.JumlahPekerja = request.JumlahPekerja;
                existingSIKPCalonDebitur.StatusSubsidi = request.StatusSubsidi;
                existingSIKPCalonDebitur.SubsidiSebelumnya = request.SubsidiSebelumnya;

                // Foreign Keys
                existingSIKPCalonDebitur.AppId = request.AppId;
                existingSIKPCalonDebitur.RFOwnerCategoryId = request.RFOwnerCategoryId;
                existingSIKPCalonDebitur.RFSectorLBU1Code = request.RFSectorLBU1Code;
                existingSIKPCalonDebitur.RFSectorLBU2Code = request.RFSectorLBU2Code;
                existingSIKPCalonDebitur.RFSectorLBU3Code = request.RFSectorLBU3Code;
                existingSIKPCalonDebitur.RFGenderId = request.RFGenderId;
                existingSIKPCalonDebitur.RFMaritalId = request.RFMaritalId;
                existingSIKPCalonDebitur.RFEducationId = request.RFEducationId;
                existingSIKPCalonDebitur.RFJobId = request.RFJobId;
                existingSIKPCalonDebitur.RFZipCodeId = request.RFZipCodeId;
                existingSIKPCalonDebitur.RFZipCodeUsahaId = request.RFZipCodeUsahaId;
                existingSIKPCalonDebitur.RFLinkageUsahaId = request.RFLinkageUsahaId;
                
                await _SIKPCalonDebitur.UpdateAsync(existingSIKPCalonDebitur);

                var response = _mapper.Map<SIKPCalonDebiturResponseDto>(existingSIKPCalonDebitur);

                return ServiceResponse<SIKPCalonDebiturResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SIKPCalonDebiturResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}