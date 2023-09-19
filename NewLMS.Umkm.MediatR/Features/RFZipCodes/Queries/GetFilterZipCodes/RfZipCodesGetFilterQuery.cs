using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfZipCodes;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.MediatR.Features.RfZipCodes.Queries
{
    public class RfZipCodeGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfZipCodeResponse>>>
    {
    }

    public class GetFilterRfZipCodeQueryHandler : IRequestHandler<RfZipCodeGetFilterQuery, PagedResponse<IEnumerable<RfZipCodeResponse>>>
    {
        private IGenericRepositoryAsync<RfZipCode> _rfZipCode;
        private readonly IMapper _mapper;

        public GetFilterRfZipCodeQueryHandler(IGenericRepositoryAsync<RfZipCode> rfZipCode, IMapper mapper)
        {
            _rfZipCode = rfZipCode;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfZipCodeResponse>>> Handle(RfZipCodeGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfZipCode.GetPagedReponseAsync(request);
            var dataVm = _mapper.Map<IEnumerable<RfZipCodeResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfZipCodeResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
