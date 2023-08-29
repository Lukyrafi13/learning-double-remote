using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFZipCodes;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFZipcodes.Commands
{
    public class RFZipCodePutCommand : RFZipCodePutRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class PutRFZipCodeCommandHandler : IRequestHandler<RFZipCodePutCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFZipCode> _rfZipCode;
        private readonly IMapper _mapper;

        public PutRFZipCodeCommandHandler(IGenericRepositoryAsync<RFZipCode> rfZipCode, IMapper mapper)
        {
            _rfZipCode = rfZipCode;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFZipCodePutCommand request, CancellationToken cancellationToken)
        {
            var rfZipCode = await _rfZipCode.GetByIdAsync(request.Id, "Id");

            rfZipCode.ZipCode = request.ZipCode;
            rfZipCode.Seq = request.Seq;
            rfZipCode.ZipDesc = request.ZipDesc;
            rfZipCode.Kelurahan = request.Kelurahan;
            rfZipCode.Kecamatan = request.Kecamatan;
            rfZipCode.Provinsi = request.Provinsi;
            rfZipCode.Kota = request.Kota;
            rfZipCode.Dati_II = request.Dati_II;
            rfZipCode.Dati_II_Code = request.Dati_II_Code;
            rfZipCode.Negara = request.Negara;
            rfZipCode.SandiWilayahBI = request.SandiWilayahBI;
            rfZipCode.Active = request.Active;
            rfZipCode.KodeKabupaten = request.KodeKabupaten;
            rfZipCode.KodeProvinsi = request.KodeProvinsi;
            rfZipCode.KodeKabKota = request.KodeKabKota;
            rfZipCode.KodeKecamatan = request.KodeKecamatan;
            rfZipCode.KodeKelurahan = request.KodeKelurahan;

            await _rfZipCode.UpdateAsync(rfZipCode);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}
