using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFApprKomoditis;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFApprKomoditis.Queries
{
    public class RFApprKomoditisGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFApprKomoditiResponseDto>>>
    {
    }

    public class GetFilterRFApprKomoditiQueryHandler : IRequestHandler<RFApprKomoditisGetFilterQuery, PagedResponse<IEnumerable<RFApprKomoditiResponseDto>>>
    {
        private IGenericRepositoryAsync<RFApprKomoditi> _RFApprKomoditi;
        private readonly IMapper _mapper;

        public GetFilterRFApprKomoditiQueryHandler(IGenericRepositoryAsync<RFApprKomoditi> RFApprKomoditi, IMapper mapper)
        {
            _RFApprKomoditi = RFApprKomoditi;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFApprKomoditiResponseDto>>> Handle(RFApprKomoditisGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFApprKomoditi.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFApprKomoditiResponseDto>>(data.Results);
            IEnumerable<RFApprKomoditiResponseDto> dataVm;
            var listResponse = new List<RFApprKomoditiResponseDto>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<RFApprKomoditiResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFApprKomoditiResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}