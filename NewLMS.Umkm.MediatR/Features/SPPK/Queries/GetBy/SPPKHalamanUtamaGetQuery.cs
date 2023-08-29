using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.SPPKs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.SPPKs.Queries
{
    public class SPPKHalamanUtamaGetQuery : SPPKFind, IRequest<ServiceResponse<SPPKHalamanUtamaResponse>>
    {
    }

    public class SPPKHalamanUtamaGetQueryHandler : IRequestHandler<SPPKHalamanUtamaGetQuery, ServiceResponse<SPPKHalamanUtamaResponse>>
    {
        private IGenericRepositoryAsync<SPPK> _SPPK;
        private readonly IMapper _mapper;

        public SPPKHalamanUtamaGetQueryHandler(IGenericRepositoryAsync<SPPK> SPPK, IMapper mapper)
        {
            _SPPK = SPPK;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<SPPKHalamanUtamaResponse>> Handle(SPPKHalamanUtamaGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                };

                var data = await _SPPK.GetByIdAsync(request.Id, "Id", includes);
                if (data == null)
                    return ServiceResponse<SPPKHalamanUtamaResponse>.Return404("Data SPPK not found");
                var response = _mapper.Map<SPPKHalamanUtamaResponse>(data);
                return ServiceResponse<SPPKHalamanUtamaResponse>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SPPKHalamanUtamaResponse>.ReturnException(ex);
            }
        }
    }
}