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
    public class GetWilayahRegencyQuery : IRequest<ServiceResponse<List<SimpleResponse<string>>>>
    {
        public string ParentCode;
    }

    public class GetWilayahRegencyQueryHandler : IRequestHandler<GetWilayahRegencyQuery, ServiceResponse<List<SimpleResponse<string>>>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepositoryAsync<WilayahRegencies> _wilayahRegency;

        public GetWilayahRegencyQueryHandler(IMapper mapper, IGenericRepositoryAsync<WilayahRegencies> wilayahRegency)
        {
            _mapper = mapper;
            _wilayahRegency = wilayahRegency;
        }
        public async Task<ServiceResponse<List<SimpleResponse<string>>>> Handle(GetWilayahRegencyQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var wilayahRegency = await _wilayahRegency.GetListByPredicate(x => x.ParentCode == request.ParentCode);

                return ServiceResponse<List<SimpleResponse<string>>>.ReturnResultWith200(_mapper.Map<List<SimpleResponse<string>>>(wilayahRegency.ToList()));
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<SimpleResponse<string>>>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
