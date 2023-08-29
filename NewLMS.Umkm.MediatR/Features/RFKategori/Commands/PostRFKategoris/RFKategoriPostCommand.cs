using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfCategorys;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfCategorys.Commands
{
    public class RfCategoryPostCommand : RfCategoryPostRequestDto, IRequest<ServiceResponse<RfCategoryResponseDto>>
    {

    }
    public class PostRfCategoryCommandHandler : IRequestHandler<RfCategoryPostCommand, ServiceResponse<RfCategoryResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RfCategory> _RfCategory;
        private readonly IMapper _mapper;

        public PostRfCategoryCommandHandler(IGenericRepositoryAsync<RfCategory> RfCategory, IMapper mapper)
        {
            _RfCategory = RfCategory;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfCategoryResponseDto>> Handle(RfCategoryPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RfCategory = _mapper.Map<RfCategory>(request);

                var returnedRfStatusTarget = await _RfCategory.AddAsync(RfCategory, callSave: false);

                // var response = _mapper.Map<RfCategoryResponseDto>(returnedRfStatusTarget);
                var response = _mapper.Map<RfCategoryResponseDto>(returnedRfStatusTarget);

                await _RfCategory.SaveChangeAsync();
                return ServiceResponse<RfCategoryResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RfCategoryResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}