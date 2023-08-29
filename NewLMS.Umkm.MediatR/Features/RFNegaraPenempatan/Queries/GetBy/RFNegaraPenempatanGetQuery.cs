using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFNegaraPenempatans;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFNegaraPenempatans.Queries
{
    public class RFNegaraPenempatanGetQuery : RFNegaraPenempatanFindRequestDto, IRequest<ServiceResponse<RFNegaraPenempatanResponseDto>>
    {
    }

    public class RFNegaraPenempatanGetQueryHandler : IRequestHandler<RFNegaraPenempatanGetQuery, ServiceResponse<RFNegaraPenempatanResponseDto>>
    {
        private IGenericRepositoryAsync<RFNegaraPenempatan> _RFNegaraPenempatan;
        private readonly IMapper _mapper;

        public RFNegaraPenempatanGetQueryHandler(IGenericRepositoryAsync<RFNegaraPenempatan> RFNegaraPenempatan, IMapper mapper)
        {
            _RFNegaraPenempatan = RFNegaraPenempatan;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFNegaraPenempatanResponseDto>> Handle(RFNegaraPenempatanGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFNegaraPenempatan.GetByIdAsync(request.NegaraCode, "NegaraCode");
                if (data == null)
                    return ServiceResponse<RFNegaraPenempatanResponseDto>.Return404("Data RFNegaraPenempatan not found");
                var response = _mapper.Map<RFNegaraPenempatanResponseDto>(data);
                return ServiceResponse<RFNegaraPenempatanResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFNegaraPenempatanResponseDto>.ReturnException(ex);
            }
        }
    }
}