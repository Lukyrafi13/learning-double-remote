using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.FileDokumens;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.FileDokumens.Queries
{
    public class FileDokumenGetQuery : FileDokumenFindRequestDto, IRequest<ServiceResponse<FileDokumenResponseDto>>
    {
    }

    public class FileDokumenGetQueryHandler : IRequestHandler<FileDokumenGetQuery, ServiceResponse<FileDokumenResponseDto>>
    {
        private IGenericRepositoryAsync<FileDokumen> _FileDokumen;
        private readonly IMapper _mapper;

        public FileDokumenGetQueryHandler(IGenericRepositoryAsync<FileDokumen> FileDokumen, IMapper mapper)
        {
            _FileDokumen = FileDokumen;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<FileDokumenResponseDto>> Handle(FileDokumenGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                    "PrescreeningDokumen",
                    "FileUrl",
                };

                var data = await _FileDokumen.GetByIdAsync(request.Id, "Id", includes);
                if (data == null)
                    return ServiceResponse<FileDokumenResponseDto>.Return404("Data FileDokumen not found");
                var response = _mapper.Map<FileDokumenResponseDto>(data);
                return ServiceResponse<FileDokumenResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<FileDokumenResponseDto>.ReturnException(ex);
            }
        }
    }
}