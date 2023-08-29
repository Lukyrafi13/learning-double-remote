using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.SCJabatans;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.SCJabatans.Commands
{
    public class SCJabatanPutCommand : SCJabatanPutRequestDto, IRequest<ServiceResponse<SCJabatanResponseDto>>
    {
    }

    public class PutSCJabatanCommandHandler : IRequestHandler<SCJabatanPutCommand, ServiceResponse<SCJabatanResponseDto>>
    {
        private readonly IGenericRepositoryAsync<SCJabatan> _SCJabatan;
        private readonly IMapper _mapper;

        public PutSCJabatanCommandHandler(IGenericRepositoryAsync<SCJabatan> SCJabatan, IMapper mapper)
        {
            _SCJabatan = SCJabatan;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<SCJabatanResponseDto>> Handle(SCJabatanPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingSCJabatan = await _SCJabatan.GetByIdAsync(request.JAB_CODE, "JAB_CODE");
                existingSCJabatan.ACTIVE = true;
                existingSCJabatan.JAB_CODE = request.JAB_CODE;
                existingSCJabatan.JAB_DESC = request.JAB_DESC;
                existingSCJabatan.CORE_CODE = request.CORE_CODE;
                existingSCJabatan.SK_CODE = request.SK_CODE;
                existingSCJabatan.SK_LIMIT_CODE = request.SK_LIMIT_CODE;

                await _SCJabatan.UpdateAsync(existingSCJabatan);

                var response = new SCJabatanResponseDto();
                response.Id = existingSCJabatan.Id;
                response.JAB_CODE = existingSCJabatan.JAB_CODE;
                response.JAB_DESC = existingSCJabatan.JAB_DESC;
                response.CORE_CODE = existingSCJabatan.CORE_CODE;
                response.SK_CODE = existingSCJabatan.SK_CODE;
                response.SK_LIMIT_CODE = existingSCJabatan.SK_LIMIT_CODE;
                response.ACTIVE = existingSCJabatan.ACTIVE;

                return ServiceResponse<SCJabatanResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SCJabatanResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}