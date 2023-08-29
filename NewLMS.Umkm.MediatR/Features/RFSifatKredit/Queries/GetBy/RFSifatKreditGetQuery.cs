using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFSifatKredits;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFSifatKredits.Queries
{
    public class RFSifatKreditGetQuery : RFSifatKreditFindRequestDto, IRequest<ServiceResponse<RFSifatKreditResponseDto>>
    {
    }

    public class RFSifatKreditGetQueryHandler : IRequestHandler<RFSifatKreditGetQuery, ServiceResponse<RFSifatKreditResponseDto>>
    {
        private IGenericRepositoryAsync<RFSifatKredit> _RFSifatKredit;
        private readonly IMapper _mapper;

        public RFSifatKreditGetQueryHandler(IGenericRepositoryAsync<RFSifatKredit> RFSifatKredit, IMapper mapper)
        {
            _RFSifatKredit = RFSifatKredit;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFSifatKreditResponseDto>> Handle(RFSifatKreditGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFSifatKredit.GetByIdAsync(request.SKCode, "SKCode");
                if (data == null)
                    return ServiceResponse<RFSifatKreditResponseDto>.Return404("Data RFSifatKredit not found");
                var response = _mapper.Map<RFSifatKreditResponseDto>(data);
                return ServiceResponse<RFSifatKreditResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSifatKreditResponseDto>.ReturnException(ex);
            }
        }
    }
}