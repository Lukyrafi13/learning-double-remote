using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFMappingLBU3s;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFMappingLBU3s.Queries
{
    public class RFMappingLBU3sGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFMappingLBU3ResponseDto>>>
    {
    }

    public class RFMappingLBU3sGetFilterQueryHandler : IRequestHandler<RFMappingLBU3sGetFilterQuery, PagedResponse<IEnumerable<RFMappingLBU3ResponseDto>>>
    {
        private IGenericRepositoryAsync<RFMappingLBU3> _RFMappingLBU3;
        private readonly IMapper _mapper;

        public RFMappingLBU3sGetFilterQueryHandler(IGenericRepositoryAsync<RFMappingLBU3> RFMappingLBU3, IMapper mapper)
        {
            _RFMappingLBU3 = RFMappingLBU3;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFMappingLBU3ResponseDto>>> Handle(RFMappingLBU3sGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
            };

            var data = await _RFMappingLBU3.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFMappingLBU3ResponseDto>>(data.Results);
            IEnumerable<RFMappingLBU3ResponseDto> dataVm;
            var listResponse = new List<RFMappingLBU3ResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFMappingLBU3ResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFMappingLBU3ResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}