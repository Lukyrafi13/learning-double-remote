using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.FileUrls;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.FileUrls.Commands
{
    public class FileUrlPostCommand : FileUrlPostRequestDto, IRequest<ServiceResponse<FileUrlResponseDto>>
    {

    }
    public class FileUrlPostCommandHandler : IRequestHandler<FileUrlPostCommand, ServiceResponse<FileUrlResponseDto>>
    {
        private readonly IGenericRepositoryAsync<FileUrl> _FileUrl;
        private readonly IMapper _mapper;

        public FileUrlPostCommandHandler(IGenericRepositoryAsync<FileUrl> FileUrl, IMapper mapper)
        {
            _FileUrl = FileUrl;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<FileUrlResponseDto>> Handle(FileUrlPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var FileUrl = _mapper.Map<FileUrl>(request);

                var returnedFileUrl = await _FileUrl.AddAsync(FileUrl, callSave: false);

                // var response = _mapper.Map<FileUrlResponseDto>(returnedFileUrl);
                var response = _mapper.Map<FileUrlResponseDto>(returnedFileUrl);

                await _FileUrl.SaveChangeAsync();
                return ServiceResponse<FileUrlResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<FileUrlResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}