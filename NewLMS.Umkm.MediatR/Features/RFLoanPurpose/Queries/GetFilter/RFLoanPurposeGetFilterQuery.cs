using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFLoanPurposes;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFLoanPurposes.Queries
{
    public class RFLoanPurposesGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFLoanPurposeResponseDto>>>
    {
    }

    public class GetFilterRFLoanPurposeQueryHandler : IRequestHandler<RFLoanPurposesGetFilterQuery, PagedResponse<IEnumerable<RFLoanPurposeResponseDto>>>
    {
        private IGenericRepositoryAsync<RFLoanPurpose> _RFLoanPurpose;
        private readonly IMapper _mapper;

        public GetFilterRFLoanPurposeQueryHandler(IGenericRepositoryAsync<RFLoanPurpose> RFLoanPurpose, IMapper mapper)
        {
            _RFLoanPurpose = RFLoanPurpose;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFLoanPurposeResponseDto>>> Handle(RFLoanPurposesGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFLoanPurpose.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFLoanPurposeResponseDto>>(data.Results);
            IEnumerable<RFLoanPurposeResponseDto> dataVm;
            var listResponse = new List<RFLoanPurposeResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFLoanPurposeResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFLoanPurposeResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}