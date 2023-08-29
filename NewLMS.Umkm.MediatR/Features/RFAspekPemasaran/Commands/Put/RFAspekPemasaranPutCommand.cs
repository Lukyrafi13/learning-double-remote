using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFAspekPemasarans;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFAspekPemasarans.Commands
{
    public class RFAspekPemasaranPutCommand : RFAspekPemasaranPutRequestDto, IRequest<ServiceResponse<RFAspekPemasaranResponseDto>>
    {
    }

    public class PutRFAspekPemasaranCommandHandler : IRequestHandler<RFAspekPemasaranPutCommand, ServiceResponse<RFAspekPemasaranResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFAspekPemasaran> _RFAspekPemasaran;
        private readonly IMapper _mapper;

        public PutRFAspekPemasaranCommandHandler(IGenericRepositoryAsync<RFAspekPemasaran> RFAspekPemasaran, IMapper mapper)
        {
            _RFAspekPemasaran = RFAspekPemasaran;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFAspekPemasaranResponseDto>> Handle(RFAspekPemasaranPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFAspekPemasaran = await _RFAspekPemasaran.GetByIdAsync(request.ANL_CODE, "ANL_CODE");
                existingRFAspekPemasaran.ANL_CODE = request.ANL_CODE;
                existingRFAspekPemasaran.ANL_DESC = request.ANL_DESC;
                existingRFAspekPemasaran.CORE_CODE = request.CORE_CODE;
                existingRFAspekPemasaran.ACTIVE = request.ACTIVE;

                await _RFAspekPemasaran.UpdateAsync(existingRFAspekPemasaran);

                var response = _mapper.Map<RFAspekPemasaranResponseDto>(existingRFAspekPemasaran);

                return ServiceResponse<RFAspekPemasaranResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFAspekPemasaranResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}