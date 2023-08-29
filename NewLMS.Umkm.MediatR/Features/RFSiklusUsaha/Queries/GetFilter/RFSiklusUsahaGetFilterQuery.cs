using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFSiklusUsahas;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFSiklusUsahas.Queries
{
    public class RFSiklusUsahasGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFSiklusUsahaResponseDto>>>
    {
    }

    public class RFSiklusUsahasGetFilterQueryHandler : IRequestHandler<RFSiklusUsahasGetFilterQuery, PagedResponse<IEnumerable<RFSiklusUsahaResponseDto>>>
    {
        private IGenericRepositoryAsync<RFSiklusUsaha> _RFSiklusUsaha;
        private readonly IMapper _mapper;

        public RFSiklusUsahasGetFilterQueryHandler(IGenericRepositoryAsync<RFSiklusUsaha> RFSiklusUsaha, IMapper mapper)
        {
            _RFSiklusUsaha = RFSiklusUsaha;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFSiklusUsahaResponseDto>>> Handle(RFSiklusUsahasGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
            };

            var data = await _RFSiklusUsaha.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFSiklusUsahaResponseDto>>(data.Results);
            IEnumerable<RFSiklusUsahaResponseDto> dataVm;
            var listResponse = new List<RFSiklusUsahaResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFSiklusUsahaResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFSiklusUsahaResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}