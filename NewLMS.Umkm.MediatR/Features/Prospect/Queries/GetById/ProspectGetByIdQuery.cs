using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.Prospects;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.Prospects.Queries
{
    public class ProspectsGetByIdQuery : ProspectFindRequestDto, IRequest<ServiceResponse<ProspectResponseDto>>
    {
    }

    public class GetByIdProspectQueryHandler : IRequestHandler<ProspectsGetByIdQuery, ServiceResponse<ProspectResponseDto>>
    {
        private IGenericRepositoryAsync<Prospect> _prospect;
        private readonly IMapper _mapper;

        public GetByIdProspectQueryHandler(IGenericRepositoryAsync<Prospect> prospect, IMapper mapper)
        {
            _prospect = prospect;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<ProspectResponseDto>> Handle(ProspectsGetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var prospect = await _prospect.GetByIdAsync(Guid.Parse(request.Id), "Id", 
                    new string[] {
                        "JenisProduk",
                        "TipeDebitur",
                        "JenisKelamin",
                        "JenisPermohonanKredit",
                        "KodePos",
                        "Status",
                        "SektorEkonomi",
                        "SubSektorEkonomi",
                        "SubSubSektorEkonomi",
                        "Kategori",
                        "KodeDinas",
                        "Stage",
                        "KodePosUsaha",
                        "KodePosTempat",
                        "KelompokBidangUsaha",
                        "JenisUsaha",
                        "ProspectStageLogs",
                        "ProspectStageLogs.RFStages",
                    }
                );
                if (prospect == null)
                    return ServiceResponse<ProspectResponseDto>.Return404("Data Prospect not found");

                var response = _mapper.Map<ProspectResponseDto>(prospect);
                
                return ServiceResponse<ProspectResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<ProspectResponseDto>.ReturnException(ex);
            }
        }
    }
}