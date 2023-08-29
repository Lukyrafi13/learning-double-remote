using MediatR;
using NewLMS.Umkm.Data.Dto.RFZipCodes;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFZipcodes.Queries
{
    public class GetKecamatanByKabKotaQueryZipCode : IRequest<ServiceResponse<IEnumerable<RFZipCodeKecamatanResponse>>>
    {
        public string KodeKabKota { get; set; }
    }
    public class GetKecamatanByKabKotaQueryZipCodeHandler : IRequestHandler<GetKecamatanByKabKotaQueryZipCode, ServiceResponse<IEnumerable<RFZipCodeKecamatanResponse>>>
    {
        IGenericRepositoryAsync<RFZipCode> _rfZipCode;

        public GetKecamatanByKabKotaQueryZipCodeHandler(IGenericRepositoryAsync<RFZipCode> rfZipCode)
        {
            _rfZipCode = rfZipCode;
        }
        public async Task<ServiceResponse<IEnumerable<RFZipCodeKecamatanResponse>>> Handle(GetKecamatanByKabKotaQueryZipCode request, CancellationToken cancellationToken)
        {
            List<RFZipCodeKecamatanResponse> finaldata = new List<RFZipCodeKecamatanResponse>();
            var data = await _rfZipCode.GetListByPredicate(x => x.KodeKabKota == request.KodeKabKota);
            var dataMap = data.Select(x => (x.KodeKecamatan, x.Kecamatan)).DistinctBy(x => x.Kecamatan).OrderBy(i => i.Kecamatan);
            foreach (var dataVm in dataMap)
            {
                finaldata.Add(new RFZipCodeKecamatanResponse
                {
                    kodeKecamatan = dataVm.KodeKecamatan,
                    kecamatan = dataVm.Kecamatan
                });
            }
            return ServiceResponse<IEnumerable<RFZipCodeKecamatanResponse>>.ReturnResultWith200(finaldata);
        }
    }
}