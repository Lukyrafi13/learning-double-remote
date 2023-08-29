using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFLoanPurposes;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFLoanPurposes.Commands
{
    public class RFLoanPurposePostCommand : RFLoanPurposePostRequestDto, IRequest<ServiceResponse<RFLoanPurposeResponseDto>>
    {

    }
    public class PostRFLoanPurposeCommandHandler : IRequestHandler<RFLoanPurposePostCommand, ServiceResponse<RFLoanPurposeResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFLoanPurpose> _RFLoanPurpose;
        private readonly IMapper _mapper;

        public PostRFLoanPurposeCommandHandler(IGenericRepositoryAsync<RFLoanPurpose> RFLoanPurpose, IMapper mapper)
        {
            _RFLoanPurpose = RFLoanPurpose;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFLoanPurposeResponseDto>> Handle(RFLoanPurposePostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFLoanPurpose = _mapper.Map<RFLoanPurpose>(request);

                var returnedRFLoanPurpose = await _RFLoanPurpose.AddAsync(RFLoanPurpose, callSave: false);

                // var response = _mapper.Map<RFLoanPurposeResponseDto>(returnedRFLoanPurpose);
                var response = _mapper.Map<RFLoanPurposeResponseDto>(returnedRFLoanPurpose);

                await _RFLoanPurpose.SaveChangeAsync();
                return ServiceResponse<RFLoanPurposeResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFLoanPurposeResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}