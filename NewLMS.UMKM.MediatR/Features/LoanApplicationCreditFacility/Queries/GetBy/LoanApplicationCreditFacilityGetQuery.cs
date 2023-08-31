
using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.LoanApplicationCreditFacilities;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.LoanApplicationCreditFacilities.Queries
{
    public class LoanApplicationCreditFacilityGetQuery : LoanApplicationCreditFacilityFindRequestDto, IRequest<ServiceResponse<LoanApplicationCreditFacilityResponseDto>>
    {
    }

    public class LoanApplicationCreditFacilityGetQueryHandler : IRequestHandler<LoanApplicationCreditFacilityGetQuery, ServiceResponse<LoanApplicationCreditFacilityResponseDto>>
    {
        private IGenericRepositoryAsync<LoanApplicationCreditFacility> _LoanApplicationCreditFacility;
        private IGenericRepositoryAsync<AnalisaFasilitas> _AnalisaFasilitas;
        private IGenericRepositoryAsync<AnalisaSandiOJK> _AnalisaSandiOJK;
        private readonly IMapper _mapper;

        public LoanApplicationCreditFacilityGetQueryHandler(
            IGenericRepositoryAsync<LoanApplicationCreditFacility> LoanApplicationCreditFacility,
            IGenericRepositoryAsync<AnalisaFasilitas> AnalisaFasilitas,
            IGenericRepositoryAsync<AnalisaSandiOJK> AnalisaSandiOJK,
            IMapper mapper)
        {
            _LoanApplicationCreditFacility = LoanApplicationCreditFacility;
            _AnalisaFasilitas = AnalisaFasilitas;
            _AnalisaSandiOJK = AnalisaSandiOJK;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<LoanApplicationCreditFacilityResponseDto>> Handle(LoanApplicationCreditFacilityGetQuery request, CancellationToken cancellationToken)
        {
            try
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

                var data = await _LoanApplicationCreditFacility.GetByIdAsync(request.Id, "Id", includes);
                if (data == null)
                    return ServiceResponse<LoanApplicationCreditFacilityResponseDto>.Return404("Data LoanApplicationCreditFacility not found");
                var response = _mapper.Map<LoanApplicationCreditFacilityResponseDto>(data);

                // Check if there's an analisa fasilitas
                // var analisaFasilitas = await _AnalisaFasilitas.GetByIdAsync(response.Id, "LoanApplicationCreditFacilityId", new string[] {"JangkaWaktu", "SkimKredit"});

                // if (analisaFasilitas != null){
                //     response.AnalisaFasilitas = analisaFasilitas;
                // }

                // Check if there's an analisa sandi ojk
                // var AnalisaSandiOJK = await _AnalisaSandiOJK.GetByIdAsync(response.Id, "LoanApplicationCreditFacilityId");

                // if (AnalisaSandiOJK != null){
                //     response.AnalisaSandiOJK = AnalisaSandiOJK;
                // }

                return ServiceResponse<LoanApplicationCreditFacilityResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<LoanApplicationCreditFacilityResponseDto>.ReturnException(ex);
            }
        }
    }
}