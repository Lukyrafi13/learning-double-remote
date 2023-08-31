using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.LoanApplicationCreditFacilities;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.LoanApplicationCreditFacilities.Queries
{
    public class LoanApplicationCreditFacilitiesGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<LoanApplicationCreditFacilityResponseDto>>>
    {
    }

    public class GetFilterLoanApplicationCreditFacilityQueryHandler : IRequestHandler<LoanApplicationCreditFacilitiesGetFilterQuery, PagedResponse<IEnumerable<LoanApplicationCreditFacilityResponseDto>>>
    {
        private IGenericRepositoryAsync<LoanApplicationCreditFacility> _LoanApplicationCreditFacility;
        private IGenericRepositoryAsync<AnalisaSandiOJK> _AnalisaSandiOJK;
        private IGenericRepositoryAsync<AnalisaFasilitas> _AnalisaFasilitas;
        private readonly IMapper _mapper;

        public GetFilterLoanApplicationCreditFacilityQueryHandler(
            IGenericRepositoryAsync<LoanApplicationCreditFacility> LoanApplicationCreditFacility,
            IGenericRepositoryAsync<AnalisaSandiOJK> AnalisaSandiOJK,
            IGenericRepositoryAsync<AnalisaFasilitas> AnalisaFasilitas,
            IMapper mapper)
        {
            _LoanApplicationCreditFacility = LoanApplicationCreditFacility;
            _AnalisaSandiOJK = AnalisaSandiOJK;
            _AnalisaFasilitas = AnalisaFasilitas;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<LoanApplicationCreditFacilityResponseDto>>> Handle(LoanApplicationCreditFacilitiesGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
                "LoanApplication",
                "RfAppType",
                "RfLoanPurpose",
                "RfSubProduct",
                "RfPlacementCountry",
                "Sector",
                "SubSector",
                "SubSubSector",
                "CreditBehavior",
                "CreditTenor",
            };

            var data = await _LoanApplicationCreditFacility.GetPagedReponseAsync(request, includes);
            // var dataVm = _mapper.Map<IEnumerable<LoanApplicationCreditFacilityResponseDto>>(data.Results);
            IEnumerable<LoanApplicationCreditFacilityResponseDto> dataVm;
            var listResponse = new List<LoanApplicationCreditFacilityResponseDto>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<LoanApplicationCreditFacilityResponseDto>(res);

                listResponse.Add(response);

                // Check if there's an analisa fasilitas
                // var analisaFasilitas = await _AnalisaFasilitas.GetByIdAsync(response.Id, "LoanApplicationCreditFacilityId",  new string[] {"JangkaWaktu", "SkimKredit"});

                // if (analisaFasilitas != null)
                // {
                //     response.AnalisaFasilitas = analisaFasilitas;
                // }

                // // Check if there's an analisa sandi ojk
                // var AnalisaSandiOJK = await _AnalisaSandiOJK.GetByIdAsync(response.Id, "LoanApplicationCreditFacilityId");

                // if (AnalisaSandiOJK != null)
                // {
                //     response.AnalisaSandiOJK = AnalisaSandiOJK;
                // }

            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<LoanApplicationCreditFacilityResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}