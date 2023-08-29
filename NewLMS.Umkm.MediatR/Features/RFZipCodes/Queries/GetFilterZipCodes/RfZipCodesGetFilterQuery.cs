using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RFZipCodes;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFZipcodes.Queries
{
    public class RFZipCodeGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFZipCodeResponse>>>
    {
    }

    public class GetFilterRFZipCodeQueryHandler : IRequestHandler<RFZipCodeGetFilterQuery, PagedResponse<IEnumerable<RFZipCodeResponse>>>
    {
        private IGenericRepositoryAsync<RFZipCode> _rfZipCode;
        private readonly IMapper _mapper;

        public GetFilterRFZipCodeQueryHandler(IGenericRepositoryAsync<RFZipCode> rfZipCode, IMapper mapper)
        {
            _rfZipCode = rfZipCode;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFZipCodeResponse>>> Handle(RFZipCodeGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfZipCode.GetPagedReponseAsync(request);
            var dataVm = _mapper.Map<IEnumerable<RFZipCodeResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RFZipCodeResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
