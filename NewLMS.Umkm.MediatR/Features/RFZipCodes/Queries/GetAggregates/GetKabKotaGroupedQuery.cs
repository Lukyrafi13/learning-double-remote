using MediatR;
using NewLMS.Umkm.Data.Dto.RfZipCodes;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.MediatR.Features.RfZipCodes.Queries
{
    public class GetKabKotaGroupedQuery : IRequest<ServiceResponse<IEnumerable<RfZipCodeKabKotaGroupedResponse>>>
    {
    }
    public class GetKabKotaGroupedQueryHandler : IRequestHandler<GetKabKotaGroupedQuery, ServiceResponse<IEnumerable<RfZipCodeKabKotaGroupedResponse>>>
    {
        IGenericRepositoryAsync<RfZipCode> _rfZipCode;

        public GetKabKotaGroupedQueryHandler(IGenericRepositoryAsync<RfZipCode> rfZipCode)
        {
            _rfZipCode = rfZipCode;
        }
        public async Task<ServiceResponse<IEnumerable<RfZipCodeKabKotaGroupedResponse>>> Handle(GetKabKotaGroupedQuery request, CancellationToken cancellationToken)
        {
            List<RfZipCodeKabKotaGroupedResponse> finaldata = new List<RfZipCodeKabKotaGroupedResponse>();
            var data = await _rfZipCode.GetListByPredicate(x => true);
            var dataMap = data.Select(x => (x.Kota, x.Provinsi)).DistinctBy(x => x.Kota);
            foreach (var dataVm in dataMap)
            {
                finaldata.Add(new RfZipCodeKabKotaGroupedResponse
                {
                    KabupatenKota = dataVm.Kota,
                    Provinsi = dataVm.Provinsi,
                });
            }
            return ServiceResponse<IEnumerable<RfZipCodeKabKotaGroupedResponse>>.ReturnResultWith200(finaldata);
        }
    }
}