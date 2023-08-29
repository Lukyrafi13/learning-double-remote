using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.SPPKFileUploads;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.SPPKFileUploads.Queries
{
    public class SPPKFileUploadGetQuery : SPPKFileUploadFindRequestDto, IRequest<ServiceResponse<SPPKFileUploadResponseDto>>
    {
    }

    public class SPPKFileUploadGetQueryHandler : IRequestHandler<SPPKFileUploadGetQuery, ServiceResponse<SPPKFileUploadResponseDto>>
    {
        private IGenericRepositoryAsync<SPPKFileUpload> _SPPKFileUpload;
        private readonly IMapper _mapper;

        public SPPKFileUploadGetQueryHandler(IGenericRepositoryAsync<SPPKFileUpload> SPPKFileUpload, IMapper mapper)
        {
            _SPPKFileUpload = SPPKFileUpload;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<SPPKFileUploadResponseDto>> Handle(SPPKFileUploadGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                    "SPPK",
                    "FileUrl",
                };

                var data = await _SPPKFileUpload.GetByIdAsync(request.Id, "Id", includes);
                if (data == null)
                    return ServiceResponse<SPPKFileUploadResponseDto>.Return404("Data SPPKFileUpload not found");
                var response = _mapper.Map<SPPKFileUploadResponseDto>(data);
                return ServiceResponse<SPPKFileUploadResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SPPKFileUploadResponseDto>.ReturnException(ex);
            }
        }
    }
}