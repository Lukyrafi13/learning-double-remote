using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFApprTingkatKesuburans;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFApprTingkatKesuburans.Commands
{
    public class RFApprTingkatKesuburanPostCommand : RFApprTingkatKesuburanPostRequestDto, IRequest<ServiceResponse<RFApprTingkatKesuburanResponseDto>>
    {

    }
    public class PostRFApprTingkatKesuburanCommandHandler : IRequestHandler<RFApprTingkatKesuburanPostCommand, ServiceResponse<RFApprTingkatKesuburanResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFApprTingkatKesuburan> _RFApprTingkatKesuburan;
        private readonly IMapper _mapper;

        public PostRFApprTingkatKesuburanCommandHandler(IGenericRepositoryAsync<RFApprTingkatKesuburan> RFApprTingkatKesuburan, IMapper mapper)
        {
            _RFApprTingkatKesuburan = RFApprTingkatKesuburan;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFApprTingkatKesuburanResponseDto>> Handle(RFApprTingkatKesuburanPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFApprTingkatKesuburan = _mapper.Map<RFApprTingkatKesuburan>(request);

                var returnedRFApprTingkatKesuburan = await _RFApprTingkatKesuburan.AddAsync(RFApprTingkatKesuburan, callSave: false);

                // var response = _mapper.Map<RFApprTingkatKesuburanResponseDto>(returnedRFApprTingkatKesuburan);
                var response = _mapper.Map<RFApprTingkatKesuburanResponseDto>(returnedRFApprTingkatKesuburan);

                await _RFApprTingkatKesuburan.SaveChangeAsync();
                return ServiceResponse<RFApprTingkatKesuburanResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFApprTingkatKesuburanResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}