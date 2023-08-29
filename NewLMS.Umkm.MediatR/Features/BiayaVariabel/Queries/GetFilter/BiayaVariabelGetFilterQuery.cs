using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.BiayaVariabels;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.BiayaVariabels.Queries
{
    public class BiayaVariabelsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<BiayaVariabelResponseDto>>>
    {
    }

    public class GetFilterBiayaVariabelQueryHandler : IRequestHandler<BiayaVariabelsGetFilterQuery, PagedResponse<IEnumerable<BiayaVariabelResponseDto>>>
    {
        private IGenericRepositoryAsync<BiayaVariabel> _BiayaVariabel;
        private readonly IMapper _mapper;

        public GetFilterBiayaVariabelQueryHandler(IGenericRepositoryAsync<BiayaVariabel> BiayaVariabel, IMapper mapper)
        {
            _BiayaVariabel = BiayaVariabel;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<BiayaVariabelResponseDto>>> Handle(BiayaVariabelsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _BiayaVariabel.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<BiayaVariabelResponseDto>>(data.Results);
            IEnumerable<BiayaVariabelResponseDto> dataVm;
            var listResponse = new List<BiayaVariabelResponseDto>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<BiayaVariabelResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<BiayaVariabelResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}