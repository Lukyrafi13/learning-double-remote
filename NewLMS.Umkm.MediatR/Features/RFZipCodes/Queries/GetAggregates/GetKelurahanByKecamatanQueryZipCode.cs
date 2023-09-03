using MediatR;
using NewLMS.UMKM.Data.Dto.RfZipCodes;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.MediatR.Features.RfZipCodes.Queries
{
    public class GetKelurahanByKecamatanQueryZipCode : IRequest<ServiceResponse<IEnumerable<RfZipCodeKelurahanResponse>>>
    {
        public string KodeKecamatan { get; set; }
    }


    public class GetKelurahanByKecamatanQueryZipCodeHandler : IRequestHandler<GetKelurahanByKecamatanQueryZipCode, ServiceResponse<IEnumerable<RfZipCodeKelurahanResponse>>>
    {
        private IGenericRepositoryAsync<RfZipCode> _rfZipCode;

        public GetKelurahanByKecamatanQueryZipCodeHandler(IGenericRepositoryAsync<RfZipCode> rfZipCode)
        {
            _rfZipCode = rfZipCode;
        }

        public async Task<ServiceResponse<IEnumerable<RfZipCodeKelurahanResponse>>> Handle(GetKelurahanByKecamatanQueryZipCode request, CancellationToken cancellationToken)
        {
            List<RfZipCodeKelurahanResponse> finaldata = new List<RfZipCodeKelurahanResponse>();
            var data = await _rfZipCode.GetListByPredicate(x => x.KodeKecamatan == request.KodeKecamatan);
            var dataMap = data.Select(x => (x.KodeKelurahan, x.Kelurahan, x.ZipCode, x.Id)).DistinctBy(x => x.Kelurahan).OrderBy(i => i.Kelurahan);
            foreach (var dataVm in dataMap)
            {
                finaldata.Add(new RfZipCodeKelurahanResponse
                {
                    kodeKelurahan = dataVm.KodeKelurahan,
                    kelurahan = dataVm.Kelurahan,
                    ZipCode = dataVm.ZipCode,
                    ZipCodeId = dataVm.Id,
                });
            }
            return ServiceResponse<IEnumerable<RfZipCodeKelurahanResponse>>.ReturnResultWith200(finaldata);
        }
    }
}