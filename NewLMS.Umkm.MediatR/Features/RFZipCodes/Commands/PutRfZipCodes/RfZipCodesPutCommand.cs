using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfZipCodes;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfZipCodes.Commands
{
    public class RfZipCodePutCommand : RfZipCodePutRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class PutRfZipCodeCommandHandler : IRequestHandler<RfZipCodePutCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RfZipCode> _rfZipCode;
        private readonly IMapper _mapper;

        public PutRfZipCodeCommandHandler(IGenericRepositoryAsync<RfZipCode> rfZipCode, IMapper mapper)
        {
            _rfZipCode = rfZipCode;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RfZipCodePutCommand request, CancellationToken cancellationToken)
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
