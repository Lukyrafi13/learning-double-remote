using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.SlikRequestDuplikasis;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.MSearchs;

namespace NewLMS.Umkm.MediatR.Features.SlikRequestDuplikasis.Queries
{
    public class SlikRequestDuplikasiGetQuery : IRequest<ServiceResponse<MSearchResponse>>
    {
        public Guid Id { get; set; }
    }

    public class SlikRequestDuplikasiGetQueryHandler : IRequestHandler<SlikRequestDuplikasiGetQuery, ServiceResponse<MSearchResponse>>
    {
        private IGenericRepositoryAsync<SlikRequestDuplikasi> _SlikRequestDuplikasi;
        private readonly IMapper _mapper;

        public SlikRequestDuplikasiGetQueryHandler(IGenericRepositoryAsync<SlikRequestDuplikasi> SlikRequestDuplikasi, IMapper mapper)
        {
            _SlikRequestDuplikasi = SlikRequestDuplikasi;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<MSearchResponse>> Handle(SlikRequestDuplikasiGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var SlikRequestDuplikasi = await _SlikRequestDuplikasi.GetByIdAsync(request.Id, "Id", 
                    new string[] {
                    }
                );
                if (SlikRequestDuplikasi == null)
                    return ServiceResponse<MSearchResponse>.Return404("Data SlikRequestDuplikasi not found");

                var response = _mapper.Map<MSearchResponse>(SlikRequestDuplikasi);
                
                return ServiceResponse<MSearchResponse>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<MSearchResponse>.ReturnException(ex);
            }
        }
    }
}