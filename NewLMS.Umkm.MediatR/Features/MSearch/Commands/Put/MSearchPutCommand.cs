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
    public class MSearchPutCommand : MSearchPutRequestDto, IRequest<ServiceResponse<MSearchResponseDto>>
    {
    }

    public class PutMSearchCommandHandler : IRequestHandler<MSearchPutCommand, ServiceResponse<MSearchResponseDto>>
    {
        private readonly IGenericRepositoryAsync<MSearch> _MSearch;
        private readonly IMapper _mapper;

        public PutMSearchCommandHandler(IGenericRepositoryAsync<MSearch> MSearch, IMapper mapper){
            _MSearch = MSearch;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<MSearchResponseDto>> Handle(MSearchPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingMSearch = await _MSearch.GetByIdAsync(request.TypeId, "TypeId");
                
                existingMSearch = _mapper.Map<MSearchPutRequestDto, MSearch>(request, existingMSearch);
                
                await _MSearch.UpdateAsync(existingMSearch);

                var response = _mapper.Map<MSearchResponseDto>(existingMSearch);

                return ServiceResponse<MSearchResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<MSearchResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}