using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFTipeKredits;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFTipeKredits.Queries
{
    public class RFTipeKreditGetQuery : RFTipeKreditFindRequestDto, IRequest<ServiceResponse<RFTipeKreditResponseDto>>
    {
    }

    public class RFTipeKreditGetQueryHandler : IRequestHandler<RFTipeKreditGetQuery, ServiceResponse<RFTipeKreditResponseDto>>
    {
        private IGenericRepositoryAsync<RFTipeKredit> _RFTipeKredit;
        private readonly IMapper _mapper;

        public RFTipeKreditGetQueryHandler(IGenericRepositoryAsync<RFTipeKredit> RFTipeKredit, IMapper mapper)
        {
            _RFTipeKredit = RFTipeKredit;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFTipeKreditResponseDto>> Handle(RFTipeKreditGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                };

                var data = await _RFTipeKredit.GetByIdAsync(request.Code, "Code");
                if (data == null)
                    return ServiceResponse<RFTipeKreditResponseDto>.Return404("Data RFTipeKredit not found");
                var response = _mapper.Map<RFTipeKreditResponseDto>(data);
                return ServiceResponse<RFTipeKreditResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFTipeKreditResponseDto>.ReturnException(ex);
            }
        }
    }
}