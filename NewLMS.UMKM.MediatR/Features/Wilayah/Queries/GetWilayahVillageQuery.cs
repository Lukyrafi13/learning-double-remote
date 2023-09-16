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
    public class GetWilayahVillageQuery : IRequest<ServiceResponse<List<SimpleResponseWithPostCode<string>>>>
    {
        public string ParentCode;
    }

    public class GetWilayahVillageQueryHandler : IRequestHandler<GetWilayahVillageQuery, ServiceResponse<List<SimpleResponseWithPostCode<string>>>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepositoryAsync<WilayahVillages> _wilayahVillages;

        public GetWilayahVillageQueryHandler(IMapper mapper, IGenericRepositoryAsync<WilayahVillages> wilayahVillages)
        {
            _mapper = mapper;
            _wilayahVillages = wilayahVillages;
        }
        public async Task<ServiceResponse<List<SimpleResponseWithPostCode<string>>>> Handle(GetWilayahVillageQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var wilayahVillages = await _wilayahVillages.GetListByPredicate(x => x.ParentCode == request.ParentCode);

                return ServiceResponse<List<SimpleResponseWithPostCode<string>>>.ReturnResultWith200(_mapper.Map<List<SimpleResponseWithPostCode<string>>>(wilayahVillages.ToList()));
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<SimpleResponseWithPostCode<string>>>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
