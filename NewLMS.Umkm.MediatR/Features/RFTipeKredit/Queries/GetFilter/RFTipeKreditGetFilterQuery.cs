using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfCreditTypes;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfCreditTypes.Queries
{
    public class RfCreditTypesGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfCreditTypeResponseDto>>>
    {
    }

    public class RfCreditTypesGetFilterQueryHandler : IRequestHandler<RfCreditTypesGetFilterQuery, PagedResponse<IEnumerable<RfCreditTypeResponseDto>>>
    {
        private IGenericRepositoryAsync<RfCreditType> _RfCreditType;
        private readonly IMapper _mapper;

        public RfCreditTypesGetFilterQueryHandler(IGenericRepositoryAsync<RfCreditType> RfCreditType, IMapper mapper)
        {
            _RfCreditType = RfCreditType;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfCreditTypeResponseDto>>> Handle(RfCreditTypesGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
            };

            var data = await _RfCreditType.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RfCreditTypeResponseDto>>(data.Results);
            IEnumerable<RfCreditTypeResponseDto> dataVm;
            var listResponse = new List<RfCreditTypeResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RfCreditTypeResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RfCreditTypeResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}