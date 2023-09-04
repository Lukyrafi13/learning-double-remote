using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfVehClass;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfVehClasses.Queries.GetFilterRfVehClasses
{
    public class RfVehClassesGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfVehClassResponse>>>
    {
    }

    public class RfVehClassesGetFilterQueryHandler : IRequestHandler<RfVehClassesGetFilterQuery, PagedResponse<IEnumerable<RfVehClassResponse>>>
    {
        private IGenericRepositoryAsync<RfVehClass> _rfVehClass;
        private readonly IMapper _mapper;

        public RfVehClassesGetFilterQueryHandler(IGenericRepositoryAsync<RfVehClass> rfVehClass, IMapper mapper)
        {
            _rfVehClass = rfVehClass;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfVehClassResponse>>> Handle(RfVehClassesGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[] {
                "RfVehType",
                "RfVehModel",
                "RfVehMaker",
            };
            var data = await _rfVehClass.GetPagedReponseAsync(request, includes);
            var dataVm = _mapper.Map<IEnumerable<RfVehClassResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfVehClassResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
