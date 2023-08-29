using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFCSBPDetails;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFCSBPDetails.Commands
{
    public class RFCSBPDetailPutCommand : RFCSBPDetailPutRequestDto, IRequest<ServiceResponse<RFCSBPDetailResponseDto>>
    {
    }

    public class PutRFCSBPDetailCommandHandler : IRequestHandler<RFCSBPDetailPutCommand, ServiceResponse<RFCSBPDetailResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFCSBPDetail> _RfCSBPDetail;
        private readonly IMapper _mapper;

        public PutRFCSBPDetailCommandHandler(IGenericRepositoryAsync<RFCSBPDetail> RfCSBPDetail, IMapper mapper)
        {
            _RfCSBPDetail = RfCSBPDetail;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFCSBPDetailResponseDto>> Handle(RFCSBPDetailPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFCSBPDetail = await _RfCSBPDetail.GetByIdAsync(request.CSBPDetailID, "CSBPDetailID");

                existingRFCSBPDetail = _mapper.Map<RFCSBPDetailPutRequestDto, RFCSBPDetail>(request, existingRFCSBPDetail);

                await _RfCSBPDetail.UpdateAsync(existingRFCSBPDetail);

                var response = _mapper.Map<RFCSBPDetailResponseDto>(existingRFCSBPDetail);

                return ServiceResponse<RFCSBPDetailResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFCSBPDetailResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}