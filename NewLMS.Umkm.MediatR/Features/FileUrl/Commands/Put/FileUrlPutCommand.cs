using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.FileUrls;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.FileUrls.Commands
{
    public class FileUrlPutCommand : FileUrlPutRequestDto, IRequest<ServiceResponse<FileUrlResponseDto>>
    {
    }

    public class PutFileUrlCommandHandler : IRequestHandler<FileUrlPutCommand, ServiceResponse<FileUrlResponseDto>>
    {
        private readonly IGenericRepositoryAsync<FileUrl> _FileUrl;
        private readonly IMapper _mapper;

        public PutFileUrlCommandHandler(IGenericRepositoryAsync<FileUrl> FileUrl, IMapper mapper)
        {
            _FileUrl = FileUrl;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<FileUrlResponseDto>> Handle(FileUrlPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingFileUrl = await _FileUrl.GetByIdAsync(request.Id, "Id");
                
                existingFileUrl.Url = request.Url;
                existingFileUrl.FileSize = request.FileSize;
                existingFileUrl.FileType = request.FileType;
                await _FileUrl.UpdateAsync(existingFileUrl);

                var response = _mapper.Map<FileUrlResponseDto>(existingFileUrl);

                return ServiceResponse<FileUrlResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<FileUrlResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}