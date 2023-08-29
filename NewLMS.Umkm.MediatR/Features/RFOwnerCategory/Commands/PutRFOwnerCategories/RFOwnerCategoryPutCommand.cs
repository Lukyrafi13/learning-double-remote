using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFOwnerCategories;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFOwnerCategories.Commands
{
    public class RfOwnerCategoryPutCommand : RfOwnerCategoryPutRequestDto, IRequest<ServiceResponse<RfOwnerCategoryResponseDto>>
    {
    }

    public class PutRfOwnerCategoryCommandHandler : IRequestHandler<RfOwnerCategoryPutCommand, ServiceResponse<RfOwnerCategoryResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RfOwnerCategory> _rfOwnerCategory;
        private readonly IMapper _mapper;

        public PutRfOwnerCategoryCommandHandler(IGenericRepositoryAsync<RfOwnerCategory> rfOwnerCategory, IMapper mapper){
            _rfOwnerCategory = rfOwnerCategory;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfOwnerCategoryResponseDto>> Handle(RfOwnerCategoryPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRfOwnerCategory = await _rfOwnerCategory.GetByIdAsync(request.OwnCode, "OwnCode");
                existingRfOwnerCategory.Active = true;
                existingRfOwnerCategory.OwnCode = request.OwnCode;
                existingRfOwnerCategory.OwnDesc = request.OwnDesc;
                existingRfOwnerCategory.CoreCode = request.CoreCode;
                
                await _rfOwnerCategory.UpdateAsync(existingRfOwnerCategory);

                var response = new RfOwnerCategoryResponseDto();
                response.Id = existingRfOwnerCategory.Id;
                response.OwnCode = existingRfOwnerCategory.OwnCode;
                response.OwnDesc = existingRfOwnerCategory.OwnDesc;
                response.CoreCode = existingRfOwnerCategory.CoreCode;
                response.Active = existingRfOwnerCategory.Active;

                return ServiceResponse<RfOwnerCategoryResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RfOwnerCategoryResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}