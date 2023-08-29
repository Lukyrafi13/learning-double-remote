using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFStatusDokumens;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFStatusDokumens.Queries
{
    public class RFStatusDokumensGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFStatusDokumenResponseDto>>>
    {
    }

    public class RFStatusDokumensGetFilterQueryHandler : IRequestHandler<RFStatusDokumensGetFilterQuery, PagedResponse<IEnumerable<RFStatusDokumenResponseDto>>>
    {
        private IGenericRepositoryAsync<RFStatusDokumen> _RFStatusDokumen;
        private readonly IMapper _mapper;

        public RFStatusDokumensGetFilterQueryHandler(IGenericRepositoryAsync<RFStatusDokumen> RFStatusDokumen, IMapper mapper)
        {
            _RFStatusDokumen = RFStatusDokumen;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFStatusDokumenResponseDto>>> Handle(RFStatusDokumensGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
            };

            var data = await _RFStatusDokumen.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFStatusDokumenResponseDto>>(data.Results);
            IEnumerable<RFStatusDokumenResponseDto> dataVm;
            var listResponse = new List<RFStatusDokumenResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFStatusDokumenResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFStatusDokumenResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}