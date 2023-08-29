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
    public class SCJabatanPostCommand : SCJabatanPostRequestDto, IRequest<ServiceResponse<SCJabatanResponseDto>>
    {

    }
    public class PostSCJabatanCommandHandler : IRequestHandler<SCJabatanPostCommand, ServiceResponse<SCJabatanResponseDto>>
    {
        private readonly IGenericRepositoryAsync<SCJabatan> _SCJabatan;
        private readonly IMapper _mapper;

        public PostSCJabatanCommandHandler(IGenericRepositoryAsync<SCJabatan> SCJabatan, IMapper mapper)
        {
            _SCJabatan = SCJabatan;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<SCJabatanResponseDto>> Handle(SCJabatanPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var SCJabatan = new SCJabatan();

                SCJabatan.ACTIVE = true;
                SCJabatan.JAB_CODE = request.JAB_CODE;
                SCJabatan.JAB_DESC = request.JAB_DESC;
                SCJabatan.SK_CODE = request.SK_CODE;
                SCJabatan.CORE_CODE = request.CORE_CODE;
                SCJabatan.SK_LIMIT_CODE = request.SK_LIMIT_CODE;

                var returnedRfStatusTarget = await _SCJabatan.AddAsync(SCJabatan, callSave: false);

                // var response = _mapper.Map<SCJabatanResponseDto>(returnedRfStatusTarget);
                var response = new SCJabatanResponseDto();

                response.Id = returnedRfStatusTarget.Id;
                response.JAB_CODE = returnedRfStatusTarget.JAB_CODE;
                response.JAB_DESC = returnedRfStatusTarget.JAB_DESC;
                response.SK_CODE = returnedRfStatusTarget.SK_CODE;
                response.CORE_CODE = returnedRfStatusTarget.CORE_CODE;
                response.ACTIVE = returnedRfStatusTarget.ACTIVE;
                response.SK_LIMIT_CODE = returnedRfStatusTarget.SK_LIMIT_CODE;

                await _SCJabatan.SaveChangeAsync();
                return ServiceResponse<SCJabatanResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SCJabatanResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}