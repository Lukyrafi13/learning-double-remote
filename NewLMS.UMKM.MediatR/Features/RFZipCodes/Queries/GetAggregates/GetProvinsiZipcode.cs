using AutoMapper;
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
    public class GetProvinsiZipCode : IRequest<ServiceResponse<IEnumerable<RfZipCodeProvinsiResponse>>>
    {

    }

    public class GetProvinsiZipCodeHandler : IRequestHandler<GetProvinsiZipCode, ServiceResponse<IEnumerable<RfZipCodeProvinsiResponse>>>
    {
        IGenericRepositoryAsync<RfZipCode> _rfZipcode;
        IMapper _mapper;

        public GetProvinsiZipCodeHandler(IGenericRepositoryAsync<RfZipCode> rfZipcode, IMapper mapper)
        {
            _rfZipcode = rfZipcode;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<IEnumerable<RfZipCodeProvinsiResponse>>> Handle(GetProvinsiZipCode request, CancellationToken cancellationToken)
        {
            List<RfZipCodeProvinsiResponse> finaldata = new List<RfZipCodeProvinsiResponse>();

            var data = await _rfZipcode.GetListByPredicate(x=>x.KodeProvinsi != null);
            var dataDupli = data
            .DistinctBy(x => x.Provinsi)
            .DistinctBy(x => x.KodeProvinsi)
            .Select(x => new { x.KodeProvinsi, x.Provinsi })
            .OrderBy(i => i.Provinsi).ToList();
            foreach (var dataValue in dataDupli)
            {
                finaldata.Add(new RfZipCodeProvinsiResponse
                {
                    kodeProvinsi = dataValue.KodeProvinsi,
                    Provinsi = dataValue.Provinsi
                });
            }

            return ServiceResponse<IEnumerable<RfZipCodeProvinsiResponse>>.ReturnResultWith200(finaldata);
        }
    }
}