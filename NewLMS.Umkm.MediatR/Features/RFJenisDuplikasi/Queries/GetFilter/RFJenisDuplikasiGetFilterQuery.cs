using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFJenisDuplikasis;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFJenisDuplikasis.Queries
{
    public class RFJenisDuplikasisGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFJenisDuplikasiResponseDto>>>
    {
    }

    public class RFJenisDuplikasisGetFilterQueryHandler : IRequestHandler<RFJenisDuplikasisGetFilterQuery, PagedResponse<IEnumerable<RFJenisDuplikasiResponseDto>>>
    {
        private IGenericRepositoryAsync<RFJenisDuplikasi> _RFJenisDuplikasi;
        private readonly IMapper _mapper;

        public RFJenisDuplikasisGetFilterQueryHandler(IGenericRepositoryAsync<RFJenisDuplikasi> RFJenisDuplikasi, IMapper mapper)
        {
            _RFJenisDuplikasi = RFJenisDuplikasi;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFJenisDuplikasiResponseDto>>> Handle(RFJenisDuplikasisGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
            };

            var data = await _RFJenisDuplikasi.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFJenisDuplikasiResponseDto>>(data.Results);
            IEnumerable<RFJenisDuplikasiResponseDto> dataVm;
            var listResponse = new List<RFJenisDuplikasiResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFJenisDuplikasiResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFJenisDuplikasiResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}