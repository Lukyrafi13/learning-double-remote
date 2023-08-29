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
    public class RFCSBPDetailPostCommand : RFCSBPDetailPostRequestDto, IRequest<ServiceResponse<RFCSBPDetailResponseDto>>
    {

    }
    public class PostRFCSBPDetailCommandHandler : IRequestHandler<RFCSBPDetailPostCommand, ServiceResponse<RFCSBPDetailResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFCSBPDetail> _RFCSBPDetail;
        private readonly IMapper _mapper;

        public PostRFCSBPDetailCommandHandler(IGenericRepositoryAsync<RFCSBPDetail> RFCSBPDetail, IMapper mapper)
        {
            _RFCSBPDetail = RFCSBPDetail;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFCSBPDetailResponseDto>> Handle(RFCSBPDetailPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFCSBPDetail = _mapper.Map<RFCSBPDetail>(request);

                var returnedRFCSBPDetail = await _RFCSBPDetail.AddAsync(RFCSBPDetail, callSave: false);

                // var response = _mapper.Map<RFCSBPDetailResponseDto>(returnedRFCSBPDetail);
                var response = _mapper.Map<RFCSBPDetailResponseDto>(returnedRFCSBPDetail);

                await _RFCSBPDetail.SaveChangeAsync();
                return ServiceResponse<RFCSBPDetailResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFCSBPDetailResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}