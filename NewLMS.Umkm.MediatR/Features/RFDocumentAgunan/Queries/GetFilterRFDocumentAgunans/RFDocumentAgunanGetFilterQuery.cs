using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFDocumentAgunans;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFDocumentAgunans.Queries
{
    public class RFDocumentAgunansGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFDocumentAgunanResponseDto>>>
    {
    }

    public class GetFilterRFDocumentAgunanQueryHandler : IRequestHandler<RFDocumentAgunansGetFilterQuery, PagedResponse<IEnumerable<RFDocumentAgunanResponseDto>>>
    {
        private IGenericRepositoryAsync<RFDocumentAgunan> _RFDocumentAgunan;
        private readonly IMapper _mapper;

        public GetFilterRFDocumentAgunanQueryHandler(IGenericRepositoryAsync<RFDocumentAgunan> RFDocumentAgunan, IMapper mapper)
        {
            _RFDocumentAgunan = RFDocumentAgunan;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFDocumentAgunanResponseDto>>> Handle(RFDocumentAgunansGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFDocumentAgunan.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFDocumentAgunanResponseDto>>(data.Results);
            IEnumerable<RFDocumentAgunanResponseDto> dataVm;
            var listResponse = new List<RFDocumentAgunanResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFDocumentAgunanResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFDocumentAgunanResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}