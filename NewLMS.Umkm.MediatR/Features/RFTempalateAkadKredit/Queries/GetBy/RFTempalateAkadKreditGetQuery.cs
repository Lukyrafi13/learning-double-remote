using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFTempalateAkadKredits;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFTempalateAkadKredits.Queries
{
    public class RFTempalateAkadKreditGetQuery : RFTempalateAkadKreditFindRequestDto, IRequest<ServiceResponse<RFTempalateAkadKreditResponseDto>>
    {
    }

    public class RFTempalateAkadKreditGetQueryHandler : IRequestHandler<RFTempalateAkadKreditGetQuery, ServiceResponse<RFTempalateAkadKreditResponseDto>>
    {
        private IGenericRepositoryAsync<RFTempalateAkadKredit> _RFTempalateAkadKredit;
        private readonly IMapper _mapper;

        public RFTempalateAkadKreditGetQueryHandler(IGenericRepositoryAsync<RFTempalateAkadKredit> RFTempalateAkadKredit, IMapper mapper)
        {
            _RFTempalateAkadKredit = RFTempalateAkadKredit;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFTempalateAkadKreditResponseDto>> Handle(RFTempalateAkadKreditGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFTempalateAkadKredit.GetByIdAsync(request.TermDesc, "TermDesc");
                if (data == null)
                    return ServiceResponse<RFTempalateAkadKreditResponseDto>.Return404("Data RFTempalateAkadKredit not found");
                var response = _mapper.Map<RFTempalateAkadKreditResponseDto>(data);
                return ServiceResponse<RFTempalateAkadKreditResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFTempalateAkadKreditResponseDto>.ReturnException(ex);
            }
        }
    }
}