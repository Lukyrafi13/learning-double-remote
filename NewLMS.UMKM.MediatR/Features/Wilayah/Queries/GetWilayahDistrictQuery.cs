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
    public class GetWilayahDistrictQuery : IRequest<ServiceResponse<List<SimpleResponse<string>>>>
    {
        public string ParentCode;
    }

    public class GetWilayahDistrictQueryHandler : IRequestHandler<GetWilayahDistrictQuery, ServiceResponse<List<SimpleResponse<string>>>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepositoryAsync<WilayahDistricts> _wilayahDistrict;

        public GetWilayahDistrictQueryHandler(IMapper mapper, IGenericRepositoryAsync<WilayahDistricts> wilayahDistrict)
        {
            _mapper = mapper;
            _wilayahDistrict = wilayahDistrict;
        }
        public async Task<ServiceResponse<List<SimpleResponse<string>>>> Handle(GetWilayahDistrictQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var wilayahDistrict = await _wilayahDistrict.GetListByPredicate(x => x.ParentCode == request.ParentCode);

                return ServiceResponse<List<SimpleResponse<string>>>.ReturnResultWith200(_mapper.Map<List<SimpleResponse<string>>>(wilayahDistrict.ToList()));
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<SimpleResponse<string>>>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
