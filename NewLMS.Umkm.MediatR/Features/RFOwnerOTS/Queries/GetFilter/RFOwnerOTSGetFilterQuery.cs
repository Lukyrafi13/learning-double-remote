using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFOwnerOTSs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFOwnerOTSs.Queries
{
    public class RFOwnerOTSGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFOwnerOTSResponseDto>>>
    {
    }

    public class RFOwnerOTSGetFilterQueryHandler : IRequestHandler<RFOwnerOTSGetFilterQuery, PagedResponse<IEnumerable<RFOwnerOTSResponseDto>>>
    {
        private IGenericRepositoryAsync<RFOwnerOTS> _RFOwnerOTS;
        private readonly IMapper _mapper;

        public RFOwnerOTSGetFilterQueryHandler(IGenericRepositoryAsync<RFOwnerOTS> RFOwnerOTS, IMapper mapper)
        {
            _RFOwnerOTS = RFOwnerOTS;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFOwnerOTSResponseDto>>> Handle(RFOwnerOTSGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFOwnerOTS.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFOwnerOTSResponseDto>>(data.Results);
            IEnumerable<RFOwnerOTSResponseDto> dataVm;
            var listResponse = new List<RFOwnerOTSResponseDto>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<RFOwnerOTSResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFOwnerOTSResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}