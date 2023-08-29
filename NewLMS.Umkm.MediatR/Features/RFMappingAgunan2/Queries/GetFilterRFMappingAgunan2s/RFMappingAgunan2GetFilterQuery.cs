using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFMappingAgunan2s;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFMappingAgunan2s.Queries
{
    public class RFMappingAgunan2sGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFMappingAgunan2ResponseDto>>>
    {
    }

    public class GetFilterRFMappingAgunan2QueryHandler : IRequestHandler<RFMappingAgunan2sGetFilterQuery, PagedResponse<IEnumerable<RFMappingAgunan2ResponseDto>>>
    {
        private IGenericRepositoryAsync<RFMappingAgunan2> _RFMappingAgunan2;
        private readonly IMapper _mapper;

        public GetFilterRFMappingAgunan2QueryHandler(IGenericRepositoryAsync<RFMappingAgunan2> RFMappingAgunan2, IMapper mapper)
        {
            _RFMappingAgunan2 = RFMappingAgunan2;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFMappingAgunan2ResponseDto>>> Handle(RFMappingAgunan2sGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFMappingAgunan2.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFMappingAgunan2ResponseDto>>(data.Results);
            IEnumerable<RFMappingAgunan2ResponseDto> dataVm;
            var listResponse = new List<RFMappingAgunan2ResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFMappingAgunan2ResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFMappingAgunan2ResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}