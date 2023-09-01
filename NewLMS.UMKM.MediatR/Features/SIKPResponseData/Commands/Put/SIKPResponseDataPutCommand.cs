using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.SIKPResponseDatas;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.SIKPResponseDatas.Commands
{
    public class SIKPResponseDataPutCommand : SIKPResponseDataPutRequestDto, IRequest<ServiceResponse<SIKPResponseDataResponseDto>>
    {
    }

    public class PutSIKPResponseDataCommandHandler : IRequestHandler<SIKPResponseDataPutCommand, ServiceResponse<SIKPResponseDataResponseDto>>
    {
        private readonly IGenericRepositoryAsync<SIKPResponseData> _SIKPResponseData;
        private readonly IMapper _mapper;

        public PutSIKPResponseDataCommandHandler(IGenericRepositoryAsync<SIKPResponseData> SIKPResponseData, IMapper mapper)
        {
            _SIKPResponseData = SIKPResponseData;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<SIKPResponseDataResponseDto>> Handle(SIKPResponseDataPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingSIKPResponseData = await _SIKPResponseData.GetByIdAsync(request.Id, "Id");

                existingSIKPResponseData.NoCIF = request.NoCIF;
                existingSIKPResponseData.NoKTP = request.NoKTP;
                existingSIKPResponseData.NPWP = request.NPWP;
                existingSIKPResponseData.NamaDebitur = request.NamaDebitur;
                existingSIKPResponseData.TanggalLahir = request.TanggalLahir;
                existingSIKPResponseData.Alamat = request.Alamat;
                existingSIKPResponseData.Kelurahan = request.Kelurahan;
                existingSIKPResponseData.Kecamatan = request.Kecamatan;
                existingSIKPResponseData.KabupatenKota = request.KabupatenKota;
                existingSIKPResponseData.Propinsi = request.Propinsi;

                // Data Usaha
                existingSIKPResponseData.TanggalMulaiUsaha = request.TanggalMulaiUsaha;
                existingSIKPResponseData.AlamatUsaha = request.AlamatUsaha;
                existingSIKPResponseData.KelurahanUsaha = request.KelurahanUsaha;
                existingSIKPResponseData.KecamatanUsaha = request.KecamatanUsaha;
                existingSIKPResponseData.KabupatenKotaUsaha = request.KabupatenKotaUsaha;
                existingSIKPResponseData.PropinsiUsaha = request.PropinsiUsaha;
                existingSIKPResponseData.IzinUsaha = request.IzinUsaha;
                existingSIKPResponseData.ModalUsaha = request.ModalUsaha;
                existingSIKPResponseData.JumlahKredit = request.JumlahKredit;
                existingSIKPResponseData.NoHP = request.NoHP;
                existingSIKPResponseData.Agunan = request.Agunan;
                existingSIKPResponseData.JumlahPekerja = request.JumlahPekerja;
                existingSIKPResponseData.StatusSubsidi = request.StatusSubsidi;
                existingSIKPResponseData.SubsidiSebelumnya = request.SubsidiSebelumnya;

                // Foreign Keys
                existingSIKPResponseData.LoanApplicationId = request.AppId;
                existingSIKPResponseData.RfOwnerCategoryId = request.RfOwnerCategoryId;
                existingSIKPResponseData.RfSectorLBU1Code = request.RfSectorLBU1Code;
                existingSIKPResponseData.RfSectorLBU2Code = request.RfSectorLBU2Code;
                existingSIKPResponseData.RfSectorLBU3Code = request.RfSectorLBU3Code;
                existingSIKPResponseData.RfGenderId = request.RfGenderId;
                existingSIKPResponseData.RFMaritalId = request.RFMaritalId;
                existingSIKPResponseData.RFEducationId = request.RFEducationId;
                existingSIKPResponseData.RFJobId = request.RFJobId;
                existingSIKPResponseData.RfZipCodeId = request.RfZipCodeId;
                existingSIKPResponseData.RfZipCodeUsahaId = request.RfZipCodeUsahaId;
                existingSIKPResponseData.RFLinkageUsahaId = request.RFLinkageUsahaId;
                
                await _SIKPResponseData.UpdateAsync(existingSIKPResponseData);

                var response = _mapper.Map<SIKPResponseDataResponseDto>(existingSIKPResponseData);

                return ServiceResponse<SIKPResponseDataResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SIKPResponseDataResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}