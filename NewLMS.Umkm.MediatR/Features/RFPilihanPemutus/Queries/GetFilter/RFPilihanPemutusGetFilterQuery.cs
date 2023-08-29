using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFPilihanPemutuss;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFPilihanPemutuss.Queries
{
    public class RFPilihanPemutussGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFPilihanPemutusResponseDto>>>
    {
    }

    public class RFPilihanPemutussGetFilterQueryHandler : IRequestHandler<RFPilihanPemutussGetFilterQuery, PagedResponse<IEnumerable<RFPilihanPemutusResponseDto>>>
    {
        private IGenericRepositoryAsync<RFPilihanPemutus> _RFPilihanPemutus;
        private readonly IMapper _mapper;

        public RFPilihanPemutussGetFilterQueryHandler(IGenericRepositoryAsync<RFPilihanPemutus> RFPilihanPemutus, IMapper mapper)
        {
            _RFPilihanPemutus = RFPilihanPemutus;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFPilihanPemutusResponseDto>>> Handle(RFPilihanPemutussGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
            };

            var data = await _RFPilihanPemutus.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFPilihanPemutusResponseDto>>(data.Results);
            IEnumerable<RFPilihanPemutusResponseDto> dataVm;
            var listResponse = new List<RFPilihanPemutusResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFPilihanPemutusResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFPilihanPemutusResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}