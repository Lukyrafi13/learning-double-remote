using AutoMapper;
using Bjb.DigitalBisnis.SLIK.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.SLIKs;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.SLIKRequests.Command
{
    public class SubmitSLIKKontigensiRequestCommand : SLIKRequestAKBLSubmitRequest, IRequest<byte[]>
    {

    }

    public class SubmitSLIKKontigensiRequestCommandHandler : IRequestHandler<SubmitSLIKKontigensiRequestCommand, byte[]>
    {
        private readonly IGenericRepositoryAsync<SLIKRequest> _slikRequest;
        private readonly IGenericRepositoryAsync<SLIKRequestDebtor> _slikRequestDebtor;
        private readonly IGenericRepositoryAsync<LoanApplication> _loanApplication;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _userInfoToken;
        private readonly IConfiguration _appConfig;
        private readonly ISlikService _slikService;

        public SubmitSLIKKontigensiRequestCommandHandler(IGenericRepositoryAsync<SLIKRequest> slikRequest, IGenericRepositoryAsync<SLIKRequestDebtor> slikRequestDebtor, IGenericRepositoryAsync<LoanApplication> loanApplication, IMapper mapper, ICurrentUserService ICurrentUserService, IConfiguration appConfig, ISlikService slikService)
        {
            _slikRequest = slikRequest;
            _slikRequestDebtor = slikRequestDebtor;
            _loanApplication = loanApplication;
            _mapper = mapper;
            _userInfoToken = ICurrentUserService;
            _appConfig = appConfig;
            _slikService = slikService;
        }

        public async Task<byte[]> Handle(SubmitSLIKKontigensiRequestCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var slikRequests = await _slikRequest.GetListByPredicate(x => request.SLIKIds.Contains(x.Id), new string[]
                {
                    "LoanApplication",
                    "SLIKRequestDebtors"
                });
                List<string> LoanApplicationIds = new List<string>();
                List<SLIKRequestDebtor> sLIKRequestDebtors = new List<SLIKRequestDebtor>();
                List<SLIKRequest> sLIKRequests = new List<SLIKRequest>();
                using (MemoryStream stream = new MemoryStream())
                {
                    StreamWriter objstreamwriter = new StreamWriter(stream);
                    foreach (SLIKRequest slikRequest in slikRequests)
                    {
                        var _slikRequest = slikRequest;
                        foreach (var sLIKRequestDebtor in slikRequest.SLIKRequestDebtors)
                        {
                            var _slikRequestDebtor = sLIKRequestDebtor;
                            string kodeRef = $"{slikRequest?.LoanApplication?.LoanApplicationId}_M|01|I|{sLIKRequestDebtor.NoIdentity}";
                            objstreamwriter.WriteLine(kodeRef, Environment.NewLine);
                            _slikRequestDebtor.KodeRefPengguna = kodeRef;
                            sLIKRequestDebtors.Add(_slikRequestDebtor);
                        }
                        sLIKRequests.Add(_slikRequest);
                    }
                    objstreamwriter.Flush();
                    objstreamwriter.Close();
                    await _slikRequestDebtor.UpdateRangeAsync(sLIKRequestDebtors);
                    await _slikRequest.UpdateRangeAsync(sLIKRequests);
                    return stream.ToArray();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
