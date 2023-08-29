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
    public class FileUrlDeleteCommand : FileUrlFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteFileUrlCommandHandler : IRequestHandler<FileUrlDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<FileUrl> _FileUrl;
        private readonly IMapper _mapper;

        public DeleteFileUrlCommandHandler(IGenericRepositoryAsync<FileUrl> FileUrl, IMapper mapper){
            _FileUrl = FileUrl;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(FileUrlDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _FileUrl.GetByIdAsync(request.Id, "Id");
            rFProduct.IsDeleted = true;
            await _FileUrl.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}