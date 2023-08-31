using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.LoanApplications;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.LoanApplications.Queries
{
    public class LoanApplicationIdeGet : LoanApplicationFind, IRequest<ServiceResponse<LoanApplicationIDEPutRequestDtoResponse>>
    {
    }

    public class LoanApplicationIdeGetQueryHandler : IRequestHandler<LoanApplicationIdeGet, ServiceResponse<LoanApplicationIDEPutRequestDtoResponse>>
    {
        private IGenericRepositoryAsync<LoanApplicationCreditScoring> _LoanApplicationCreditScoring;
        private readonly IMapper _mapper;

        public LoanApplicationIdeGetQueryHandler(IGenericRepositoryAsync<LoanApplicationCreditScoring> LoanApplicationCreditScoring, IMapper mapper)
        {
            _LoanApplicationCreditScoring = LoanApplicationCreditScoring;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<LoanApplicationIDEPutRequestDtoResponse>> Handle(LoanApplicationIdeGet request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
                "RfBusinessPrimaryCycle",
                "LoanApplication",
                "RFSCOReputasiTempatTinggal",
                "RFSCOTingkatKebutuhan",
                "RFSCOCaraTransaksi",
                "RFSCOPengelolaKeuangan",
                "RFSCOHutangPihakLain",
                "RFSCOLokTempatUsaha",
                "RFSCOHubunganPerbankan",
                "RFSCOMutasiPerBulan",
                "RFSCORiwayatKreditBJB",
                "RFSCOScoringAgunan",
                "RFSCOSaldoRekRata",
            };

            var data = await _LoanApplicationCreditScoring.GetByPredicate(x=>x.LoanApplicationGuid == request.Id, includes);

            var response = data == null? new LoanApplicationIDEPutRequestDtoResponse(): _mapper.Map<LoanApplicationIDEPutRequestDtoResponse>(data);

            return ServiceResponse<LoanApplicationIDEPutRequestDtoResponse>.ReturnResultWith200(response);
        }
    }
}