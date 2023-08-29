using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFOwnerCategories;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFOwnerCategories.Commands
{
    public class RFOwnerCategoryPutCommand : RFOwnerCategoryPutRequestDto, IRequest<ServiceResponse<RFOwnerCategoryResponseDto>>
    {
    }

    public class PutRFOwnerCategoryCommandHandler : IRequestHandler<RFOwnerCategoryPutCommand, ServiceResponse<RFOwnerCategoryResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFOwnerCategory> _rfOwnerCategory;
        private readonly IMapper _mapper;

        public PutRFOwnerCategoryCommandHandler(IGenericRepositoryAsync<RFOwnerCategory> rfOwnerCategory, IMapper mapper){
            _rfOwnerCategory = rfOwnerCategory;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFOwnerCategoryResponseDto>> Handle(RFOwnerCategoryPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFOwnerCategory = await _rfOwnerCategory.GetByIdAsync(request.OwnCode, "OwnCode");
                existingRFOwnerCategory.Active = true;
                existingRFOwnerCategory.OwnCode = request.OwnCode;
                existingRFOwnerCategory.OwnDesc = request.OwnDesc;
                existingRFOwnerCategory.CoreCode = request.CoreCode;
                
                await _rfOwnerCategory.UpdateAsync(existingRFOwnerCategory);

                var response = new RFOwnerCategoryResponseDto();
                response.Id = existingRFOwnerCategory.Id;
                response.OwnCode = existingRFOwnerCategory.OwnCode;
                response.OwnDesc = existingRFOwnerCategory.OwnDesc;
                response.CoreCode = existingRFOwnerCategory.CoreCode;
                response.Active = existingRFOwnerCategory.Active;

                return ServiceResponse<RFOwnerCategoryResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFOwnerCategoryResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}