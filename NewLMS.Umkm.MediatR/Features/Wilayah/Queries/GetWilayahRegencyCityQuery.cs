using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.Wilayah.Queries
{
    public class GetWilayahRegencyCityQuery : IRequest<ServiceResponse<IEnumerable<SimpleResponse<String>>>>
    {
    }

    public class GetWilayahRegencyCityQueryHandler : IRequestHandler<GetWilayahRegencyCityQuery, ServiceResponse<IEnumerable<SimpleResponse<String>>>>
    {
        IGenericRepositoryAsync<WilayahRegencies> WilayahRegencies;
        IMapper _mapper;

        public GetWilayahRegencyCityQueryHandler(IMapper mapper, IGenericRepositoryAsync<WilayahRegencies> Wilayah)
        {
            _mapper = mapper;
            WilayahRegencies = Wilayah;
        }
        public async Task<ServiceResponse<IEnumerable<SimpleResponse<String>>>> Handle(GetWilayahRegencyCityQuery request, CancellationToken cancellationToken)
        {
            List<SimpleResponse<String>> finaldata = new List<SimpleResponse<String>>();

            var data = await WilayahRegencies.GetAllAsync();
            var dataOrdered = data.OrderBy(i => i.Name).ToList();
            foreach (var value in dataOrdered)
            {
                finaldata.Add(new SimpleResponse<String>
                {
                    Id = value.Code,
                    Description = value.Name
                });
            }

            return ServiceResponse<IEnumerable<SimpleResponse<String>>>.ReturnResultWith200(finaldata);
        }
    }
}
