using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFPaymentMethods;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFPaymentMethods.Queries
{
    public class RFPaymentMethodsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFPaymentMethodResponseDto>>>
    {
    }

    public class RFPaymentMethodsGetFilterQueryHandler : IRequestHandler<RFPaymentMethodsGetFilterQuery, PagedResponse<IEnumerable<RFPaymentMethodResponseDto>>>
    {
        private IGenericRepositoryAsync<RFPaymentMethod> _RFPaymentMethod;
        private readonly IMapper _mapper;

        public RFPaymentMethodsGetFilterQueryHandler(IGenericRepositoryAsync<RFPaymentMethod> RFPaymentMethod, IMapper mapper)
        {
            _RFPaymentMethod = RFPaymentMethod;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFPaymentMethodResponseDto>>> Handle(RFPaymentMethodsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
            };

            var data = await _RFPaymentMethod.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFPaymentMethodResponseDto>>(data.Results);
            IEnumerable<RFPaymentMethodResponseDto> dataVm;
            var listResponse = new List<RFPaymentMethodResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFPaymentMethodResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFPaymentMethodResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}