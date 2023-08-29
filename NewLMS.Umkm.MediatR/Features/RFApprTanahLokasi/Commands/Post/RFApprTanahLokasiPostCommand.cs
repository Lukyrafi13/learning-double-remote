using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFApprTanahLokasis;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFApprTanahLokasis.Commands
{
    public class RFApprTanahLokasiPostCommand : RFApprTanahLokasiPostRequestDto, IRequest<ServiceResponse<RFApprTanahLokasiResponseDto>>
    {

    }
    public class PostRFApprTanahLokasiCommandHandler : IRequestHandler<RFApprTanahLokasiPostCommand, ServiceResponse<RFApprTanahLokasiResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFApprTanahLokasi> _RFApprTanahLokasi;
        private readonly IMapper _mapper;

        public PostRFApprTanahLokasiCommandHandler(IGenericRepositoryAsync<RFApprTanahLokasi> RFApprTanahLokasi, IMapper mapper)
        {
            _RFApprTanahLokasi = RFApprTanahLokasi;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFApprTanahLokasiResponseDto>> Handle(RFApprTanahLokasiPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFApprTanahLokasi = _mapper.Map<RFApprTanahLokasi>(request);

                var returnedRFApprTanahLokasi = await _RFApprTanahLokasi.AddAsync(RFApprTanahLokasi, callSave: false);

                // var response = _mapper.Map<RFApprTanahLokasiResponseDto>(returnedRFApprTanahLokasi);
                var response = _mapper.Map<RFApprTanahLokasiResponseDto>(returnedRFApprTanahLokasi);

                await _RFApprTanahLokasi.SaveChangeAsync();
                return ServiceResponse<RFApprTanahLokasiResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFApprTanahLokasiResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}