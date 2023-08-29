using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFJenisPermohonans;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFJenisPermohonans.Queries
{
    public class RFJenisPermohonansGetByIdQuery : RFJenisPermohonanFindRequestDto, IRequest<ServiceResponse<RFJenisPermohonanResponseDto>>
    {
    }

    public class GetByIdRFJenisPermohonanQueryHandler : IRequestHandler<RFJenisPermohonansGetByIdQuery, ServiceResponse<RFJenisPermohonanResponseDto>>
    {
        private IGenericRepositoryAsync<RFJenisPermohonan> _rfJenisPermohonan;
        private readonly IMapper _mapper;

        public GetByIdRFJenisPermohonanQueryHandler(IGenericRepositoryAsync<RFJenisPermohonan> rfJenisPermohonan, IMapper mapper)
        {
            _rfJenisPermohonan = rfJenisPermohonan;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFJenisPermohonanResponseDto>> Handle(RFJenisPermohonansGetByIdQuery request, CancellationToken cancellationToken)
        {

            var data = await _rfJenisPermohonan.GetByIdAsync(request.Id, "Id");

            var response = _mapper.Map<RFJenisPermohonanResponseDto>(data);
            
            return ServiceResponse<RFJenisPermohonanResponseDto>.ReturnResultWith200(response);
        }
    }
}