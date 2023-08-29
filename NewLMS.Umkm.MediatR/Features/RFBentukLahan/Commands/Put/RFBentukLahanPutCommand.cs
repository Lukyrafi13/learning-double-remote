using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFBentukLahans;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFBentukLahans.Commands
{
    public class RFBentukLahanPutCommand : RFBentukLahanPutRequestDto, IRequest<ServiceResponse<RFBentukLahanResponseDto>>
    {
    }

    public class PutRFBentukLahanCommandHandler : IRequestHandler<RFBentukLahanPutCommand, ServiceResponse<RFBentukLahanResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFBentukLahan> _RFBentukLahan;
        private readonly IMapper _mapper;

        public PutRFBentukLahanCommandHandler(IGenericRepositoryAsync<RFBentukLahan> RFBentukLahan, IMapper mapper)
        {
            _RFBentukLahan = RFBentukLahan;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFBentukLahanResponseDto>> Handle(RFBentukLahanPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFBentukLahan = await _RFBentukLahan.GetByIdAsync(request.BentukLahan_Id, "BentukLahan_Id");
                existingRFBentukLahan.BentukLahan_Id = request.BentukLahan_Id;
                existingRFBentukLahan.BentukLahan_Desc = request.BentukLahan_Desc;

                await _RFBentukLahan.UpdateAsync(existingRFBentukLahan);

                var response = _mapper.Map<RFBentukLahanResponseDto>(existingRFBentukLahan);

                return ServiceResponse<RFBentukLahanResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFBentukLahanResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}