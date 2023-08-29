using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.SIKPHistoryDetails;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.SIKPHistoryDetails.Commands
{
    public class SIKPHistoryDetailPutCommand : SIKPHistoryDetailPutRequestDto, IRequest<ServiceResponse<SIKPHistoryDetailResponseDto>>
    {
    }

    public class PutSIKPHistoryDetailCommandHandler : IRequestHandler<SIKPHistoryDetailPutCommand, ServiceResponse<SIKPHistoryDetailResponseDto>>
    {
        private readonly IGenericRepositoryAsync<SIKPHistoryDetail> _SIKPHistoryDetail;
        private readonly IMapper _mapper;

        public PutSIKPHistoryDetailCommandHandler(IGenericRepositoryAsync<SIKPHistoryDetail> SIKPHistoryDetail, IMapper mapper)
        {
            _SIKPHistoryDetail = SIKPHistoryDetail;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<SIKPHistoryDetailResponseDto>> Handle(SIKPHistoryDetailPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingSIKPHistoryDetail = await _SIKPHistoryDetail.GetByIdAsync(request.Id, "Id");
                
                existingSIKPHistoryDetail.KodeBank = request.KodeBank;
                existingSIKPHistoryDetail.SisaHari = request.SisaHari;
                existingSIKPHistoryDetail.Skema = request.Skema;
                existingSIKPHistoryDetail.JumlahAkad = request.JumlahAkad;
                existingSIKPHistoryDetail.MaxJumlahAkad = request.MaxJumlahAkad;
                existingSIKPHistoryDetail.RateAkad = request.RateAkad;
                existingSIKPHistoryDetail.LimitAktifDefault = request.LimitAktifDefault;
                existingSIKPHistoryDetail.LimitAktif = request.LimitAktif;
                existingSIKPHistoryDetail.TotalLimitDefault = request.TotalLimitDefault;
                existingSIKPHistoryDetail.TotalLimit = request.TotalLimit;
                existingSIKPHistoryDetail.SIKPHistoryId = request.SIKPHistoryId;

                await _SIKPHistoryDetail.UpdateAsync(existingSIKPHistoryDetail);

                var response = _mapper.Map<SIKPHistoryDetailResponseDto>(existingSIKPHistoryDetail);

                return ServiceResponse<SIKPHistoryDetailResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SIKPHistoryDetailResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}