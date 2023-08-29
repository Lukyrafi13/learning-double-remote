using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFTipeKredits;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFTipeKredits.Queries
{
    public class RFTipeKreditsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFTipeKreditResponseDto>>>
    {
    }

    public class RFTipeKreditsGetFilterQueryHandler : IRequestHandler<RFTipeKreditsGetFilterQuery, PagedResponse<IEnumerable<RFTipeKreditResponseDto>>>
    {
        private IGenericRepositoryAsync<RFTipeKredit> _RFTipeKredit;
        private readonly IMapper _mapper;

        public RFTipeKreditsGetFilterQueryHandler(IGenericRepositoryAsync<RFTipeKredit> RFTipeKredit, IMapper mapper)
        {
            _RFTipeKredit = RFTipeKredit;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFTipeKreditResponseDto>>> Handle(RFTipeKreditsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
            };

            var data = await _RFTipeKredit.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFTipeKreditResponseDto>>(data.Results);
            IEnumerable<RFTipeKreditResponseDto> dataVm;
            var listResponse = new List<RFTipeKreditResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFTipeKreditResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFTipeKreditResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}