using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFTipeDokumens;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFTipeDokumens.Queries
{
    public class RFTipeDokumensGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFTipeDokumenResponseDto>>>
    {
    }

    public class RFTipeDokumensGetFilterQueryHandler : IRequestHandler<RFTipeDokumensGetFilterQuery, PagedResponse<IEnumerable<RFTipeDokumenResponseDto>>>
    {
        private IGenericRepositoryAsync<RFTipeDokumen> _RFTipeDokumen;
        private readonly IMapper _mapper;

        public RFTipeDokumensGetFilterQueryHandler(IGenericRepositoryAsync<RFTipeDokumen> RFTipeDokumen, IMapper mapper)
        {
            _RFTipeDokumen = RFTipeDokumen;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFTipeDokumenResponseDto>>> Handle(RFTipeDokumensGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
            };

            var data = await _RFTipeDokumen.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFTipeDokumenResponseDto>>(data.Results);
            IEnumerable<RFTipeDokumenResponseDto> dataVm;
            var listResponse = new List<RFTipeDokumenResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFTipeDokumenResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFTipeDokumenResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}