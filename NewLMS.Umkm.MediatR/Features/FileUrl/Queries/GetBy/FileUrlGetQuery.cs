using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.FileUrls;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.FileUrls.Queries
{
    public class FileUrlGetQuery : FileUrlFindRequestDto, IRequest<ServiceResponse<FileUrlResponseDto>>
    {
    }

    public class FileUrlGetQueryHandler : IRequestHandler<FileUrlGetQuery, ServiceResponse<FileUrlResponseDto>>
    {
        private IGenericRepositoryAsync<FileUrl> _FileUrl;
        private readonly IMapper _mapper;

        public FileUrlGetQueryHandler(IGenericRepositoryAsync<FileUrl> FileUrl, IMapper mapper)
        {
            _FileUrl = FileUrl;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<FileUrlResponseDto>> Handle(FileUrlGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                };

                var data = await _FileUrl.GetByIdAsync(request.Id, "Id");
                if (data == null)
                    return ServiceResponse<FileUrlResponseDto>.Return404("Data FileUrl not found");
                var response = _mapper.Map<FileUrlResponseDto>(data);
                return ServiceResponse<FileUrlResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<FileUrlResponseDto>.ReturnException(ex);
            }
        }
    }
}