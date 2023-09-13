using MediatR;
using NewLMS.UMKM.Data.Dto.RfZipCodes;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.MediatR.Features.RfZipCodes.Queries
{
    public class GetKabKotaByProvinsiQueryZipCode : IRequest<ServiceResponse<IEnumerable<RfZipCodeKabKotaResponse>>>
    {
        public string KodeProvinsi { get; set; }

    }
    public class GetKabKotaByProvinsiQueryZipCodeHandler : IRequestHandler<GetKabKotaByProvinsiQueryZipCode, ServiceResponse<IEnumerable<RfZipCodeKabKotaResponse>>>
    {
        IGenericRepositoryAsync<RfZipCode> _rfZipCode;

        public GetKabKotaByProvinsiQueryZipCodeHandler(IGenericRepositoryAsync<RfZipCode> rfZipCode)
        {
            _rfZipCode = rfZipCode;
        }
        public async Task<ServiceResponse<IEnumerable<RfZipCodeKabKotaResponse>>> Handle(GetKabKotaByProvinsiQueryZipCode request, CancellationToken cancellationToken)
        {
            List<RfZipCodeKabKotaResponse> finaldata = new List<RfZipCodeKabKotaResponse>();
            var data = await _rfZipCode.GetListByPredicate(x => x.KodeProvinsi == request.KodeProvinsi);
            var dataMap = data.Select(x => new { x.KodeKabKota, x.Kota }).DistinctBy(x => x.Kota).OrderBy(i => i.Kota).ToList();
            foreach (var dataVm in dataMap)
            {
                finaldata.Add(new RfZipCodeKabKotaResponse
                {
                    kodeKabKota = dataVm.KodeKabKota,
                    Kota = dataVm.Kota,
                });
            }
            return ServiceResponse<IEnumerable<RfZipCodeKabKotaResponse>>.ReturnResultWith200(finaldata);

        }
    }
}