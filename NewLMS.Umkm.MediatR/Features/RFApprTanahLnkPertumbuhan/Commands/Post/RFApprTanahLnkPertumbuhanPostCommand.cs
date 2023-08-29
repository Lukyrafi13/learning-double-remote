using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFApprTanahLnkPertumbuhans;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFApprTanahLnkPertumbuhans.Commands
{
    public class RFApprTanahLnkPertumbuhanPostCommand : RFApprTanahLnkPertumbuhanPostRequestDto, IRequest<ServiceResponse<RFApprTanahLnkPertumbuhanResponseDto>>
    {

    }
    public class PostRFApprTanahLnkPertumbuhanCommandHandler : IRequestHandler<RFApprTanahLnkPertumbuhanPostCommand, ServiceResponse<RFApprTanahLnkPertumbuhanResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFApprTanahLnkPertumbuhan> _RFApprTanahLnkPertumbuhan;
        private readonly IMapper _mapper;

        public PostRFApprTanahLnkPertumbuhanCommandHandler(IGenericRepositoryAsync<RFApprTanahLnkPertumbuhan> RFApprTanahLnkPertumbuhan, IMapper mapper)
        {
            _RFApprTanahLnkPertumbuhan = RFApprTanahLnkPertumbuhan;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFApprTanahLnkPertumbuhanResponseDto>> Handle(RFApprTanahLnkPertumbuhanPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFApprTanahLnkPertumbuhan = _mapper.Map<RFApprTanahLnkPertumbuhan>(request);

                var returnedRFApprTanahLnkPertumbuhan = await _RFApprTanahLnkPertumbuhan.AddAsync(RFApprTanahLnkPertumbuhan, callSave: false);

                // var response = _mapper.Map<RFApprTanahLnkPertumbuhanResponseDto>(returnedRFApprTanahLnkPertumbuhan);
                var response = _mapper.Map<RFApprTanahLnkPertumbuhanResponseDto>(returnedRFApprTanahLnkPertumbuhan);

                await _RFApprTanahLnkPertumbuhan.SaveChangeAsync();
                return ServiceResponse<RFApprTanahLnkPertumbuhanResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFApprTanahLnkPertumbuhanResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}