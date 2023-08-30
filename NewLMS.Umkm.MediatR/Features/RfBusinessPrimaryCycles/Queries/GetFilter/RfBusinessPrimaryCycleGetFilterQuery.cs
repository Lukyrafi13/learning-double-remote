using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfBusinessPrimaryCycle;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfBusinessPrimaryCiclus.Queries
{
    public class RfBusinessPrimaryCycleGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfBusinessPrimaryCicleResponseDto>>>
    {
    }

    public class RfBusinessPrimaryCiclusGetFilterQueryHandler : IRequestHandler<RfBusinessPrimaryCycleGetFilterQuery, PagedResponse<IEnumerable<RfBusinessPrimaryCicleResponseDto>>>
    {
        private IGenericRepositoryAsync<RfBusinessPrimaryCycle> _RFSiklusUsahaPokok;
        private readonly IMapper _mapper;

        public RfBusinessPrimaryCiclusGetFilterQueryHandler(IGenericRepositoryAsync<RfBusinessPrimaryCycle> RFSiklusUsahaPokok, IMapper mapper)
        {
            _RFSiklusUsahaPokok = RFSiklusUsahaPokok;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfBusinessPrimaryCicleResponseDto>>> Handle(RfBusinessPrimaryCycleGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
            };

            var data = await _RFSiklusUsahaPokok.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFSiklusUsahaPokokResponseDto>>(data.Results);
            IEnumerable<RfBusinessPrimaryCicleResponseDto> dataVm;
            var listResponse = new List<RfBusinessPrimaryCicleResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RfBusinessPrimaryCicleResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RfBusinessPrimaryCicleResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}