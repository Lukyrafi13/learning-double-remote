using MediatR;
using NewLMS.UMKM.Data.Dto.RfZipCodes;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfZipcodes.Queries
{
    public class GetKabKotaByZipCode : IRequest<ServiceResponse<IEnumerable<RfZipCodeKabKotaResponse>>>
    {
        public string ZipCode { get; set; }

    }
    public class GetKabKotaByZipCodeHandler : IRequestHandler<GetKabKotaByZipCode, ServiceResponse<IEnumerable<RfZipCodeKabKotaResponse>>>
    {
        IGenericRepositoryAsync<RfZipCode> _rfZipCode;

        public GetKabKotaByZipCodeHandler(IGenericRepositoryAsync<RfZipCode> rfZipCode)
        {
            _rfZipCode = rfZipCode;
        }
        public async Task<ServiceResponse<IEnumerable<RfZipCodeKabKotaResponse>>> Handle(GetKabKotaByZipCode request, CancellationToken cancellationToken)
        {
            List<RfZipCodeKabKotaResponse> finaldata = new List<RfZipCodeKabKotaResponse>();
            var data = await _rfZipCode.GetListByPredicate(x => x.ZipCode == request.ZipCode);
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