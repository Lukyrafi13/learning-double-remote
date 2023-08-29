using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfCategories;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfCategories.Commands
{
    public class RfCategoryPutCommand : RfCategoryPutRequestDto, IRequest<ServiceResponse<RfCategoryResponseDto>>
    {
    }

    public class PutRfCategoryCommandHandler : IRequestHandler<RfCategoryPutCommand, ServiceResponse<RfCategoryResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RfCategory> _RfCategory;
        private readonly IMapper _mapper;

        public PutRfCategoryCommandHandler(IGenericRepositoryAsync<RfCategory> RfCategory, IMapper mapper){
            _RfCategory = RfCategory;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfCategoryResponseDto>> Handle(RfCategoryPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRfCategory = await _RfCategory.GetByIdAsync(request.CategoryCode, "CategoryCode");
                existingRfCategory.CategoryCode = request.CategoryCode;
                existingRfCategory.CategoryDesc = request.CategoryDesc;
                existingRfCategory.Active = request.Active;
                
                await _RfCategory.UpdateAsync(existingRfCategory);
                
                var response = _mapper.Map<RfCategoryResponseDto>(existingRfCategory);

                return ServiceResponse<RfCategoryResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RfCategoryResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}