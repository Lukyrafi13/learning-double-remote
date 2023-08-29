using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFVEHMAKERs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFVEHMAKERs.Queries
{
    public class RFVEHMAKERsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFVEHMAKERResponseDto>>>
    {
    }

    public class GetFilterRFVEHMAKERQueryHandler : IRequestHandler<RFVEHMAKERsGetFilterQuery, PagedResponse<IEnumerable<RFVEHMAKERResponseDto>>>
    {
        private IGenericRepositoryAsync<RFVEHMAKER> _RFVEHMAKER;
        private readonly IMapper _mapper;

        public GetFilterRFVEHMAKERQueryHandler(IGenericRepositoryAsync<RFVEHMAKER> RFVEHMAKER, IMapper mapper)
        {
            _RFVEHMAKER = RFVEHMAKER;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFVEHMAKERResponseDto>>> Handle(RFVEHMAKERsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFVEHMAKER.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFVEHMAKERResponseDto>>(data.Results);
            IEnumerable<RFVEHMAKERResponseDto> dataVm;
            var listResponse = new List<RFVEHMAKERResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFVEHMAKERResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFVEHMAKERResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}