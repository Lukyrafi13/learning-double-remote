using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSatuanLuass;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFSatuanLuass.Queries
{
    public class RFSatuanLuassGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFSatuanLuasResponseDto>>>
    {
    }

    public class GetFilterRFSatuanLuasQueryHandler : IRequestHandler<RFSatuanLuassGetFilterQuery, PagedResponse<IEnumerable<RFSatuanLuasResponseDto>>>
    {
        private IGenericRepositoryAsync<RFSatuanLuas> _RFSatuanLuas;
        private readonly IMapper _mapper;

        public GetFilterRFSatuanLuasQueryHandler(IGenericRepositoryAsync<RFSatuanLuas> RFSatuanLuas, IMapper mapper)
        {
            _RFSatuanLuas = RFSatuanLuas;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFSatuanLuasResponseDto>>> Handle(RFSatuanLuassGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFSatuanLuas.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFSatuanLuasResponseDto>>(data.Results);
            IEnumerable<RFSatuanLuasResponseDto> dataVm;
            var listResponse = new List<RFSatuanLuasResponseDto>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<RFSatuanLuasResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFSatuanLuasResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}