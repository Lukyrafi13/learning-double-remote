using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFBanks;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFBanks.Commands
{
    public class RFBankPostCommand : RFBankPostRequestDto, IRequest<ServiceResponse<RFBankResponseDto>>
    {

    }
    public class RFBankPostCommandHandler : IRequestHandler<RFBankPostCommand, ServiceResponse<RFBankResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFBank> _RFBank;
        private readonly IMapper _mapper;

        public RFBankPostCommandHandler(IGenericRepositoryAsync<RFBank> RFBank, IMapper mapper)
        {
            _RFBank = RFBank;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFBankResponseDto>> Handle(RFBankPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFBank = _mapper.Map<RFBank>(request);

                var returnedRFBank = await _RFBank.AddAsync(RFBank, callSave: false);

                // var response = _mapper.Map<RFBankResponseDto>(returnedRFBank);
                var response = _mapper.Map<RFBankResponseDto>(returnedRFBank);

                await _RFBank.SaveChangeAsync();
                return ServiceResponse<RFBankResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFBankResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}