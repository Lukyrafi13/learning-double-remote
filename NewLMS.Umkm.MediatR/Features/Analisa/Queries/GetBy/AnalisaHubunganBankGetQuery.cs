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
    public class AnalisaHubunganBankGetQuery : AnalisaFind, IRequest<ServiceResponse<AnalisaHubunganBankResponse>>
    {
    }

    public class AnalisaHubunganBankGetQueryHandler : IRequestHandler<AnalisaHubunganBankGetQuery, ServiceResponse<AnalisaHubunganBankResponse>>
    {
        private IGenericRepositoryAsync<Analisa> _Analisa;
        private IGenericRepositoryAsync<RFLoanPurpose> _RFLoanPurpose;
        private IGenericRepositoryAsync<AnalisaPinjamanDariBank> _AnalisaPinjamanDariBank;
        private readonly IMapper _mapper;

        public AnalisaHubunganBankGetQueryHandler(
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
        public async Task<ServiceResponse<AnalisaHubunganBankResponse>> Handle(AnalisaHubunganBankGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                    "Survey"
                };

                var data = await _Analisa.GetByIdAsync(request.Id, "Id", includes);
                if (data == null)
                    return ServiceResponse<AnalisaHubunganBankResponse>.Return404("Data Analisa not found");
                var response = _mapper.Map<AnalisaHubunganBankResponse>(data);

                // Perhitungan plafond dan outstanding

                var LPInvestasi = await _RFLoanPurpose.GetByIdAsync("IN", "LP_CODE");
                var LPKonsumtif = await _RFLoanPurpose.GetByIdAsync("KON", "LP_CODE");
                var LPModalKerja = await _RFLoanPurpose.GetByIdAsync("MD", "LP_CODE");

                var listPinjamanLain = await _AnalisaPinjamanDariBank.GetListByPredicate(x => x.AnalisaId == data.Id);

                response.TotalPlafon = 0;
                response.TotalOutstanding = 0;
                response.PlafonInvestasi = 0;
                response.OutstandingInvestasi = 0;
                response.PlafonKonsumtif = 0;
                response.OutstandingKonsumtif = 0;
                response.PlafonModalKerja = 0;
                response.OutstandingModalKerja = 0;

                foreach (var pinjamanLain in listPinjamanLain){
                    if (pinjamanLain.PinjamanInternal??false){
                        continue;
                    }

                    if (pinjamanLain.RFLoanPurposeId == LPInvestasi.Id){
                        response.PlafonInvestasi += pinjamanLain.Plafond;
                        response.OutstandingInvestasi += pinjamanLain.Outstanding;
                    }

                    if (pinjamanLain.RFLoanPurposeId == LPKonsumtif.Id){
                        response.PlafonKonsumtif += pinjamanLain.Plafond;
                        response.OutstandingKonsumtif += pinjamanLain.Outstanding;
                    }

                    if (pinjamanLain.RFLoanPurposeId == LPModalKerja.Id){
                        response.PlafonModalKerja += pinjamanLain.Plafond;
                        response.OutstandingModalKerja += pinjamanLain.Outstanding;
                    }

                    response.TotalPlafon += pinjamanLain.Plafond;
                    response.TotalOutstanding += pinjamanLain.Outstanding;
                }

                return ServiceResponse<AnalisaHubunganBankResponse>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<AnalisaHubunganBankResponse>.ReturnException(ex);
            }
        }
    }
}