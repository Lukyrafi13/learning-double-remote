using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFBanks;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFBanks.Queries
{
    public class RFBankGetQuery : RFBankFindRequestDto, IRequest<ServiceResponse<RFBankResponseDto>>
    {
    }

    public class RFBankGetQueryHandler : IRequestHandler<RFBankGetQuery, ServiceResponse<RFBankResponseDto>>
    {
        private IGenericRepositoryAsync<RFBank> _RFBank;
        private readonly IMapper _mapper;

        public RFBankGetQueryHandler(IGenericRepositoryAsync<RFBank> RFBank, IMapper mapper)
        {
            _RFBank = RFBank;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFBankResponseDto>> Handle(RFBankGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                };

                var data = await _RFBank.GetByIdAsync(request.BankId, "BankId");
                if (data == null)
                    return ServiceResponse<RFBankResponseDto>.Return404("Data RFBank not found");
                var response = _mapper.Map<RFBankResponseDto>(data);
                return ServiceResponse<RFBankResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFBankResponseDto>.ReturnException(ex);
            }
        }
    }
}