using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFEDUCATIONs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFEDUCATIONs.Queries
{
    public class RFEDUCATIONsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFEDUCATIONResponseDto>>>
    {
    }

    public class GetFilterRFEDUCATIONQueryHandler : IRequestHandler<RFEDUCATIONsGetFilterQuery, PagedResponse<IEnumerable<RFEDUCATIONResponseDto>>>
    {
        private IGenericRepositoryAsync<RFEDUCATION> _RFEDUCATION;
        private readonly IMapper _mapper;

        public GetFilterRFEDUCATIONQueryHandler(IGenericRepositoryAsync<RFEDUCATION> RFEDUCATION, IMapper mapper)
        {
            _RFEDUCATION = RFEDUCATION;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFEDUCATIONResponseDto>>> Handle(RFEDUCATIONsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFEDUCATION.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFEDUCATIONResponseDto>>(data.Results);
            IEnumerable<RFEDUCATIONResponseDto> dataVm;
            var listResponse = new List<RFEDUCATIONResponseDto>();

            foreach (var Education in data.Results){
                var response = _mapper.Map<RFEDUCATIONResponseDto>(Education);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFEDUCATIONResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}