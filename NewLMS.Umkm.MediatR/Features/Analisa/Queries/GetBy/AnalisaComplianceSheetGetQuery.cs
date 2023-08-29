using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.Analisas;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.Analisas.Queries
{
    public class AnalisaComplianceSheetGetQuery : AnalisaFind, IRequest<ServiceResponse<AnalisaComplianceSheetResponse>>
    {
    }

    public class AnalisaComplianceSheetGetQueryHandler : IRequestHandler<AnalisaComplianceSheetGetQuery, ServiceResponse<AnalisaComplianceSheetResponse>>
    {
        private IGenericRepositoryAsync<Analisa> _Analisa;
        private IGenericRepositoryAsync<RFLoanPurpose> _RFLoanPurpose;
        private IGenericRepositoryAsync<AnalisaPinjamanDariBank> _AnalisaPinjamanDariBank;
        private readonly IMapper _mapper;

        public AnalisaComplianceSheetGetQueryHandler(
            IGenericRepositoryAsync<Analisa> Analisa,
            IGenericRepositoryAsync<RFLoanPurpose> RFLoanPurpose,
            IGenericRepositoryAsync<AnalisaPinjamanDariBank> AnalisaPinjamanDariBank,
            IMapper mapper)
        {
            _Analisa = Analisa;
            _RFLoanPurpose = RFLoanPurpose;
            _AnalisaPinjamanDariBank = AnalisaPinjamanDariBank;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<AnalisaComplianceSheetResponse>> Handle(AnalisaComplianceSheetGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                    "HubunganBank",
                    "PengecekanBJB",
                    "ProfileNasabah",
                    "BenturanKepentingan",
                };

                var data = await _Analisa.GetByIdAsync(request.Id, "Id", includes);
                if (data == null)
                    return ServiceResponse<AnalisaComplianceSheetResponse>.Return404("Data Analisa not found");
                var response = _mapper.Map<AnalisaComplianceSheetResponse>(data);

                return ServiceResponse<AnalisaComplianceSheetResponse>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<AnalisaComplianceSheetResponse>.ReturnException(ex);
            }
        }
    }
}