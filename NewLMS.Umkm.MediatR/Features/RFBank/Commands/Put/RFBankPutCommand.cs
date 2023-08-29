using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFBanks;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFBanks.Commands
{
    public class RFBankPutCommand : RFBankPutRequestDto, IRequest<ServiceResponse<RFBankResponseDto>>
    {
    }

    public class PutRFBankCommandHandler : IRequestHandler<RFBankPutCommand, ServiceResponse<RFBankResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFBank> _RFBank;
        private readonly IMapper _mapper;

        public PutRFBankCommandHandler(IGenericRepositoryAsync<RFBank> RFBank, IMapper mapper)
        {
            _RFBank = RFBank;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFBankResponseDto>> Handle(RFBankPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFBank = await _RFBank.GetByIdAsync(request.BankId, "BankId");
                
                existingRFBank = _mapper.Map<RFBankPutRequestDto, RFBank>(request, existingRFBank);
                
                await _RFBank.UpdateAsync(existingRFBank);

                var response = _mapper.Map<RFBankResponseDto>(existingRFBank);

                return ServiceResponse<RFBankResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFBankResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}