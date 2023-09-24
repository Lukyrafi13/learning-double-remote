using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.ChekingSIKPs;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using NewLMS.Umkm.SIKP.Interfaces;
using NewLMS.Umkm.SIKP.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.ChekingSKIPs.Commands
{
    public class ChekingSIKPChekCommand : ChekingSIKPChekRequest, IRequest<ServiceResponse<RateAkadResponseModel>>
    {

    }

    public class ChekingSIKPChekCommandHandler : IRequestHandler<ChekingSIKPChekCommand, ServiceResponse<RateAkadResponseModel>>
    {
        private ISIKPService _SIKPService;
        private IGenericRepositoryAsync<RfSkemaSIKP> _rfSkemaSIKP;
        private IGenericRepositoryAsync<SIKPHistory> _sikpHistory;
        private IGenericRepositoryAsync<SIKPHistoryDetail> _sikpHistoryDetail;
        private readonly IMapper _mapper;

        public ChekingSIKPChekCommandHandler(
            ISIKPService SIKPService,
            IGenericRepositoryAsync<RfSkemaSIKP> rfSkemaSIKP,
            IGenericRepositoryAsync<SIKPHistory> sikpHistory,
            IGenericRepositoryAsync<SIKPHistoryDetail> sikpHistoryDetail,
            IMapper mapper)
        {
            _SIKPService = SIKPService;
            _rfSkemaSIKP = rfSkemaSIKP;
            _sikpHistory = sikpHistory;
            _sikpHistoryDetail = sikpHistoryDetail;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RateAkadResponseModel>> Handle(ChekingSIKPChekCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                };
                var requestRateAkad = new RateAkadRequestModel
                {
                    nik = request.NoIdentiry,
                    sektor = request.SectorLBU3Code
                };
                var data = (await _SIKPService.GetRateAkad(requestRateAkad)).data;
                if (data == null)
                    return ServiceResponse<RateAkadResponseModel>.Return404("Data SIKPService not found");

                var dataCalon = (await _SIKPService.GetCalonDebitur(request.NoIdentiry))?.data;
                if (dataCalon == null)
                    return ServiceResponse<RateAkadResponseModel>.Return404("Data Calon not found");

                data.code_inquiry_calon = dataCalon.code;

                if (data.data?.Count > 0)
                {
                    var listSkema = await _rfSkemaSIKP.GetAllAsync();

                    var listSkemaParent = listSkema.DistinctBy(x => x.SkemaParentCode)
                    .Select(x => new { x.SkemaParentCode, x.SkemaParentDesc })
                    .OrderBy(i => i.SkemaParentCode)
                    .ToList();

                    for (var i = 0; i < data.data.Count; i++)
                    {
                        data.data[i].sisaWaktuBooking = int.Parse(dataCalon.data?.sisa_waktu_book ?? "0");
                        data.data[i].sisaHari = int.Parse(dataCalon.data?.sisa_hari ?? "0");

                        var skemaObj = listSkemaParent.Where(x => x.SkemaParentCode == data.data[i].skema).ToList().Last();

                        data.data[i].skema += " - " + skemaObj.SkemaParentDesc;
                    }
                }
                var response = _mapper.Map<RateAkadResponseModel>(data);

                //Add Cheking History
                if(response.data.Count > 0)
                {
                    var SIKpHistoryId = Guid.NewGuid();
                    var newSIKPHistory = new SIKPHistory
                    {
                        Id = SIKpHistoryId,
                        NoIdentiry = request.NoIdentiry,
                        BanckCode = response.data[0].kode_bank,
                        PlanPlafond = request.PlanPlafond,
                        RateAkad = response.data[0].rate,
                        LimitActive = Convert.ToDouble(response.data[0].limit_aktif),
                        AllowedAkad = response.data[0].sisa_akad,
                        RemainingBookDays = response.data[0].sisaWaktuBooking,
                    };
                    await _sikpHistory.AddAsync(newSIKPHistory);

                    foreach(var datas in response.data)
                    {
                        var newSIKPHistoryDetail = new SIKPHistoryDetail
                        {
                            Id = Guid.NewGuid(),
                            SIKPHistoryId = SIKpHistoryId,
                            BanckCode = datas.kode_bank,
                            RemainingDay = datas.sisaHari,
                            Schema = datas.skema,
                            TotalAkad = datas.count_akad,
                            MaxTotalAkad = datas.max_akad,
                            AllowedAkad = datas.sisa_akad,
                            RateAkad = datas.rate,
                            LimitActiveDefault = datas.limit_aktif_default,
                            LimitActive = datas.limit_aktif,
                            TotalLimit = Convert.ToDouble(datas.total_limit),
                            AllowedRemainingPlafond = Convert.ToDouble(datas.total_limit_default) - Convert.ToDouble(datas.total_limit),
                        };
                        await _sikpHistoryDetail.AddAsync(newSIKPHistoryDetail);
                    }
                }


                return ServiceResponse<RateAkadResponseModel>.ReturnResultWith200(data);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RateAkadResponseModel>.ReturnException(ex);
            }
        }
    }
}
