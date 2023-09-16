using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.Wilayah.Queries
{
    public class GetWilayahProvinceQuery : IRequest<ServiceResponse<List<SimpleResponse<string>>>>
    {
    }

    public class GetWilayahProvinceQueryHandler : IRequestHandler<GetWilayahProvinceQuery, ServiceResponse<List<SimpleResponse<string>>>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepositoryAsync<WilayahProvinces> _wilayahProvince;

        public GetWilayahProvinceQueryHandler(IMapper mapper, IGenericRepositoryAsync<WilayahProvinces> wilayahProvince)
        {
            _mapper = mapper;
            _wilayahProvince = wilayahProvince;
        }
        public async Task<ServiceResponse<List<SimpleResponse<string>>>> Handle(GetWilayahProvinceQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var wilayahProvince = await _wilayahProvince.GetAllAsync();

                return ServiceResponse<List<SimpleResponse<string>>>.ReturnResultWith200(_mapper.Map<List<SimpleResponse<string>>>(wilayahProvince.ToList()));
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<SimpleResponse<string>>>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
