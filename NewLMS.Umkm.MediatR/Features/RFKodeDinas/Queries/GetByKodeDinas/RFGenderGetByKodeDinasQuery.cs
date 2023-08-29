using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFKodeDinass;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFKodeDinass.Queries
{
    public class RFKodeDinassGetByKodeDinasQuery : RFKodeDinasFindRequestDto, IRequest<ServiceResponse<RFKodeDinasResponseDto>>
    {
    }

    public class GetByIdRFKodeDinasQueryHandler : IRequestHandler<RFKodeDinassGetByKodeDinasQuery, ServiceResponse<RFKodeDinasResponseDto>>
    {
        private IGenericRepositoryAsync<RFKodeDinas> _RFKodeDinas;
        private readonly IMapper _mapper;

        public GetByIdRFKodeDinasQueryHandler(IGenericRepositoryAsync<RFKodeDinas> RFKodeDinas, IMapper mapper)
        {
            _RFKodeDinas = RFKodeDinas;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFKodeDinasResponseDto>> Handle(RFKodeDinassGetByKodeDinasQuery request, CancellationToken cancellationToken)
        {

            var data = await _RFKodeDinas.GetByIdAsync(request.KodeDinas, "KodeDinas");

            var response = _mapper.Map<RFKodeDinasResponseDto>(data);
            
            return ServiceResponse<RFKodeDinasResponseDto>.ReturnResultWith200(response);
        }
    }
}