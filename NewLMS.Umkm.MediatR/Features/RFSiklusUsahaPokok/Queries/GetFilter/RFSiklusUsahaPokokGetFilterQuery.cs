using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSiklusUsahaPokoks;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFSiklusUsahaPokoks.Queries
{
    public class RFSiklusUsahaPokoksGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFSiklusUsahaPokokResponseDto>>>
    {
    }

    public class RFSiklusUsahaPokoksGetFilterQueryHandler : IRequestHandler<RFSiklusUsahaPokoksGetFilterQuery, PagedResponse<IEnumerable<RFSiklusUsahaPokokResponseDto>>>
    {
        private IGenericRepositoryAsync<RFSiklusUsahaPokok> _RFSiklusUsahaPokok;
        private readonly IMapper _mapper;

        public RFSiklusUsahaPokoksGetFilterQueryHandler(IGenericRepositoryAsync<RFSiklusUsahaPokok> RFSiklusUsahaPokok, IMapper mapper)
        {
            _RFSiklusUsahaPokok = RFSiklusUsahaPokok;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFSiklusUsahaPokokResponseDto>>> Handle(RFSiklusUsahaPokoksGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
            };

            var data = await _RFSiklusUsahaPokok.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFSiklusUsahaPokokResponseDto>>(data.Results);
            IEnumerable<RFSiklusUsahaPokokResponseDto> dataVm;
            var listResponse = new List<RFSiklusUsahaPokokResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFSiklusUsahaPokokResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFSiklusUsahaPokokResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}