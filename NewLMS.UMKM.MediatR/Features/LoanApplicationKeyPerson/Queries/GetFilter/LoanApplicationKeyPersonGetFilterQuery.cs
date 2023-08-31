using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.LoanApplicationKeyPersons;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.LoanApplicationKeyPersons.Queries
{
    public class LoanApplicationKeyPersonsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<LoanApplicationKeyPersonResponseDto>>>
    {
    }

    public class GetFilterLoanApplicationKeyPersonQueryHandler : IRequestHandler<LoanApplicationKeyPersonsGetFilterQuery, PagedResponse<IEnumerable<LoanApplicationKeyPersonResponseDto>>>
    {
        private IGenericRepositoryAsync<LoanApplicationKeyPerson> _LoanApplicationKeyPerson;
        private readonly IMapper _mapper;

        public GetFilterLoanApplicationKeyPersonQueryHandler(IGenericRepositoryAsync<LoanApplicationKeyPerson> LoanApplicationKeyPerson, IMapper mapper)
        {
            _LoanApplicationKeyPerson = LoanApplicationKeyPerson;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<LoanApplicationKeyPersonResponseDto>>> Handle(LoanApplicationKeyPersonsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
                    "LoanApplication",
                    "RfEducation",
                    "RfMarital",
                    "RfZipCode",
                };

            var data = await _LoanApplicationKeyPerson.GetPagedReponseAsync(request, includes);
            // var dataVm = _mapper.Map<IEnumerable<LoanApplicationKeyPersonResponseDto>>(data.Results);
            IEnumerable<LoanApplicationKeyPersonResponseDto> dataVm;
            var listResponse = new List<LoanApplicationKeyPersonResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<LoanApplicationKeyPersonResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<LoanApplicationKeyPersonResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}