using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFJenisAsuransis;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFJenisAsuransis.Queries
{
    public class RFJenisAsuransisGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFJenisAsuransiResponseDto>>>
    {
    }

    public class RFJenisAsuransisGetFilterQueryHandler : IRequestHandler<RFJenisAsuransisGetFilterQuery, PagedResponse<IEnumerable<RFJenisAsuransiResponseDto>>>
    {
        private IGenericRepositoryAsync<RFJenisAsuransi> _RFJenisAsuransi;
        private readonly IMapper _mapper;

        public RFJenisAsuransisGetFilterQueryHandler(IGenericRepositoryAsync<RFJenisAsuransi> RFJenisAsuransi, IMapper mapper)
        {
            _RFJenisAsuransi = RFJenisAsuransi;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFJenisAsuransiResponseDto>>> Handle(RFJenisAsuransisGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
            };

            var data = await _RFJenisAsuransi.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFJenisAsuransiResponseDto>>(data.Results);
            IEnumerable<RFJenisAsuransiResponseDto> dataVm;
            var listResponse = new List<RFJenisAsuransiResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFJenisAsuransiResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFJenisAsuransiResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}