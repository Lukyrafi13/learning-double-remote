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
    public class GetKabKotaByZipCode : IRequest<ServiceResponse<IEnumerable<RFZipCodeKabKotaResponse>>>
    {
        public string ZipCode { get; set; }

    }
    public class GetKabKotaByZipCodeHandler : IRequestHandler<GetKabKotaByZipCode, ServiceResponse<IEnumerable<RFZipCodeKabKotaResponse>>>
    {
        IGenericRepositoryAsync<RFZipCode> _rfZipCode;

        public GetKabKotaByZipCodeHandler(IGenericRepositoryAsync<RFZipCode> rfZipCode)
        {
            _rfZipCode = rfZipCode;
        }
        public async Task<ServiceResponse<IEnumerable<RFZipCodeKabKotaResponse>>> Handle(GetKabKotaByZipCode request, CancellationToken cancellationToken)
        {
            List<RFZipCodeKabKotaResponse> finaldata = new List<RFZipCodeKabKotaResponse>();
            var data = await _rfZipCode.GetListByPredicate(x => x.ZipCode == request.ZipCode);
            var dataMap = data.Select(x => new { x.KodeKabKota, x.Kota }).DistinctBy(x => x.Kota).OrderBy(i => i.Kota).ToList();
            foreach (var dataVm in dataMap)
            {
                finaldata.Add(new RFZipCodeKabKotaResponse
                {
                    kodeKabKota = dataVm.KodeKabKota,
                    Kota = dataVm.Kota,
                });
            }
            return ServiceResponse<IEnumerable<RFZipCodeKabKotaResponse>>.ReturnResultWith200(finaldata);

        }
    }
}