using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.FileUrls;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.FileUrls.Queries
{
    public class FileUrlsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<FileUrlResponseDto>>>
    {
    }

    public class FileUrlsGetFilterQueryHandler : IRequestHandler<FileUrlsGetFilterQuery, PagedResponse<IEnumerable<FileUrlResponseDto>>>
    {
        private IGenericRepositoryAsync<FileUrl> _FileUrl;
        private readonly IMapper _mapper;

        public FileUrlsGetFilterQueryHandler(IGenericRepositoryAsync<FileUrl> FileUrl, IMapper mapper)
        {
            _FileUrl = FileUrl;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<FileUrlResponseDto>>> Handle(FileUrlsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
            };

            var data = await _FileUrl.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<FileUrlResponseDto>>(data.Results);
            IEnumerable<FileUrlResponseDto> dataVm;
            var listResponse = new List<FileUrlResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<FileUrlResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<FileUrlResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}