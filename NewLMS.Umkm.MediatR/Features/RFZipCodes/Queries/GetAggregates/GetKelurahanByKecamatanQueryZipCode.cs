using MediatR;
using NewLMS.Umkm.Data.Dto.RFZipCodes;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFZipcodes.Queries
{
    public class GetKelurahanByKecamatanQueryZipCode : IRequest<ServiceResponse<IEnumerable<RFZipCodeKelurahanResponse>>>
    {
        public string KodeKecamatan { get; set; }
    }


    public class GetKelurahanByKecamatanQueryZipCodeHandler : IRequestHandler<GetKelurahanByKecamatanQueryZipCode, ServiceResponse<IEnumerable<RFZipCodeKelurahanResponse>>>
    {
        private IGenericRepositoryAsync<RFZipCode> _rfZipCode;

        public GetKelurahanByKecamatanQueryZipCodeHandler(IGenericRepositoryAsync<RFZipCode> rfZipCode)
        {
            _rfZipCode = rfZipCode;
        }

        public async Task<ServiceResponse<IEnumerable<RFZipCodeKelurahanResponse>>> Handle(GetKelurahanByKecamatanQueryZipCode request, CancellationToken cancellationToken)
        {
            List<RFZipCodeKelurahanResponse> finaldata = new List<RFZipCodeKelurahanResponse>();
            var data = await _rfZipCode.GetListByPredicate(x => x.KodeKecamatan == request.KodeKecamatan);
            var dataMap = data.Select(x => (x.KodeKelurahan, x.Kelurahan, x.ZipCode, x.Id)).DistinctBy(x => x.Kelurahan).OrderBy(i => i.Kelurahan);
            foreach (var dataVm in dataMap)
            {
                finaldata.Add(new RFZipCodeKelurahanResponse
                {
                    kodeKelurahan = dataVm.KodeKelurahan,
                    kelurahan = dataVm.Kelurahan,
                    ZipCode = dataVm.ZipCode,
                    ZipCodeId = dataVm.Id,
                });
            }
            return ServiceResponse<IEnumerable<RFZipCodeKelurahanResponse>>.ReturnResultWith200(finaldata);
        }
    }
}