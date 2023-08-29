using AutoMapper;
using MediatR;
using NewLMS.Umkm.Domain.Dwh.Services;
using NewLMS.Umkm.Helper;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.DomainDWH.Dtos;
using System.Collections.Generic;
using System;
using Bjb.DigitalBisnis.CoreBanking.Interfaces;
using Bjb.DigitalBisnis.CoreBanking.Models.EA;
using Bjb.DigitalBisnis.CoreBanking.Models;
using Microsoft.Extensions.Options;
using NewLMS.Umkm.Domain.Dwh.Context;
using Microsoft.Extensions.Configuration;

namespace NewLMS.Umkm.MediatR.Features.ExternalAccounts.Queries.GetByNoAcc
{
    public class GetExternalAccByNoAcc : IRequest<ServiceResponse<List<GetExtAccByNoAccountResponse>>>
    {
        public string NoExtAcc { get; set; }
    }

    public class GetExternalAccByNoAccHandler : IRequestHandler<GetExternalAccByNoAcc, ServiceResponse<List<GetExtAccByNoAccountResponse>>>
    {
        private readonly IDWHService _dwhService;
        private readonly IMapper _mapper;
        private readonly ICoreBankingService<EARequest, EAResponse> _eaService;
        private readonly CoreBankingOptionModel _coreBankingOption;
        private readonly DWHContext _dwhContext;
        private readonly IConfiguration _appConfig;
        public GetExternalAccByNoAccHandler(IMapper mapper, IDWHService dwhService, ICoreBankingService<EARequest, EAResponse> eaService, IOptions<CoreBankingOptionModel> ioptions, DWHContext dwhContext, IConfiguration appConfig)
        {
            _dwhService = dwhService;
            _mapper = mapper;
            _eaService = eaService;
            _coreBankingOption = ioptions.Value;
            _dwhContext = dwhContext;
            _appConfig = appConfig;
        }
        public async Task<ServiceResponse<List<GetExtAccByNoAccountResponse>>> Handle(GetExternalAccByNoAcc request, CancellationToken cancellationToken)
        {
            try
            {
                //TODO : Take out this service
                var data = await _dwhService.GetExtAccByNoAccount(request.NoExtAcc);
                var diffDate = _appConfig.GetValue<int>("BackDateCoreBanking");

                if (data.Count == 0)
                {
                    var req = new BaseCoreBankingRequest<EARequest>
                    {
                        CC = "0027",
                        CID = _coreBankingOption.ChannelId,
                        DT = DateTime.Now.AddDays(diffDate).ToString("yyyyMMddHHmmss").ToString(),//"20210124195140",
                        FC = "GI33",
                        MC = "90023",
                        MT = "9200",
                        PC = "001002",
                        PCC = "5",
                        REMOTEIP = _coreBankingOption.RemoteIp,
                        SID = "singleUserIDWebTeller",
                        SPPU = _coreBankingOption.UserId,
                        SPPW = _coreBankingOption.UserPass,
                        ST = DateTime.Now.AddDays(diffDate).ToString("HHmmss"),
                        BRANCHCD = "0001",
                        AUDITUID = "UABF",
                        MPI = new EARequest
                        {
                            ZLEANC = request.NoExtAcc
                        }
                    };
                    var res = await _eaService.CoreBanking(req);
                    if (res.RC == "0000")
                    {
                        var _data = new List<GetExtAccByNoAccountResponse>();
                        var accountByExternalAccount = new GetExtAccByNoAccountResponse
                        {
                            BRANCHID = res.MPO.eAResponseDetail.ZLABS,
                            CIF = res.MPO.eAResponseDetail.ZLANS,
                            SUFFIX = res.MPO.eAResponseDetail.ZLASS,
                            FULLNAME = res.MPO.eAResponseDetail.ZLSHNS,
                            EXTERNAL_ACCOUNT = res.MPO.eAResponseDetail.ZLEANS
                        };
                        _data.Add(accountByExternalAccount);
                        return ServiceResponse<List<GetExtAccByNoAccountResponse>>.ReturnResultWith200(_data);
                    }
                    throw new KeyNotFoundException($"{res.RC} - {res.RCMSG._0.MESSAGE} {res.RCMSG._0.DESCRIPTION}");
                }
                else
                {
                    var dataVm = _mapper.Map<List<GetExtAccByNoAccountResponse>>(data);
                    return ServiceResponse<List<GetExtAccByNoAccountResponse>>.ReturnResultWith200(dataVm);
                }


            }
            catch (Exception ex)
            {
                return ServiceResponse<List<GetExtAccByNoAccountResponse>>.ReturnException(ex);
            }
        }
    }
}
