using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFJenisAktas;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFJenisAktas.Queries
{
    public class RFJenisAktasGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFJenisAktaResponseDto>>>
    {
    }

    public class RFJenisAktasGetFilterQueryHandler : IRequestHandler<RFJenisAktasGetFilterQuery, PagedResponse<IEnumerable<RFJenisAktaResponseDto>>>
    {
        private IGenericRepositoryAsync<RFJenisAkta> _RFJenisAkta;
        private readonly IMapper _mapper;

        public RFJenisAktasGetFilterQueryHandler(IGenericRepositoryAsync<RFJenisAkta> RFJenisAkta, IMapper mapper)
        {
            _RFJenisAkta = RFJenisAkta;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFJenisAktaResponseDto>>> Handle(RFJenisAktasGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
            };

            var data = await _RFJenisAkta.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFJenisAktaResponseDto>>(data.Results);
            IEnumerable<RFJenisAktaResponseDto> dataVm;
            var listResponse = new List<RFJenisAktaResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFJenisAktaResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFJenisAktaResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}