using AutoMapper;
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
    public class GetProvinsiZipCode : IRequest<ServiceResponse<IEnumerable<RFZipCodeProvinsiResponse>>>
    {

    }

    public class GetProvinsiZipCodeHandler : IRequestHandler<GetProvinsiZipCode, ServiceResponse<IEnumerable<RFZipCodeProvinsiResponse>>>
    {
        IGenericRepositoryAsync<RFZipCode> _rfZipcode;
        IMapper _mapper;

        public GetProvinsiZipCodeHandler(IGenericRepositoryAsync<RFZipCode> rfZipcode, IMapper mapper)
        {
            _rfZipcode = rfZipcode;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<IEnumerable<RFZipCodeProvinsiResponse>>> Handle(GetProvinsiZipCode request, CancellationToken cancellationToken)
        {
            List<RFZipCodeProvinsiResponse> finaldata = new List<RFZipCodeProvinsiResponse>();

            var data = await _rfZipcode.GetListByPredicate(x=>x.KodeProvinsi != null);
            var dataDupli = data
            .DistinctBy(x => x.Provinsi)
            .DistinctBy(x => x.KodeProvinsi)
            .Select(x => new { x.KodeProvinsi, x.Provinsi })
            .OrderBy(i => i.Provinsi).ToList();
            foreach (var dataValue in dataDupli)
            {
                finaldata.Add(new RFZipCodeProvinsiResponse
                {
                    kodeProvinsi = dataValue.KodeProvinsi,
                    Provinsi = dataValue.Provinsi
                });
            }

            return ServiceResponse<IEnumerable<RFZipCodeProvinsiResponse>>.ReturnResultWith200(finaldata);
        }
    }
}