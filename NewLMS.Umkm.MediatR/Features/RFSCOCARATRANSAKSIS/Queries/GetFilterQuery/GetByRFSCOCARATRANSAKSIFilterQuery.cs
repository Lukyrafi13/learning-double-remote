using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RFSCOCARATRANSAKSIs;
using NewLMS.UMKM.Repository.GenericRepository;
using AutoMapper;
using NewLMS.UMKM.Data;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFSCOCARATRANSAKSIS.Queries
{
    public class GetByRFSCOCARATRANSAKSIFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFSCOCARATRANSAKSIResponseDto>>>
    {
    }

    public class GetByRFSCOCARATRANSAKSIFilterQueryHandler : IRequestHandler<GetByRFSCOCARATRANSAKSIFilterQuery, PagedResponse<IEnumerable<RFSCOCARATRANSAKSIResponseDto>>>
    {
        private IGenericRepositoryAsync<RFSCOCARATRANSAKSI> _rfSCOCARATRANSAKSI;
        private readonly IMapper _mapper;

        public GetByRFSCOCARATRANSAKSIFilterQueryHandler(IGenericRepositoryAsync<RFSCOCARATRANSAKSI> rfSCOCARATRANSAKSI, IMapper mapper)
        {
            _rfSCOCARATRANSAKSI = rfSCOCARATRANSAKSI;
            _mapper = mapper;
        }
        public async
        Task<PagedResponse<IEnumerable<RFSCOCARATRANSAKSIResponseDto>>> Handle(GetByRFSCOCARATRANSAKSIFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfSCOCARATRANSAKSI.GetPagedReponseAsync(request);
            
            IEnumerable<RFSCOCARATRANSAKSIResponseDto> dataVm;
            var listResponse = new List<RFSCOCARATRANSAKSIResponseDto>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<RFSCOCARATRANSAKSIResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFSCOCARATRANSAKSIResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}