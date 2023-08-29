using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFApprTingkatKesuburans;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFApprTingkatKesuburans.Queries
{
    public class RFApprTingkatKesuburansGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFApprTingkatKesuburanResponseDto>>>
    {
    }

    public class GetFilterRFApprTingkatKesuburanQueryHandler : IRequestHandler<RFApprTingkatKesuburansGetFilterQuery, PagedResponse<IEnumerable<RFApprTingkatKesuburanResponseDto>>>
    {
        private IGenericRepositoryAsync<RFApprTingkatKesuburan> _RFApprTingkatKesuburan;
        private readonly IMapper _mapper;

        public GetFilterRFApprTingkatKesuburanQueryHandler(IGenericRepositoryAsync<RFApprTingkatKesuburan> RFApprTingkatKesuburan, IMapper mapper)
        {
            _RFApprTingkatKesuburan = RFApprTingkatKesuburan;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFApprTingkatKesuburanResponseDto>>> Handle(RFApprTingkatKesuburansGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFApprTingkatKesuburan.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFApprTingkatKesuburanResponseDto>>(data.Results);
            IEnumerable<RFApprTingkatKesuburanResponseDto> dataVm;
            var listResponse = new List<RFApprTingkatKesuburanResponseDto>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<RFApprTingkatKesuburanResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFApprTingkatKesuburanResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}