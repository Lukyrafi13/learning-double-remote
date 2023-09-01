using MediatR;
using NewLMS.UMKM.Data.Dto.RfZipCodes;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfZipCodes.Queries
{
    public class GetKecamatanByKabKotaQueryZipCode : IRequest<ServiceResponse<IEnumerable<RfZipCodeKecamatanResponse>>>
    {
        public string KodeKabKota { get; set; }
    }
    public class GetKecamatanByKabKotaQueryZipCodeHandler : IRequestHandler<GetKecamatanByKabKotaQueryZipCode, ServiceResponse<IEnumerable<RfZipCodeKecamatanResponse>>>
    {
        IGenericRepositoryAsync<RfZipCode> _rfZipCode;

        public GetKecamatanByKabKotaQueryZipCodeHandler(IGenericRepositoryAsync<RfZipCode> rfZipCode)
        {
            _rfZipCode = rfZipCode;
        }
        public async Task<ServiceResponse<IEnumerable<RfZipCodeKecamatanResponse>>> Handle(GetKecamatanByKabKotaQueryZipCode request, CancellationToken cancellationToken)
        {
            List<RfZipCodeKecamatanResponse> finaldata = new List<RfZipCodeKecamatanResponse>();
            var data = await _rfZipCode.GetListByPredicate(x => x.KodeKabKota == request.KodeKabKota);
            var dataMap = data.Select(x => (x.KodeKecamatan, x.Kecamatan)).DistinctBy(x => x.Kecamatan).OrderBy(i => i.Kecamatan);
            foreach (var dataVm in dataMap)
            {
                finaldata.Add(new RfZipCodeKecamatanResponse
                {
                    kodeKecamatan = dataVm.KodeKecamatan,
                    kecamatan = dataVm.Kecamatan
                });
            }
            return ServiceResponse<IEnumerable<RfZipCodeKecamatanResponse>>.ReturnResultWith200(finaldata);
        }
    }
}