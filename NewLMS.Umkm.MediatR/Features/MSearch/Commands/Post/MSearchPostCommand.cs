using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.MSearchs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.MSearchs.Commands
{
    public class MSearchPostCommand : MSearchPostRequestDto, IRequest<ServiceResponse<MSearchResponseDto>>
    {

    }
    public class PostMSearchCommandHandler : IRequestHandler<MSearchPostCommand, ServiceResponse<MSearchResponseDto>>
    {
        private readonly IGenericRepositoryAsync<MSearch> _MSearch;
        private readonly IMapper _mapper;

        public PostMSearchCommandHandler(IGenericRepositoryAsync<MSearch> MSearch, IMapper mapper)
        {
            _MSearch = MSearch;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<MSearchResponseDto>> Handle(MSearchPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var MSearch = _mapper.Map<MSearch>(request);

                var returnedMSearch = await _MSearch.AddAsync(MSearch, callSave: false);

                // var response = _mapper.Map<MSearchResponseDto>(returnedMSearch);
                var response = _mapper.Map<MSearchResponseDto>(returnedMSearch);

                await _MSearch.SaveChangeAsync();
                return ServiceResponse<MSearchResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<MSearchResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}