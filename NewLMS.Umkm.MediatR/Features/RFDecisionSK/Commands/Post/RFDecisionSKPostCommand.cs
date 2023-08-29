using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFDecisionSKs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFDecisionSKs.Commands
{
    public class RFDecisionSKPostCommand : RFDecisionSKPostRequestDto, IRequest<ServiceResponse<RFDecisionSKResponseDto>>
    {

    }
    public class PostRFDecisionSKCommandHandler : IRequestHandler<RFDecisionSKPostCommand, ServiceResponse<RFDecisionSKResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFDecisionSK> _RFDecisionSK;
        private readonly IMapper _mapper;

        public PostRFDecisionSKCommandHandler(IGenericRepositoryAsync<RFDecisionSK> RFDecisionSK, IMapper mapper)
        {
            _RFDecisionSK = RFDecisionSK;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFDecisionSKResponseDto>> Handle(RFDecisionSKPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFDecisionSK = _mapper.Map<RFDecisionSK>(request);

                var returnedRFDecisionSK = await _RFDecisionSK.AddAsync(RFDecisionSK, callSave: false);

                // var response = _mapper.Map<RFDecisionSKResponseDto>(returnedRFDecisionSK);
                var response = _mapper.Map<RFDecisionSKResponseDto>(returnedRFDecisionSK);

                await _RFDecisionSK.SaveChangeAsync();
                return ServiceResponse<RFDecisionSKResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFDecisionSKResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}