using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfVehClass;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RfVehClasses.Queries.GetFilterRfVehClasses
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
