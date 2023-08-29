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
    public class GetKabKotaGroupedQuery : IRequest<ServiceResponse<IEnumerable<RFZipCodeKabKotaGroupedResponse>>>
    {
    }
    public class GetKabKotaGroupedQueryHandler : IRequestHandler<GetKabKotaGroupedQuery, ServiceResponse<IEnumerable<RFZipCodeKabKotaGroupedResponse>>>
    {
        IGenericRepositoryAsync<RFZipCode> _rfZipCode;

        public GetKabKotaGroupedQueryHandler(IGenericRepositoryAsync<RFZipCode> rfZipCode)
        {
            _rfZipCode = rfZipCode;
        }
        public async Task<ServiceResponse<IEnumerable<RFZipCodeKabKotaGroupedResponse>>> Handle(GetKabKotaGroupedQuery request, CancellationToken cancellationToken)
        {
            List<RFZipCodeKabKotaGroupedResponse> finaldata = new List<RFZipCodeKabKotaGroupedResponse>();
            var data = await _rfZipCode.GetListByPredicate(x => true);
            var dataMap = data.Select(x => (x.Kota, x.Provinsi)).DistinctBy(x => x.Kota);
            foreach (var dataVm in dataMap)
            {
                finaldata.Add(new RFZipCodeKabKotaGroupedResponse
                {
                    KabupatenKota = dataVm.Kota,
                    Provinsi = dataVm.Provinsi,
                });
            }
            return ServiceResponse<IEnumerable<RFZipCodeKabKotaGroupedResponse>>.ReturnResultWith200(finaldata);
        }
    }
}